using UnityEngine;

public class movewall : MonoBehaviour
{
    public float speed = 2f;        // 移動速度
    public float moveDistance = 3f; // 左右移動距離（半徑）

    private Vector3 startPos;
    private bool isPaused = false;  // 是否暫停（玩家站上去）

    void Start()
    {
        startPos = transform.position; // 記錄起始位置
    }

    void Update()
    {
        if (isPaused) return;  // 玩家踩上去 → 停止移動

        float x = Mathf.Sin(Time.time * speed) * moveDistance;
        transform.position = new Vector3(startPos.x + x, startPos.y, startPos.z);
    }

    // 玩家踩到方塊時停止
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            isPaused = true;
        }
    }

    // 玩家離開後恢復運作
    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            isPaused = false;
        }
    }
}
