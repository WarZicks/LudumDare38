using UnityEngine;

public class EndWayCollision : MonoBehaviour
{
    public EndWayStep _step;

    private void Start()
    {
        if (_step == EndWayStep.Zero)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
    }

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
