using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainClickerLogic : MonoBehaviour
{
    // Clasa de tip Service pentru logica ce tine de apasarea hatzului
    // HatzOnClick - Numarul de Hatzuri pe care le primesti pe apasarea butonului
    // TemporaryMultiplier - Multiplicatorul de Hatzuri (daca e 1 nu e multiplicare practic)

    public double HatzOnClick;
    public double TemporaryMultiplier;

    public void InitializeClickerLogic()
    {
        // Functie pentru initializarea service-ului, ar trebui apelata doar o data
        // Reseteaza HatzOnClick si TemporaryMultiplier
        HatzOnClick = 1;
        TemporaryMultiplier = 1;
    }
    public double GetHatzOnClick()
    {
        // Functie de tip Getter pentru returnarea valorii HatzOnClick
        return HatzOnClick;
    }
    public double GetTemporaryMultiplier()
    {
        // Functie de tip Getter pentru returnarea valorii TemporaryMultiplier
        return TemporaryMultiplier;
    }

    public void SetHatzOnClick(double HatzOnClickToSet)
    {
        // Functie de tip Setter pentru HatzOnClick
        HatzOnClick = HatzOnClickToSet;
    }

    public void SetTemporaryMultiplier(double TemporaryMultiplierToSet)
    {
        // Functie de tip Setter pentru TemporaryMultiplier
        TemporaryMultiplier = TemporaryMultiplierToSet;
    }

    public void ResetTemporaryMultiplier()
    {
        // Functie pentru resetarea valorii TemporaryMultiplier
        TemporaryMultiplier = 1;
    }
    public double GetHatzToAdd()
    {
        //Functie pentru returnarea valorii EFECTIVE de hatzuri pe click (cu tot cu eventualele efecte temporare / speciale)
        return HatzOnClick * TemporaryMultiplier;
    }
}
