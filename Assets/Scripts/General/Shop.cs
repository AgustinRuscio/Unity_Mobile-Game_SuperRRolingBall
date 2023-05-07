using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks.Sources;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private int _shopIndex;

    [SerializeField]
    private int _skinCost;

    [SerializeField]
    private GameObject _shopCanvas;

    [SerializeField]
    private SoundData _soundButton;

    [SerializeField]
    private SoundData _soundNah;

    private void Awake() => EventManager.Subscribe(EventEnum.UpdateValues, UpdateValues);

    private void OnEnable() => UpdateValues();

    private void UpdateValues(params object[] parameters)
    {
        if (GameData.instance.skins[_shopIndex] == 1)
            _shopCanvas.SetActive(false);
        else
            _shopCanvas.SetActive(true);
    }

    public void ChangeActualSkin()
    {
        if (GameData.instance.skins[_shopIndex] == 0)
        {
            if (GameData.instance.GetActualCoins() >= _skinCost)
            {
                GameData.instance.SubstractCoins(_skinCost);
                GameData.instance.ObteinSkin(_shopIndex);
                GameData.instance.skins[_shopIndex] = 1;

                if (GameData.instance.skins[_shopIndex] == 1)
                    _shopCanvas.SetActive(false);

                EventManager.Trigger(EventEnum.UpdateValues);
                AudioManager.instance.AudioPlay(_soundButton);
            }
            else
                AudioManager.instance.AudioPlay(_soundNah);
        }
        else
        {
            AudioManager.instance.AudioPlay(_soundButton);
            GameData.instance.SetSkin(_shopIndex);
        }
    }

    private void OnDestroy() => EventManager.Unsubscribe(EventEnum.UpdateValues, UpdateValues);
}
