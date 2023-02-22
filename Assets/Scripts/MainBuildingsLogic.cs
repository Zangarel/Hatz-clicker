using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBuildingsLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] listOfBuildings;

    public ulong tickBuildings()
    {
        ulong totalTicked = 0;
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

    public string getAllBuildingsMetaData()
    {
        string fullMetaData = "";
        for (int buildingIndex = 0; buildingIndex < listOfBuildings.Length; buildingIndex++)
        {
            fullMetaData += listOfBuildings[buildingIndex].GetComponent<BuildingLogic>().getBuildingMetaData();
            fullMetaData += "-";
        }
        return fullMetaData;
    }

    public void loadSaveDataFromString(string saveData)
    {
        string[] splitSaveData = saveData.Split("-");
        for (int buildingIndex = 0; buildingIndex < listOfBuildings.Length; buildingIndex++)
        {
            string buildingData = splitSaveData[buildingIndex];
            listOfBuildings[buildingIndex].GetComponent<BuildingLogic>().setBuildingMetaData(buildingData);
        }
    }
}
