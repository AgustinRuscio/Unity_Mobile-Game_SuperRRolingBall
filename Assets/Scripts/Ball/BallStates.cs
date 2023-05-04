using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class BallStates : MonoBehaviour, IFaneable
{
    private Rigidbody _ballRigidBody;
    private SphereCollider _ballCollider;

    [SerializeField]
    private Image _doubleJumpImage;
    
    private void Awake()
    {
        _ballRigidBody = GetComponent<Rigidbody>();
        _ballCollider = GetComponent<SphereCollider>();
     
        _ballCollider.isTrigger = false;
        
        EventManager.Subscribe(EventEnum.EnableDoubleJump, TurnOnDoubleJump);
        EventManager.Subscribe(EventEnum.DisableDoubleJump, TurnOffJump);
        
    }


    public bool DeathCondition()
    {
        return (transform.position.y < -5f);
    }
    
    public void OnFan(Vector3 _airDir, float _strength) => _ballRigidBody.AddForce(_airDir * _strength);
    

    public void MakeTrigger() => _ballCollider.isTrigger = true;

    private void TurnOnDoubleJump(params object[] parameters)
    {
        _doubleJumpImage.color = Color.white;
    }
    
    private void TurnOffJump(params object[] parameters)
    {
        _doubleJumpImage.color = Color.grey;
    }

    private void OnDestroy()
    {
        EventManager.Unsubscribe(EventEnum.EnableDoubleJump, TurnOnDoubleJump);
        EventManager.Unsubscribe(EventEnum.DisableDoubleJump, TurnOffJump);
    }
}
