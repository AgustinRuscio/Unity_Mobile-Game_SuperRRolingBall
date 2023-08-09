//--------------------------------------------
//          Agustin Ruscio & Merdeces Riego
//--------------------------------------------


using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameData : MonoBehaviour
{
    public static GameData instance;

    StaminaSystem _staminasystem;
    
    private int _coins = 0;

    private int _stamina;

    DateTime nextStaminaTime;
    DateTime lastStaminaTime;

    [SerializeField]
    private GameObject _deleteGamePopUp;

    public Dictionary<int, int> skins = new Dictionary<int, int>();

    public int currentSkin;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);


        LoadGame();
    }

    public float GetActualCoins() => _coins;
    
    public void ObteinSkin(int index)
    {
        switch (index)
        {
            case 1:
                PlayerPrefs.SetInt(ConstantStrings.dictotionarySlot1, 1);
                break;

            case 2:
                PlayerPrefs.SetInt(ConstantStrings.dictotionarySlot2, 1);
                break;

            case 3:
                PlayerPrefs.SetInt(ConstantStrings.dictotionarySlot3, 1);
                break;

                case 4:
                PlayerPrefs.SetInt(ConstantStrings.dictotionarySlot4, 1);
                break;

            case 5:
                PlayerPrefs.SetInt(ConstantStrings.dictotionarySlot5, 1);
                break;

            case 6:
                PlayerPrefs.SetInt(ConstantStrings.dictotionarySlot6, 1);
                break;

            case 7:
                PlayerPrefs.SetInt(ConstantStrings.dictotionarySlot7, 1);
                break;
        }            
    }

    public void SubstractCoins(int amount)
    {
        _coins -= amount;

        if(_coins < 0)
            _coins = 0;

        PlayerPrefs.SetInt(ConstantStrings.coinKey, _coins);
    }


    //------------------------------------Save methods
    #region Save

    private void SaveGame()
    {
        PlayerPrefs.SetInt(ConstantStrings.coinKey, _coins);
    }

    private void LoadGame()
    {
        if (PlayerPrefs.GetInt(ConstantStrings.firstTimePlaying) != 0)
        {
            _coins = PlayerPrefs.GetInt(ConstantStrings.coinKey);
            _stamina = PlayerPrefs.GetInt(ConstantStrings.staminaKey);

            nextStaminaTime = StringToDateTime(PlayerPrefs.GetString("nextStaminaTime"));
            lastStaminaTime = StringToDateTime(PlayerPrefs.GetString("lastStaminaTime"));

             //Skins

            currentSkin = PlayerPrefs.GetInt(ConstantStrings.currentSkin);

            skins[0] = PlayerPrefs.GetInt(ConstantStrings.dictotionarySlot0);
            skins[1] = PlayerPrefs.GetInt(ConstantStrings.dictotionarySlot1);
            skins[2] = PlayerPrefs.GetInt(ConstantStrings.dictotionarySlot2);
            skins[3] = PlayerPrefs.GetInt(ConstantStrings.dictotionarySlot3);
            skins[4] = PlayerPrefs.GetInt(ConstantStrings.dictotionarySlot4);
            skins[5] = PlayerPrefs.GetInt(ConstantStrings.dictotionarySlot5);
            skins[6] = PlayerPrefs.GetInt(ConstantStrings.dictotionarySlot6);
            skins[7] = PlayerPrefs.GetInt(ConstantStrings.dictotionarySlot7);

        }
        else
        {
            PlayerPrefs.SetInt(ConstantStrings.coinKey, 0);
            _coins = PlayerPrefs.GetInt(ConstantStrings.coinKey);

            PlayerPrefs.SetInt(ConstantStrings.staminaKey, 6);
            _stamina = PlayerPrefs.GetInt(ConstantStrings.staminaKey);

            PlayerPrefs.SetInt(ConstantStrings.currentSkin, 0);
            currentSkin = PlayerPrefs.GetInt(ConstantStrings.currentSkin);

            //Clean dictionary
            PlayerPrefs.SetInt(ConstantStrings.dictotionarySlot0, 1);
            skins[0] = PlayerPrefs.GetInt(ConstantStrings.dictotionarySlot0);

            PlayerPrefs.SetInt(ConstantStrings.dictotionarySlot1, 0);
            skins[1] = PlayerPrefs.GetInt(ConstantStrings.dictotionarySlot1);

            PlayerPrefs.SetInt(ConstantStrings.dictotionarySlot2, 0);
            skins[2] = PlayerPrefs.GetInt(ConstantStrings.dictotionarySlot2);

            PlayerPrefs.SetInt(ConstantStrings.dictotionarySlot3, 0);
            skins[3] = PlayerPrefs.GetInt(ConstantStrings.dictotionarySlot3);

            PlayerPrefs.SetInt(ConstantStrings.dictotionarySlot4, 0);
            skins[4] = PlayerPrefs.GetInt(ConstantStrings.dictotionarySlot4);

            PlayerPrefs.SetInt(ConstantStrings.dictotionarySlot5, 0);
            skins[5] = PlayerPrefs.GetInt(ConstantStrings.dictotionarySlot5);

            PlayerPrefs.SetInt(ConstantStrings.dictotionarySlot6, 0);
            skins[6] = PlayerPrefs.GetInt(ConstantStrings.dictotionarySlot6);

            PlayerPrefs.SetInt(ConstantStrings.dictotionarySlot7, 0);
            skins[7] = PlayerPrefs.GetInt(ConstantStrings.dictotionarySlot7);
        }
    }

    public void DeleteDataPopUp() => _deleteGamePopUp.SetActive(true);
    

    public void CancelDeleting() => _deleteGamePopUp.SetActive(false);
    

    public void DeletegameData()
    {
        PlayerPrefs.SetInt(ConstantStrings.coinKey, 0);
        PlayerPrefs.SetInt(ConstantStrings.staminaKey, 6);
        PlayerPrefs.SetInt(ConstantStrings.firstTimePlaying, 0);

        //Skins
        PlayerPrefs.SetInt(ConstantStrings.dictotionarySlot1, 0);
        PlayerPrefs.SetInt(ConstantStrings.dictotionarySlot2, 0);
        PlayerPrefs.SetInt(ConstantStrings.dictotionarySlot3, 0);
        PlayerPrefs.SetInt(ConstantStrings.dictotionarySlot4, 0);
        PlayerPrefs.SetInt(ConstantStrings.dictotionarySlot5, 0);
        PlayerPrefs.SetInt(ConstantStrings.dictotionarySlot6, 0);
        PlayerPrefs.SetInt(ConstantStrings.dictotionarySlot7, 0);

        //levelints
        PlayerPrefs.SetInt(ConstantStrings.unlockedLevel, 1);
        PlayerPrefs.SetInt(ConstantStrings.reachedIndex, 1);

        //reseteo de timers
        PlayerPrefs.DeleteKey(ConstantStrings.nextStaminaTime);
        PlayerPrefs.DeleteKey(ConstantStrings.lastStaminaTime);



        Debug.Log("Game Deleted");

        _deleteGamePopUp.SetActive(false);
        LoadGame();
        SceneManager.LoadScene("MainMenue");
    }
    
    void OnApplicationQuit() => SaveGame();
    

    void OnApplicationPause(bool isPaused)
    {
        if (isPaused)
            SaveGame();
        else { }
    }
        
    #endregion

    
    //------------------------------------Modify variables methods
    #region ModifyVariables

    public void AddCoinsToGeneral(int add)
    {
        _coins += add;
        
        PlayerPrefs.SetInt(ConstantStrings.coinKey, _coins);

        Debug.Log(_coins);
    }


    public void AddCoinsInput(int add = 5)
    {
        _coins += add;


        PlayerPrefs.SetInt(ConstantStrings.coinKey, _coins);

        EventManager.Trigger(EventEnum.UpdateValues);

        Debug.Log(_coins);
    }

    public void SetSkin(int skin)
    {
        currentSkin = skin;

        PlayerPrefs.SetInt(ConstantStrings.currentSkin, currentSkin);

        Debug.Log("Ahora la current skin es" + PlayerPrefs.GetInt(ConstantStrings.currentSkin));
    }

    #endregion

    public float GetActualStamina() => _stamina;
    
    DateTime StringToDateTime(string date)
    {
        if (string.IsNullOrEmpty(date))
            return DateTime.UtcNow;
        else
            return DateTime.Parse(date);
    }
}