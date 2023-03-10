using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : MonoBehaviour
{
    public float damage = 5f;
    public float effectRange = 10f;
    public float speed = 5f;
    public LayerMask enemyMask;

    Vector3 target;
    bool targetSet = false;
    float zRot;

    public void SetTarget(Vector3 _target, float dMod)
    {
        zRot = transform.rotation.z;
        damage = dMod;
        target = _target;
        targetSet = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!targetSet)
        {
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(target, transform.position) < .5f)
        {

            RaycastHit2D[] enemiesInRange = Physics2D.CircleCastAll(transform.position, effectRange, Vector3.forward, effectRange, enemyMask);

            for (int i = enemiesInRange.Length - 1; i >= 0; i--)
            {
                enemiesInRange[i].collider.gameObject.GetComponent<EnemyController>()?.takeDamage(damage);
            }

            Destroy(gameObject);
        }

        zRot += 95f * Time.deltaTime;
        if (zRot >= 360)
        {
            zRot = 0f;
        }
        transform.rotation = Quaternion.AngleAxis(zRot, Vector3.forward);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, effectRange);
    }
}
