using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemyRangedController : EnemyController
{
    protected float distanceMax = 10f;

    [SerializeField] GameObject bullet;
    [SerializeField] float timeToShoot = 5f;
    [SerializeField] float bulletSpeed = 10f;
    float timer;

    void FixedUpdate()
    {
        Movement();
    }

    public override void Movement()
    {

        //Math.Sqrt((Math.Pow(transform.position.x - playerT.position.x, 2) +
        //                             Math.Pow(transform.position.y - playerT.position.y, 2)));
        //  double distance = Vector2.Distance()
        //Vector2 backwards = new Vector2(playerT.position.x - transform.position.y, playerT.position.y - transform.position.y);
        //transform.localScale = flip ? new Vector2(-1, 1) : Vector2.one;

        Vector3 direction = Vector3.Normalize(transform.position - playerT.position);
        float distance = Vector2.Distance(transform.position, playerT.position);

        var runAway = distance > distanceMax;

        var mustMove = Mathf.Abs(distance - distanceMax) > 0.1f;
        var flip = transform.position.x > playerT.position.x ^ runAway;

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            
            GameObject projectile = Instantiate(bullet, transform.position + direction, Quaternion.Euler(0f, 0f, 0f));
            projectile.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed * -1;
            timer = timeToShoot;
        }

        if (mustMove)
        {



            if (runAway)
            {
                transform.position -= direction * Time.smoothDeltaTime;
            }
            else
            {
                transform.position += direction * Time.smoothDeltaTime;
                if (timer <= 0)
                {

                }
            }
        }

        enemySR.flipX = !flip;


        /*if (transform.position.x > playerT.position.x && distanceMax < distance)
        {
            transform.localScale = new Vector2(-1, 1);
            transform.position = Vector2.MoveTowards(transform.position, playerT.position, enemySpeed * Time.deltaTime);
            enemySR.flipX = false;
        }
        else if (transform.position.x < playerT.position.x && distanceMax < distance)
        {
            transform.localScale = new Vector2(-1, 1);
            transform.position = Vector2.MoveTowards(transform.position, playerT.position, enemySpeed * Time.deltaTime);
            enemySR.flipX = true;
        }

        else if (transform.position.x > playerT.position.x && distanceMax > distance)
        {
            Debug.Log("si");
            transform.localScale = new Vector2(-1, 1);
            transform.position = Vector2.MoveTowards(transform.position, -backwards, enemySpeed * Time.deltaTime);
            enemySR.flipX = false;
        }
        else if (transform.position.x < playerT.position.x && distanceMax > distance)
        {
            transform.localScale = new Vector2(-1, 1);
            transform.position = Vector2.MoveTowards(transform.position, -backwards, enemySpeed * Time.deltaTime);
            enemySR.flipX = true;
        }*/
    }

}
