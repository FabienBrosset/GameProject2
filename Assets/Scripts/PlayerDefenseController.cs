using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefenseController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Animator animator;
    private Collider2D collider2D;

    private float takeDamageStartTime;
    public float inviciblityTime = 1f;

    public Transform maxTopRight;
    public Transform maxBottomLeft;

    public int hp = 5;

    private Vector2 movement;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        collider2D = gameObject.GetComponent<Collider2D>();
    }

    void Update()
    {
        // reset the collider when invicibilty frame end
        if (Time.time - takeDamageStartTime >= inviciblityTime && collider2D.isTrigger == true)
        {
            collider2D.isTrigger = false;
        }

        if (hp <= 0)
        {
            Debug.Log("You lost");
        }
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        if (rb.position.x >= maxTopRight.position.x && movement.x > 0)
        {
            movement.x = 0;
        }
        if (rb.position.x <= maxBottomLeft.position.x && movement.x < 0)
        {
            movement.x = 0;
        }
        if (rb.position.y >= maxTopRight.position.y && movement.y > 0)
        {
            movement.y = 0;
        }
        if (rb.position.y <= maxBottomLeft.position.y && movement.y < 0)
        {
            movement.y = 0;
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
                collider2D.isTrigger = true;
                takeDamageStartTime = Time.time;

                Debug.Log("Losing life");
            } else
            {
                Debug.Log("Already dead");
            }
        }    
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed);
    }
}
