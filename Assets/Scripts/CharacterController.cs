using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;

    public float runSpeed = 20.0f;
    public float health = 5;

    void Start ()
    {
        body = GetComponent<Rigidbody2D>(); 
    }

    void Update ()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical"); 
    }

    private void FixedUpdate()
    {  
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Enemy"))
        {
            this.health -= col.gameObject.GetComponent<EnemyController>().damage;
            if (this.health <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
