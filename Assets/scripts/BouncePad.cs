using UnityEngine;

public class BouncePad : MonoBehaviour
{
    // 設定彈跳力道，可以在 Inspector 調整
    public float bounceForce = 10f;

    // 當有物體「碰撞」到這個方塊時觸發
    private void OnCollisionEnter(Collision collision)
    {
        // 1. 嘗試抓取碰到方塊的物體身上的 Rigidbody 組件
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

        // 2. 如果對方有 Rigidbody (代表它是可以受物理影響的角色或物體)
        if (rb != null)
        {
            // 歸零當前的垂直速度 (避免因為重力抵銷彈跳力，讓每次彈跳高度一致)
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

            // 3. 給它一個向上的瞬間力道 (Impulse 代表瞬間衝擊力)
            rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
        }
    }
}