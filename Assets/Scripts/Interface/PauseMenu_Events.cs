using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu_Events : MonoBehaviour
{
    public void OnClickResume()
    {
        InterfaceManager.instance.TogglePauseMenu();
    }

    public void OnClickMenu()
    {
        InterfaceManager.instance.GoToMenu();
    }

    public void OnClickQuit()
    {
        InterfaceManager.instance.Quit();
    }
}
