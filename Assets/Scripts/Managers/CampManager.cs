using System.Collections.Generic;
using UnityEngine;

public class CampManager : MonoBehaviour
{
    public static CampManager instance;

    [Header("Camps")]
    [SerializeField] private GameObject _initialCamp;
    [SerializeField] private GameObject _firstCamp;
    [SerializeField] private GameObject _secondCamp;
    [SerializeField] private GameObject _thirdCamp;

    [Header("Camp Steps")]
    [SerializeField] private int _firstCampStep;
    [SerializeField] private int _secondCampStep;
    [SerializeField] private int _thirdCampStep;

    private List<CampMesh> _campList = new List<CampMesh>();


    private void Awake()
    {
        instance = this;

        foreach (CampMesh camp in GameObject.FindObjectsOfType<CampMesh>())
            _campList.Add(camp);
    }

    private void Start()
    {
        foreach(CampMesh camp in _campList)
        {
            camp.CreateNewMesh(_initialCamp);
        }

        GameManager.instance.onUpdateEndWay += () => CheckCampStep();

    }

    private void CheckCampStep()
    {
        // FIRST CAMP STEP
        if (GameManager.instance._endWayActivated >= _firstCampStep)
        {
            foreach (CampMesh camp in _campList)
            {
                camp.CreateNewMesh(_firstCamp);
                // LAUNCH VFX & SFX
            }
        }
        else
        {
            foreach (CampMesh camp in _campList)
            {
                camp.CreateNewMesh(_initialCamp);

                // LAUNCH VFX & SFX
            }
        }

        // SECOND CAMP STEP
        if (GameManager.instance._endWayActivated >= _secondCampStep)
        {
            foreach (CampMesh camp in _campList)
            {
                camp.CreateNewMesh(_secondCamp);

                // LAUNCH VFX & SFX
            }
        }

        // THIRD CAMP STEP
        if (GameManager.instance._endWayActivated >= _thirdCampStep)
        {
            foreach (CampMesh camp in _campList)
            {
                camp.CreateNewMesh(_thirdCamp);

                // LAUNCH VFX & SFX
            }
        }

        if(GameManager.instance._endWayActivated == _firstCampStep || GameManager.instance._endWayActivated == _secondCampStep || GameManager.instance._endWayActivated == _thirdCampStep)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
