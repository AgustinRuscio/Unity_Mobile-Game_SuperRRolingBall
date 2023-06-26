using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    Transform _cameraobj;

    public Transform player;

    [SerializeField]
    private Vector3 maxDistance;


    private void Start()
    {
        var p = FindObjectOfType<BallStates>();

        if (p != null)
            player = p.gameObject.transform;

        

    }

    void Update()
    {
        _cameraobj.transform.position = player.localToWorldMatrix.GetPosition() + maxDistance;
    }

}
