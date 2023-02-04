using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsController : MonoBehaviour
{
    public List<GameObject> weapons;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Pickup"))
        {
            switch(collision.GetComponent<DropController>().PickupSelect())
            {
                case WeaponTypeEnum.Seeds:
                    weapons[0].SetActive(true);
                    break;
                case WeaponTypeEnum.Acorns:
                    weapons[1].SetActive(true);
                    break;
                case WeaponTypeEnum.Sap:
                    weapons[2].SetActive(true);
                    break;
                case WeaponTypeEnum.Roots:
                    weapons[3].SetActive(true);
                    break;
            }
        }
    }
}
