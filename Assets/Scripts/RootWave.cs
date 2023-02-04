using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootWave : MonoBehaviour
{
    public GameObject rootWavePrefab;
    public float attackRate = .5f;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = attackRate;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0f)
        {
            Instantiate
            timer = 1f / attackRate;
        }
    }
    Vector3 ClosestEnemy()
    {
        Vector3 pos = transform.position;

        RaycastHit2D[] enemiesInRange = Physics2D.CircleCastAll(transform.position, 100f, Vector3.forward);

        float dis = 999f;
        int id;

        for (int i = 0; i < enemiesInRange.Length; i++)
        {
            enemiesInRange[i].collider.gameObject.GetComponent<EnemyController>()?.takeDamage(damage);
        }

        return pos;
    }
}
