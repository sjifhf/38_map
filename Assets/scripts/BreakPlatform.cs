using UnityEngine;

public class BreakPlatform : MonoBehaviour
{
    public float stayTime = 1.5f;  // 站多久會壞掉
    public float destroyDelay = 0.3f; // 壞掉後延遲消失（可做破碎動畫）

    private bool isCounting = false;
    private float timer = 0f;

    void OnTriggerStay(Collider other)
    {
        // 判定是不是玩家（Tag 記得設定 Player）
        if (other.CompareTag("Player"))
        {
            isCounting = true;
            timer += Time.deltaTime;

            if (timer >= stayTime)
            {
                Break();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        // 玩家離開就重置計時
        if (other.CompareTag("Player"))
        {
            isCounting = false;
            timer = 0f;
        }
    }

    void Break()
    {
        // 你可以改成播放動畫或掉落
        Destroy(gameObject, destroyDelay);
    }
}
