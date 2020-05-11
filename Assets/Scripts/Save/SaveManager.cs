using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { set; get; }
    public SaveState state;
    // Start is called before the first frame update

    private void Awake()
    {
        Instance = this;
        
        //ResetSave();
        Load();

        //Debug.Log(Helper.Decrypt())

        Debug.Log(state.coinsAmount);
    }
    //save the whole state in SaveState script to playerPrefs
    public void Save() 
    {
        PlayerPrefs.SetString("save",Helper.Encrypt(Helper.Serialize<SaveState>(state)));
    
    }
    //Load the previous saved state in SaveState script to playerPrefs
    public void Load() 
    {
        if (PlayerPrefs.HasKey("save"))
        {
            Debug.Log(PlayerPrefs.GetString("save"));
            state = Helper.Deserialize<SaveState>(Helper.Decrypt(PlayerPrefs.GetString("save")));
        }
        else
        {
            state = new SaveState();
            Save();
            Debug.Log("No save file found");
        }
    
    }
    //check if color is owned
    public bool IsColorOwned(int index) 
    {

        return (state.colorOwned & (1 << index)) != 0;
    }
    //unlock a color in the "colorOwned"
    public void UnlockColor(int index) 
    {

        state.colorOwned |= 1 << index;
    
    }
    //Reset The whole save file
    public void ResetSave() 
    {
        PlayerPrefs.DeleteKey("save");
    }
    //AddCoins
    public void AddCoins(int Amount) 
    {
        state.coinsAmount += Amount;
        Save();
    }
    //AddBatteries
    public void AddBatteries(int Amount)
    {
        state.batteriesAmount += Amount;
        Save();
    }
    //AddMaxScore
    public void AddMaxScore(int Amount)
    {
        state.maxScore = Amount;
        Save();
    }
    //Buy Recharge
    public void BuyRecharge(int Amount)
    {
        if (state.batteriesAmount > 0 && state.batteriesAmount - Amount >= 0 )
        {
            state.batteriesAmount -= Amount;
            Save();
            
        }
       
    }
}
