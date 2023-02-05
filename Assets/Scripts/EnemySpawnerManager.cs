using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerManager : MonoBehaviour
{
    public static EnemySpawnerManager instance;

    public GameObject playerObject;

    public WavePresetSC wavesPreset;
    [Tooltip("Map size in one direction")]
    public float mapRadius = 10f;
    public float radiusFromPlayer = 2f;

    float countdown = 1f;
    int selectedWaveInfo = 0;
    int enemyToPick = 0;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;
    }
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
            if (enemyToPick >= wavesPreset.waves[selectedWaveInfo].Enemies.Count)
            {
                enemyToPick = 0;
            }
            GameObject gm = Instantiate(wavesPreset.waves[selectedWaveInfo].Enemies[enemyToPick], PickPosition(), Quaternion.identity);
            enemyToPick++;
            
            gm.GetComponent<EnemyController>().health *= wavesPreset.waves[selectedWaveInfo].enemyHealthMulplier;
            countdown = 1f / wavesPreset.waves[selectedWaveInfo].waveSpawnRate;
        }
    }

    Vector3 PickPosition()
    {
        float xPlPos = playerObject.transform.position.x + radiusFromPlayer / 2;
        float yPlPos = playerObject.transform.position.y + radiusFromPlayer / 2;
        float x = Random.Range(-mapRadius, mapRadius);
        float y = Random.Range(-mapRadius, mapRadius);
        if (x < xPlPos && x > xPlPos - radiusFromPlayer)
        {
            if (y < yPlPos && y > yPlPos - radiusFromPlayer)
            {
                if (xPlPos > mapRadius / 2)
                {
                    x -= radiusFromPlayer;
                }
                else
                {
                    x += radiusFromPlayer;
                }
            }
        }
        Vector3 pos = new Vector3(x, y);
        return pos;
    }
    private void OnDrawGizmos()
    {
        Vector3 upRight = new Vector3(mapRadius, mapRadius);
        Vector3 lowerLeft = new Vector3(mapRadius, mapRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Vector3.zero, Vector3.one * mapRadius * 2);

        Gizmos.color = Color.blue;
        if (playerObject != null)
        {
            Gizmos.DrawWireCube(playerObject.transform.position, Vector3.one * radiusFromPlayer);
        }
    }

    public void IncrementWave()
    {
        if(selectedWaveInfo + 1 < wavesPreset.waves.Count)
            selectedWaveInfo++;
    }
}
