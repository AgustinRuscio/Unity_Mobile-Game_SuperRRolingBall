using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    [SerializeField] private int _sumKeys = 1;

    [SerializeField]
    private SoundData _keySound;

    private void OnTriggerEnter(Collider other)
    {
        var ball = other.gameObject.GetComponent<BallStates>();

        if (ball != null)
        {
            AudioManager.instance.AudioPlay(_keySound);
            EventManager.Trigger(EventEnum.AddKey, _sumKeys);

            Destroy(this.gameObject, 0.1f);
        }
    }
}