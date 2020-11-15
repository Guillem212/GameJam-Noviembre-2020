using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CardPlayer : MonoBehaviour
{
    public Play play;
    public List<Upgrade> m_Deck;
    public List<Play> m_playAgainstMe;


    private int m_CardIndex;
    private int m_EnemyIndex;
    private CardAction m_action;
    private GameObject[] players;
    private PlayerInput[] playersInputs;

    private void OnEnable()
    {
        m_Deck = GetComponent<Robot>().inventory;
        m_CardIndex = 0;
        m_EnemyIndex = -1;
        m_action = CardAction.none;
        m_playAgainstMe = new List<Play>();

        initializeEnemies();
    }

    private void initializeEnemies()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        playersInputs = new PlayerInput[players.Length];
        for (int i = 0; i < players.Length; i++)
        {
            playersInputs[i] = players[i].GetComponent<PlayerInput>();
        }
    }

    public void f_ChooseCard (float value)
    {
        if(value < 0)
        {
            m_CardIndex--;
            if(m_CardIndex < 0)
            {
                m_CardIndex = m_Deck.Count - 1;
            }
        }
        else if (value > 0)
        {
            m_CardIndex++;
            if (m_CardIndex > m_Deck.Count - 1)
            {
                m_CardIndex = 0;
            }
        }
    }

    public void f_ChooseEnemie(int index)
    {
        if(m_EnemyIndex == -1)
        {
            m_EnemyIndex = index;
        }

    }

    public void f_ChoosActionOfCard(CardAction action)
    {
        m_action = action;
        GetComponent<PlayerInput>().SwitchCurrentActionMap("CardsPlay");
    }

    /// <summary>
    /// When play is finished or tiems goes up, the player send the play.
    /// </summary>
    public void f_LaunchPlay()
    {
        if(m_EnemyIndex == -1 || m_action == CardAction.none)
        {
            int r = Random.Range(0, m_Deck.Count);
            m_Deck.RemoveAt(r);
            play = new Play(gameObject, null, CardAction.none, null);
        }
        else
        {
            GameObject enemy = null;
            for (int i = 0; i < playersInputs.Length; i++)
            {
                if (m_EnemyIndex == playersInputs[i].playerIndex)
                {
                    enemy = players[i];
                    break;
                }
            }
            play = new Play(gameObject, m_Deck[m_CardIndex], m_action, enemy);
            enemy.GetComponent<CardPlayer>().m_playAgainstMe.Add(play);
        }
    }
}
