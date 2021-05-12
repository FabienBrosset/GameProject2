using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefenseController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Animator animator;
    private Collider2D _collider2D;

    private float takeDamageStartTime;
    public float inviciblityTime = 1f;

    public Transform maxTopRight;
    public Transform maxBottomLeft;

    public int hp = 5;


    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        _collider2D = gameObject.GetComponent<Collider2D>();
    }

    void Update()
    {
        // reset the collider when invicibilty frame end
        if (Time.time - takeDamageStartTime >= inviciblityTime && _collider2D.isTrigger == true)
        {
            _collider2D.isTrigger = false;
        }

        if (hp <= 0)
        {
            Debug.Log("You lost");
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate((Vector2.right * moveSpeed) * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate((Vector2.left * moveSpeed) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate((Vector2.up * moveSpeed) * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate((Vector2.down * moveSpeed) * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("EnemyAttack"))
        {
            if (hp > 0)
            {
                hp--;
                animator.SetTrigger("TakeDamage");
                _collider2D.isTrigger = true;
                takeDamageStartTime = Time.time;

                Debug.Log("Losing life");
            } else
            {
                Debug.Log("Already dead");
            }
        }    
    }
}
