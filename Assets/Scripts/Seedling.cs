using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seedling : MonoBehaviour
{
    public float damage = 2f;
    public float lifetime = 3f;

    float remTime;

    private void Start()
    {
        remTime = lifetime;
    }

    private void Update()
    {
        remTime -= Time.deltaTime;
        if(remTime <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if(collision.tag.Equals("Enemy"))
        {     
            collision.GetComponent<EnemyController>().takeDamage(damage);
        }
    }
}
