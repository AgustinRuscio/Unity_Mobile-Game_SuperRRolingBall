using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BallMovement : MonoBehaviour
{
    private Rigidbody _sphereRb;

    private GenericTimer _timer;

    [SerializeField]
    private SoundData _jumpSound;

    [SerializeField]
    private float _speed = 1;

    [SerializeField]
    private float _jumpForce ;

    private float _coolDown = 0.5f;
    
    private int _jumping = 0;

    private bool _doubleJumping = false;

    public bool canJump = true;
    public bool canMove = true;
   
    [SerializeField]
    private Camera mainCamera;

  

    private void Awake()
    {
        canJump = false;
        mainCamera =  Camera.main;

        EventManager.Subscribe(EventEnum.EnableDoubleJump, EnableDoubleJump);
        _sphereRb = GetComponent<Rigidbody>();
        _timer = new GenericTimer(_coolDown);
        StartCoroutine(CanJumpAgain());

    }

    void Update()
    {
        if (!canMove) return;

        
        Vector3 accelerationFixed =  Input.acceleration ;
        accelerationFixed = Quaternion.Euler(90, 0, 0) * accelerationFixed;
        accelerationFixed *= _speed;
        accelerationFixed.y = 0;
        
        _sphereRb.AddForce(accelerationFixed);
        _timer.RunTimer();

        if (Input.touchCount == 1 || Input.GetMouseButtonDown(0))
        {
            Touch touch = Input.GetTouch(0);
            
            Debug.Log("Entre al primer if y tiro el raycast");
            Debug.Log(touch.position + "touch position");
           
            if (touch.position.x > Screen.width / 2 )
            {
                Debug.Log("Entre Jump");
                Jump();
                _timer.ResetTimer();
                CheckJumping();
            }
            else 
            {

                Stop();
                Debug.Log("Entre Stop");
            }
          
        }
    }

    public void EnableDoubleJump(params object[] parameters)
    {
        _doubleJumping = true;
        _jumping = -1;
    }

    private void CheckJumping()
    {
        if(_jumping > 0)
            EventManager.Trigger(EventEnum.DisableDoubleJump);
    }



     public void Jump()
     {
        
         if (_jumping <= 0 && canJump && _timer.CheckCoolDown() )
         {
            _sphereRb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _jumping++;
            
           // _sphereRb.velocity = Vector3.up * _jumpForce;
            Debug.Log(_jumping);
            AudioManager.instance.AudioPlay(_jumpSound);

             UnityEngine.Debug.Log("salte");

             _timer.ResetTimer();
             CheckJumping();
         }
     }

    public void Stop()
    {
        _sphereRb.velocity = Vector3.zero;
        _sphereRb.angularVelocity = Vector3.zero;
    }
    IEnumerator CanJumpAgain()
    {
        yield return new WaitForSeconds(0.5f);
        canJump = true;
    }


 

}