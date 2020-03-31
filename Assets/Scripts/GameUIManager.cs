using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour {

    [Tooltip("Hides the cursor if checked.")]
    public bool hideMouseCursor;

    [Header("Pause Menu")]
    public KeyCode keyToPressForPauseMenu;
    public GameObject pauseMenu;
    [Tooltip("If checked, mouse cursor shows during pause mode.")]
    public bool showMouseCursorWhenPaused;

    // Cette variable + le code dans la fonction Awake permet de faire appel à ce script
    // depuis n'importe quel autre script dans la scène, en tapant :
    // GameUIManager.s_Singleton.[NomDeLaFonctionAExecuter]()
    // Le code dans Awake permet également de s'assurer qu'il n'y a qu'un seul GameUIManager dans toute la scène.
    public static GameUIManager s_Singleton;

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
    }
	
	// Update is called once per frame
	void Update () {

        // Quelques connaissances en Input Manager sont nécessaires pour modifier le bloc ci-dessous - si besoin
		if (Input.GetKeyDown(keyToPressForPauseMenu))
        {
            TogglePauseMenu();
        }
	}

    public void TogglePauseMenu ()
    {
        if (pauseMenu.activeSelf)
        {
            pauseMenu.SetActive(false);
            if (hideMouseCursor)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
        else if (!pauseMenu.activeSelf)
        {
            pauseMenu.SetActive(true);
            if (showMouseCursorWhenPaused)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
            }
        }
    }

    public void OnClickResume ()
    {
        TogglePauseMenu();
    }

    //Penser à mettre la scène du Main Menu en première position (index 0) dans les Build Settings
    public void OnClickMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
