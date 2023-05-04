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


    private void OnTriggerEnter(Collider other)
    {
        _tutorialUI.SetActive(true);
        _messageTutorialTxt.text = (_messageModify);
        Time.timeScale = 0f;
    }


    public void Continue()
    {
        _tutorialUI.SetActive(false);
        Time.timeScale = 1f;
    }

}