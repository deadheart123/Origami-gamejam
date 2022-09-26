using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatform : MonoBehaviour
{
    [SerializeField] private PlatformData platformData;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(Vector3.right * platformData.rotationSpeed * Time.deltaTime);
    }
}
