using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    public CargoSpawner cargoSpawner;
    public Mailboxs mailboxs;
   public void ControlDelivery()
   {
     for(int i = 0;i<=mailboxs.mailBox.Length;i++)
     {
        for(int j=0;j<=cargoSpawner.spawnPoint.Length;j++)
        {
            if(cargoSpawner.spawnPoint[j]==mailboxs.mailBox[i])
            {
                
            }
        }
     }

   }
}
