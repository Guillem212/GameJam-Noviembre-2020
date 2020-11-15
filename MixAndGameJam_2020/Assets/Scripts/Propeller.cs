using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class Propeller : MonoBehaviour
{

    private float fuel;
    public float dashSpeed;
    bool pressed;
    public AnimationCurve curve;
    public float timePressed;
    [Range(0, 5)] public float refillDuration;
    Robot robot;

    public void Start()
    {
        robot = GetComponent<Robot>();
        fuel = robot.maxFuel;
        pressed = false;
    }

    private void Update()
    {
        if (pressed)
        {
            if (fuel > 0)
            {
                timePressed += Time.deltaTime;
                fuel = Mathf.Max(0, fuel - Time.deltaTime);
                dashSpeed = curve.Evaluate(Mathf.Min(timePressed, robot.bMaxFuel));
            }
            else
            {
                timePressed = 0;
                dashSpeed = 0;
            }
        }
        else
        {
            timePressed = 0;
            dashSpeed = 0;
            if (fuel < robot.maxFuel)
            {
                fuel = Mathf.Min(robot.maxFuel, fuel + robot.maxFuel * (Time.deltaTime / refillDuration));
            }
        }
    }

    public void Dash()
    {
        pressed = true;
    }

    public void Release()
    {
        pressed = false;
    }
}
