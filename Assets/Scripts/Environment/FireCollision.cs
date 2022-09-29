using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.SetActive(false);
            AudioEventSystem.TriggerEvent("PlayerDisintegrated", this.gameObject);
        }
    }
}
