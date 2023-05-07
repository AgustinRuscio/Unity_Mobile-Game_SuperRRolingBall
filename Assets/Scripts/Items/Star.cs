using System.Collections;
using System.Collections.Generic;
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
            //StartCoroutine(WaitForEndOfSound());

            _winCanvas.SetActive(true);
        }
    }

    private void CheckTutorial()
    {
        if (SceneManager.GetActiveScene().name == "Tutorial")
            PlayerPrefs.SetInt(ConstantStrings.firstTimePlaying, 1);
    }


    IEnumerator WaitForEndOfSound()
    {
        yield return new WaitForSeconds(2f); ;
    }
}
