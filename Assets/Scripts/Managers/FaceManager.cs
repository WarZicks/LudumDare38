using UnityEngine;

public class FaceManager : MonoBehaviour
{
     public Transform actualFace { get; private set;}
    public GameObject uiFace;
    public bool canRotate = true;
    

    private void Start()
    {
        canRotate = true;
        uiFace.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FaceRotation>())
            actualFace = other.transform;
    }
    private void OnMouseOver()
    {
        if (canRotate)
        {
            uiFace.SetActive(true);
        }
        

    }
    private void OnMouseExit()
    {
        uiFace.SetActive(false);
    }
}
