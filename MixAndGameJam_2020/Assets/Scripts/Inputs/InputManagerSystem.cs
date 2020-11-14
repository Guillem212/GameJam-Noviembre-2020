using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInputManager))]
public class InputManagerSystem : MonoBehaviour
{
    public static InputManagerSystem m_InputManagerSystem;
    public List<PlayerInput> m_players;

    private void Awake()
    {
        if(m_InputManagerSystem != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            m_InputManagerSystem = this;
        }
    }
    public void OnPlayerJoined(PlayerInput player)
    {
        m_players.Add(player);
    }
    
    public void OnPlayerLeft(PlayerInput player)
    {
        m_players.Remove(player);
    }

    /// <summary>
    /// Get the current Action Map of all the players.
    /// </summary>
    /// <returns>String with the name of the current Action Map of all the players.</returns>
    public string f_GetCurrentActionMap()
    {
        return m_players[0].currentActionMap.name;
    }

    /// <summary>
    /// Switch to the Action map given of all the players.
    /// </summary>
    /// <param name="actionMap"></param>
    public void f_SetCurrentActionMap(string actionMap)
    {
        foreach (PlayerInput player in m_players)
        {
            player.SwitchCurrentActionMap(actionMap);
        }
    }
}
