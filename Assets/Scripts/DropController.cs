using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropController : MonoBehaviour
{
    public WeaponTypeEnum itemUnlock;
    public AudioClip pickupSound;

    public WeaponTypeEnum PickupSelect()
    {
        SoundManager.Instance.Play(pickupSound);
        Destroy(gameObject, .5f);
        return itemUnlock;
    }
}
