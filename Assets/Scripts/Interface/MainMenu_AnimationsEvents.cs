using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu_AnimationsEvents : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickPlay ()
    {
        MenuManager.s_Singleton.LoadFirstScene();
    }

    public void OnClickCredits()
    {
        MenuManager.s_Singleton.DisplayCreditsScreen();
    }

    public void OnClickExit()
    {
        MenuManager.s_Singleton.QuitGame();
    }

    public void OnClickBackFromCredits()
    {
        MenuManager.s_Singleton.BackFromCredits();
    }
}
