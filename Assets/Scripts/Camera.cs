using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    

    [SerializeField]
    Transform _cameraobj;

    public Transform player;

    [SerializeField]
    private Vector3 maxDistance;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        _cameraobj.transform.position = player.localToWorldMatrix.GetPosition() + maxDistance;


      

    }

    






}
