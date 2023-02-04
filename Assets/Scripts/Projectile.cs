using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damageAmount = 1;
    public AudioClip slapSound;

    public void Start()
    {
        SoundManager.Instance.Play(slapSound);
    }

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
