using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLifeManager : MonoBehaviour
{
    public int hp = 5;

    private void Update()
    {
        if (hp <= 0)
        {
            SceneManager.LoadScene(5);
        }
    }
}