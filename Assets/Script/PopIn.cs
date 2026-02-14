using UnityEngine;

public class PopIn : MonoBehaviour
{
    [SerializeField] private float duration = 0.12f;
    [SerializeField] private float startScale = 0.2f;

    private void OnEnable()
    {
        StopAllCoroutines();
        StartCoroutine(Animate());
    }

    private System.Collections.IEnumerator Animate()
    {
        Vector3 end = Vector3.one;
        Vector3 start = Vector3.one * startScale;
        transform.localScale = start;

        float t = 0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            float a = Mathf.Clamp01(t / duration);
            transform.localScale = Vector3.Lerp(start, end, a);
            yield return null;
        }

        transform.localScale = end;
    }
}