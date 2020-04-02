using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbianceSingleton : MonoBehaviour
{
    public static AmbianceSingleton instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
