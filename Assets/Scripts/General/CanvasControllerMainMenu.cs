using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


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
    private GameObject _optionsCanvas;

    [SerializeField]
    private GameObject _exitCanvas;

    [SerializeField]
    private SceneChanger _scenehanger;

    [SerializeField]
    private GameObject _level1Canvas;


    [SerializeField]
    private GameObject _level2Canvas;

    [SerializeField]
    private GameObject _level3Canvas;


    [SerializeField]
    private GameObject _level4Canvas;




    [SerializeField]
    private Slider _masterSlider;

    [SerializeField]
    private Slider _fxSlider;

    [SerializeField]
    private Slider _musicSlider;

    [SerializeField]
    private AudioMixer _master;


    private void Awake() => _scenehanger = new SceneChanger().SetSceneToChangeName("Level1");

    public void Start()
    {
        if(PlayerPrefs.GetFloat("masterVol") != default)
        {
            _masterSlider.value = PlayerPrefs.GetFloat("masterVol");
            _master.SetFloat("Master", Mathf.Log(_masterSlider.value) * 20);
        }
        else
            _masterSlider.value = _masterSlider.maxValue * .5f;

        if (PlayerPrefs.GetFloat("musicVol") != default)
        {
            _musicSlider.value = PlayerPrefs.GetFloat("musicVol");
            _master.SetFloat("Music", Mathf.Log(_musicSlider.value) * 20);
        }
        else
            _musicSlider.value = _masterSlider.maxValue * .5f;


        if (PlayerPrefs.GetFloat("fxVol") != default)
        {
            _fxSlider.value = PlayerPrefs.GetFloat("fxVol");
            _master.SetFloat("Fx", Mathf.Log(_fxSlider.value) * 20);
        }
        else
            _fxSlider.value = _masterSlider.maxValue * .5f;
    }


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


    public void CanvasLevel1()
    {

        _level1Canvas.SetActive(true);
        SoundClick();

    }

    public void CanvasLevel2()
    {

        _level2Canvas.SetActive(true);
        SoundClick();

    }

    public void CanvasLevel3()
    {

        _level3Canvas.SetActive(true);
        SoundClick();

    }
    public void CanvasLevel4()
    {

        _level4Canvas.SetActive(true);
        SoundClick();

    }




    public void OptionsOn()
    {
        SoundClick();
        _optionsCanvas.SetActive(true);
    }

    public void OptionsOff()
    {
        SoundClick();
        _optionsCanvas.SetActive(false);
    }

    public void ExitOn()
    {
        SoundClick();
        _exitCanvas.SetActive(true);
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

    public void changeMasterVolumen(float value)
    {
        float log = 0f;
        log = Mathf.Log(value) * 20;
        _master.SetFloat("Master", log);
        PlayerPrefs.SetFloat("masterVol", value);

    }

    public void changeMusicVolumen(float value)
    {
        float log = 0f;

        log = Mathf.Log(value) * 20;
        _master.SetFloat("Music", log);

        PlayerPrefs.SetFloat("musicVol", value);
    }

    public void changeFxVolumen(float value)
    {
        float log = 0f;

        log = Mathf.Log(value) * 20;
        _master.SetFloat("Fx", log);

        PlayerPrefs.SetFloat("fxVol", value);

       
    }





    private void SoundClick() => AudioManager.instance.AudioPlay(_clip);
}