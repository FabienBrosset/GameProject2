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
        if (Input.GetKeyDown("space"))
        {
            Debug.Log(sceneToGo);
            SceneManager.LoadScene(sceneToGo, LoadSceneMode.Single);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) && state > 0)
        {
            state -= 1;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && state < checkpoints.Length - 1)
        {
            state += 1;
        }
        Vector2 move = Vector2.zero;
        // without this check the jukebox is shaking when not moving on checkpoint
        if((checkpoints[state].transform.position.x - rigidBody.position.x > 0.1f || checkpoints[state].transform.position.x - rigidBody.position.x < -0.1f) 
            && (checkpoints[state].transform.position.y - rigidBody.position.y > 0.1f || checkpoints[state].transform.position.y - rigidBody.position.y < -0.1))
            move = (new Vector2(checkpoints[state].transform.position.x - rigidBody.position.x, checkpoints[state].transform.position.y - rigidBody.position.y)).normalized * 10f;

        rigidBody.velocity = move;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.CompareTag("Checkpoint"))
        {
            sceneToGo = collider.GetComponent<Checkpoint_level>().sceneName;
        }
    }
    void OnTrigger2D(Collider2D collider)
    {
        if (collider.transform.CompareTag("Checkpoint"))
        {
            sceneToGo = collider.GetComponent<Checkpoint_level>().sceneName;
        }
    }
}
