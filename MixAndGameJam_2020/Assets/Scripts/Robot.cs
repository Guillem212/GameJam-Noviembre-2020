using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public enum UpgradeType { Motor, Spring, HidraulicBomb, Deposit, Propeller}
    private readonly float STATSCALE = 5;

    public List<Upgrade> inventory;
    public HookController hook;
    public PlayerInputs inputs;
   
    [Header("Base Stats")]
    public float bSpeed;
    public float bLoadTime;
    public float bLaunchForce;
    public float bMaxFuel;
    public float bDashForce;

    [Header("Final Stats")]
    public float speed;
    public float loadTime;
    public float launchForce;
    public float maxFuel;
    public float dashForce;

    public void Start()
    {
        inputs = GetComponent<PlayerInputs>();
        inventory = new List<Upgrade>();
        inventory.Add(new Upgrade());
        inventory.Add(new Upgrade());
        foreach(Upgrade u in inventory)
        {
            print(u.ToString());
        }
        UpdateAllStats();
    }

    public void AddUpgrade(Upgrade upgrade)
    {
        if (upgrade!=null)
        {
            inventory.Add(upgrade);
            UpdateStat(upgrade.type);
        }
    }

    public void RemoveUpgrade(Upgrade upgrade)
    {
        inventory.Remove(upgrade);
        UpdateStat(upgrade.type);
    }

    public Upgrade StealUpgrade()
    {
        Upgrade toSteal = inventory[Random.Range(0, inventory.Count)];
        RemoveUpgrade(toSteal);
        return toSteal;

    }

    public void UpdateAllStats()
    {
        UpdateStat(UpgradeType.Motor);
        UpdateStat(UpgradeType.Spring);
        UpdateStat(UpgradeType.HidraulicBomb);
        UpdateStat(UpgradeType.Deposit);
        UpdateStat(UpgradeType.Propeller);
    }

    public void UpdateStat(UpgradeType type)
    {
        float totalValue = 0;
        foreach(Upgrade u in inventory)
        {
            if(u.type == type)
            {
                totalValue += u.value * STATSCALE;
            }
        }
        switch (type)
        {
            case UpgradeType.Motor:
                speed = bSpeed * (1+ totalValue/50f);
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
