using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainCollider : MonoBehaviour
{
    protected void ProcessCollision(GameObject collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            AudioEventSystem.TriggerEvent("RainDropHitPlayer", this.gameObject);
            Destroy(collider.gameObject);
            Destroy(this.gameObject);
        }

        else
        {
            AudioEventSystem.TriggerEvent("RainDrop", this.gameObject);
            Destroy(this.gameObject);
        }
        
    }

    protected void OnCollisionEnter(Collision collision)
    {
        ProcessCollision(collision.gameObject);
      
    }
}
