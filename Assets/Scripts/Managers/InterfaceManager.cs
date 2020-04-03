using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{
    public static InterfaceManager instance;

    [Header("Referencies")]
    [SerializeField] private GameObject _winMenu;
    [SerializeField] private GameObject _planetArrows;
    [SerializeField] private GameObject _pauseMenu;

    private bool _togglePauseMenu = false;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GameManager.instance.onWin += () => Win();
        _winMenu.SetActive(false);
        _pauseMenu.SetActive(false);
        _planetArrows.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GetComponent<AudioSource>().Play();
            TogglePauseMenu();
        }
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

    public void NextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            SceneManager.LoadScene(0);

    }

    public void TogglePauseMenu()
    {
        _togglePauseMenu = !_togglePauseMenu;
        _planetArrows.SetActive(_togglePauseMenu);
        _pauseMenu.SetActive(!_togglePauseMenu);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
