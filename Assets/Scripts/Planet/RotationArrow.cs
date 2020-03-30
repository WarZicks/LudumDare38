using UnityEngine;

public class RotationArrow : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;
    [SerializeField] private PlanetMovement _planet;

    public void OnClick()
    {
        _planet.LaunchRotation(_direction);
    }
}
