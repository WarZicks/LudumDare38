using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campfire : MonoBehaviour
{
    [SerializeField] private EndWayCollision _linkedEndWay;

    private void Start()
    {
        _linkedEndWay.onTriggerEndWay += () => CheckMyEndWay();
    }

    private void CheckMyEndWay()
    {
        if (_linkedEndWay.activated)
            LightOn();  
        else
            LightOff();
    }

    private void LightOn()
    {
        Debug.Log("Light on");
    }

    private void LightOff()
    {
        Debug.Log("Light off");
    }
}
