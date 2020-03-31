using System.Collections;
using UnityEngine;

public class FaceRotation : MonoBehaviour
{
    private float _lerpTime = .25f;
    private bool _rotate;
    private bool _canLaunchRotation;
    private Vector3 _targetRotation;
    private PlanetMovement _planet;

    private void Start()
    {
        _planet = GameObject.FindObjectOfType<PlanetMovement>();
        _rotate = false;
        _canLaunchRotation = true;
    }

    public void LaunchRotation(Vector3 direction)
    {
        if (!_canLaunchRotation)    
            return;

        _planet.canRotatePlanet = false;
        _canLaunchRotation = false;
        StartCoroutine(Rotate(direction, _lerpTime));

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
        _canLaunchRotation = true;
        _planet.canRotatePlanet = true;
    }
}
