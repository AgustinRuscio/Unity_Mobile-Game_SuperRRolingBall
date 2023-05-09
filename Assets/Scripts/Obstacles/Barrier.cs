using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField] private int _keysRequiere;

    private int _currentKeys = 0;

    [SerializeField]
    private Animator _myAnim;

    [SerializeField]
    private Collider _myCollider;

    [SerializeField]
    private SoundData _barrierAudioOpen;

    [SerializeField]
    private SoundData _barrierAudioClose;


    private void Awake() => EventManager.Subscribe(EventEnum.AddKey, UpdateKeys);

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<BallMovement>())
            CheckKeys();
    }

    private void CheckKeys()
    {
        if (_currentKeys >= _keysRequiere)
        {
            _myAnim.SetBool("Barrierup", true);
            AudioManager.instance.AudioPlayWithPos(_barrierAudioOpen, this.transform.position);

            _myCollider.enabled = false;
        }
        else if (_currentKeys < _keysRequiere)
            AudioManager.instance.AudioPlayWithPos(_barrierAudioClose, this.transform.position);
    }

    private void UpdateKeys(params  object[] parameters)
    {
        _currentKeys += (int)parameters[0];
    }

    private void OnDestroy() => EventManager.Unsubscribe(EventEnum.AddKey, UpdateKeys);
}