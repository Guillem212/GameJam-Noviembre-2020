using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade
{
    public int value;
    public Robot.UpgradeType type;

    public Upgrade()
    {
        value = Random.Range(1, 9);
        type = (Robot.UpgradeType)Random.Range(0, 5);
    }

    public override string ToString()
    {
        return type.ToString() + " [" + value + "]";
    }
}
