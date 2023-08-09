using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipButton : MonoBehaviour
{

    [SerializeField]
    private SoundData _soundButton;

    [SerializeField]
    private int _shopIndex;


    public void Equip() 
    {
        if (GameData.instance.skins[_shopIndex] == 1)
        {

            AudioManager.instance.AudioPlay(_soundButton);
            GameData.instance.SetSkin(_shopIndex);


        }

    }



}
