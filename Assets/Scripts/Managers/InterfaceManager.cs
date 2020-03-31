using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceManager : MonoBehaviour
{
    [Header("Referencies")]
    [SerializeField] private GameObject _winMenu;
    [SerializeField] private GameObject _planetArrows;

    private void Start()
    {
        GameManager.instance.onWin += () => Win();
    }

    private void Win()
    {
        ActiveObject(_winMenu, true, .5f);
        ActiveObject(_planetArrows, false, .5f);
    }

    public void ActiveObject(GameObject go, bool active, float delay = 0f)
    {
        StartCoroutine(WaitForActiveObject(go, active, delay));
    }

    private IEnumerator WaitForActiveObject(GameObject go, bool active, float delay)
    {
        yield return new WaitForSeconds(delay);
        go.SetActive(active);
    }
}
