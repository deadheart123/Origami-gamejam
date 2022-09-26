using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    void Start()
    {
        
    }

    void LateUpdate()
    {
        Vector3 camPos = Camera.main.transform.position;
        this.transform.LookAt(new Vector3(camPos.x, this.transform.position.y, camPos.z));
    }
}
