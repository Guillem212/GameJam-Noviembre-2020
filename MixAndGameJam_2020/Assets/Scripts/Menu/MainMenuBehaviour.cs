using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainMenuBehaviour : MonoBehaviour
{
    public GameObject c_MainMenu;

    public void OnClickStart()
    {
        //TODO: Animacion de fade out del menu.
        c_MainMenu.SetActive(false);

        GameManager.m_GameManager.GetComponent<PlayerInputManager>().EnableJoining();
    }

    private void Start()
    {
        GameManager.m_GameManager.GetComponent<PlayerInputManager>().EnableJoining();

    }
}
