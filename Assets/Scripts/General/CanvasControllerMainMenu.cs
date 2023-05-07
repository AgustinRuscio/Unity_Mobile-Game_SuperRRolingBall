using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasControllerMainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _creditsCanvas;

    [SerializeField]
    protected SoundData _clip;

    [SerializeField]
    private GameObject _levelsSelectorCanvas;

    [SerializeField]
    private GameObject _shopCanvas;

    [SerializeField]
    private GameObject _notEnoughStaminaCanvas;


    [SerializeField]
    private SceneChanger _scenehanger;

    private void Awake() => _scenehanger = new SceneChanger().SetSceneToChangeName("Tutorial");
    

    public void LvlSelectorOn()
    {
        if(PlayerPrefs.GetInt(ConstantStrings.firstTimePlaying) == 0)
        {
            SoundClick();
            _scenehanger.LoadScene();
        }
        else
        {
            SoundClick();
            _levelsSelectorCanvas.SetActive(true);
        }
    }
    
    public void LvlSelectorOff()
    {
        SoundClick();
        _levelsSelectorCanvas.SetActive(false);
    }
   
    public void CreditsOn()
    {
        SoundClick();
        _creditsCanvas.SetActive(true);
    }

    public void CreditsOff()
    {
        SoundClick();
        _creditsCanvas.SetActive(false);
    }
    
    public void ShopOn()
    {
        SoundClick();
        _shopCanvas.SetActive(true);
    }

    public void ShopOff()
    {
        SoundClick();
        _shopCanvas.SetActive(false);
    }

    public void StaminaOff()
    {
        _notEnoughStaminaCanvas.SetActive(false);
    }

    public void Quit()
    {
        SoundClick();
        Application.Quit();
    }
    
    private void SoundClick() => AudioManager.instance.AudioPlay(_clip);
}