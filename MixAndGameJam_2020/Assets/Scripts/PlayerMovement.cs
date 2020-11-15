using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

[RequireComponent(typeof(CharacterController), typeof(PlayerInputs))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController m_Controller;
    private PlayerInputs m_Inputs;
    private Vector3 m_MoveDirection;
    private Robot robot;

    [Range(0, 1)] public float slow;
    [Range(0, 1)] public float dashSlow;

    // Start is called before the first frame update
    void Start()
    {
        robot = GetComponent<Robot>();
        m_Inputs = GetComponent<PlayerInputs>();
        m_Controller = GetComponent<CharacterController>();
        Tween.Position(transform, new Vector3(transform.position.x, 1f, transform.position.z), .3f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
    }

    private void movePlayer()
    {
        float propellerSpeed = robot.propeller.dashSpeed * robot.dashForce;
        float speed = robot.speed;
        if (robot.hook.isLoading)
        {
            speed *= slow;
            propellerSpeed *= dashSlow;
        }
        speed += propellerSpeed;
        m_MoveDirection = new Vector3(m_Inputs.m_LeftStick.x, 0f, m_Inputs.m_LeftStick.y);
        m_MoveDirection = Camera.main.transform.TransformDirection(m_MoveDirection);
        m_MoveDirection.y = 0.0f;
        m_MoveDirection.Normalize();
        m_Controller.Move(m_MoveDirection * Time.deltaTime * speed);
    }

}
