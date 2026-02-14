using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [Header("Drag these in Inspector")]
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private BoxCollider2D spawnArea;

    [Header("Spawn Settings")]
    [SerializeField] private int maxCoinsOnMap = 15;

    [Header("Feedback Loop (Smooth)")]
    [SerializeField] private int lowCoins = 0;          // at or below this: fastest spawns
    [SerializeField] private int highCoins = 30;        // at or above this: slowest spawns
    [SerializeField] private float fastInterval = 0.13f; // seconds
    [SerializeField] private float slowInterval = 3.0f; // seconds
    
    [Header("Anti-overlap")]
    [SerializeField] private float minDistanceBetweenCoins = 0.6f;
    [SerializeField] private int maxSpawnAttempts = 10;

    private int activeCoins = 0;

    private void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            int c = (GameState.I != null) ? GameState.I.Coins : 0;

            // t = 0 when c<=lowCoins, t = 1 when c>=highCoins
            float t = Mathf.InverseLerp(lowCoins, highCoins, c);

            // interval increases smoothly from fastInterval -> slowInterval
            float currentInterval = Mathf.Lerp(fastInterval, slowInterval, t);

            yield return new WaitForSeconds(currentInterval);

            if (coinPrefab == null || spawnArea == null) continue;
            if (activeCoins >= maxCoinsOnMap) continue;

            Vector2 pos;
            bool found = TryGetNonOverlappingPosition(out pos);

            if (!found) continue; // skip this spawn tick if we can't find a good spot
            GameObject coin = Instantiate(coinPrefab, pos, Quaternion.identity);

            activeCoins++;

            // When coin is destroyed (picked up), reduce the count
            coin.AddComponent<DestroyHook>().onDestroyed = () => activeCoins--;
        }
    }
    
    private bool TryGetNonOverlappingPosition(out Vector2 pos)
    {
        for (int attempt = 0; attempt < maxSpawnAttempts; attempt++)
        {
            Vector2 candidate = GetRandomPointInBounds(spawnArea.bounds);

            // Check for nearby coins so we don't overlap/spawn too close
            Collider2D hit = Physics2D.OverlapCircle(candidate, minDistanceBetweenCoins);
            if (hit == null || !hit.CompareTag("Coin"))
            {
                pos = candidate;
                return true;
            }
        }

        pos = Vector2.zero;
        return false;
    }

    private Vector2 GetRandomPointInBounds(Bounds b)
    {
        float x = Random.Range(b.min.x, b.max.x);
        float y = Random.Range(b.min.y, b.max.y);
        return new Vector2(x, y);
    }
}

public class DestroyHook : MonoBehaviour
{
    public System.Action onDestroyed;

    private void OnDestroy()
    {
        onDestroyed?.Invoke();
    }
}