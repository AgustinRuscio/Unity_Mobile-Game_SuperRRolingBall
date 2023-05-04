using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData instance;
    
    private int _coins = 0;

    private int _stamina;

    [SerializeField]
    private GameObject _deleteGamePopUp;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);



        LoadGame();
    }

    public float GetActualStamina()
    {
        return _stamina;
    }

    public void SubstractStamina()
    {
        _stamina--;
        PlayerPrefs.SetInt(ConstantStrings.staminaKey, _stamina);
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
        }
        else
        {
            PlayerPrefs.SetInt(ConstantStrings.coinKey, 0);
            _coins = PlayerPrefs.GetInt(ConstantStrings.coinKey);

            PlayerPrefs.SetInt(ConstantStrings.staminaKey, 5);
            _stamina = PlayerPrefs.GetInt(ConstantStrings.staminaKey);
        }
    }

    public void DeleteDataPopUp()
    {
        _deleteGamePopUp.SetActive(true);
    }

    public void CancelDeleting()
    {
        _deleteGamePopUp.SetActive(false);
    }

    public void DeletegameData()
    {
        PlayerPrefs.SetInt(ConstantStrings.coinKey, 0);
        PlayerPrefs.SetInt(ConstantStrings.staminaKey, 5);
        PlayerPrefs.SetInt(ConstantStrings.firstTimePlaying, 0);

        Debug.Log("Game Deleted");

        _deleteGamePopUp.SetActive(false);

        EventManager.Trigger(EventEnum.UpdateValues);

        LoadGame();
    }
    
    void OnApplicationQuit()
    {
        SaveGame();
    }

    void OnApplicationPause(bool isPaused)
    {
        if (isPaused)
        {
            SaveGame();
        }
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

    public void AddStamina(int add = 5)
    {
        _stamina += add;

        if(_stamina > 6)
            _stamina = 6;

        PlayerPrefs.SetInt(ConstantStrings.staminaKey, _stamina);

        EventManager.Trigger(EventEnum.UpdateValues);

        Debug.Log(_stamina);
    }
    
    #endregion


    private void OnDestroy()
    {
        
    }
}
