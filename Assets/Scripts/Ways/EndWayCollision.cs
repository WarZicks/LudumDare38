using UnityEngine;

public class EndWayCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<EndWayCollision>())
            GameManager.instance.UpdateEndWay(1);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<EndWayCollision>())
            GameManager.instance.UpdateEndWay(-1);
    }
}
