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
        _rotate = true;
        _canLaunchRotation = false;
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
}
