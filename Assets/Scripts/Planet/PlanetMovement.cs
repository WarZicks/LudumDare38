using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMovement : MonoBehaviour
{
    [SerializeField] private float _lerpSpeed = 2f;
    private bool _rotate;
    private bool _canLaunchRotation;
    private Vector3 _targetRotation;

    private void Start()
    {
        _rotate = false;
        _canLaunchRotation = true;
    }

    private void Update()
    {
        if (_rotate)
            RotateToNewRotation();
    }

    public void LaunchRotation(Vector3 direction)
    {
        if (!_canLaunchRotation)
            return;

        _targetRotation = new Vector3(this.transform.localEulerAngles.x + direction.x, this.transform.localEulerAngles.y + direction.y, this.transform.localEulerAngles.z + direction.z);
        //_rotate = true;
        //_canLaunchRotation = false;
        StartCoroutine(Rotate(direction, .5f));

    }

    private void RotateToNewRotation()
    {
        transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(_targetRotation), _lerpSpeed * Time.deltaTime);

        if (Quaternion.Angle(this.transform.rotation, Quaternion.Euler(_targetRotation)) < .1f)
        {
            _canLaunchRotation = true;
            _rotate = false;
        }
    }

    private IEnumerator Rotate(Vector3 angles, float duration)
    {
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
    }
}
