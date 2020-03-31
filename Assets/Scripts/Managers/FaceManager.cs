using UnityEngine;

public class FaceManager : MonoBehaviour
{
    [HideInInspector] public Transform actualFace { get; private set;}
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FaceRotation>())
            actualFace = other.transform;
    }
}
