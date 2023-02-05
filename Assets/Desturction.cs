using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desturction : MonoBehaviour
{
    public float lifetime;

    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this);
        }
    }
}
