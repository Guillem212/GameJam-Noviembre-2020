using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(PlayerInputs))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController m_Controller;
    private PlayerInputs m_Inputs;
    private Vector3 m_MoveDirection;


    /// <summary>
    /// Velocity of the player in a range of 0 to 20.
    /// </summary>
    [Range(1, 20)] public float m_PlayerVelocity;

    // Start is called before the first frame update
    void Start()
    {
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
        m_MoveDirection = new Vector3(m_Inputs.m_LeftStick.x, 0f, m_Inputs.m_LeftStick.y);
        m_MoveDirection = Camera.main.transform.TransformDirection(m_MoveDirection);
        m_MoveDirection.y = 0.0f;
        m_MoveDirection.Normalize();
        m_Controller.Move(m_MoveDirection * Time.deltaTime * m_PlayerVelocity);

        if (transform.position.y < 1f || transform.position.y > 1f)
        {
            transform.position = new Vector3(transform.position.x, 1f, transform.position.z);
        }
    }
}
