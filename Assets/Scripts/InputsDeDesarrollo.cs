//--------------------------------------------
//          Agustin Ruscio & Merdeces Riego
//--------------------------------------------


using UnityEngine;

public class InputsDeDesarrollo : MonoBehaviour
{
    public KeyCode DeleteKey;

    public GameData _data;
    
    void Update()
    {
        if(Input.GetKeyDown(DeleteKey))
            _data.DeletegameData();
    }
}