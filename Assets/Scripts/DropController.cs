using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropController : MonoBehaviour
{
    public string itemUnlock;

    public void PickupSelect()
    {
        switch (itemUnlock)
        {
            case "Sapling":
                GameObject.FindGameObjectWithTag("SeedWeapon").GetComponent<SowTheSeeds>().enabled = true;
                break; 
            default:
                break;
            
        }
        Destroy(gameObject);
    }
}
