using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int sum = 1;


    private void OnTriggerEnter(Collider other)
    {
        var ball = other.gameObject.GetComponent<BallMovement>();
    
        if (ball != null)
        {
            EventManager.Trigger(EventEnum.AddCoin, sum);
            Destroy(gameObject);
        }
    }
}
