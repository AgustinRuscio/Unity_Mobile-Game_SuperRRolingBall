using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Coin : MonoBehaviour
{
    public int sum = 1;

    [SerializeField]
    private AudioSource _coinSound;

    [SerializeField]
    float speed;

    bool moveToCoin =  false;

    [SerializeField]
    GameObject targetToMove;



    private void Start()
    {
        targetToMove = FindObjectOfType<BallMovement>().gameObject;
    }

    private void Update()
    {
        if (moveToCoin)
        {
            transform.position = Vector3.Lerp(transform.position, targetToMove.transform.position, speed * Time.deltaTime);
           
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var ball = other.gameObject.GetComponent<BallMovement>();
        
        if (ball != null)
        {
            EventManager.Trigger(EventEnum.AddCoin, sum);
            _coinSound.Play();
            gameObject.GetComponent<BoxCollider>().enabled = false;
            moveToCoin = true;
            
            Destroy(gameObject, 0.25f);
        }
    }

 

}