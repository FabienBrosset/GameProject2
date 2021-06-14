using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManagement : MonoBehaviour
{
    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    //SceneManagement for FreeMode
    public void OpenBSaberSite()
    {
        Application.OpenURL("https://bsaber.com/songs/top/?time=all");
    }

    public void openSongFolder ()
    {
        string dataPath = Application.persistentDataPath + "/Songs";

        dataPath = dataPath.Replace(@"/", @"\");
        System.Diagnostics.Process.Start("explorer.exe", "/select," + dataPath);
    }

    public void openFreeModeInfo(GameObject canvas)
    {
        canvas.SetActive(true);
    }

    public void closeFreeModeInfo(GameObject canvas)
    {
        canvas.SetActive(false);
    }
}
