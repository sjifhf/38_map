using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement_2D : MonoBehaviour
{
    [Header("移動設定")]
    public float speed = 5f;          // 水平移動速度
    public float jumpHeight = 2f;     // 跳躍高度
    public float gravity = -9.8f;     // 重力加速度

    private CharacterController controller;
    private float yVelocity = 0f;     // 垂直速度
    private bool isGrounded;          // 是否接觸地面

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // 1️⃣ 判斷是否接觸地面
        isGrounded = controller.isGrounded;

        // 2️⃣ 跳躍與重力
        if (isGrounded && yVelocity < 0)
            yVelocity = -1f; // 保持貼地

        if (Input.GetButtonDown("Jump") && isGrounded)
            yVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);

        yVelocity += gravity * Time.deltaTime;

        // 3️⃣ 撞天花板時停止上升
        if ((controller.collisionFlags & CollisionFlags.Above) != 0 && yVelocity > 0)
            yVelocity = 0f;

        // 4️⃣ 水平移動（前後左右）
        float moveX = Input.GetAxis("Horizontal"); // A/D
        float moveZ = Input.GetAxis("Vertical");   // W/S

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        move.y = yVelocity;

        // 5️⃣ 移動
        controller.Move(move * speed * Time.deltaTime);
    }
}
