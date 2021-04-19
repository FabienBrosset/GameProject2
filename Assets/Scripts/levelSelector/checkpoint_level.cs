using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class checkpoint_level : MonoBehaviour
{
    public string sceneName;
    public GameObject text;


    void Start()
    {
        text = gameObject.transform.GetChild(0).gameObject;
    }
}
