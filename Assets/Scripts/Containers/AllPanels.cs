using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AllPanels : MonoBehaviour
{



    [SerializeField] public SwipeDetector swipeDetector;
    [SerializeField] public RestartGame restartGame;
    [SerializeField] public UI_CentralManager uI_CentralManager;
    [SerializeField] public UI_Panels_Manager uI_Panels_Manager;

    [SerializeField] public GameObject helperPanel;

    [Header("All for Main Menu ")]
    [SerializeField] public GameObject up_Panel;
    [SerializeField] public GameObject bottom_Panel;
    [SerializeField] Button shop_BTN;
    [SerializeField] GameObject upUI_Panel;
    [SerializeField] public TextMeshProUGUI maxRecord_TMP;
    [SerializeField] public TextMeshProUGUI batteries_TMP;
    [SerializeField] public TextMeshProUGUI coins_TMP;
    [SerializeField] public GameObject PressToPlay_BTN_GO;
    [SerializeField] public Button     PressToPlay_BTN;
    [SerializeField] public GameObject playerTrail;


    [Header("All for Volti Section ")]
    [SerializeField] public GameObject volti_Panel;
    [SerializeField] public Button volti_BTN;
    [SerializeField] public GameObject voltiMenu_Panel;
    [SerializeField] public Button colors_BTN;
    [SerializeField] public Button awards_BTN;
    [SerializeField] public Button backMenu_voltiM_BTN;
    [SerializeField] public GameObject colors_Panel;
    [SerializeField] public GameObject awards_Panel;


    [Header("All for InGame Section ")]
    [SerializeField] public GameObject pauseBTN_Panel;
    [SerializeField] public GameObject pausePanel;
    [SerializeField] public GameObject right_Information_Panel;
    [SerializeField] public GameObject counter_Panel;
    [SerializeField] public GameObject master_Disconnection_Panel;
    [SerializeField] public GameObject imageDesconnection_Panel;
    [SerializeField] public Button     pause_BTN;
    [SerializeField] public Button     backMenu_Pause_BTN;
    [SerializeField] public Button     continue_BTN;
    [SerializeField] public TextMeshProUGUI Counter_text_TMPRO;
    [SerializeField] public TextMeshProUGUI CurrentScore_TMPRO;
    [SerializeField] public TextMeshProUGUI Batteries2_TMPRO;
    [SerializeField] public Slider Battery_Slider;
    [SerializeField] public GameObject disconnectionPanel;
    [SerializeField] public Button reconnect_BTN;
    [SerializeField] public TextMeshProUGUI reconnect_BTN_TMPRO;

    //[SerializeField] public GameObject imageDisconnection_Panel;




    [Header("Buttons for movement")]
    [SerializeField] public GameObject leftMovement_BTN;
    [SerializeField] public  GameObject rightMovement_BTN;

    [Header("Start Menu Buttons & Panels")]
    
    //[SerializeField] Button shop_BTN;
    //[SerializeField] GameObject upUI_Panel;
    //[SerializeField] Button startGame_BTN;

    

    
    //play BTN

    [Header("Volti Buttons & Panels")]
    

    [Header("In Game Buttons, Panels & Variables ")]
    

    //private float counter_Pause;
    //private float maxTime_Pause = 3.0f;
    //private bool count_Pause = false;

    //private float counter_Disconnection = 7.0f;
    //private float maxTime_Disconnection = 7.0f;
    //public bool count_Disconnection = false;

    //public bool SwipeActive = false;

    [SerializeField] public static Button Reset_BTN;


    //Pause Panels


    //Disconnection Panels
    // Start is called before the first frame update

    
}
