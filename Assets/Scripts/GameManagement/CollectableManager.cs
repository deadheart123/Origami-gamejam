using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    public static CollectableManager Instance { get; private set; }
    public List<OrigamiCollectable> craneCollectableGroup;
    public int cranesCollected = 0;

    public List<OrigamiCollectable> snakeCollectableGroup;
    public int snakesCollected = 0;

    public List<OrigamiCollectable> ratCollectableGroup;
    public int ratsCollected = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void GetCollectable(Animal type)
    {
        switch (type)
        {
            case Animal.CRANE:
                cranesCollected++;
                if (cranesCollected == craneCollectableGroup.Count)
                {
                    AreaManager.Instance.LoadArea(1);
                }
                break;
            case Animal.SNAKE:
                snakesCollected++;
                if (snakesCollected == snakeCollectableGroup.Count)
                {
                    AreaManager.Instance.LoadArea(2);
                }
                break;
            case Animal.RAT:
                ratsCollected++;
                if (ratsCollected == ratCollectableGroup.Count)
                {
                    AreaManager.Instance.LoadArea(3);
                }
                break;
            default:
                break;
        }
    }
}
