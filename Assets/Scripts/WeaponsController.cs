using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsController : MonoBehaviour
{
    public List<GameObject> weapons;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pickup"))
        {
            switch (collision.GetComponent<DropController>().PickupSelect())
            {
                case WeaponTypeEnum.Seeds:
                    if (weapons[0].activeSelf)
                    {
                        weapons[0].GetComponent<SowTheSeeds>().seedingRate += .2f;
                        weapons[0].GetComponent<SowTheSeeds>().range += .1f;
                        weapons[0].GetComponent<SowTheSeeds>().rotSpeed += 1f;
                    }
                    weapons[0].SetActive(true);
                    break;
                case WeaponTypeEnum.Acorns:
                    if (weapons[1].activeSelf)
                    {
                        weapons[1].GetComponent<AcornDoom>().damageModifier+=.1f;
                        weapons[1].GetComponent<AcornDoom>().cooldown -= 0.025f;
                    }
                    weapons[1].SetActive(true);
                    break;
                case WeaponTypeEnum.Sap:
                    if (weapons[2].activeSelf)
                    {
                        weapons[2].GetComponent<Sap>().Upgrade(1f);
                    }
                    weapons[2].SetActive(true);
                    break;
                case WeaponTypeEnum.Roots:
                    if (weapons[3].activeSelf)
                    {
                        weapons[3].GetComponent<RootWaveLauncher>().attackRate += .02f;
                        weapons[3].GetComponent<RootWaveLauncher>().rootsModifier += .05f;
                    }
                    weapons[3].SetActive(true);
                    break;
            }
        }
    }
}
