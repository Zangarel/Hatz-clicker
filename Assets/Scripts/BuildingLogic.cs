using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingLogic : MonoBehaviour
{
    public string buildingName;
    public double buildingCount;
    public double hatzPerSecond;
    public double cost;
    public double costScaling;

    public double getSecondOfHatz()
    {
        return buildingCount * hatzPerSecond;
    }

    public void addBuilding(int howMany)
    {
        buildingCount += howMany;
        cost *= costScaling;
    }
}
