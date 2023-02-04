using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Loot table", menuName = "GameData/LootTable")]
public class LootDropTable : ScriptableObject
{
    public List<GameObject> itemDrops;

    public GameObject PickItem()
    {
        if(itemDrops.Count == 1)
        {
            return itemDrops[0];
        }
        int i = Random.Range(0, itemDrops.Count);
        return itemDrops[i];
    }
}
