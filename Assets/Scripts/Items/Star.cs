using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Star : MonoBehaviour
{
    [SerializeField]
    private GameObject _winCanvas;

    private void OnTriggerEnter(Collider other)
    {
        var ball = other.gameObject.GetComponent<BallMovement>();

        if (ball != null)
        {
            CheckTutorial();
            _winCanvas.SetActive(true);
        }

    }

    private void CheckTutorial()
    {
        if (SceneManager.GetActiveScene().name == "Tutorial")
            PlayerPrefs.SetInt(ConstantStrings.firstTimePlaying, 1);
    }
}
