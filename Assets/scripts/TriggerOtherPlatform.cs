using UnityEngine;

public class TriggerOtherPlatform : MonoBehaviour
{
    public Transform targetPlatform; // 要被移動的方塊 B
    public float moveDistance = 3f;  // 往下移動的距離
    public float speed = 2f;         // 移動速度

    private bool startMove = false;
    private Vector3 targetPos;
    private Vector3 originalPos;

    void Start()
    {
        if (targetPlatform != null)
        {
            originalPos = targetPlatform.position;
            targetPos = originalPos + new Vector3(0, -moveDistance, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            startMove = true; // 踩到 A，開始移動 B
        }
    }

    void Update()
    {
        if (startMove && targetPlatform != null)
        {
            targetPlatform.position = Vector3.MoveTowards(
                targetPlatform.position,
                targetPos,
                speed * Time.deltaTime
            );
        }
    }
}
