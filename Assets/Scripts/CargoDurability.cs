using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoDurability : MonoBehaviour
{
    public void CalculateDurability(Package cargo)
    {
        Package cargoPackage = cargo.gameObject.GetComponent<Package>();
        int n = Random.Range(0, 40);

        cargo.cargoSO.durability-=n; 
        if(cargo.cargoSO.durability<=0)
        {
            cargo.cargoSO.durability=0;
        }   

    } 
}
