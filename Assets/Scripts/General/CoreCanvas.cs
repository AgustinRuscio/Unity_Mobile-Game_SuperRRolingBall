//--------------------------------------------
//          Agustin Ruscio & Merdeces Riego
//--------------------------------------------


using TMPro;
using UnityEngine;

public class CoreCanvas : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _coinsNumber;

    private void Start() => UpdateCanvas();

    public void UpdateCanvas(int update = 0) => _coinsNumber.text = update.ToString(); 

}