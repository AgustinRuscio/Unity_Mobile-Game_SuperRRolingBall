using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    [SerializeField]
    private SoundData sound;

    private void OnTriggerEnter(Collider other)
    {
        var ball = other.gameObject.GetComponent<BallStates>();

        if (ball != null)
        {
            EventManager.Trigger(EventEnum.EnableDoubleJump);
            AudioManager.instance.AudioPlay(sound);
            Destroy(gameObject);
        }
    }
}
