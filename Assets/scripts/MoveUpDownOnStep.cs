using UnityEngine;

public class MoveUpDownOnStep : MonoBehaviour
{
    public float moveDistance = 2f; // 上下移動距離
    public float speed = 2f;        // 移動速度
    private bool isMoving = false;  // 是否開始移動

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (isMoving)
        {
            float offset = Mathf.Sin(Time.time * speed) * moveDistance;
            transform.position = startPos + new Vector3(0, offset, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isMoving = true; // 踩到開始上下移動
        }
    }
}
