using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var ball = other.gameObject.GetComponent<BallStates>();

        if (ball != null)
        {
            EventManager.Trigger(EventEnum.EnableDoubleJump);
            Destroy(gameObject);
        }
    }
}
