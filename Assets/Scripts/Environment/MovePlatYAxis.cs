using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatYAxis : MovePlatBase
{

    override protected void MovePlatform()
    {
        if (movePos)
        {
            transform.Translate(Vector3.up * platformData.movementSpeed * Time.deltaTime);

        }
        else if (!movePos)
        {
            transform.Translate(Vector3.down * platformData.movementSpeed * Time.deltaTime);
        }
    }
}
