using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    //---------------------------------------------------------
    //INPUTS FIGHT GAME
    //---------------------------------------------------------
    [HideInInspector] public Vector2 i_Move;
    [HideInInspector] public Vector2 i_HookDirection;
    [HideInInspector] public bool i_HookLaunched;
    public void OnMove(InputValue value)
    {
        i_Move = value.Get<Vector2>();
    }

    public void OnHookDirection(InputValue value)
    {
        i_HookDirection = value.Get<Vector2>();
    }

    public void OnMoOnHook(InputValue value)
    {
        i_HookLaunched = value.Get<bool>();
    }

    //---------------------------------------------------------
    //INPUTS CARD GAME
    //---------------------------------------------------------
    [HideInInspector] public Vector2 i_SelectCard;
    [HideInInspector] public bool i_Attack;
    [HideInInspector] public bool i_Defend;
    [HideInInspector] public bool i_Steal;
    [HideInInspector] public bool i_AttackPlayerX;
    [HideInInspector] public bool i_AttackPlayerY;
    [HideInInspector] public bool i_AttackPlayerB;
    [HideInInspector] public bool i_AttackPlayerA;
    public void OnSelectCard(InputValue value)
    {
        i_SelectCard = value.Get<Vector2>();
    }

    public void OnAttack(InputValue value)
    {
        i_Attack = value.Get<bool>();
    }

    public void OnSteal(InputValue value)
    {
        i_Steal = value.Get<bool>();

    }
    public void OnDefend(InputValue value)
    {
        i_Defend = value.Get<bool>();
    }
    public void OnAttackPlayerX(InputValue value)
    {
        i_AttackPlayerX = value.Get<bool>();
    }
    public void OnAttackPlayerY(InputValue value)
    {
        i_AttackPlayerY = value.Get<bool>();
    }
    public void OnAttackPlayerB(InputValue value)
    {
        i_AttackPlayerB = value.Get<bool>();
    }
    public void OnAttackPlayerA(InputValue value)
    {
        i_AttackPlayerA = value.Get<bool>();
    }

    //---------------------------------------------------------
    //INPUTS MENU
    //---------------------------------------------------------
    [HideInInspector] public Vector2 i_SelectColor;
    [HideInInspector] public bool i_Accept;
    [HideInInspector] public bool i_Decline;

    public void OnSelectColor(InputValue value)
    {
        i_SelectColor = value.Get<Vector2>();
    }
    public void OnAccept(InputValue value)
    {
        i_Accept = value.Get<bool>();
    }
    public void OnDecline(InputValue value)
    {
        i_Decline = value.Get<bool>();
    }
}
