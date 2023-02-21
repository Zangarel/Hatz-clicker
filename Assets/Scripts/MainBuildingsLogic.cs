using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBuildingsLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] listOfBuildings;

    public double tickBuildings()
    {
        double totalTicked = 0f;
        for(int buildingIndex = 0; buildingIndex < listOfBuildings.Length; buildingIndex++)
        {
            totalTicked += listOfBuildings[buildingIndex].GetComponent<BuildingLogic>().getSecondOfHatz();
        }
        return totalTicked;
    }

    public void buyBuilding(int buildingIndex)
    {
        listOfBuildings[buildingIndex].GetComponent<BuildingLogic>().addBuilding(1);
    }
}
