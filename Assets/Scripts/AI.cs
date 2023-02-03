using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AI : MonoBehaviour
{
    private Rigidbody2D enemyR;
    private SpriteRenderer enemySR;

    private GameObject player;
    private Transform playerT;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerT = player.transform;
        enemyR = GetComponent<Rigidbody2D>();
        enemySR = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (transform.position.x > playerT.position.x)
        {
            transform.localScale = new Vector2(-1, 1);           
            enemyR.velocity = new Vector2(-2f, 0f); // -2f galima pakeisti "movement speed"
            transform.position = Vector2.MoveTowards(transform.position, playerT.position, 2f * Time.deltaTime);
            if(enemySR.flipX != true)
            {
                enemySR.flipX = true;
            }
        }
        else if (transform.position.x < playerT.position.x)
        {
            transform.localScale = new Vector2(-1, 1);
            enemyR.velocity = new Vector2(2f, 0f);
            transform.position = Vector2.MoveTowards(transform.position, playerT.position, 2f * Time.deltaTime);
        }
    }
}
