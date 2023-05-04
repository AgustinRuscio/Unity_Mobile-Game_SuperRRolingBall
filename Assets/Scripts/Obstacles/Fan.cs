using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    [SerializeField]
    private Vector3 _airDir;

    [SerializeField]
    private float _strength;

   
    private void OnTriggerStay(Collider other)
    {
        var iFanable = other.gameObject.GetComponent<IFaneable>();

        if(iFanable != null)
            iFanable.OnFan(_airDir, _strength);  
    }    
}