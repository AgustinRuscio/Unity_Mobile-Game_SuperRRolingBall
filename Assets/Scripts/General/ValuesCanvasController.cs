//--------------------------------------------
//          Agustin Ruscio & Merdeces Riego
//--------------------------------------------


using UnityEngine;
using TMPro;

public class ValuesCanvasController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _coinsNumber;

    [SerializeField]
    private TMP_Text _staminaNumber;

    private void Awake() => EventManager.Subscribe(EventEnum.UpdateValues, UpdateValues);
    
    private void Start() => _coinsNumber.text = PlayerPrefs.GetInt(ConstantStrings.coinKey).ToString();
    
    private void UpdateValues(params object[] parameters)
    {
         _staminaNumber.text = PlayerPrefs.GetInt(ConstantStrings.staminaKey).ToString();
        _coinsNumber.text = PlayerPrefs.GetInt(ConstantStrings.coinKey).ToString();
    }

    private void OnDestroy() => EventManager.Unsubscribe(EventEnum.UpdateValues, UpdateValues);
}