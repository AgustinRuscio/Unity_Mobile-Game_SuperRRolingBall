using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ValuesCanvasController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _coinsNumber;

    [SerializeField]
    private TMP_Text _staminaNumber;

  

    private void Awake() => EventManager.Subscribe(EventEnum.UpdateValues, UpdateValues);
    

    private void Start()
    {
        //Stamina and coins
       // _staminaNumber.text = PlayerPrefs.GetInt(ConstantStrings.staminaKey).ToString();   //SAQUE ESTO PORQUE EN EZ DE PONERLO 6/6 LO PONIA 6 Y SE BUGGEABA. LO SETTEA STAMINASYSTEM
        _coinsNumber.text = PlayerPrefs.GetInt(ConstantStrings.coinKey).ToString();
    }

    private void UpdateValues(params object[] parameters)
    {
         _staminaNumber.text = PlayerPrefs.GetInt(ConstantStrings.staminaKey).ToString(); //SAQUE ESTO PORQUE EN EZ DE PONERLO 6/6 LO PONIA 6 Y SE BUGGEABA. LO UPDATEA STAMINASYSTEM
        _coinsNumber.text = PlayerPrefs.GetInt(ConstantStrings.coinKey).ToString();

    }


    private void OnDestroy() => EventManager.Unsubscribe(EventEnum.UpdateValues, UpdateValues);
}