using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class SliderLogic : MonoBehaviour
{
    public bool sliding = false;
    public bool MouseClicked = false;
    public bool IsUp = false;
    private const float TopPosition = 770;
    private const float BotPosition = -587;
    public float pos = 0;
    public int slidingSpeed = 4000;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /* Da slide la meniu cand tragi de capu meniului
         * 
         */
        pos = gameObject.transform.position.y;
        if(Input.GetMouseButtonDown(0))
            MouseClicked = true;    
        if (pos == TopPosition || pos == BotPosition)
            sliding = false;
        if (sliding && MouseClicked)
        {
            Vector2 finalVectorSpeed = Vector2.up * slidingSpeed * Time.deltaTime;
            gameObject.transform.Translate(IsUp ? finalVectorSpeed : finalVectorSpeed * -1);
            if (pos >= TopPosition || pos <= BotPosition)
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, IsUp ? TopPosition : BotPosition);
                sliding = false;
                MouseClicked = false;
                IsUp = !IsUp;
            }
        }
    }


    public void OnSlide()
    {
        sliding = true;
    }

    

    
}
