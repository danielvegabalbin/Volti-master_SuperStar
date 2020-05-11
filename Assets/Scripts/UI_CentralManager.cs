using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.Tilemaps;

public class UI_CentralManager : MonoBehaviour
{
    [SerializeField] AllPanels allPanels;
    [SerializeField] SaveManager saveManager;
    [SerializeField] UI_Panels_Manager uI_Panels_Manager;
    [SerializeField] PlayerCO1 playerCO1;
    [SerializeField] CameraFollow cameraFollow;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] TileManager tileManager;
    [SerializeField] GameObject tileManagerGO;

    int rechargeValue = 1;

    [Header("Buttons for movement")]
    [SerializeField] GameObject leftMovement_BTN;
    [SerializeField] GameObject rightMovement_BTN;

    [SerializeField] public Collider[] enemies;
    [SerializeField] public GameObject[] obstacles;
    [SerializeField] public GameObject playerGO;
    
    [SerializeField] TextMeshProUGUI Counter_text_TMPRO;
    public Vector3 tileManagerSP;
    public GameObject TContainer;

    
    

    //[SerializeField] public GameObject imageDisconnection_Panel;

    private float counter_Pause;
    private float maxTime_Pause = 3.0f;
    private bool count_Pause = false;
    private float counter_Disconnection = 7.0f;
    private float maxTime_Disconnection = 7.0f;
    public bool count_Disconnection = false;
    public bool SwipeActive = false;
    public bool charged = false;

    private void Awake()
    {
        allPanels.playerTrail.SetActive(false);
        uI_Panels_Manager.Start_PM();
        uI_Panels_Manager.OpenMainMenu(1);
        Time.timeScale = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        cameraFollow.startOffsetPosActive = true;
        //Reset_BTN.onClick.AddListener(ResetGame);
        allPanels.PressToPlay_BTN.onClick.AddListener(StartGame);
        allPanels.pause_BTN.onClick.AddListener(Pause);
        allPanels.continue_BTN.onClick.AddListener(Continue);
        counter_Disconnection = maxTime_Disconnection;
        allPanels.backMenu_Pause_BTN.onClick.AddListener(ToMenu);
        allPanels.volti_BTN.onClick.AddListener(VoltiSectionOn);
        allPanels.backMenu_voltiM_BTN.onClick.AddListener(ToMenu);
        allPanels.reconnect_BTN.onClick.AddListener(Reconnect);
        allPanels.reconnect_BTN_TMPRO.text = ("CHARGE " + rechargeValue).ToString();
        allPanels.awards_BTN.onClick.AddListener(OpenVoltiAwards);
        allPanels.colors_BTN.onClick.AddListener(OpenVoltiColors);
    }
    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Y))
        {
            saveManager.AddBatteries(5);
        }

        #region Swipe or button change
        if (SwipeActive)
        {
            leftMovement_BTN.SetActive(false);
            rightMovement_BTN.SetActive(false);
        }
        else
        {
            leftMovement_BTN.SetActive(true);
            rightMovement_BTN.SetActive(true);
        }
        #endregion

        //this region is used when the player decided to continue after use the pause
        #region Counter Region
        if (count_Pause)
        {

            if (counter_Pause > -0.1f)
            {
                counter_Pause -= Time.unscaledDeltaTime;
                Time.timeScale = 0;

            }
            if (counter_Pause <= 0.1f)
            {
                allPanels.counter_Panel.SetActive(false);
                allPanels.uI_Panels_Manager.OpenInGame(1);
                Time.timeScale = 1;
            }
            Counter_text_TMPRO.text = counter_Pause.ToString("0");
        }



        #endregion

        //this region is used to change the slider value when the player have been disconnected
        #region Counter Battery Region - SLIDER
        if (count_Disconnection && charged == false)
        {

            if (counter_Disconnection > -0.1f)
            {
                counter_Disconnection -= Time.unscaledDeltaTime;


            }
            if (counter_Disconnection <= 0.1f)
            {
                Disconnect();
            }
            allPanels.Battery_Slider.value = counter_Disconnection;
        }


        #endregion

        //chek if can buy a recharge
        #region Cheker Buy
        if (saveManager.state.batteriesAmount <= rechargeValue)
        {
            allPanels.reconnect_BTN.interactable = false;
        }
        else
        {
            allPanels.reconnect_BTN.interactable = true;
        }
        #endregion

    }
    //open volti section and active volti colors
    void VoltiSectionOn() 
    {

        allPanels.uI_Panels_Manager.OpenVoltiPanel(1);
        OpenVoltiColors();
    
    }
    //Method used For start the game
    void StartGame() 
    {
        allPanels.playerTrail.SetActive(true);
        allPanels.playerTrail.GetComponent<TrailRenderer>().Clear();
        playerCO1.disconnectionAv = true;
        Time.timeScale = 1;
        cameraFollow.startOffsetPosActive = false;

        allPanels.uI_Panels_Manager.OpenInGame(1);
        allPanels.uI_Panels_Manager.OpenMainMenu(0);
        allPanels.uI_Panels_Manager.OpenVoltiPanel(0);
    }
    //Show the MainMenu
    void ToMenu() 
    {
        allPanels.uI_Panels_Manager.BackMenuFromPause();
    
    }
    //Pause The game
    void Pause() 
    {
        Time.timeScale = 0;
        counter_Pause = maxTime_Pause;
        allPanels.uI_Panels_Manager.OpenPause(1);
    }
    //Continue Game After Pause
    void Continue() 
    {
        counter_Pause = maxTime_Pause;
        allPanels.counter_Panel.SetActive(true);
        count_Pause = true;


        allPanels.uI_Panels_Manager.OpenPause(0);
    }
    //Open volti colors menu and close volti awards
    void OpenVoltiColors()
    {

        allPanels.colors_Panel.SetActive(true);
        allPanels.awards_Panel.SetActive(false);

    }
    //Open volti Awards menu and close volti color
    void OpenVoltiAwards()
    {
        allPanels.colors_Panel.SetActive(false);
        allPanels.awards_Panel.SetActive(true);


    }
    //Disconnect Player
    void Disconnect() 
    {
        allPanels.counter_Panel.SetActive(false);
        allPanels.uI_Panels_Manager.OpenDisconnectionPanel(0);
        allPanels.uI_Panels_Manager.OpenInGame(0);
        allPanels.uI_Panels_Manager.OpenPause(0);
        allPanels.uI_Panels_Manager.OpenMainMenu(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Time.timeScale = 0;
    }
    //Reconnect player when he buys a recharge
    void Reconnect()
    {
        Time.timeScale = 1;
        count_Disconnection = false;
        counter_Disconnection = maxTime_Disconnection;
        playerCO1.reconnectedBool = true;
        playerCO1.colliderCounter = playerCO1.reconnectedMaxTime;
       
        saveManager.BuyRecharge(1);
        allPanels.counter_Panel.SetActive(false);
        allPanels.uI_Panels_Manager.OpenInGame(1);
        allPanels.uI_Panels_Manager.OpenDisconnectionPanel(0);
        playerCO1.transform.Translate(new Vector3( 0, 10, -20), Space.Self);
        playerCO1.transform.Rotate (new Vector3(0, 0 , 0), Space.Self);
        Time.timeScale = 1;


    }
    //Desactive colliders of some GameObjects
    public void ColliderOff()
    {
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");

        for (int i = 0; i < obstacles.Length; i++)
        {
            obstacles[i].GetComponent<Collider>().enabled = false;
        }
      
        

    }
    //active colliders of some GameObjects
    public void ColliderOn()
    {
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        

        for (int i = 0; i < obstacles.Length; i++)
        {
            obstacles[i].GetComponent<Collider>().enabled = true;
        }

    }

    //void ReloadAllSystem() 
    //{
    //    allPanels.uI_Panels_Manager.OpenMainMenu(1);

    //    playerGO.transform.position = new Vector3(playerCO1.startPosition.x, playerCO1.startPosition.y,playerCO1.startPosition.z);

    //    allPanels.uI_Panels_Manager.OpenDisconnectionPanel(0);
    //    allPanels.uI_Panels_Manager.OpenInGame(0);
    //    allPanels.uI_Panels_Manager.OpenPause(0);

    //    allPanels.counter_Panel.SetActive(false);

    //    count_Disconnection = false;
    //    counter_Disconnection = maxTime_Disconnection;
    //    // tileManager.DestroySpecificTiles();
    //    //tileManager.Reset();
    //    //tileManager.enabled = false;
        
    //    //tileManager.enabled = true;
    //    //tileManager.DestroySpecificTiles();
    //    //tileManager.Start();
    //    //tileManager.RestarINT = 0;
       
    //    //tileManager.spawnZ = -50f;
    //    //tileManager.maxTilesReached = 3;

    //    scoreManager.actualScore = 0;
    //}
}
