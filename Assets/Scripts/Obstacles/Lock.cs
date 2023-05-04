using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lock : MonoBehaviour
{
    [SerializeField] private int _keysRequiere;

    private int _currentKeys = 0;

    private void Awake()
    {
        EventManager.Subscribe(EventEnum.AddKey, UpdateKeys);
    }

    private void UpdateKeys(params  object[] parameters)
    {
        _currentKeys += (int)parameters[0];

        if (_currentKeys >= _keysRequiere)
        {
            //Hacer sonido
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        EventManager.Unsubscribe(EventEnum.AddKey, UpdateKeys);
    }
}
