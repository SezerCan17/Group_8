using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoToCarManager : MonoBehaviour
{
    public Transform trunkLocation; // Location where cargo will be placed in the car

    private void OnDrawGizmos()
    {
        if (trunkLocation != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawCube(trunkLocation.position, new Vector3(1.5f,0.1f,1.5f));
            //Gizmos.DrawSphere(trunkLocation.position, 0.5f);
        }
    }
}
