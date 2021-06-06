using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLifeManager : MonoBehaviour
{
    public int hp = 5;
    private bool alreadyLost = false;

    public GameObject transitionPrefab;
    public AudioSource audiosource;

    private void Update()
    {
        if (hp <= 0 && alreadyLost == false)
        {
            alreadyLost = true;
            audiosource.pitch = 0.75f;

            GameObject _trans = Instantiate(transitionPrefab);

            _trans.transform.parent = GameObject.Find("Canvas").transform;

            _trans.transform.localPosition = new Vector3(0f, 0f, 0f);
            _trans.transform.localScale = new Vector3(1f, 1f, 1f);

            StartCoroutine(WaitFor());
        }
    }

    IEnumerator WaitFor()
    {
        Scene scene = SceneManager.GetActiveScene();
        yield return new WaitForSeconds(3);

        Debug.Log(scene.name);

        PlayerPrefs.SetInt("player_score", -1);
        if (scene.name == "FreeModeFight")
            SceneManager.LoadScene("FreeLoseScene");
        else
            SceneManager.LoadScene("LoseScene");
    }
}
