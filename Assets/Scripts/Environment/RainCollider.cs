using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainCollider : MonoBehaviour
{
    protected void ProcessCollision(GameObject collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Destroy(collider.gameObject);
            Destroy(this.gameObject);
        }

        else
        {
            Destroy(this.gameObject);
        }
        
    }

    protected void OnCollisionEnter(Collision collision)
    {
        ProcessCollision(collision.gameObject);
      
    }
}
