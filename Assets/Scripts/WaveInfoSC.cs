using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Wave info", menuName = "GameData/Wave")]
public class WaveInfoSC : ScriptableObject
{
    public List<GameObject> Enemies;
    public float waveSpawnCooldown = 1f;
}
