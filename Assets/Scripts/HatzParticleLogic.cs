using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HatzParticleLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public double hatzCount;
    public Text hatzText;
    void Start()
    {
        Destroy(gameObject, 1.69f);
    }

    // Update is called once per frame
    void Update()
    {
        hatzText.transform.Translate(Vector2.down);
    }

    public void setHatzCount(double hatz)
    {
        hatzCount = hatz;
        hatzText.text = "+ " + hatzCount.ToString();
        hatzText.transform.position = UnityEngine.Input.mousePosition;
    }
}
