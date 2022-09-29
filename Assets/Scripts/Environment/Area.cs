using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    GameObject player;

    public Transform spawnpoint;
    private Vector3 cachedPosition = Vector3.zero;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void LoadSubArea()
    {
        cachedPosition = player.transform.position;
        player.transform.position = spawnpoint.position;
    }

    public void LoadMainArea()
    {
        player.transform.position = cachedPosition;
    }
}
