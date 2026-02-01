using UnityEngine;
using System.Collections.Generic;

public class TrapManager : MonoBehaviour
{
    public static TrapManager Instance;
    private List<TrapSpawner> spawners = new List<TrapSpawner>();


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            spawners.AddRange(Object.FindObjectsByType<TrapSpawner>(FindObjectsSortMode.None));
        }
        else Destroy(gameObject);
    }

    // Resets all trap spawners in the scene
    public void ResetAll()
    {
        foreach (var spawner in spawners)
            spawner.Reset();
    }
}