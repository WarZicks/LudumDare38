using System;
using System.Collections.Generic;
using UnityEngine;

public enum EndWayStep
{
    Zero,
    First,
    Second,
    Third
}

public class EndWayManager : MonoBehaviour
{
    [SerializeField] private int firstStepIndex;
    [SerializeField] private int secondStepIndex;
    [SerializeField] private int thirdStepIndex;
    private List<EndWayCollision> _endWayList = new List<EndWayCollision>();

    private void Awake()
    {
        foreach (EndWayCollision endway in GameObject.FindObjectsOfType<EndWayCollision>())
            _endWayList.Add(endway);
    }

    private void Start()
    {
        GameManager.instance.onUpdateEndWay += () => CheckUpdateStep();
    }

    private void CheckUpdateStep()
    {
        // FIRST STEP END WAY
        if(GameManager.instance._endWayActivated >= firstStepIndex)
        {
            foreach(EndWayCollision endWay in _endWayList)
            {
                if (endWay._step == EndWayStep.First)
                    endWay.gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (EndWayCollision endWay in _endWayList)
            {
                if (endWay._step == EndWayStep.First)
                    endWay.gameObject.SetActive(false);
            }
        }

        // SECOND STEP END WAY
        if (GameManager.instance._endWayActivated >= secondStepIndex)
        {
            foreach (EndWayCollision endWay in _endWayList)
            {
                if (endWay._step == EndWayStep.Second)
                    endWay.gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (EndWayCollision endWay in _endWayList)
            {
                if (endWay._step == EndWayStep.Second)
                    endWay.gameObject.SetActive(false);
            }
        }

        // THIRD STEP END WAY
        if (GameManager.instance._endWayActivated >= thirdStepIndex)
        {
            foreach (EndWayCollision endWay in _endWayList)
            {
                if (endWay._step == EndWayStep.Third)
                    endWay.gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (EndWayCollision endWay in _endWayList)
            {
                if (endWay._step == EndWayStep.Third)
                    endWay.gameObject.SetActive(false);
            }
        }
    }
}
