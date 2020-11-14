using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMovement), typeof(CardPlayer))]
public class PlayerInputs : MonoBehaviour
{

    private PlayerMovement m_PlayerMovement;
    private CardPlayer m_CardPlayer;
    public Vector2 m_LeftStick;
    public Vector2 m_RightStick;

    private void Start()
    {
        m_CardPlayer = GetComponent<CardPlayer>();
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

    }

    public void OnHook(InputValue value)
    {

    }

    //---------------------------------------------------------
    //INPUTS CARD GAME
    //---------------------------------------------------------
    public void OnSelectCard(InputValue value)
    {
        m_CardPlayer.f_ChooseCard(value.Get<Vector2>().x);
    }

    public void OnAttack(InputValue value) 
    {
        m_CardPlayer.f_ChoosActionOfCard(CardAction.attack);
    }

    public void OnSteal(InputValue value)
    {
        m_CardPlayer.f_ChoosActionOfCard(CardAction.steal);
    }
    public void OnDefend(InputValue value)
    {
        m_CardPlayer.f_ChoosActionOfCard(CardAction.defense);
    }
    public void OnAttackPlayerX(InputValue value)
    {
        m_CardPlayer.f_ChooseEnemie(0);
    }
    public void OnAttackPlayerY(InputValue value)
    {
        m_CardPlayer.f_ChooseEnemie(1);
    }
    public void OnAttackPlayerB(InputValue value)
    {
        m_CardPlayer.f_ChooseEnemie(2);
    }
    public void OnAttackPlayerA(InputValue value)
    {
        m_CardPlayer.f_ChooseEnemie(3);
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
