using System.Collections;
using UnityEngine;

public class ShrinkPlatform : MonoBehaviour
{
    public float stayTime = 1f;         // 站多久開始縮小
    public float shrinkDuration = 1f;   // 縮小需要多久
    public float minScale = 0.2f;       // 縮到多小後停止縮小
    public float fallDelay = 0.1f;      // 縮完後多久掉下去
    public float destroyDelay = 2f;     // 掉下去後多久刪除

    private float timer = 0f;
    private bool isShrinking = false;

    private Vector3 originalScale;
    private Rigidbody rb;

    void Start()
    {
        originalScale = transform.localScale;

        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;  // 一開始不會掉
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timer += Time.deltaTime;

            if (timer >= stayTime && !isShrinking)
            {
                StartCoroutine(ShrinkAndFall());
                isShrinking = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timer = 0f;
        }
    }

    IEnumerator ShrinkAndFall()
    {
        float t = 0;

        // 一段時間內慢慢縮小
        while (t < shrinkDuration)
        {
            t += Time.deltaTime;
            float lerp = t / shrinkDuration;

            Vector3 newScale = Vector3.Lerp(originalScale, originalScale * minScale, lerp);
            transform.localScale = newScale;

            yield return null;
        }

        // 等一下再開始掉下去
        yield return new WaitForSeconds(fallDelay);

        rb.isKinematic = false; // 開始掉落

        Destroy(gameObject, destroyDelay);
    }
}
