using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerManager : MonoBehaviour
{
    public WavePresetSC enemyPrefab;
    [Tooltip("Map size in one direction")]
    public float mapRadius= 10f;
    public float radiusFromPlayer = 2f;

    float countdown = 1f;
    int selectedWaveInfo = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = 1f;
        }
    }

    IEnumerator SpawnWave()
    {
        /*waveIndex++;
        PlayerStats.Rounds++;

        for (int i = 0; i < waveIndex; i++)
        {
            int enemyID = Random.Range(0, enemyPrefabs.Length);

            SpawnEnemy(enemyID);*/
            yield return new WaitForSeconds(1.5f);
            /*enemiesAlive++;
        }*/
    }
}
