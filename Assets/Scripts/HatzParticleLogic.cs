using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HatzParticleLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public Text hatzText;
    void Start()
    {
        /* Distruce textul particula dupa o secunda
         */
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        /* Misca particula in jos dupa ce apare
         */
        hatzText.transform.Translate(360 * Time.deltaTime * Vector2.down);
    }

    public void setHatzCount(ulong hatz)
    {
        /* Initializeaza particula text dupa apasarea clickerului
         */
        hatzText.text = "+ " + hatz.ToString();
        hatzText.transform.position = UnityEngine.Input.mousePosition + Vector3.right * 150;
    }
}
