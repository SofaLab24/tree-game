using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Vector3 direction = Vector3.Normalize(transform.position - playerT.position);
        float distance = Vector2.Distance(transform.position, playerT.position);

        var runAway = distance > distanceMax;

        var mustMove = Mathf.Abs(distance - distanceMax) > 0.1f;
        var flip = transform.position.x > playerT.position.x ^ runAway;

        timer -= Time.deltaTime;
        if (timer <= 0)
        {

            GameObject projectile = Instantiate(bullet, transform.position + direction, Quaternion.identity);
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
    }

}
