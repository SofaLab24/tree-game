using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seedling : MonoBehaviour
{
    public float damage = 2f;
    public float lifetime = 3f;
    public float growthRate = 2f;

    float remTime;

    CapsuleCollider2D coll;
    Material mat;
    float currentGrowth;

    private void Awake()
    {
        coll = GetComponent<CapsuleCollider2D>();
        mat = GetComponent<SpriteRenderer>().material;
        currentGrowth = -5f;
    }
    private void Start()
    {
        coll.enabled = false;
        remTime = lifetime;
    }

    private void Update()
    {
        if (remTime >= 0.1f)
        {
            currentGrowth = Mathf.MoveTowards(currentGrowth, 5, growthRate * Time.deltaTime);
            mat.SetFloat("_Growth", currentGrowth);
        }

        if (currentGrowth <= 4.5f && remTime > 0f)
        {
            return;
        }

        coll.enabled = true;
        remTime -= Time.deltaTime;
        if (remTime <= 0)
        {
            currentGrowth = Mathf.MoveTowards(currentGrowth, -5, growthRate * Time.deltaTime);
            mat.SetFloat("_Growth", currentGrowth);
            if (currentGrowth <= -4.5f)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Enemy"))
        {
            collision.GetComponent<EnemyController>().takeDamage(damage);
        }
    }
}
