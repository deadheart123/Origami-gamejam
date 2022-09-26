using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This is a base class that moves a platform on the X axis, whether it is negative or positive movemement depends on the movPosBool,
  the platform will initially move positively along the x axis, when colliding with 'PlatformB' tagged collider the bool will switch to false, sending platform back along the x axis negatively and vice versa for 'PlatformA' tagged platform */
public class MovePlatBase : MonoBehaviour
{
    [SerializeField] protected PlatformData platformData;
    protected bool movePos;
    
    // Start is called before the first frame update
    protected void Start()
    {
        movePos = true;

    }

    // Update is called once per frame
    protected void Update()
    {

        MovePlatform();

    }

    //When inheriting this class, override this method to change along which axis the platform moves
    virtual protected void MovePlatform()
    {
        if (movePos)
        {
            transform.Translate(Vector3.right * platformData.movementSpeed * Time.deltaTime);

        }
        else if (!movePos)
        {
            transform.Translate(Vector3.left * platformData.movementSpeed * Time.deltaTime);
        }
    }

    protected void ProcessCollision(GameObject collider)
    {
        if (collider.gameObject.CompareTag("PlatformA"))
        {
            movePos = true;
            Debug.Log("A");
        }
        else if (collider.gameObject.CompareTag("PlatformB"))
        {
            movePos = false;
            Debug.Log("B");
        }
    }

    protected void OnCollisionEnter(Collision collision)
    {
        ProcessCollision(collision.gameObject);
        Debug.Log("Collision");
    }
}
