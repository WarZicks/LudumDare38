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
            for (int i = 0; i < _linkedRoad.Length; i++)
            {
                _linkedRoad[i].SetActive(active);
            }
        }

        if(active)
        {
            EndWayManager.instance._audioSource.clip = EndWayManager.instance._showNewWayClip;
            EndWayManager.instance._audioSource.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EndWayCollision>())
        {
            if (!CampManager.instance.GetComponent<AudioSource>().isPlaying && !EndWayManager.instance._audioSource.isPlaying)
            {
                EndWayManager.instance._audioSource.clip = EndWayManager.instance._endWayActivatedClip;
                EndWayManager.instance._audioSource.Play();
            }

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
