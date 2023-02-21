using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class SliderLogic : MonoBehaviour
{
    public bool Sliding = false;
    public bool MouseClicked = false;
    public bool IsUp = false;
    private const float TopPosition = 770;
    private const float BotPosition = -587;
    public float Pos = 0;
    public float PositionBefore = -1;
    public int SlidingSpeed = 4000;
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
        Pos = gameObject.transform.position.y;
        if (Pos > TopPosition)
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, TopPosition);
        if (Pos < BotPosition)
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, BotPosition);
        if (Input.GetMouseButtonUp(0))
            MouseClicked = true;    
        if (Pos == TopPosition || Pos == BotPosition)
            Sliding = false;
        if (Sliding && MouseClicked)
        {
            Vector2 finalVectorSpeed = Vector2.up * SlidingSpeed * Time.deltaTime;
            gameObject.transform.Translate(IsUp ? finalVectorSpeed : finalVectorSpeed * -1);
            if (Pos >= TopPosition || Pos <= BotPosition)
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, IsUp ? TopPosition : BotPosition);
                Sliding = false;
                MouseClicked = false;
                IsUp = !IsUp;
            }
        }
    }


    public void OnSlide()
    {
        Sliding = true;
    }

    

    
}
