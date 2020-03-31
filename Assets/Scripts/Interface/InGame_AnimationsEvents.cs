using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGame_AnimationsEvents : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickResume ()
    {
        GameUIManager.s_Singleton.OnClickResume();
    }

    public void OnClickBackToMainMenu()
    {
        GameUIManager.s_Singleton.OnClickMainMenu();
    }
}
