using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    public List<GameObject> areas;

    public int currentlyActiveArea = 0;

    public static AreaManager Instance { get; private set; }

    public GameObject player;

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

        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void LoadArea(int levelIndex)
    {
        areas[levelIndex].SetActive(true);
        player.transform.position = areas[levelIndex].GetComponent<Area>().spawnpoint.position;
        areas[currentlyActiveArea].SetActive(false);
        currentlyActiveArea = levelIndex;
    }
}
