using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

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

    private float _coolDown = 1.5f;
    
    private int _jumping = 0;

    private bool _doubleJumping = false;

    public bool canJump = true;
    public bool canMove = true;
    
    private void Awake()
    {
        EventManager.Subscribe(EventEnum.EnableDoubleJump, EnableDoubleJump);
        _sphereRb = GetComponent<Rigidbody>();

        _timer = new GenericTimer(_coolDown);

        canJump = true;
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
        if (_jumping <= 0 && _timer.CheckCoolDown() && canJump)
        {
            _jumping++;
            _sphereRb.AddForce(0,1 * _jumpForce,0, ForceMode.Impulse);

            AudioManager.instance.AudioPlay(_jumpSound);

            _timer.ResetTimer();
            CheckJumping();
        }
    }

    public void Stop()
    {
        _sphereRb.velocity = Vector3.zero;
        _sphereRb.angularVelocity = Vector3.zero;
    }
}