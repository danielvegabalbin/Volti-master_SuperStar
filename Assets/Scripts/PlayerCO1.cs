using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AllPlayerData;

public class PlayerCO1 : MonoBehaviour
{
    [Header("Scripts Needed")]
    [SerializeField] AudioSource pAudioSource;
    [SerializeField] AudioClip changeLineClip;
    [SerializeField] SaveManager saveManager;
    [SerializeField] UI_CentralManager ui_CentralManager;
    [SerializeField] UI_Panels_Manager uI_Panels_Manager;
    [SerializeField] SwipeDetector swipeDetector;
    [SerializeField] SphereCollider playerCollider;

    [SerializeField] public Rigidbody rigidbody;
    [SerializeField] public bool reconnectedBool = false;
    [SerializeField] public float colliderCounter;
    [SerializeField] public float reconnectedMaxTime = 5.0f;

    [SerializeField] public Vector3 startPosition;

    [Header("Fordward Speed")]
    [SerializeField] float forwardSpeed = 4;

    [Header("Current Lane")]
    [SerializeField] public int desiredLane = 1; // 0 LEFT, 1 MIDDLE, 2 RIGHT

    [Header("On Wires Checker")]
    [SerializeField] public bool onWires;

    [Header("Jump Force")]
    [SerializeField] public float jumpForce;

     private float gravityScale = -2;

    [SerializeField] public float[] laneX;

    Vector3 lane = new Vector3(0, 0, 0); // 0 izquierda, 1 medio, 2 derecha

    Vector3 leftLaneV = new Vector3(0,0,0);
    Vector3 middleLaneV = new Vector3(0, 0, 0);
    Vector3 rightLaneV = new Vector3(0, 0, 0);

    [SerializeField] public int actualLane;

    [SerializeField] public bool disconnectionAv = false;


    private void Awake()
    {
        startPosition = transform.position;

        rigidbody = GetComponent<Rigidbody>();
        //serializer = GameObject.FindGameObjectWithTag("Serializer").GetComponent<Serializer>();
        
    }

    

    void Update()
    {

        actualLane = desiredLane;
        
        #region Input Checkers
        if (Input.GetKeyDown(KeyCode.Space) && onWires)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && desiredLane < 2) { MoveRight(); }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && desiredLane > -1) { MoveLeft(); }

        if (desiredLane > 2)
        {
            desiredLane = 2;
        }
        if (desiredLane < 0)
        {
            desiredLane = 0;
        }
        #endregion

        #region Side Movement

        leftLaneV = new Vector3(laneX[0], transform.position.y, transform.position.z);
        middleLaneV = new Vector3(laneX[1], transform.position.y, transform.position.z);
        rightLaneV = new Vector3(laneX[2], transform.position.y, transform.position.z);


        if (desiredLane == 1 && (transform.position.x == leftLaneV.x)) // im in the left 
        {
            

            if (transform.position.x != middleLaneV.x)
            {
                swipeDetector.swipeWork = true;
                
                transform.position = Vector3.Lerp(leftLaneV, middleLaneV, 10);
                
            }
            if (transform.position.x == middleLaneV.x)
            {
                swipeDetector.swipeWork = false;
            }

        }
        if (desiredLane == 1 && (transform.position.x == rightLaneV.x)) // im in the right 
        {
            

            if (transform.position.x != middleLaneV.x)
            {
                swipeDetector.swipeWork = true;

                transform.position = Vector3.Lerp(rightLaneV, middleLaneV, 10);
            }
            if (transform.position.x == middleLaneV.x)
            {
                swipeDetector.swipeWork = false;
            }
            
        }

        if (desiredLane == 0 && (transform.position.x == middleLaneV.x)) // im in the middle to left 
        {
            

            if (transform.position.x != leftLaneV.x)
            {
                swipeDetector.swipeWork = true;

                transform.position = Vector3.Lerp(middleLaneV, leftLaneV, 10);
            }
            if (transform.position.x == leftLaneV.x)
            {
                swipeDetector.swipeWork = false;
            }
        }

        if (desiredLane == 2 && (transform.position.x == middleLaneV.x)) // im in the middle to right 
        {
          

            if (transform.position.x != rightLaneV.x)
            {
                swipeDetector.swipeWork = true;

                transform.position = Vector3.Lerp(middleLaneV, rightLaneV, 10);
            }
            if (transform.position.x == rightLaneV.x)
            {
                swipeDetector.swipeWork = false;
            }
        }


        #endregion

        #region Reconnected
        if (reconnectedBool == true)
        {

            if (colliderCounter > -0.1f)
            {
                colliderCounter -= Time.unscaledDeltaTime;
                ui_CentralManager.ColliderOff();

            }
            if (colliderCounter <= 0.1f)
            {
                ui_CentralManager.ColliderOn();
            }
            
        }
        #endregion
       

    }

    private void FixedUpdate()
    {
        transform.position += transform.forward * Time.deltaTime * forwardSpeed;

        if (!onWires)
        {
            rigidbody.velocity += Vector3.up * gravityScale;
        }
        else
        {
            rigidbody.velocity += Vector3.up * gravityScale * 0; ;
        }

    }

    public void ActiveCo()
    {
        playerCollider.enabled = true;

    }

    public void UnActiveCo()
    {
        playerCollider.enabled = false;

    }
    public void Jump()
    {
        if (onWires)
        {
            rigidbody.AddForce(0, jumpForce, 0, ForceMode.Impulse);

            Debug.Log("Jump");
        }
       
    }
    public void MoveRight()
    {
        PlaySoundMovement();
        desiredLane = desiredLane + 1;
    }
    public void MoveLeft()
    {
        PlaySoundMovement();
        
        desiredLane = desiredLane -1;
    }

    public void SetSpeed( float modifier) 
    {
        forwardSpeed = 2f + modifier;
    
    }
    //Reproduce a sound when moves
    void PlaySoundMovement()
    {
        Sound_Manager.Instance.PlaySFX(changeLineClip);

        //pAudioSource.clip = changeLineClip;
        //pAudioSource.PlayOneShot(changeLineClip);
    }

    #region OnTriggers
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wire")
        {
            onWires = true;
        }

        if (other.tag == "Coin")
        {
            saveManager.AddCoins(1);
            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Wire")
        {
            onWires = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Wire")
        {
            onWires = false;
        }
    }

    
    #endregion

    #region OnCollisions

   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wire")
        {
            onWires = true;

        }
        if (disconnectionAv == true)
        {
            if (collision.gameObject.tag == "Base" || collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "DisconnectedLine" && disconnectionAv == true)
            {
                Disconnected();
            }
        }

    }
    private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.tag == "Wire")
        {
            onWires = true;

        }
    }
    private void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.tag == "Wire")
        {
            onWires = false;
        }
    }
    #endregion

    void Disconnected() 
    {
        //Time.timeScale = 0;
        uI_Panels_Manager.OpenDisconnectionPanel(1);
        
    }

    

}
