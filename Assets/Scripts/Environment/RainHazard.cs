using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainHazard : MonoBehaviour
{
    public GameObject[] rainPrefabs;
    public Transform[] spawnPoints;
    private float  rainTimer;
    [SerializeField] private float rainTimerMin;
    [SerializeField] private float rainTimerMax;

    // Start is called before the first frame update
    void Start()
    {
        ResetSpawnTimer();
    }

    // Update is called once per frame
    void Update()
    {
        rainTimer = rainTimer -= Time.deltaTime;

        if (rainTimer <= 0)
        {
            SpawnRain();
        }
    }

    private void SpawnRain()
    {
        int rainIndexToSpawn = Random.Range(0, 2);
        int positionIndexToSpawn = Random.Range(0, 30);

        Instantiate(rainPrefabs[rainIndexToSpawn], spawnPoints[positionIndexToSpawn].position, Quaternion.identity);
        ResetSpawnTimer();
    }

    void ResetSpawnTimer()
    {
        rainTimer = Random.Range(rainTimerMin, rainTimerMax);
    }

}
