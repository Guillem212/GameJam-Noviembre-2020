using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    Upgrade upgrade;
    public Robot robot;

    private void OnTriggerEnter(Collider other)
    {
        Robot enemy = other.GetComponent<Robot>();
        if (enemy && enemy!=robot)
        {
            upgrade = enemy.StealUpgrade();
            robot.hook.Return();
        }
    }

    public Upgrade GetUpgrade()
    {
        Upgrade u = upgrade;
        upgrade = null;
        return u;
    }
}
