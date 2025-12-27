using UnityEngine;

public class MoveUpDown : MonoBehaviour
{
    public float speed = 2f;        // 移動速度
    public float moveDistance = 3f; // 上下移動距離（半徑）

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position; // 記錄起始位置
    }

    void Update()
    {
        float y = Mathf.Sin(Time.time * speed) * moveDistance;
        transform.position = new Vector3(startPos.x, startPos.y + y, startPos.z);
    }
}
