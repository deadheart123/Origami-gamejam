using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatZAxis : MovePlatBase
{
  
    override protected void MovePlatform()
    {
        if (movePos)
        {
            transform.Translate(Vector3.forward * platformData.movementSpeed * Time.deltaTime);

        }
        else if (!movePos)
        {
            transform.Translate(Vector3.back * platformData.movementSpeed * Time.deltaTime);
        }
    }
}
