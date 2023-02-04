using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sap : MonoBehaviour
{
    [SerializeField] float damage = 1f;
    [SerializeField] float radius = 10f;
    [SerializeField] float sapDuration = 2f;
    [SerializeField] float timeToAttack = 2f;

    Collider2D col;
    LayerMask layerMask;

    float timer;

    void Start()
    {
        transform.localScale = new Vector3(radius, radius, 0f);
        layerMask = LayerMask.GetMask("Enemy");
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, radius, layerMask);
            foreach (var hitCollider in hitColliders)
            {
                Attack(hitCollider.gameObject.GetComponent<EnemyController>());
            }
        }
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
        timer = timeToAttack;
        enemy.takeDamage(damage);
        Debug.Log("Applied sap");
        enemy.sapped(sapDuration);
    }
}
