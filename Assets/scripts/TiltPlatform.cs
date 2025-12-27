using UnityEngine;

public class TiltPlatform : MonoBehaviour
{
    [Header("設定參數")]
    public float maxAngle = 15f;    // 最大傾斜角度 (限制角度)
    public float tiltSpeed = 50f;   // 傾斜的速度
    public float returnSpeed = 30f; // 沒有人踩時，回正的速度

    private float currentZAngle = 0f; // 目前的傾斜角度
    private bool isPlayerOnTop = false; // 判斷玩家是否在上面
    private int tiltDirection = 0; // 1 = 往左傾斜, -1 = 往右傾斜

    void Update()
    {
        // 設定目標角度
        float targetAngle = 0f;

        if (isPlayerOnTop)
        {
            // 如果玩家在左邊，目標是正角度 (左邊下沉)
            // 如果玩家在右邊，目標是負角度 (右邊下沉)
            targetAngle = (tiltDirection == 1) ? maxAngle : -maxAngle;

            // 使用 MoveTowards 平滑地改變角度
            currentZAngle = Mathf.MoveTowards(currentZAngle, targetAngle, tiltSpeed * Time.deltaTime);
        }
        else
        {
            // 如果沒人踩，目標是 0 度 (回正)
            currentZAngle = Mathf.MoveTowards(currentZAngle, 0f, returnSpeed * Time.deltaTime);
        }

        // 將計算好的角度套用到方塊的 Z 軸旋轉
        // 使用 localRotation 確保是相對於父物件旋轉 (如果有的話)
        transform.localRotation = Quaternion.Euler(0, 0, currentZAngle);
    }

    // 當有物體持續踩在方塊上時觸發
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnTop = true;

            // 核心邏輯：算出玩家相對於方塊中心的座標
            // InverseTransformPoint 會忽略方塊本身的旋轉，只看相對位置
            Vector3 playerLocalPos = transform.InverseTransformPoint(collision.transform.position);

            // 判斷左右 (x < 0 是左邊, x > 0 是右邊)
            if (playerLocalPos.x < -0.1f)
            {
                tiltDirection = 1; // 往左傾斜 (左低右高)
            }
            else if (playerLocalPos.x > 0.1f)
            {
                tiltDirection = -1; // 往右傾斜 (右低左高)
            }
            // 中間區域 (-0.1 到 0.1) 可以設為不改變方向，防止抖動
        }
    }

    // 當物體離開方塊時觸發
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnTop = false; // 開始執行回正邏輯
        }
    }
}
