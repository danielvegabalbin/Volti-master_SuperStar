using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using AllPlayerData;


public class ScoreManager : MonoBehaviour
{
    [SerializeField] AllPanels allPanels;
    [SerializeField] PlayerCO1 playerCO1;
    [SerializeField] SaveManager saveManager;
    [SerializeField] TextMeshProUGUI coins_TXT;


    [SerializeField] public float actualScore = 0.0f;
    [SerializeField] public float maxScore = 0.0f;

    //[SerializeField] int batteriesInAccount;
    //[SerializeField] public int coins;

    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 8;
    private int scoreToNextLevel = 10;

    [SerializeField] TextMeshProUGUI actualScore_TXT;
    TextMeshProUGUI maxScore_TXT;



    

    void Start()
    {
        actualScore = 0;

        
    }

    
    void Update()
    {
        

        ShowCoins();
        ShowBatteries();
        ShowMaxScore();
      
        
        actualScore = 2* playerCO1.transform.position.z;
        ScoreTextManager(actualScore);
       

        if (actualScore >= scoreToNextLevel)
        {
            LevelUp();
        }

        

    }
    public void ScoreTextManager(float value) 
    {
        value = actualScore;
        allPanels.CurrentScore_TMPRO.text = (((int)value).ToString("#"));
        if (value > saveManager.state.maxScore)
        {
            saveManager.AddMaxScore((int)value);
        }
        
       
    
    }
    //Show the amount of coins player have
    public void ShowCoins() 
    {
        allPanels.coins_TMP.text = saveManager.state.coinsAmount.ToString();
    
    }
    //Show the amount of batteries player have
    public void ShowBatteries() 
    {
        allPanels.batteries_TMP.text = saveManager.state.batteriesAmount.ToString();
        allPanels.Batteries2_TMPRO.text = saveManager.state.batteriesAmount.ToString();
    }
    //Show the maxRecord of player
    public void ShowMaxScore() 
    {
        allPanels.maxRecord_TMP.text = ((int)saveManager.state.maxScore).ToString();
    
    }
    //Level UP the game difficulty
    private void LevelUp()
    {
        if (difficultyLevel == maxDifficultyLevel)
        {
            return;
        }

        scoreToNextLevel *= 2;
        difficultyLevel++;

        playerCO1.SetSpeed(difficultyLevel *1.4f);

    }

    
}

