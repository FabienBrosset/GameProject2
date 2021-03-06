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

    public PlayerLifeManager playerLifeManager;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        _collider2D = gameObject.GetComponent<Collider2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < maxTopRight.position.x)
        {
            transform.Translate((Vector2.right * moveSpeed) * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > maxBottomLeft.position.x)
        {
            transform.Translate((Vector2.left * moveSpeed) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < maxTopRight.position.y)
        {
            transform.Translate((Vector2.up * moveSpeed) * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > maxBottomLeft.position.y)
        {
            transform.Translate((Vector2.down * moveSpeed) * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.CompareTag("EnemyAttack"))
        {
            if (Time.time - takeDamageStartTime <= inviciblityTime)
                return;
            if (playerLifeManager.hp > 0)
            {
                playerLifeManager.hp--;
                animator.SetTrigger("TakeDamage");
                takeDamageStartTime = Time.time;
            }
        }    
    }
}
