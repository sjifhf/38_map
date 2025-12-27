using UnityEngine;

public class ShrinkForwardBackward : MonoBehaviour
{
    public float shrinkSpeed = 1f;      // 縮小速度
    public float minZScale = 0.2f;      // Z 軸最小縮小比例
    private bool isShrinking = false;   // 是否正在縮小

    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        if (isShrinking)
        {
            Vector3 scale = transform.localScale;
            scale.z = Mathf.Lerp(scale.z, minZScale * originalScale.z, Time.deltaTime * shrinkSpeed);
            transform.localScale = scale;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isShrinking = true;   // 踩到開始縮小
        }
    }
}

