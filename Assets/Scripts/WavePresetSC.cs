using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Wave preset", menuName = "GameData/WavePreset")]
public class WavePresetSC : ScriptableObject
{
    public List<WaveInfoSC> waves;
}
