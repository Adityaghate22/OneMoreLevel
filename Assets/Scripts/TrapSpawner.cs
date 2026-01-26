using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrapSpawner : MonoBehaviour
{
    [Header("Trap Settings")]
    public GameObject[] trapPrefabs; // Drag SpikePrefab, SawPrefab, etc.
    [Range(0.1f, 1f)] public float triggerDelay = 0.3f;
    public float popHeight = 2f; // Start pop from below ground


    [Header("Randomize")]
    public bool randomizeTrap = true;
    public bool randomizeDelay = true;

    private bool triggered = false;
    private GameObject activeTrap; // Track to destroy on reset


    // Trigger detection
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            float delay = randomizeDelay ? Random.Range(0.1f, triggerDelay * 1.5f) : triggerDelay;
            StartCoroutine(SpawnTrap(delay));
        }
    }

    // Spawn trap coroutine
    private IEnumerator SpawnTrap(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Safety: Destroy old trap if exists
        if (activeTrap != null)
        {
            Destroy(activeTrap);
        }

        // Pick prefab
        GameObject prefab = trapPrefabs.Length > 0
            ? (randomizeTrap && trapPrefabs.Length > 1 ? trapPrefabs[Random.Range(0, trapPrefabs.Length)] : trapPrefabs[0])
            : null;

        if (prefab == null) yield break; // No prefab assigned

        Vector3 spawnPos = transform.position - Vector3.up * popHeight;

        activeTrap = Instantiate(prefab, spawnPos, Quaternion.identity);
        SpikeTrap spikeTrap = activeTrap.GetComponent<SpikeTrap>(); //  SpikeTrap component
        if (spikeTrap != null)
        {
            spikeTrap.PopUp(transform.position);
        }
    }

    // Reset trap spawner
    public void Reset()
    {
        triggered = false;
        StopAllCoroutines();
        if (activeTrap != null)
        {
            Destroy(activeTrap);
            activeTrap = null;
        }
    }

    // Optional: Visualize trigger in Scene view
    void OnDrawGizmos()
    {
        Gizmos.color = triggered ? Color.red : Color.yellow;
        BoxCollider2D col = GetComponent<BoxCollider2D>();
        if (col != null)
        {
            Gizmos.DrawWireCube(col.bounds.center, col.bounds.size);
        }
    }
}