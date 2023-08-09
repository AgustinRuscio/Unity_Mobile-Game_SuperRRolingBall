using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    [SerializeField] private int _sumKeys = 1;

    [SerializeField]
    private SoundData _keySound;

    private int numero = 0;

    [SerializeField]
    GameObject targetToMove;


    [SerializeField]
    float speedKeys;

    bool moveToKey = false;


    private void Start()
    {
        targetToMove = FindObjectOfType<BallMovement>().gameObject;
    }


    private void Update()
    {
        if (moveToKey)
        {
            transform.position = Vector3.Lerp(transform.position, targetToMove.transform.position, speedKeys * Time.deltaTime);

        }
    }



    private void OnTriggerEnter(Collider other)
    {
        var ball = other.gameObject.GetComponent<BallStates>();

        if (ball != null)
        {
            if (numero == 0)
            {
                numero++;
                AudioManager.instance.AudioPlay(_keySound);
                EventManager.Trigger(EventEnum.AddKey, _sumKeys);
                moveToKey = true;

                Destroy(this.gameObject, 0.25f);

            }
        }
    }
}