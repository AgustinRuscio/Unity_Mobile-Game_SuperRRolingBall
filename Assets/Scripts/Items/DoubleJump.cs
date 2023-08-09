//--------------------------------------------
//          Agustin Ruscio & Merdeces Riego
//--------------------------------------------


using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    [SerializeField]
    private SoundData sound;

    private int  numero =  0;

    [SerializeField]
    GameObject targetToMove;

    [SerializeField]
    float speedDJump;

    bool movetoDJump = false;

    private void Start() => targetToMove = FindObjectOfType<BallMovement>().gameObject;
    

    private void Update()
    {
        if (movetoDJump)
            transform.position = Vector3.Lerp(transform.position, targetToMove.transform.position, speedDJump * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        var ball = other.gameObject.GetComponent<BallStates>();

        if (ball != null)
        {
            if (numero == 0)
            {
                numero++;   
                EventManager.Trigger(EventEnum.EnableDoubleJump);
                AudioManager.instance.AudioPlay(sound);
                movetoDJump = true;
                Destroy(gameObject, 0.25f);
            }
          
        }
    }
}