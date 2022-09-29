using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainCollider : MonoBehaviour
{
    private float rainLifeTimeTimer = 5f;
    void Update()
    {
       
            rainLifeTimeTimer = rainLifeTimeTimer -= Time.deltaTime;

            if (rainLifeTimeTimer <= 0)
            {
                Destroy(this.gameObject);
            }
        
    }
    protected void ProcessCollision(GameObject collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            AudioEventSystem.TriggerEvent("RainDropHitPlayer", this.gameObject);
            collider.gameObject.SetActive(false);
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
