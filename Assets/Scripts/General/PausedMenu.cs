using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class PausedMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _optionsCanvas;

    [SerializeField]
    private GameObject _pauseCanvas;

    [SerializeField]
    private SoundData _pauseClip;

    private string menu = "MainMenue";

    private SceneChanger _changer ;

    private BallMovement _ballMovement;

    [SerializeField]
    private Slider _masterSlider;

    [SerializeField]
    private Slider _fxSlider;

    [SerializeField]
    private Slider _musicSlider;

    [SerializeField]
    private AudioMixer _master;

    private void Awake() => _changer = new SceneChanger().SetSceneToChangeName(menu);

    private void Start() => _ballMovement = FindObjectOfType<BallMovement>();
    

    public void Resume()
    {
        Time.timeScale = 1f;
        _ballMovement.canMove = true;

        AudioManager.instance.AudioPlay(_pauseClip);
        GameManager.instance.SetGamePaused(false);

        _pauseCanvas.SetActive(false);
        StartCoroutine(CanJumpAgain());
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        _ballMovement.canMove = false;
        _ballMovement.canJump = false;

        AudioManager.instance.AudioPlay(_pauseClip);
        GameManager.instance.SetGamePaused(true);

        _pauseCanvas.SetActive(true);
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        AudioManager.instance.AudioPlay(_pauseClip);
        GameManager.instance.SetGamePaused(false);
        _pauseCanvas.SetActive(false);

        _changer.LoadScene();
    }

    public void OptionsOn()
    {

        AudioManager.instance.AudioPlay(_pauseClip);
        _pauseCanvas.SetActive(false);
        _optionsCanvas.SetActive(true);

    }

    public void OptionsOff()
    {
        AudioManager.instance.AudioPlay(_pauseClip);
        _optionsCanvas.SetActive(false);
        _pauseCanvas.SetActive(true);
        

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

    IEnumerator CanJumpAgain()
    {
        yield return new WaitForSeconds (0.25f);
        _ballMovement.canJump = true;
    }
}