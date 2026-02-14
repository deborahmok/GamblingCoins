using UnityEngine;

public class CoinSpin : MonoBehaviour
{
    [SerializeField] private Sprite frontSprite;
    [SerializeField] private Sprite sideSprite;
    [SerializeField] private float frameTime = 0.12f; // smaller = faster spin

    private SpriteRenderer sr;
    private float timer;
    private bool toggle;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        toggle = Random.value > 0.5f; // optional: randomize start frame
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer < frameTime) return;

        toggle = !toggle;
        sr.sprite = toggle ? frontSprite : sideSprite;
        timer = 0f;
    }
}