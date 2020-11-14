using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInputManager))]
public class InputManagerSystem : MonoBehaviour
{
    [SerializeField] private List<GameObject> m_players;

    public void OnPlayerJoined(PlayerInput player)
    {
        m_players.Add(player.gameObject);
    }
}
