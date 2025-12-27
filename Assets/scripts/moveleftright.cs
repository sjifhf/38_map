using UnityEngine;

public class MoveForwardBackward : MonoBehaviour
{
    public float speed = 2f;        // 移動速度
    public float moveDistance = 3f; // 前後移動距離（半徑）

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position; // 記錄起始位置
    }

    void Update()
    {
        float z = Mathf.Sin(Time.time * speed) * moveDistance;
        transform.position = new Vector3(startPos.x, startPos.y, startPos.z + z);
    }
}
