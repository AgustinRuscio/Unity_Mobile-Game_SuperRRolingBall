//--------------------------------------------
//          Agustin Ruscio & Merdeces Riego
//--------------------------------------------


using UnityEngine;
using UnityEngine.UI;

public class ButtonsForLevelSelector : MonoBehaviour
{

    [SerializeField]
    private Button [] _buttons;

    [SerializeField]
    private SoundData _soundButton;

    LevelSlector levelselector;


    private void Awake()
    { 
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel");

        for (int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].interactable = false;
        }

        for (int i = 0; i < unlockedLevel; i++)
        {
            _buttons[i].interactable = true;
        }
    }

    public void SoundForLevelLocked(Button [] _buttons, int i)
    {
        if (_buttons[i].interactable == false)
        {
            AudioManager.instance.AudioPlay(_soundButton);
            Debug.Log(1);
        }
        else if (_buttons[i].interactable == true)
            Debug.Log(2);
    }
}