using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveThroughWaypoints : MonoBehaviour
{
    [SerializeField]
    private Transform[] _waypoints;

    private int _index;

    [SerializeField]
    private float _movementSpeed;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Vector3.Distance(transform.position, _waypoints[_index].position) < 0.1f)
        {
            _index++;

            if (_index >= _waypoints.Length)
                _index = 0;
        }

        transform.position += (_waypoints[_index].position - transform.position) * Time.deltaTime * _movementSpeed;
    }
}