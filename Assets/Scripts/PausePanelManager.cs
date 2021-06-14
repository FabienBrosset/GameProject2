using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanelManager : MonoBehaviour
{
    public GameObject PausePanel;
    public AudioSource audioSource;

    private bool isGamePaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseHandling();
        }
    }

    void PauseHandling()
    {
        if (isGamePaused)
        {
            // unpause the game
            Time.timeScale = 1;
            audioSource.pitch = 1;
            isGamePaused = false;
            PausePanel.SetActive(false);
        }
        else
        {
            // pause the game
            Time.timeScale = 0;
            audioSource.pitch = 0;
            isGamePaused = true;
            PausePanel.SetActive(true);
        }
    }

    public void OnClickResumeButton()
    {
        PauseHandling();
    }

    public void LeavePauseScene()
    {
        Time.timeScale = 1;
        audioSource.pitch = 1;
    }
}
