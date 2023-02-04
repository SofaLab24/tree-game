using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SowTheSeeds : MonoBehaviour
{
    public GameObject seedlingObject;
    public float rotSpeed = 2f;
    public float range = 10f;
    public float seedingRate = 1f;

    float zRot = 0f;
    float timer = 0f;

    private void Start()
    {
        zRot = transform.rotation.z;
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            SpawnSeedling();
            timer = 1f / seedingRate;
        }
        zRot += rotSpeed * Time.deltaTime;
        if (zRot >= 360)
        {
            zRot = 0f;
        }
        transform.rotation = Quaternion.AngleAxis(zRot, Vector3.forward);
    }
    void SpawnSeedling()
    {
        float dis = Random.Range(1f, range - 1);
        Vector3 pos = CalculateForwardPos(dis);
        if(seedlingObject != null)
        {
            Instantiate(seedlingObject, pos, Quaternion.identity);
        }
    }
    Vector3 CalculateForwardPos(float dis)
    {
        Vector3 dir = transform.right * dis;
        dir.x += transform.position.x;
        dir.y += transform.position.y;
        return dir;
    }
    private void OnDrawGizmosSelected()
    {
        Vector3 dir = CalculateForwardPos(range);
        Gizmos.DrawLine(transform.position, dir);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
