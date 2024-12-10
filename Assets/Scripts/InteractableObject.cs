using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public bool isPlayerEnter = false;

    //private void OnTriggerEnter(Collider other)
    //{
    //    isPlayerEnter = true;
    //}
    private void OnCollisionEnter(Collision collision)
    {
        isPlayerEnter = true;
    }
}
