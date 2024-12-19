using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoLocationControlManager : MonoBehaviour
{
    public EconomyController economyController;
    public CustomerSatisfaction customerSatisfaction;
    public SecurityandHealthManager securityandHealthManager;
    public void HandleLocation(LocationType locationType, bool onTime)
{
    if (locationType.ToString().Contains("Apartment"))
    {
        if(onTime)
        {
            customerSatisfaction.CalculateGovermentSatisfactionPlus(10);

        }
        else
        {
            
        }
        Debug.Log("Bu bir apartman.");
    }
    else if (locationType.ToString().Contains("Pizza"))
    {
        if(onTime)
        {
            economyController.EconomyCalculatePlus(10);
            customerSatisfaction.CalculateGovermentSatisfactionPlus(10);

        }
        else
        {
            economyController.EconomyCalculateMinus(10);
            customerSatisfaction.CalculateGovermentSatisfactionMinus(20);

        }
        Debug.Log("Bu bir pizzacı.");
    }
    else if (locationType.ToString().Contains("IceCreamShop"))
    {
        if(onTime)
        {
            economyController.EconomyCalculatePlus(10);
            customerSatisfaction.CalculateGovermentSatisfactionPlus(10);

        }
        else
        {
            economyController.EconomyCalculateMinus(10);
            customerSatisfaction.CalculateGovermentSatisfactionMinus(20);

        }
        Debug.Log("Bu bir dondurma dükkanı.");
    }
    else if (locationType.ToString().Contains("BurgerShop"))
    {
        if(onTime)
        {
            economyController.EconomyCalculatePlus(10);
            customerSatisfaction.CalculateGovermentSatisfactionPlus(10);

        }
        else
        {
            economyController.EconomyCalculateMinus(10);
            customerSatisfaction.CalculateGovermentSatisfactionMinus(20);

        }
        Debug.Log("Bu bir burger dükkanı.");
    }
    else if (locationType.ToString().Contains("CoffeeShop"))
    {
        if(onTime)
        {
            economyController.EconomyCalculatePlus(10);
            customerSatisfaction.CalculateGovermentSatisfactionPlus(10);

        }
        else
        {
            economyController.EconomyCalculateMinus(10);
            customerSatisfaction.CalculateGovermentSatisfactionMinus(20);

        }
        Debug.Log("Bu bir kahve dükkanı.");
    }
    else if (locationType.ToString().Contains("SausageStand"))
    {
        if(onTime)
        {
            economyController.EconomyCalculatePlus(10);
            customerSatisfaction.CalculateGovermentSatisfactionPlus(10);

        }
        else
        {
            economyController.EconomyCalculateMinus(10);
            customerSatisfaction.CalculateGovermentSatisfactionMinus(20);

        }
        Debug.Log("Bu bir sosis standı.");
    }
    else if (locationType.ToString().Contains("LemonadeShop"))
    {
        if(onTime)
        {
            economyController.EconomyCalculatePlus(10);
            customerSatisfaction.CalculateGovermentSatisfactionPlus(10);
            

        }
        else
        {
            economyController.EconomyCalculateMinus(10);
            customerSatisfaction.CalculateGovermentSatisfactionMinus(20);

        }
        Debug.Log("Bu bir limonata dükkanı.");
    }
    else if (locationType.ToString().Contains("Warehouse"))
    {
        if(onTime)
        {
            economyController.EconomyCalculatePlus(10);
            customerSatisfaction.CalculateGovermentSatisfactionPlus(10);

        }
        else
        {
            economyController.EconomyCalculateMinus(10);
            customerSatisfaction.CalculateGovermentSatisfactionMinus(20);

        }
        Debug.Log("Bu bir depo.");
    }
    else if (locationType.ToString().Contains("Insaat"))
    {
        if(onTime)
        {
            economyController.EconomyCalculatePlus(10);
            customerSatisfaction.CalculateGovermentSatisfactionPlus(10);

        }
        else
        {
            economyController.EconomyCalculateMinus(10);
            customerSatisfaction.CalculateGovermentSatisfactionMinus(20);

        }
        Debug.Log("Bu bir inşaat.");
    }
    else if (locationType.ToString().Contains("PowerPlant"))
    {
        if(onTime)
        {
            economyController.EconomyCalculatePlus(10);
            customerSatisfaction.CalculateGovermentSatisfactionPlus(10);
            

        }
        else
        {
            
            customerSatisfaction.CalculateGovermentSatisfactionMinus(20);
            

        }
        Debug.Log("Bu bir elektrik santrali.");
    }
    else if (locationType.ToString().Contains("Industry"))
    {
        if(onTime)
        {
            economyController.EconomyCalculatePlus(10);
            customerSatisfaction.CalculateGovermentSatisfactionPlus(10);
            

        }
        else
        {
            
            customerSatisfaction.CalculateGovermentSatisfactionMinus(20);

        }
        Debug.Log("Bu bir endüstri bölgesi.");
    }
    else if (locationType.ToString().Contains("NaturalGasPlant"))
    {
        if(onTime)
        {
            economyController.EconomyCalculatePlus(10);
            customerSatisfaction.CalculateGovermentSatisfactionPlus(10);
            

        }
        else
        {
            
            customerSatisfaction.CalculateGovermentSatisfactionMinus(20);

        }
        Debug.Log("Bu bir doğalgaz santrali.");
    }
    else if (locationType.ToString().Contains("Hotel"))
    {
        if(onTime)
        {
            economyController.EconomyCalculatePlus(10);
            customerSatisfaction.CalculateGovermentSatisfactionPlus(10);
            

        }
        else
        {
            
            customerSatisfaction.CalculateGovermentSatisfactionMinus(20);

        }
        Debug.Log("Bu bir otel.");
    }
    else if (locationType.ToString().Contains("Church"))
    {
        if(onTime)
        {
            
            customerSatisfaction.CalculateGovermentSatisfactionPlus(10);
            

        }
        else
        {
            
            customerSatisfaction.CalculateGovermentSatisfactionMinus(20);

        }

        Debug.Log("Bu bir kilise.");
    }
    else if (locationType.ToString().Contains("TennisCourt"))
    {
        if(onTime)
        {
            economyController.EconomyCalculatePlus(10);
            customerSatisfaction.CalculateGovermentSatisfactionPlus(10);

        }
        else
        {
            economyController.EconomyCalculateMinus(10);
            customerSatisfaction.CalculateGovermentSatisfactionMinus(20);

        }
        Debug.Log("Bu bir tenis kortu.");
    }
    else if (locationType == LocationType.PoliceOffice)
    {
        if(onTime)
        {
            securityandHealthManager.CalculateSecurityandHealthPlus(10);
            customerSatisfaction.CalculateGovermentSatisfactionPlus(10);
          

        }
        else
        {
            securityandHealthManager.CalculateSecurityandHealthMinus(10);
            customerSatisfaction.CalculateGovermentSatisfactionMinus(20);

        }
        Debug.Log("Bu bir polis ofisi.");
    }
    else if (locationType == LocationType.Hospital)
    {
        if(onTime)
        {
            securityandHealthManager.CalculateSecurityandHealthPlus(10);
            customerSatisfaction.CalculateGovermentSatisfactionPlus(10);

        }
        else
        {
            securityandHealthManager.CalculateSecurityandHealthMinus(10);
            customerSatisfaction.CalculateGovermentSatisfactionMinus(20);

        }
        Debug.Log("Bu bir hastane.");
    }
    else if (locationType == LocationType.FireStation)
    {
        if(onTime)
        {
            securityandHealthManager.CalculateSecurityandHealthPlus(10);
            customerSatisfaction.CalculateGovermentSatisfactionPlus(10);

        }
        else
        {
            securityandHealthManager.CalculateSecurityandHealthMinus(10);
            customerSatisfaction.CalculateGovermentSatisfactionMinus(20);

        }
        Debug.Log("Bu bir itfaiye istasyonu.");
    }
    else if (locationType == LocationType.TrainStation)
    {
        if(onTime)
        {
            economyController.EconomyCalculatePlus(10);
            customerSatisfaction.CalculateGovermentSatisfactionPlus(10);

        }
        else
        {
            economyController.EconomyCalculateMinus(10);
            customerSatisfaction.CalculateGovermentSatisfactionMinus(20);

        }
        Debug.Log("Bu bir tren istasyonu.");
    }
    else if (locationType == LocationType.Banka)
    {
        if(onTime)
        {
            economyController.EconomyCalculatePlus(10);
            customerSatisfaction.CalculateGovermentSatisfactionPlus(10);

        }
        else
        {
            economyController.EconomyCalculateMinus(10);
            customerSatisfaction.CalculateGovermentSatisfactionMinus(20);

        }
        Debug.Log("Bu bir banka.");
    }
    else if (locationType == LocationType.GasStation)
    {
        if(onTime)
        {
            economyController.EconomyCalculatePlus(10);
            customerSatisfaction.CalculateGovermentSatisfactionPlus(10);

        }
        else
        {
            economyController.EconomyCalculateMinus(10);
            customerSatisfaction.CalculateGovermentSatisfactionMinus(20);

        }
        Debug.Log("Bu bir benzin istasyonu.");
    }
    else if (locationType == LocationType.Museum)
    {
        if(onTime)
        {
            economyController.EconomyCalculatePlus(10);
            customerSatisfaction.CalculateGovermentSatisfactionPlus(10);

        }
        else
        {
            economyController.EconomyCalculateMinus(10);
            customerSatisfaction.CalculateGovermentSatisfactionMinus(20);

        }
        Debug.Log("Bu bir müze.");
    }
    else if (locationType == LocationType.CargoOffice)
    {
        Debug.Log("Bu bir kargo ofisi.");
    }
    else if (locationType == LocationType.ParkingLot)
    {
        Debug.Log("Bu bir otopark.");
    }
    else
    {
        Debug.Log("Bilinmeyen bir konum.");
    }
}

}
