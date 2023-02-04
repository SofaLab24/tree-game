using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootWaveLauncher : MonoBehaviour
{
    public GameObject rootWavePrefab;
    public float attackRate = .5f;
    public LayerMask enemyMask;

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
                Debug.Log("no enemies");
                return;
            }
            GameObject gm = Instantiate(rootWavePrefab, transform.position, Quaternion.identity);
            gm.GetComponent<RootWave>().SetTarget(target);
            timer = 1f / attackRate;
        }
    }
    Vector3 ClosestEnemy()
    {
        RaycastHit2D[] enemiesInRange = Physics2D.CircleCastAll(transform.position, 100f, Vector3.forward, 100f, enemyMask);

        if(enemiesInRange.Length == 0)
        {
            return Vector3.forward;
        }

        float dis = Vector3.Distance(transform.position,enemiesInRange[0].transform.position);
        int id = 0;

        for (int i = 1; i < enemiesInRange.Length; i++)
        {
            float temp = Vector3.Distance(transform.position, enemiesInRange[i].transform.position);
            if(temp < dis)
            {
                dis = temp;
                id = i;
            }
        }

        return enemiesInRange[id].transform.position;
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 pos = ClosestEnemy();
        Gizmos.DrawLine(transform.position, pos);
        Gizmos.color = Color.yellow;
    }

}
