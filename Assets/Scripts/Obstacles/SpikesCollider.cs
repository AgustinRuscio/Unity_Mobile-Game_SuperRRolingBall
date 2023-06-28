using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesCollider : MonoBehaviour
{
    private AudioSource _sound;

    private void Awake() => _sound = GetComponent<AudioSource>();
    

    private void OnTriggerEnter(Collider other)
    {
        var ball = other.gameObject.GetComponent<BallStates>();

        if (ball != null)
        {
            ball.SetDeath(true);
            _sound.Play();
            Destroy(gameObject);
        }
    }
}
