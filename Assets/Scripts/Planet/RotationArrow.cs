using UnityEngine;

public class RotationArrow : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;
    private PlanetMovement _planet;

    private void Start()
    {
        _planet = GameObject.FindObjectOfType<PlanetMovement>();
    }

    public void OnClick()
    {
        _planet.LaunchRotation(_direction);
    }
}
