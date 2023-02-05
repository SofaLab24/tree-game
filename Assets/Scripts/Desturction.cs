using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desturction : MonoBehaviour
{
    public float damage = 1f;
    public float lifetime;

    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            Destroy(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<CharacterController>().takeDamage(damage);
            Destroy(this);
        }
    }
}
