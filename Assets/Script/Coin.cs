using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int value = 1;
    [SerializeField] private AudioClip pickupSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (GameState.I != null)
            GameState.I.AddCoins(value);

        if (pickupSound != null && Camera.main != null)
            AudioSource.PlayClipAtPoint(pickupSound, Camera.main.transform.position);

        Destroy(gameObject);
    }
}