using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PausedMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _pauseCanvas;

    
    private string menu = "MainMenue";

    private SceneChanger _changer ;

    private void Awake()
    {
        _changer = new SceneChanger().SetSceneToChangeName(menu);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        GameManager.instance.SetGamePaused(false);
        _pauseCanvas.SetActive(false);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        GameManager.instance.SetGamePaused(true);
        _pauseCanvas.SetActive(true);
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        GameManager.instance.SetGamePaused(false);
        _pauseCanvas.SetActive(false);

        _changer.LoadScene();
    }

}
