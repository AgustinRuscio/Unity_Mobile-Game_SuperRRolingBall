using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PausedMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _pauseCanvas;

    [SerializeField]
    private SoundData _pauseClip;

    private string menu = "MainMenue";

    private SceneChanger _changer ;

    private BallMovement _ballMovement;

    private void Awake() => _changer = new SceneChanger().SetSceneToChangeName(menu);

    private void Start()
    {
        _ballMovement = FindObjectOfType<BallMovement>();
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        _ballMovement.canMove = true;

        AudioManager.instance.AudioPlay(_pauseClip);
        GameManager.instance.SetGamePaused(false);

        _pauseCanvas.SetActive(false);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        _ballMovement.canMove = false;

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
}