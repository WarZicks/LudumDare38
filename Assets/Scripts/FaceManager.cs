using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceManager : MonoBehaviour
{
    public Transform actualFace;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FaceRotation>())
        {
            actualFace = other.transform;
        }
        


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
