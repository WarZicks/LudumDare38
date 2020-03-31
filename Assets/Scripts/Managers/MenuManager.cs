using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    [Tooltip("Hides the cursor if checked.")]
    public bool hideMouseCursor;

    [Tooltip("The name of the scene to load when player clicks 'Play'")]
    public string sceneToLoadOnClickPlay;

    [Header("Menu Screens")]
    public GameObject mainMenuScreen;
    public GameObject creditsScreen;
    public GameObject loadingScreen;

    // Cette variable + le code dans la fonction Awake permet de faire appel à ce script
    // depuis n'importe quel autre script dans la scène, en tapant :
    // MenuManager.s_Singleton.[NomDeLaFonctionAExecuter]()
    // Le code dans Awake permet également de s'assurer qu'il n'y a qu'un seul MenuManager dans toute la scène.
    public static MenuManager s_Singleton;

    void Awake()
    {
        if (s_Singleton != null)
        {
            Destroy(gameObject);
        }
        else
        {
            s_Singleton = this;
        }
    }

    // Use this for initialization
    void Start () {
        if (hideMouseCursor)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        mainMenuScreen.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void LoadFirstScene ()
    {
        mainMenuScreen.SetActive(false);
        loadingScreen.SetActive(true);
        SceneManager.LoadScene(sceneToLoadOnClickPlay);
    }

    public void DisplayCreditsScreen ()
    {
        mainMenuScreen.SetActive(false);
        creditsScreen.SetActive(true);
    }

    public void BackFromCredits ()
    {
        creditsScreen.SetActive(false);
        mainMenuScreen.SetActive(true);
    }

    public void QuitGame ()
    {
        Application.Quit();
    }
}
