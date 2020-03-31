using UnityEngine;

public class FaceManager : MonoBehaviour
{
    [HideInInspector] public Transform actualFace { get; private set;}
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FaceRotation>())
            actualFace = other.transform;
    }
    private void OnMouseOver()
    {
        actualFace.transform.GetChild(0).gameObject.SetActive(true);
    }
    void OnMouseExit()
    {
        actualFace.transform.GetChild(0).gameObject.SetActive(false);
    }
}
