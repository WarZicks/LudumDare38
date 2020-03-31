﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMovement : MonoBehaviour
{
    [SerializeField] private float _lerpTime = .5f;
    private bool _rotate;
    private bool _canLaunchRotation;
    private FaceManager rotationManager;
    [HideInInspector] public bool canRotatePlanet;

    private void Start()
    {
        rotationManager = GameObject.FindObjectOfType<FaceManager>();
        canRotatePlanet = true;
        _rotate = false;
        _canLaunchRotation = true;
    }
    public void LaunchRotation(Vector3 direction)
    {
        if (!_canLaunchRotation)
            return;

        _canLaunchRotation = false;
        if (canRotatePlanet)
        {
            StartCoroutine(Rotate(direction, _lerpTime));
        }  

    }

    private IEnumerator Rotate(Vector3 angles, float duration)
    {
        rotationManager.canRotate = false;
        _rotate = true;
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(angles) * startRotation;
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, t / duration);
            yield return null;
        }
        transform.rotation = endRotation;
        _rotate = false;
        _canLaunchRotation = true;
        rotationManager.canRotate = true;
    }
}
