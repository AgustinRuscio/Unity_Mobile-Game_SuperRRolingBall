using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lock : MonoBehaviour
{
    [SerializeField] private int _keysRequiere;

    private int _currentKeys = 0;

    [SerializeField]
    private Animator _myAnim;

    [SerializeField]
    private Collider _colliderBig;

    [SerializeField]
    private SoundData _barrierAudioOpen;

    [SerializeField]
    private SoundData _barrierAudioClose;


    private void Awake() => EventManager.Subscribe(EventEnum.AddKey, UpdateKeys);
    
    private void OnTriggerEnter(Collider other)
    {
        if (_currentKeys >= _keysRequiere )
        {            
            _myAnim.SetBool("Barrierup", true);
            AudioManager.instance.AudioPlayWithPos(_barrierAudioOpen, this.transform.position);          
        }
        else if (_currentKeys < _keysRequiere)
        {
            AudioManager.instance.AudioPlayWithPos(_barrierAudioClose, this.transform.position);
            _colliderBig.isTrigger = false;
        }
    }

    private void UpdateKeys(params  object[] parameters)
    {
        _currentKeys += (int)parameters[0];

        /*if (_currentKeys >= _keysRequiere)
        {
            _myAnim.SetBool("Barrierup", true);
           
            AudioManager.instance.AudioPlayWithPos(_barrierAudio, this.transform.position);
            _colliderBig.enabled = true;

            //Hacer sonido
            //Destroy(gameObject);
        }*/
    }

    private void OnDestroy() => EventManager.Unsubscribe(EventEnum.AddKey, UpdateKeys);
}
