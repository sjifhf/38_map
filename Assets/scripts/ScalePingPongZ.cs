using UnityEngine;

public class ScalePingPongZ : MonoBehaviour
{
    public float minZ = 0.3f;   // Z 軸最小比例
    public float maxZ = 1f;     // Z 軸最大比例
    public float speed = 1f;    // 變化速度

    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        // 0~1 來回
        float t = Mathf.PingPong(Time.time * speed, 1f);

        // 計算 Z 軸縮放
        float newZ = Mathf.Lerp(minZ, maxZ, t);

        // 套用縮放（只有 Z 軸改變）
        Vector3 scale = originalScale;
        scale.z = originalScale.z * newZ;

        transform.localScale = scale;
    }
}
