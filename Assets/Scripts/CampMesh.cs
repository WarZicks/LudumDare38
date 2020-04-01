using UnityEngine;

public class CampMesh : MonoBehaviour
{
    public void CreateNewMesh(GameObject mesh)
    {
        foreach (Transform child in this.gameObject.transform)
            Destroy(child.gameObject);

        GameObject go = Instantiate(mesh, this.transform);
        go.transform.localPosition = new Vector3(.03f, 0f, .045f);
    }
}
