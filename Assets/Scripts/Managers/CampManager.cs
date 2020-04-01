using System.Collections.Generic;
using UnityEngine;

public class CampManager : MonoBehaviour
{
    [Header("Camps")]
    [SerializeField] private GameObject _firstCamp;
    [SerializeField] private GameObject _secondCamp;
    [SerializeField] private GameObject _thirdCamp;
    [SerializeField] private GameObject _fourthCamp;

    [Header("Camp Steps")]
    [SerializeField] private int _firstCampStep;
    [SerializeField] private int _secondCampStep;
    [SerializeField] private int _thirdCampStep;

    private List<CampMesh> _campList = new List<CampMesh>();
}
