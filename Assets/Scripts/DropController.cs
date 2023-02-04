using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropController : MonoBehaviour
{
    public string itemUnlock;
    public SowTheSeeds seedsWeapon;

    public void PickupSelect()
    {
        switch (itemUnlock)
        {
            case "Sapling":
                seedsWeapon.gameObject.SetActive(true);
                break; 
            default:
                break;
            
        }
        Destroy(gameObject);
    }
}
