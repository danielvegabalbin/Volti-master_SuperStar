using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeDetector : MonoBehaviour
{
    private Vector2 fingerDownPos;
    private Vector2 fingerUpPos;

    public bool detectSwipeAfterRelease = false;

    public bool swipeOn = true;
   
    public bool swipeWork = false;

    public int act;
   
    public PlayerCO1 playerCO1;

    public float SWIPE_THRESHOLD = 20f;

    // Update is called once per frame
    void Update()
    {

            foreach (Touch touch in Input.touches)
            {
            if (touch.phase == TouchPhase.Began)
            {
                swipeWork = true;
                fingerUpPos = touch.position;
                fingerDownPos = touch.position;
                

            }

            //Detects Swipe while finger is still moving on screen
            if (touch.phase == TouchPhase.Moved)
            {
                if (!detectSwipeAfterRelease)
                {
                    fingerDownPos = touch.position;
                    DetectSwipe();
                    //needFingerUp = true;
                }
            }

            //Detects swipe after finger is released from screen
            if (touch.phase == TouchPhase.Ended)
            {
               
                fingerDownPos = touch.position;

                DetectSwipe();
                swipeWork = false;
            }
        }
    }

    void DetectSwipe()
    {
       
        if (swipeOn)
        {
            #region Swipe

           
            if (VerticalMoveValue() > SWIPE_THRESHOLD && VerticalMoveValue() > HorizontalMoveValue())
            {
                Debug.Log("Vertical Swipe Detected!");
                if (fingerDownPos.y - fingerUpPos.y > 0)
                {
                    OnSwipeUp();
                }
                else if (fingerDownPos.y - fingerUpPos.y < 0)
                {
                    OnSwipeDown();
                }
                fingerUpPos = fingerDownPos;

            }
            else if (HorizontalMoveValue() > SWIPE_THRESHOLD && HorizontalMoveValue() > VerticalMoveValue())
            {
                Debug.Log("Horizontal Swipe Detected!");
                if (fingerDownPos.x - fingerUpPos.x > 0)
                {
                    OnSwipeRight();
                    
                }
                else if (fingerDownPos.x - fingerUpPos.x < 0)
                {
                    OnSwipeLeft();
                    

                }
                fingerUpPos = fingerDownPos;

            }
            else
            {
                Debug.Log("No Swipe Detected!");
            }
            #endregion
        }

    }

    float VerticalMoveValue()
    {
        return Mathf.Abs(fingerDownPos.y - fingerUpPos.y);
    }

    float HorizontalMoveValue()
    {
        return Mathf.Abs(fingerDownPos.x - fingerUpPos.x);
    }

    public void OnSwipeUp()
    {
        playerCO1.Jump();
    }

    public void OnSwipeDown()
    {
        //Do something when swiped down
    }

    public void OnSwipeLeft()
    {
        swipeWork = true;
        if (swipeWork)
        {
            playerCO1.MoveLeft();
        }
        swipeWork = false;

        //Do something when swiped left
    }

    public void OnSwipeRight()
    {
        swipeWork = true;

        if (swipeWork)
        {
            playerCO1.MoveRight();
        }
        swipeWork = false;

        //Do something when swiped right
    }
}