//--------------------------------------------
//          Agustin Ruscio & Merdeces Riego
//--------------------------------------------


using UnityEngine;
using UnityEngine.SceneManagement;

public class Star : MonoBehaviour
{
    [SerializeField]
    private GameObject _winCanvas;

    [SerializeField]
    private AudioSource _starClip;

    private void OnTriggerEnter(Collider other)
    {
        var ball = other.gameObject.GetComponent<BallMovement>();
        
        if (ball != null)
        {
            CheckTutorial();
            _starClip.Play();

            _winCanvas.SetActive(true);
            UnlockNewlevel();
            Destroy(gameObject, 0.5f);
        }
    }

    private void CheckTutorial()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
            PlayerPrefs.SetInt(ConstantStrings.firstTimePlaying, 1);
    }

    void UnlockNewlevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }
}