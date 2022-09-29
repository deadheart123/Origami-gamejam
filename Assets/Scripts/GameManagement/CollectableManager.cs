using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    public static CollectableManager Instance { get; private set; }
    public List<OrigamiCollectable> collectablesInScene = new List<OrigamiCollectable>();
    private int collectableCount = 0;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void GetCollectable()
    {
        collectableCount++;

        if(collectableCount == collectablesInScene.Count)
        {
            Debug.Log("All collectables collected");
        }
    }
}
