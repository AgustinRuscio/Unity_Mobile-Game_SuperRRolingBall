using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Coin : MonoBehaviour
{
    public int sum = 1;

    [SerializeField]
    private AudioSource _coinSound;

    private void OnTriggerEnter(Collider other)
    {
        var ball = other.gameObject.GetComponent<BallMovement>();
        
        if (ball != null)
        {
            EventManager.Trigger(EventEnum.AddCoin, sum);
            _coinSound.Play();
            
            Destroy(gameObject, 0.3f);
        }
    }
}