using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class switch_level : MonoBehaviour
{
    public GameObject[] checkpoints;

    private Rigidbody2D rigidBody;
    private int state = 0;

    private string sceneToGo = "";

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown("space")) {
            Debug.Log(sceneToGo);
            PlayerPrefs.SetString("Boss", sceneToGo);
            SceneManager.LoadScene(sceneToGo, LoadSceneMode.Single);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) && state > 0) {
            state -= 1;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && state < checkpoints.Length - 1) {
            state += 1;
        }
        rigidBody.position = Vector3.Lerp(rigidBody.position, checkpoints[state].transform.position, 0.005f);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.CompareTag("Checkpoint")) {
            sceneToGo = collider.GetComponent<checkpoint_level>().sceneName;
            collider.GetComponent<checkpoint_level>().text.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.transform.CompareTag("Checkpoint")) {
            sceneToGo = collider.GetComponent<checkpoint_level>().sceneName;
            collider.GetComponent<checkpoint_level>().text.SetActive(false);
        }
    }
}
