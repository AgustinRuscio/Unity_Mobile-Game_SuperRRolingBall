//--------------------------------------------
//          Agustin Ruscio & Merdeces Riego
//--------------------------------------------


using System.Collections;
using UnityEngine;

public class CheckRequirements : MonoBehaviour
{
    [SerializeField]
    private GameObject _popUp;

    private void Awake() => Screen.sleepTimeout = SleepTimeout.NeverSleep;
    
    private bool RequisitsTest() => SystemInfo.supportsAccelerometer;

    IEnumerator QuitGame()
    {
        yield return new WaitForSeconds(5);
        Application.Quit();
    }
}