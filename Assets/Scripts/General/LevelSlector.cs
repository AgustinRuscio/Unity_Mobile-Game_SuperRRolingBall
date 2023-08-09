//--------------------------------------------
//          Agustin Ruscio & Merdeces Riego
//--------------------------------------------


using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSlector : MonoBehaviour
{
    private SceneChanger _changer;

    [SerializeField]
    private GameObject _canvas;

    [SerializeField]
    private GameObject _staminaCanvas;

    [SerializeField]
    private GameObject _confirmationLvlCanvas;

    [SerializeField]
    private string _nextLvl;

    [SerializeField]
    private Button _myButton;

    [SerializeField]
    private SoundData _soundButtonEnterLvl;

    [SerializeField]
    private SoundData _soundButtonDeny;

    [SerializeField]
    private GameObject _c;


    private void Awake() => _changer = new SceneChanger().SetSceneToChangeName(_nextLvl);

    public void ResetLevel()
    {
        _changer.LoadScene(SceneManager.GetActiveScene().name);
        _canvas.SetActive(false);
    }

    public void OpenLevel(int levelID)
    {
        if (StaminaSystem.instance.GetActualStamina() > 0)
        {
            AudioManager.instance.AudioPlay(_soundButtonEnterLvl);
            StaminaSystem.instance.UseEnergy();

            string levelName = "Level" + levelID;
            SceneManager.LoadScene(levelName);

            _changer.LoadScene();
        }
    }

    public void SoundForLevelLocked()
    {

        if (_myButton.interactable == false)
            AudioManager.instance.AudioPlay(_soundButtonDeny);
        else
            return;
    }

    public void OpenLevelCanvas()
    {
        if (StaminaSystem.instance.GetActualStamina() > 0)
            _confirmationLvlCanvas.SetActive(true);
        else
            _staminaCanvas.SetActive(true);
    }
}