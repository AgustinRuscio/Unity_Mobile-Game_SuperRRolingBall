using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasControllerMainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _creditsCanvas;
    
    [SerializeField]
    private GameObject _levelsSelectorCanvas;

    [SerializeField]
    private GameObject _shopCanvas;

    [SerializeField]
    private SceneChanger _scenehanger;

    private void Awake()
    {
        _scenehanger = new SceneChanger().SetSceneToChangeName("Tutorial");
    }

    public void LvlSelectorOn()
    {
        if(PlayerPrefs.GetInt(ConstantStrings.firstTimePlaying) == 0)
        {
            _scenehanger.LoadScene();
        }
        else
        {
            _levelsSelectorCanvas.SetActive(true);
        }
    }
    
    public void LvlSelectorOff()
    {
        _levelsSelectorCanvas.SetActive(false);
    }
   
    public void CreditsOn()
    {
        _creditsCanvas.SetActive(true);
    }

    public void CreditsOff()
    {
        _creditsCanvas.SetActive(false);
    }
    
    public void ShopOn()
    {
        _shopCanvas.SetActive(true);
    }

    public void ShopOff()
    {
        _shopCanvas.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
    
    private void SoundClick()
    {
        
    }
    

}
