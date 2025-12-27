using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform playerBody;   // Player 物件
    public float mouseSensitivity = 100f;
    public bool enableLook = true;

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (!enableLook) return;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // 上下看（CameraPivot）
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // 左右轉（Player）
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
