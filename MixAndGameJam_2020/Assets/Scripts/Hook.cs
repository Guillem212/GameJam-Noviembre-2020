using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    Upgrade upgrade;
    public Robot robot;

    private void OnTriggerEnter(Collider other)
    {
        Robot r = other.GetComponent<Robot>();
        if (r)
        {
            if (r == robot)
            {
                if (!robot.hook.cable.enabled)
                {
                    r.hook.PickUp();
                }
            }
            else if(r!=robot)
            {
                if (robot.hook.cable.enabled)
                {
                    upgrade = r.StealUpgrade();
                    robot.hook.Return();
                    robot.animScript.f_HitAPlayer();
                    r.animScript.f_HitByAPlayer();
                }
                else
                {
                    r.AddUpgrade(upgrade);
                }
            }
        }
    }

    public Upgrade GetUpgrade()
    {
        Upgrade u = upgrade;
        upgrade = null;
        return u;
    }
}
