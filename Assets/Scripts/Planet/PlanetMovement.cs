﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMovement : MonoBehaviour
{
    [SerializeField] private float _lerpTime = .5f;
    private bool _rotate;
    private bool _canLaunchRotation;
    public GameObject rotationManager;
    public bool canRotateCube;

    private void Start()
    {
        canRotateCube = true;
        _rotate = false;
        _canLaunchRotation = true;
    }
    public void LaunchRotation(Vector3 direction)
    {
        if (!_canLaunchRotation)
            return;

        _canLaunchRotation = false;
        if (canRotateCube)
        {
            StartCoroutine(Rotate(direction, _lerpTime));
        }  

    }

    private IEnumerator Rotate(Vector3 angles, float duration)
    {
        rotationManager.GetComponent<FaceManager>().canRotate = false;
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
        rotationManager.GetComponent<FaceManager>().canRotate = true;
    }
}
