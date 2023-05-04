using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRequirements : MonoBehaviour
{
    [SerializeField]
    private GameObject _popUp;

    private void Awake()
    {
        /*if (!RequisitsTest())
        {
            _popUp.SetActive(true);
            Debug.Log("Don't have the requirements");
            QuitGame();
        }*/
    }

    private bool RequisitsTest()
    {
        return SystemInfo.supportsAccelerometer;
    }

    IEnumerator QuitGame()
    {
        yield return new WaitForSeconds(5);
        Application.Quit();
    }
}
