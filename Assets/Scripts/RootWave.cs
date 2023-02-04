using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootWave : MonoBehaviour
{
    public float rootTime = 1.5f;
    public float lifetime = 2f;
    public float damage = 1f;
    public float moveSpeed = 2f;

    Vector3 dir = Vector3.zero;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, transform.position + dir * moveSpeed, moveSpeed * Time.deltaTime);
    }

    public void SetTarget(Vector3 target)
    {
        dir = (target - transform.position).normalized;
        float angle = Vector2.SignedAngle(Vector2.right, dir) - 90f;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            EnemyController ec = collision.GetComponent<EnemyController>();
            ec.Root(rootTime);
            ec.takeDamage(damage);
        }
    }
}
