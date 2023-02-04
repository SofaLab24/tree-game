using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D enemyR;
    private SpriteRenderer enemySR;

    private GameObject player;
    private Transform playerT;

    public float health = 3f;
    public float damage = 1f;

    [SerializeField]
    float enemySpeed = 2f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerT = player.transform;
        enemyR = GetComponent<Rigidbody2D>();
        enemySR = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (transform.position.x > playerT.position.x)
        {
            transform.localScale = new Vector2(-1, 1);           
            //enemyR.velocity = new Vector2(-2f, 0f); // -2f galima pakeisti "movement speed"
            transform.position = Vector2.MoveTowards(transform.position, playerT.position, enemySpeed * Time.deltaTime);
            enemySR.flipX = false;
        }
        else if (transform.position.x < playerT.position.x)
        {
            transform.localScale = new Vector2(-1, 1);
            //enemyR.velocity = new Vector2(2f, 0f);
            transform.position = Vector2.MoveTowards(transform.position, playerT.position, enemySpeed * Time.deltaTime);
            enemySR.flipX = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Don't worry");
        if (other.tag.Equals("PlayerProjectile"))
        {
            Debug.Log("Be happy");
            Projectile proj = other.GetComponent<Projectile>();
            this.health -= proj.damageAmount;
            if (this.health <= 0) Destroy(this.gameObject);
        }
    }
}
