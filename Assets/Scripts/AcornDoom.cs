using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornDoom : MonoBehaviour
{
    public GameObject acorn;
    public float cooldown = 5f;
    public float damageModifier = 1f;

    float timer;

    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnAcorn();
            timer = cooldown;
        }
    }
    void SpawnAcorn()
    {
        Vector3 pos = PickPosition();

        GameObject gm = Instantiate(acorn, transform.position, Quaternion.identity);
        gm.GetComponent<Acorn>().SetTarget(pos, damageModifier);
    }
    Vector3 PickPosition()
    {
        float range = EnemySpawnerManager.instance.radiusFromPlayer / 2;
        float x = Random.Range(-range, range);
        float y = Random.Range(-range, range);
        Vector3 pos = new Vector3(x + transform.position.x, y + transform.position.y);
        return pos;
    }
}
