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
    public static EndWayManager instance;

    [Header("Steps Index")]
    [SerializeField] private int firstStepIndex;
    [SerializeField] private int secondStepIndex;
    [SerializeField] private int thirdStepIndex;

    [Header("Audio Clips")]
    public AudioClip _endWayActivatedClip;
    public AudioClip _showNewWayClip;

    private List<EndWayCollision> _endWayList = new List<EndWayCollision>();
    [HideInInspector] public AudioSource _audioSource;

    private void Awake()
    {
        instance = this;

        _audioSource = GetComponent<AudioSource>();
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
                if (endWay.step == EndWayStep.First)
                    endWay.Active(true);
            }
        }
        else
        {
            foreach (EndWayCollision endWay in _endWayList)
            {
                if (endWay.step == EndWayStep.First)
                    endWay.Active(false);
            }
        }

        // SECOND STEP END WAY
        if (GameManager.instance._endWayActivated >= secondStepIndex)
        {
            foreach (EndWayCollision endWay in _endWayList)
            {
                if (endWay.step == EndWayStep.Second)
                    endWay.Active(true);
            }
        }
        else
        {
            foreach (EndWayCollision endWay in _endWayList)
            {
                if (endWay.step == EndWayStep.Second)
                    endWay.Active(false);
            }
        }

        // THIRD STEP END WAY
        if (GameManager.instance._endWayActivated >= thirdStepIndex)
        {
            foreach (EndWayCollision endWay in _endWayList)
            {
                if (endWay.step == EndWayStep.Third)
                    endWay.Active(true);
            }
        }
        else
        {
            foreach (EndWayCollision endWay in _endWayList)
            {
                if (endWay.step == EndWayStep.Third)
                    endWay.Active(false);
            }
        }
    }
}
