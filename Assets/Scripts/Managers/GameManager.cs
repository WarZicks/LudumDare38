using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int _endWayCount;
    public int _endWayActivated { get; private set;}

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _endWayCount = GameObject.FindObjectsOfType<EndWayCollision>().Length;
    }

    public void UpdateEndWay(int amount)
    {
        _endWayActivated += amount;
        CheckEndWayCount();
    }

    private void CheckEndWayCount()
    {
        if (_endWayActivated >= _endWayCount)
            Win();
    }

    private void Win()
    {
        Debug.Log("Win !");
    }
}
