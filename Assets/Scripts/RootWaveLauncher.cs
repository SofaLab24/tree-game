using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootWaveLauncher : MonoBehaviour
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
            Vector3 target = ClosestEnemy();
            if(target == Vector3.forward)
            {
                return;
            }
            Instantiate(rootWavePrefab, target, Quaternion.identity);
            timer = 1f / attackRate;
        }
    }
    Vector3 ClosestEnemy()
    {
        RaycastHit2D[] enemiesInRange = Physics2D.CircleCastAll(transform.position, 100f, Vector3.forward);

        if(enemiesInRange.Length == 0)
        {
            return Vector3.forward;
        }

        float dis = Vector3.Distance(transform.position,enemiesInRange[0].transform.position);
        int id = 0;

        for (int i = 1; i < enemiesInRange.Length; i++)
        {
            float temp = Vector3.Distance(transform.position, enemiesInRange[i].transform.position);
            if(temp > dis)
            {
                dis = temp;
                id = i;
            }
        }

        return enemiesInRange[id].transform.position;
    }
}
