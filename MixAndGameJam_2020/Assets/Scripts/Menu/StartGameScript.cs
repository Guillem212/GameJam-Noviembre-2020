using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameScript : MonoBehaviour
{
    private int m_countPlayers;

    [SerializeField] private float m_secondsToWait = 2f;

    private void Start()
    {
        m_countPlayers = 0;
    }

    private void Update()
    {
        if(m_countPlayers >= InputManagerSystem.m_InputManagerSystem.m_players.Count && m_countPlayers != 0)
        {
            StartCoroutine(StartPlaying(m_secondsToWait));
        }
    }

    IEnumerator StartPlaying(float secondsToWait)
    {
        yield return new WaitForSeconds(secondsToWait);
        //Cambio de escena
        print("Se ha cambiado de escena!");
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Player"))
            m_countPlayers++;
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
            m_countPlayers--;
    }
}
