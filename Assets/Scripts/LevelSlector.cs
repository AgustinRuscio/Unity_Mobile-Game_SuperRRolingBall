using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSlector : MonoBehaviour
{
    private SceneChanger _changer;

    [SerializeField]
    private GameObject _canvas;

    [SerializeField]
    private GameObject _staminaCanvas;

    [SerializeField]
    private string _nextLvl;

    private void Awake()
    {
        _changer = new SceneChanger().SetSceneToChangeName(_nextLvl);
    }

    public void ChangeLevel()
    {
        if(GameData.instance.GetActualStamina() > 0)
        {
            GameData.instance.SubstractStamina();
            _changer.LoadScene();
        }
        else
        {
            _staminaCanvas.SetActive(true);
        }
    }

    public void ResetLevel()
    {
        _changer.LoadScene(SceneManager.GetActiveScene().name);
        _canvas.SetActive(false);
    }
}
