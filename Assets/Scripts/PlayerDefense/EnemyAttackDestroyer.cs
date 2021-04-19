using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackDestroyer : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("EnemyAttack"))
        {
            Destroy(collision.gameObject);
        }
    }
}
