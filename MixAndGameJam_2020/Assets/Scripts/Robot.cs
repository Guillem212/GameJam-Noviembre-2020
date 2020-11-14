using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public enum UpgradeType { Motor, Magnet, Spring, HidraulicBomb, Deposit, Propeller}

    public List<Upgrade> inventory;

    [Header("Base Stats")]
    public float bSpeed;
    public float bMagnetism;
    public float bLoadTime;
    public float bLaunchForce;
    public float bMaxFuel;
    public float bDashForce;

    [Header("Final Stats")]
    public float speed;
    public float magnetism;
    public float loadTime;
    public float launchForce;
    public float maxFuel;
    public float dashForce;

    public void AddUpgrade(Upgrade upgrade)
    {
        inventory.Add(upgrade);
        UpdateStat(upgrade.type);
    }

    public void RemoveUpgrade(Upgrade upgrade)
    {
        inventory.Remove(upgrade);
        UpdateStat(upgrade.type);
    }

    public void UpdateStat(UpgradeType type)
    {
        int totalValue = 0;
        foreach(Upgrade u in inventory)
        {
            if(u.type == type)
            {
                totalValue += u.value;
            }
        }
        switch (type)
        {
            case UpgradeType.Motor:
                speed = bSpeed * (1+ totalValue/100f);
                break;
            case UpgradeType.Magnet:
                magnetism = bMagnetism * (1 + totalValue / 100f);
                break;
            case UpgradeType.Spring:
                loadTime = bLoadTime * (1 - totalValue / 100f);
                break;
            case UpgradeType.HidraulicBomb:
                launchForce = bLaunchForce * (1 + totalValue / 100f);
                break;
            case UpgradeType.Deposit:
                maxFuel = bMaxFuel * (1 + totalValue / 100f);
                break;
            case UpgradeType.Propeller:
                dashForce = bDashForce * (1 + totalValue / 100f);
                break;
            default:
                break;
        }
    }
}
