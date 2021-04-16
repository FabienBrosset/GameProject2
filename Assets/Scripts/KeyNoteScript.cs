using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyNoteScript : MonoBehaviour
{

    public string direction = "left";
    public float speed = 3f;

    void Update()
    {
        if (direction == "left")
        {
            transform.Translate((-Vector2.right * speed) * Time.deltaTime);
        }
        else if (direction == "right")
        {
            transform.Translate((Vector2.right * speed) * Time.deltaTime);
        }
        else if (direction == "up")
        {
            transform.Translate((Vector2.up * speed) * Time.deltaTime);
        }
        else if (direction == "down")
        {
            transform.Translate((-Vector2.up * speed) * Time.deltaTime);
        }
    }


}
