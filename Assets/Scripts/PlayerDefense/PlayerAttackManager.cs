using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{
    
    private float time;
    private float timeTo;

    public float speedValue = 3f;

    public GameObject keyNotePrefab;
    public float distanceInstantiate = 4f;

    void Start()
    {
        timeTo = Time.deltaTime + 1;
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time > timeTo)
        {
            timeTo = time + 1;
            int _rand = Random.Range(0, 4); // left,right,up,down
            
            if (_rand == 0)
            {
                CreateKeyNote(new Vector2(distanceInstantiate, 0f), "left", speedValue);
            }
            else if (_rand == 1)
            {
                CreateKeyNote(new Vector2(-distanceInstantiate, 0f), "right", speedValue);
            }
            else if (_rand == 2)
            {
                CreateKeyNote(new Vector2(0f, -distanceInstantiate), "up", speedValue);
            }
            else if (_rand == 3)
            {
                CreateKeyNote(new Vector2(0f, distanceInstantiate), "down", speedValue);
            }
        }
    }

    private void CreateKeyNote(Vector2 pos, string direction, float speed)
    {
        GameObject _key = Instantiate(keyNotePrefab, pos, new Quaternion());

        _key.GetComponent<KeyNoteScript>().direction = direction;
        _key.GetComponent<KeyNoteScript>().speed = speed;
    }
}
