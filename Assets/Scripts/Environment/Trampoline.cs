using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] private float bounceForce = 2f;

    private void OnTriggerEnter(Collider other)
    {
        CharacterControllerScript ccs = other.GetComponent<CharacterControllerScript>();
        if(ccs != null)
        {
            other.GetComponent<CharacterControllerScript>().Bounce(bounceForce);
        }
    }
}
