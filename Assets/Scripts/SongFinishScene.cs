using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SongFinishScene : MonoBehaviour
{
    public Text ScoreText;

    void Start()
    {
        int score = PlayerPrefs.GetInt("player_score");
        string boss = PlayerPrefs.GetString("Boss");
        if (score == -1)
        {
            ScoreText.text = "You Failed !";
        } else {
            ScoreText.text = "You killed " + boss;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene("LevelSelector");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            string boss = PlayerPrefs.GetString("Boss");
            SceneManager.LoadScene(boss);
        }
    }
}
