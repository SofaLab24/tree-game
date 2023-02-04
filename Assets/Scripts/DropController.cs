using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropController : MonoBehaviour
{
    public string itemUnlock;
    public AudioClip pickupSound;

    public void PickupSelect()
    {
        SoundManager.Instance.Play(pickupSound);
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
