using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialTexts : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _messageTutorialTxt;

    [SerializeField]
    private GameObject _tutorialUI;

    [SerializeField]
    private string _messageModify = "x";

    [SerializeField]
    private BallMovement _ballMovement;

    private void OnTriggerEnter(Collider other)
    {
        _tutorialUI.SetActive(true);
        _messageTutorialTxt.text = (_messageModify);
        _ballMovement.canJump = false;
        _ballMovement.canMove = false;
        Time.timeScale = 0f;
    }


    public void Continue()
    {
        _tutorialUI.SetActive(false);
        Time.timeScale = 1f;
        _ballMovement.canMove = true;
        _ballMovement.canJump = true;
    }
}