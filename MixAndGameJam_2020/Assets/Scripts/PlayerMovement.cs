﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(PlayerInputs))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController m_Controller;
    private PlayerInputs m_Inputs;
    private Vector3 m_MoveDirection;
    private Robot robot;

    [Range(0, 1)] public float slow;
    [Range(1, 2)] public float dash;

    // Start is called before the first frame update
    void Start()
    {
        robot = GetComponent<Robot>();
        m_Inputs = GetComponent<PlayerInputs>();
        m_Controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
    }

    private void movePlayer()
    {
        float speed = robot.hook.isLoading ? robot.speed * slow : robot.speed;
        m_MoveDirection = new Vector3(m_Inputs.m_LeftStick.x, 0f, m_Inputs.m_LeftStick.y);
        m_MoveDirection = Camera.main.transform.TransformDirection(m_MoveDirection);
        m_MoveDirection.y = 0.0f;
        m_MoveDirection.Normalize();
        m_Controller.Move(m_MoveDirection * Time.deltaTime * speed);

        if (transform.position.y < 1f || transform.position.y > 1f)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, 1f, transform.position.z), Time.deltaTime * m_PlayerVelocity);
        }
    }

}
