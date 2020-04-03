using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndwayCountUi : MonoBehaviour
{
    Text txt;
    private int endWayActivated = 0;
    private int endWayCount = 0;

    // Use this for initialization
    void Start()
    {
        txt = gameObject.GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        endWayActivated = GameManager.instance._endWayActivated;
        endWayCount = GameManager.instance._endWayCount;

        txt.text = endWayActivated + " / " + endWayCount;
    }
}
