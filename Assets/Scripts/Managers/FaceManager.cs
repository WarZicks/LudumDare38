using UnityEngine;

public class FaceManager : MonoBehaviour
{
    [HideInInspector] public Transform actualFace { get; private set;}
    public GameObject uiFace;

    private void Start()
    {
        uiFace.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FaceRotation>())
            actualFace = other.transform;
    }
    private void OnMouseOver()
    {
        uiFace.SetActive(true);

    }
    private void OnMouseExit()
    {
        uiFace.SetActive(false);
    }
}
