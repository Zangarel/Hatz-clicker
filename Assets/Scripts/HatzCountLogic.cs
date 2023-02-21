using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class HatzCountLogic : MonoBehaviour
{
    public GameObject mainLogic;
    public Text hatzCount;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string textToSet = mainLogic.GetComponent<MainLogicScript>().GetHatzCount().ToString();
        textToSet += " Hatzuri";
        hatzCount.text = textToSet;
    }
}
