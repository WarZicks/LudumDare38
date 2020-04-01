using UnityEngine;

public class EndWayCollision : MonoBehaviour
{
    public EndWayStep step;
    [SerializeField] private GameObject[] _linkedRoad;
    [HideInInspector] public bool activated { get; private set; }

    public event System.Action onTriggerEndWay;

    private void Start()
    {
        if (step == EndWayStep.Zero)
            Active(true);
        else
            Active(false);
    }

    public void Active(bool active)
    {
        gameObject.SetActive(active);
        if (_linkedRoad != null)
        {
            for(int i = 0; i <_linkedRoad.Length; i++)
            {
                _linkedRoad[i].SetActive(active);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EndWayCollision>())
        {
            GameManager.instance.UpdateEndWay(1);
            activated = true;
            onTriggerEndWay?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<EndWayCollision>())
        {
            GameManager.instance.UpdateEndWay(-1);
            activated = false;
            onTriggerEndWay?.Invoke();
        }
    }
}
