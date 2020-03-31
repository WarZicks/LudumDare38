using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationFaceLauncher : MonoBehaviour
{
    [SerializeField] private FaceManager faceManager;
    [SerializeField] private Vector3 rotationDirection;
    private PlanetMovement Planet;

    // Start is called before the first frame update
    void Start()
    {
        Planet = GameObject.FindObjectOfType<PlanetMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void launchRotation()
    {
        Planet.canRotatePlanet = false;
        faceManager.actualFace.GetComponent<FaceRotation>().LaunchRotation(rotationDirection);
    }
    
}
