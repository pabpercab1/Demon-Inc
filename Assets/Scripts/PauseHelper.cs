using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PauseHelper : MonoBehaviour
{
    public GameObject pauseMenu;
    public void pauseButton()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void resumeButton()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.activeSelf) resumeButton();
            else pauseButton();
        }
    }
}
