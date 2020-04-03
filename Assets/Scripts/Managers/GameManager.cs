using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int _endWayCount { get; private set;}
    public int _endWayActivated { get; private set;}

    public event System.Action onUpdateEndWay;
    public event System.Action onWin;

    private void Awake()
    {
        instance = this;
        _endWayCount = GameObject.FindObjectsOfType<EndWayCollision>().Length;
    }

    public void UpdateEndWay(int amount)
    {
        _endWayActivated += amount;
        CheckEndWayCount();
        onUpdateEndWay?.Invoke();
    }

    private void CheckEndWayCount()
    {
        if (_endWayActivated >= _endWayCount)
            Win();
    }

    private void Win()
    {
        Debug.Log("Win !");
        onWin?.Invoke();
    }
}
