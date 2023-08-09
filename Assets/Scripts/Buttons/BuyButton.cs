using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BuyButton : MonoBehaviour
{

    int index;
    int cost;

    [SerializeField]
    private SoundData _soundButton;

    private event Action _onClick;

    public void SetBuyData(int index, int cost, Action f)
    {
        this.index = index;
        this.cost = cost;
        _onClick = f;
    }

    public void confirmbuy()
    {

        GameData.instance.SubstractCoins(cost);
        GameData.instance.ObteinSkin(index);
        GameData.instance.skins[index] = 1;

       
          

        EventManager.Trigger(EventEnum.UpdateValues);
        AudioManager.instance.AudioPlay(_soundButton);

        _onClick();

    }
}
