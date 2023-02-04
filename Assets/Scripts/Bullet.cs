using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10;
    public float damage = 1;
    public Rigidbody2D bullet;


    void Start()
    {
        //bullet = GetComponent<Rigidbody2D>();
        //bullet.velocity = transform.forward * bulletSpeed;
        Destroy(bullet, 10f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<CharacterController>().takeDamage(damage);
        }
    }
}