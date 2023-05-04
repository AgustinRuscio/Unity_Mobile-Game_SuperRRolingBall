using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    [SerializeField] private int _sumKeys = 1;
    
    private void OnTriggerEnter(Collider other)
    {
        var ball = other.gameObject.GetComponent<BallStates>();

        if (ball != null)
        {
            EventManager.Trigger(EventEnum.AddKey, _sumKeys);
            Destroy(gameObject);
            //Poner sonido
        }
    }
}
