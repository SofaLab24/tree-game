using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timelapse : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public double time;

    float waveCoundown;

    private void Start()
    {
        waveCoundown = 60f;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        waveCoundown -= Time.deltaTime;
        time += Time.deltaTime;
        textMeshPro.text = time.ToString("F2");

        if(waveCoundown <= 0)
        {
            EnemySpawnerManager.instance.IncrementWave();
            waveCoundown = 60f;
        }
    }
}
