using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class UI_Panels_Manager : MonoBehaviour
{
    [SerializeField] AllPanels allPanels;
    [SerializeField] CameraFollow cameraFollow;
    



    // Start is called before the first frame update
    public void Start_PM()
    {
        allPanels.swipeDetector.swipeOn = false;
        
    }

  
    public void OpenMainMenu(int active) 
    {
        if (active == 1)
        {
            allPanels.playerTrail.SetActive(false);
            //swipeDetector.swipeOn = false;
            allPanels.helperPanel.SetActive(true);
            allPanels.up_Panel.SetActive(true);
            allPanels.bottom_Panel.SetActive(true);
            allPanels.PressToPlay_BTN_GO.SetActive(true);
            allPanels.volti_Panel.SetActive(false);
        }
        if (active == 0)
        {
            //swipeDetector.swipeOn = true;
            allPanels.helperPanel.SetActive(false);
            allPanels.up_Panel.SetActive(false);
            allPanels.bottom_Panel.SetActive(false);
            allPanels.PressToPlay_BTN_GO.SetActive(false);
        }
    }

    public void OpenVoltiPanel(int active)
    {
        if (active == 1)
        {
            //swipeDetector.swipeOn = false;
            allPanels.helperPanel.SetActive(false);
            allPanels.up_Panel.SetActive(false);
            allPanels.bottom_Panel.SetActive(false);
            allPanels.PressToPlay_BTN_GO.SetActive(false);
            allPanels.volti_Panel.SetActive(true);
        }
        if (active == 0)
        {
            //swipeDetector.swipeOn = true;
            allPanels.helperPanel.SetActive(false);
            allPanels.up_Panel.SetActive(false);
            allPanels.bottom_Panel.SetActive(false);
            allPanels.PressToPlay_BTN_GO.SetActive(false);
            allPanels.volti_Panel.SetActive(false);
        }
    }

    public  void OpenInGame(int active)
    {
        if (active == 1)
        {
            allPanels.swipeDetector.swipeOn = true;
            allPanels.pauseBTN_Panel.SetActive(true);
            allPanels.right_Information_Panel.SetActive(true);
        }
        if (active == 0)
        {
            allPanels.swipeDetector.swipeOn = false;
            allPanels.pauseBTN_Panel.SetActive(false);
            allPanels.right_Information_Panel.SetActive(false);
        }
    }
    
    public  void OpenPause(int active)
    {
        if (active == 1)
        {
            allPanels.swipeDetector.swipeOn = false;
            allPanels.up_Panel.SetActive(true);
            allPanels.helperPanel.SetActive(true);
            allPanels.pauseBTN_Panel.SetActive(false);
            allPanels.pausePanel.SetActive(true);
            allPanels.right_Information_Panel.SetActive(false);
        }
        if (active == 0)
        {
            allPanels.swipeDetector.swipeOn = true;
            Time.timeScale = 1;
            OpenInGame(0);
            allPanels.helperPanel.SetActive(false);
            allPanels.up_Panel.SetActive(false);
            allPanels.pauseBTN_Panel.SetActive(false);
            allPanels.pausePanel.SetActive(false);
            allPanels.right_Information_Panel.SetActive(false);

        }
    }

    public void OpenDisconnectionPanel(int active) 
    {
        if (active == 1)
        {
            allPanels.swipeDetector.swipeOn = false;
            allPanels.master_Disconnection_Panel.SetActive(true);
            LeanTween.move(allPanels.imageDesconnection_Panel.GetComponent<RectTransform>(), new Vector3(0f, 0f, 0f), 0.5f).setIgnoreTimeScale(true);
            allPanels.uI_CentralManager.count_Disconnection = true;
            allPanels.pauseBTN_Panel.SetActive(false);
            Time.timeScale = 0;

        }
        if (active == 0)
        {
            allPanels.swipeDetector.swipeOn = true;
            //swipeDetector.swipeOn = true;
            Time.timeScale = 0;
            allPanels.master_Disconnection_Panel.SetActive(false);
            allPanels.counter_Panel.SetActive(false);
        }

    }

    public void BackMenuFromPause() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
