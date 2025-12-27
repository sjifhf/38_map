using UnityEngine;

public class RotateUntilPlayerSteps : MonoBehaviour
{
    public float rotateSpeed = 90f; // 每秒旋轉角度
    private bool isRotating = true; // 一開始先旋轉

    void Update()
    {
        if (isRotating)
        {
            transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isRotating = false; // 停止旋轉
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isRotating = true; //（可選）玩家離開後恢復旋轉
        }
    }
}
