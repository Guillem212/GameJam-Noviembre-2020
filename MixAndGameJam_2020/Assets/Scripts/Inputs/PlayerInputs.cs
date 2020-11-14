using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInputs : MonoBehaviour
{
    private PlayerMovement m_PlayerMovement;
    public Vector2 m_LeftStick;
    public Vector2 m_RightStick;

    public Robot robot;

    private void Start()
    {
        robot = GetComponent<Robot>();
        m_PlayerMovement = GetComponent<PlayerMovement>();
    }

    //---------------------------------------------------------
    //INPUTS FIGHT GAME
    //---------------------------------------------------------
    public void OnMove(InputValue value)
    {
        m_LeftStick = value.Get<Vector2>();
    }

    public void OnHookDirection(InputValue value)
    {
        robot.hook.Target(value.Get<Vector2>());
    }

    public void OnHookLoad(InputValue value)
    {
        robot.hook.Load();
    }

    public void OnHookRelease(InputValue value)
    {
        robot.hook.Release();
    }

    //---------------------------------------------------------
    //INPUTS CARD GAME
    //---------------------------------------------------------
    public void OnSelectCard(InputValue value)
    {
    }

    public void OnAttack(InputValue value)
    {

    }

    public void OnSteal(InputValue value)
    {

    }
    public void OnDefend(InputValue value)
    {

    }
    public void OnAttackPlayerX(InputValue value)
    {

    }
    public void OnAttackPlayerY(InputValue value)
    {

    }
    public void OnAttackPlayerB(InputValue value)
    {

    }
    public void OnAttackPlayerA(InputValue value)
    {

    }

    //---------------------------------------------------------
    //INPUTS MENU
    //---------------------------------------------------------
    public void OnSelectColor(InputValue value)
    {

    }
    public void OnAccept(InputValue value)
    {

    }
    public void OnDecline(InputValue value)
    {

    }
}
