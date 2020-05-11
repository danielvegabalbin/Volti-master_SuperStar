using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdviceStart : MonoBehaviour
{
    [SerializeField] GameObject advicePanel;
    [SerializeField] Button Advice_BTN;

    // Start is called before the first frame update
    void Start()
    {
        Advice_BTN.onClick.AddListener(DesactivePanelAppear);
        
        if (PlayerPrefs.HasKey("advice") == false)
        {
            PlayerPrefs.SetInt("advice", 0);
        }
        else 
        {
            if (PlayerPrefs.GetInt("advice") == 1) {advicePanel.SetActive(false);}
        }
    }
    private void DesactivePanelAppear()
    {
        PlayerPrefs.SetInt("advice", 1);
        advicePanel.SetActive(false);

    }
}
