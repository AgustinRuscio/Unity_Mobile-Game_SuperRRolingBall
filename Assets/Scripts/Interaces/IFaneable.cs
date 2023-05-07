using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFaneable 
{
    public void OnFan(Vector3 _airDir, float _strength);
}