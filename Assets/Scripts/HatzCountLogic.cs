using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HatzCountLogic : MonoBehaviour
{
    public GameObject MainLogic;
    public Text HatzCountString;
    public BigInteger HatzCount;
    Dictionary<string, BigInteger> keyValuePairs;
    void Start()
    {
        keyValuePairs = new Dictionary<string, BigInteger>
        {
            { "Million",     1_000_000 },
            { "Billion",     1_000_000_000 },
            { "Trillion",    1_000_000_000_000 },
            { "Quadrillion", 1_000_000_000_000_000 },
            { "Quintillion", 1_000_000_000_000_000_000 }
        };
    }

    // Update is called once per frame
    void Update()
    {
        HatzCount = MainLogic.GetComponent<MainLogicScript>().GetHatzCount();
        string textToSet = ValueToName(HatzCount);
        textToSet += " Hâtzuri";
        HatzCountString.text = textToSet;
    }

    private string ValueToName(BigInteger x)
    {
        if (x > keyValuePairs["Million"])
            return string.Format("%.2d Million", x / keyValuePairs["Million"]);

        if (x > keyValuePairs["Billion"])
            return string.Format("%.2d Billion", x / keyValuePairs["Billion"]);

        if (x > keyValuePairs["Trillion"])
            return string.Format("%.2d Trillion", x / keyValuePairs["Trillion"]);

        if (x > keyValuePairs["Quadrillion"])
            return string.Format("%.2d Quadrillion", x / keyValuePairs["Quadrillion"]);

        if (x > keyValuePairs["Quintillion"])
            return string.Format("%.2d Quintillion", x / keyValuePairs["Quintillion"]);

        return x.ToString();

    }
}
