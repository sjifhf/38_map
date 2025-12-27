using UnityEngine;

public class UpDownMove : MonoBehaviour
{
    public float moveDistance = 15f;   // 向下的距離
    public float moveSpeed = 4f;      // 移動速度

    private Vector3 startPos;
    private Vector3 endPos;
    private bool goingDown = true;

    void Start()
    {
        startPos = transform.position;                 // 初始位置
        endPos = startPos + Vector3.down * moveDistance; // 向下的目標位置
    }

    void Update()
    {
        // 下→上循環移動
        if (goingDown)
        {
            transform.position = Vector3.MoveTowards(
                transform.position, endPos, moveSpeed * Time.deltaTime
            );

            if (Vector3.Distance(transform.position, endPos) < 0.01f)
                goingDown = false; // 到達下方 → 開始向上
        }
        else
        {
            transform.position = Vector3.MoveTowards(
                transform.position, startPos, moveSpeed * Time.deltaTime
            );

            if (Vector3.Distance(transform.position, startPos) < 0.01f)
                goingDown = true; // 回到起點 → 再向下
        }
    }
}
