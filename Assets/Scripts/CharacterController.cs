using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    [SerializeField] GameObject character;
    Rigidbody2D body;

    float horizontal;
    float vertical;

    bool dead = false;

    public float runSpeed = 20.0f;
    public float health = 5;
    public float maxHealth = 5;

    public float xBounds = 75f;
    public float yBounds = 85f;

    public AudioClip hitSound;
    public AudioClip deathSound;
    public ParticleSystem runParticles;

    public Slider slider;

    void Start()
    {
        maxHealth = health;
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (slider != null)
        {
            slider.maxValue = maxHealth;
            slider.value = health;
        }
    }

    private void FixedUpdate()
    {
        if (!dead)
        {
            if (horizontal < 0)
            {
                var forceVector = runParticles.forceOverLifetime;
                forceVector.enabled = true;
                forceVector.xMultiplier = 1.7f;
            }
            else
            {
                var forceVector = runParticles.forceOverLifetime;
                forceVector.enabled = true;
                forceVector.xMultiplier = -1.7f;
            }

            if (transform.position.x >= xBounds)
            {
                transform.position = new Vector3(transform.position.x - Time.deltaTime, transform.position.y, 0);
                body.velocity = new Vector2(-horizontal * runSpeed, vertical * runSpeed);
            }
            else if (transform.position.x <= -xBounds)
            {
                transform.position = new Vector3(transform.position.x + Time.deltaTime, transform.position.y, 0);
                body.velocity = new Vector2(-horizontal * runSpeed, vertical * runSpeed);
            }
            else if (transform.position.y >= yBounds)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime, 0);
                body.velocity = new Vector2(horizontal * runSpeed, -vertical * runSpeed);
            }
            else if (transform.position.y <= -yBounds)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime, 0);
                body.velocity = new Vector2(horizontal * runSpeed, -vertical * runSpeed);
            }
            else
            {
                body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Enemy"))
        {
            this.health -= col.gameObject.GetComponent<EnemyController>().damage;
            SoundManager.Instance.Play(hitSound);
            if (this.health <= 0)
            {
                dead = true;
                SoundManager.Instance.Play(deathSound);
                Destroy(character);

            }
        }
    }

    public void takeDamage(float damage)
    {
        this.health -= damage;
        SoundManager.Instance.Play(hitSound);
        if (this.health <= 0)
        {
            dead = true;
            SoundManager.Instance.Play(deathSound);
            Destroy(character);
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Pickup"))
        {
            col.GetComponent<DropController>().PickupSelect();
        }
    }
}
