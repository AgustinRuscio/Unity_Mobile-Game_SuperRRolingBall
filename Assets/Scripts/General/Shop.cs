//--------------------------------------------
//          Agustin Ruscio & Merdeces Riego
//--------------------------------------------


using UnityEngine;
using System;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private SoundData _soundButton;

    [SerializeField]
    private SoundData _soundNah;

    //----
    [SerializeField]
    private int _shopIndex;

    [SerializeField]
    private int _skinCost;

    public GameObject _buyBTN;
    public GameObject _equipBTN;


    [SerializeField]
    private BuyButton comprarScript;


    [SerializeField]
    private GameObject comprarPanel;

    [SerializeField]
    private GameObject noteAlzanaPanel;


    private event Action updateButtons;


    private void Start()
    {
        ChackStatus();
        updateButtons += ChackStatus;
    }

    public void ChackStatus()
    {
        if (GameData.instance.skins[_shopIndex] == 0)
        {
            _buyBTN.SetActive(true);
            _equipBTN.SetActive(false);
        }
        else
        {
            _buyBTN.SetActive(false);
            _equipBTN.SetActive(true);
        }
    }

    public void buy()
    {
        if (GameData.instance.GetActualCoins() >= _skinCost)
        {
            comprarScript.SetBuyData(_shopIndex, _skinCost, updateButtons);
            comprarPanel.SetActive(true);
        }
        else
            noteAlzanaPanel.SetActive(true);
    }
}