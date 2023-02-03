using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerManager : MonoBehaviour
{
    public GameObject playerObject;

    public WavePresetSC wavesPreset;
    [Tooltip("Map size in one direction")]
    public float mapRadius = 10f;
    public float radiusFromPlayer = 2f;

    public bool spawnenemy = true;

    float countdown = 1f;
    int selectedWaveInfo = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!spawnenemy)
        {
            return;
        }
        countdown -= Time.deltaTime;
        if (countdown <= 0f)
        {
            Instantiate(wavesPreset.waves[selectedWaveInfo].Enemies[0], PickPosition(), Quaternion.identity);
            countdown = wavesPreset.waves[selectedWaveInfo].waveSpawnCooldown;
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

        //Need to remake this so it shows from player position
        Gizmos.color = Color.blue;
        if (playerObject != null)
        {
            Gizmos.DrawWireCube(playerObject.transform.position, Vector3.one * radiusFromPlayer);
        }
    }
}
