using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingLogic : MonoBehaviour
{
    public string buildingName;
    public string buildingMetaData;
    public ulong buildingCount;
    public ulong hatzPerSecond;
    public ulong cost;
    public ulong costScaling;

    void Start()
    {
        updateMetaData();
    }
    public ulong getSecondOfHatz()
    {
        return buildingCount * hatzPerSecond;
    }

    public void addBuilding(ulong howMany)
    {
        buildingCount += howMany;
        cost *= costScaling;
    }

    public string getBuildingMetaData()
    {
        updateMetaData();
        return buildingMetaData;
    }

    public void setBuildingMetaData(string buildingData)
    {
        buildingMetaData = buildingData;
        string[] splitBuildingData = buildingData.Split(";");
        buildingCount = Convert.ToUInt64(splitBuildingData[0]);
        hatzPerSecond = Convert.ToUInt64((splitBuildingData[1]));
        cost = Convert.ToUInt64((splitBuildingData[2]));
        costScaling = Convert.ToUInt64((splitBuildingData[3]));
    }

    private void updateMetaData()
    {
        buildingMetaData = "";
        buildingMetaData += buildingCount.ToString() + ";";
        buildingMetaData += hatzPerSecond.ToString() + ";";
        buildingMetaData += cost.ToString() + ";";
        buildingMetaData += costScaling.ToString() + ";";
    }
}
