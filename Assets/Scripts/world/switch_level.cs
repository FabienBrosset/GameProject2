using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switch_level : MonoBehaviour
{
    public Transform[] oui;

    private Rigidbody rigidBody;
    private int state = 0;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftArrow) && state > 0)
        {
            state -= 1;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && state < oui.Length - 1)
        {
            state += 1;
        }

        Vector3 move = (oui[state].position - rigidBody.position).normalized * 10f;
        move.y = 0f;

        rigidBody.velocity = move;
    }
}
