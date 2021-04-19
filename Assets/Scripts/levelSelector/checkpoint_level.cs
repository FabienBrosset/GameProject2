using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class checkpoint_level : MonoBehaviour
{
    public string scene;
    private GameObject text;


    void Start()
    {
        text = gameObject.transform.GetChild(0).gameObject;
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            text.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            text.gameObject.SetActive(false);
        }
    }
}
