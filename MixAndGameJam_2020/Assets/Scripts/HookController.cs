using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class HookController : MonoBehaviour
{
    public float minRange;
    public float maxRange;
    public float duration;
    private Vector3 direction;

    public bool prepared;
    bool pressed;
    Robot robot;
    public Hook hook;
    public GameObject arrow;

    public void Start()
    {
        robot = GetComponent<Robot>();
        prepared = true;
    }

    public void Target(Vector2 dir)
    {
        if(dir.magnitude > 0)
        {
            direction = new Vector3(dir.x, 0f, dir.y);
            direction = Camera.main.transform.TransformDirection(direction);
            direction.y = 0f;
            direction.Normalize();
            arrow.transform.position = transform.position + direction;
        }
    }

    public void Load()
    {
        pressed = true;
        if (robot.hook.prepared)
        {
            StartCoroutine(AsyncLoad());
        }
    }

    public void Release()
    {
        pressed = false;
    }

    IEnumerator AsyncLoad()
    {
        float timeLoaded = 0;
        while (pressed)
        {
            if(timeLoaded < robot.loadTime) timeLoaded += Time.deltaTime;
            yield return null;
        }
        Launch(timeLoaded / robot.loadTime);
    }

    public void Launch(float normalizedLoad)
    {
        prepared = false;
        hook.transform.SetParent(null);
        Vector3 targetPosition = transform.position + direction * WValue(minRange, maxRange, normalizedLoad) * robot.launchForce;
        Tween.Position(hook.transform, targetPosition, duration, 0, null, Tween.LoopType.None, null, Return);
    }

    private float WValue(float minValue, float maxValue, float normalized)
    {
        return minValue + ((maxValue - minValue) * normalized);
    }

    public void Return()
    {
        hook.transform.SetParent(transform);
        Tween.Stop(hook.GetInstanceID());
        Tween.LocalPosition(hook.transform, Vector3.zero, duration, 0, null, Tween.LoopType.None, null, () => { prepared = true; robot.AddUpgrade(hook.GetUpgrade()); } );
    }
}
