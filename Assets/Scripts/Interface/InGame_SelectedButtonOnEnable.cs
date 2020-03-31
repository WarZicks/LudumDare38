using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGame_SelectedButtonOnEnable : MonoBehaviour {

	// Use this for initialization
	void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnEnable ()
    {
        GetComponent<Animator>().SetTrigger("Highlighted");
    }
}
