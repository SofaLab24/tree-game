using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirchSlap : MonoBehaviour
{
    float timeToAttack = 1f;
    float timer;
    [SerializeField] float range = 5;

    [SerializeField] GameObject slash;
    [SerializeField] GameObject player;


    Rigidbody2D playerRb;
    CharacterController playerCC;

    private void Start()
    {
        playerRb = player.GetComponent<Rigidbody2D>();
        playerCC = player.GetComponent<CharacterController>();
    }
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Attack();
        }

        if (playerRb.velocity.magnitude != 0f)
        {
            transform.position = new Vector2(player.transform.position.x, player.transform.position.y) + playerRb.velocity / playerCC.runSpeed * range;
            
            if (playerRb.velocity.normalized.x == 1 && playerRb.velocity.normalized.y == 0) //right
            {
                transform.rotation = Quaternion.Euler(0f,0f,0f);
            }
            else if (playerRb.velocity.normalized.x == 0 && playerRb.velocity.normalized.y == 1) //up
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            }
            else if (playerRb.velocity.normalized.x == -1 && playerRb.velocity.normalized.y == 0) //left
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 180f);
            }
            else if (playerRb.velocity.normalized.x == 0 && playerRb.velocity.normalized.y == -1) //right
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 270f);
            }
            if (playerRb.velocity.normalized.x >= 0.5 && playerRb.velocity.normalized.y >= 0.5) //right up
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 45f);
            }
            else if (playerRb.velocity.normalized.x <= -0.5 && playerRb.velocity.normalized.y >= 0.5) //left up
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 135f);
            }
            else if (playerRb.velocity.normalized.x <= -0.5 && playerRb.velocity.normalized.y <= -0.5) //left down
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 225f);
            }
            else if (playerRb.velocity.normalized.x >= 0.5 && playerRb.velocity.normalized.y <= -0.5) //right down
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 305f);
            }
            Debug.Log(playerRb.velocity.normalized.x);
        }
        
    }

    private void Attack()
    {
        Debug.Log("Attack");
        timer = timeToAttack;

        GameObject attack = Instantiate(attack = slash, transform);
        Destroy(attack, 0.3f);
        
    }
}
