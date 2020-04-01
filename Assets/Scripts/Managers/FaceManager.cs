using UnityEngine;

public class FaceManager : MonoBehaviour
{
    public Transform actualFace { get; private set;}
    public GameObject faceUI;
    [HideInInspector] public bool canRotate = true;
    

    private void Start()
    {
        canRotate = true;
        faceUI.SetActive(false);
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
            faceUI.SetActive(true);
        }
        

    }
    private void OnMouseExit()
    {
        faceUI.SetActive(false);
        faceUI.GetComponent<LerpScale>().scaleSpeed = 0.3f;
        faceUI.GetComponent<LerpScale>().actualScaleX = 0;
        faceUI.GetComponent<LerpScale>().actualScaleY = 0;
        faceUI.GetComponent<LerpScale>().actualScaleZ = 0;
        faceUI.transform.localScale = new Vector3(0, 0, 0);
    }
}
