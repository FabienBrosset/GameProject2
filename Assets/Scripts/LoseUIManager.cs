using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseUIManager : MonoBehaviour
{
    public void OnLevelSelectorClick()
    {
        SceneManager.LoadScene(0);
    }

    public void OnRestartClick()
    {
        string boss = PlayerPrefs.GetString("Boss");
        SceneManager.LoadScene(boss);
    }
}
