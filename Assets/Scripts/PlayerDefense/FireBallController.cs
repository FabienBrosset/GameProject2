using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallController : MonoBehaviour
{
    public float speed = 6f;
    void Update()
    {
        transform.Translate(-Vector2.up * speed * Time.deltaTime);
    }
}
