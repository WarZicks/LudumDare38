using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationFaceLauncher : MonoBehaviour
{
    [SerializeField] private FaceManager faceManager;
    [SerializeField] private Vector3 rotationDirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void launchRotation()
    {
        Debug.Log("isWorking");
        faceManager.actualFace.GetComponent<FaceRotation>().LaunchRotation(rotationDirection);
    }
    
}
