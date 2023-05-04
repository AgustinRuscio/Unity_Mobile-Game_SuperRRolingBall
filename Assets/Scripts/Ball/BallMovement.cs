using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Rigidbody _sphereRb;

    [SerializeField]
    private float _speed = 1;

    [SerializeField]
    private float _jumpForce ;

    private int _jumping = 0;
    
    private bool _doubleJumping = false;

    private GenericTimer _timer;
    
    private float _coolDown = 1.5f;
    
    private void Awake()
    {
        EventManager.Subscribe(EventEnum.EnableDoubleJump, EnableDoubleJump);
        _sphereRb = GetComponent<Rigidbody>();

        _timer = new GenericTimer(_coolDown);
    }

    void Update()
    {
        Vector3 accelerationFixed =  Input.acceleration ;

        accelerationFixed = Quaternion.Euler(90, 0, 0) * accelerationFixed;
        accelerationFixed *= _speed;
        
        accelerationFixed.y = 0;
        
        _sphereRb.AddForce(accelerationFixed);

        _timer.RunTimer();
        
        if (Input.touchCount > 0 && _jumping <= 0 && _timer.CheckCoolDown())
        {
            Jump();
            _timer.ResetTimer();
            CheckJumping();
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
    
    private void Jump()
    {
        _jumping++;
        _sphereRb.AddForce(0,1 * _jumpForce,0, ForceMode.Impulse);
    }
    
}
