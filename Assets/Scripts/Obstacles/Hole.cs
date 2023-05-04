using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var ball = other.GetComponent<BallStates>();
        
        if(ball != null)
            ball.MakeTrigger();
    }
}
