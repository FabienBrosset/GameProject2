using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FreeLoseUIManager : MonoBehaviour
{
    public void OnLevelSelectorClick()
    {
        SceneManager.LoadScene("FreeModeScene");
    }
}
