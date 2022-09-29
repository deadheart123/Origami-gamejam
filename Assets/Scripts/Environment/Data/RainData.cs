using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RainData : ScriptableObject
{
    public GameObject[] rainPrefabs;
    public Transform[] spawnPoints;
    public float rainTimerMin;
    public float rainTimerMax;

}
