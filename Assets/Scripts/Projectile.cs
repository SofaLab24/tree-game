using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damageAmount = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Attack(collision.gameObject.GetComponent<EnemyController>());
        }
    }

    private void Attack(EnemyController enemy)
    {
        enemy.takeDamage(damageAmount);
    }
}
