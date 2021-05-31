using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SongFinishScene : MonoBehaviour
{
    public Text ScoreText;
    public GameObject JukeCrying;
    public GameObject Juke;

    void Start()
    {
        int score = PlayerPrefs.GetInt("player_score");
        string boss = PlayerPrefs.GetString("Boss");
        if (score == -1)
        {
            ScoreText.text = "You Failed !";
            JukeCrying.SetActive(true);
        } else {
            ScoreText.text = "You Win !";
            Juke.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene("StoryModeScene");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            string boss = PlayerPrefs.GetString("Boss");
            SceneManager.LoadScene(boss);
        }
    }
}
