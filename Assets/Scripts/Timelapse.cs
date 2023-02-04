using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timelapse : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public double time;

    private void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        textMeshPro.text = time.ToString("F2");
    }
}
