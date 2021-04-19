using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAttackController : MonoBehaviour
{
    public float speed = 2f;

    void Update()
    { 
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
