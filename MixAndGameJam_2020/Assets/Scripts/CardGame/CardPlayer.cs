using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CardPlayer : MonoBehaviour
{
    public Play play;
    List<Upgrade> m_Deck;
    int m_CardIndex;
    int m_EnemyIndex;
    CardAction m_action;
    CardGame m_cardGame;
    GameObject[] players;
    PlayerInput[] playersInputs;

// Start is called before the first frame update
public void CardGameStart()
    {

        m_Deck = GetComponent<Robot>().inventory;
        m_cardGame = GetComponent<CardGame>();
        m_CardIndex = 0;
        m_EnemyIndex = -1;
        m_action = CardAction.none;
        players = GameObject.FindGameObjectsWithTag("Player");
        playersInputs = new PlayerInput[players.Length];
        for (int i = 0; i < players.Length; i++)
        {
            playersInputs[i] = players[i].GetComponent<PlayerInput>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
            if (m_action != CardAction.none) f_LaunchPlay();
        }

    }

    public void f_ChoosActionOfCard(CardAction action)
    {
        m_action = action;
        if (m_EnemyIndex != -1) f_LaunchPlay();
    }

    void f_LaunchPlay()
    {
        if(m_EnemyIndex == -1 || m_action == CardAction.none)
        {
            int r = Random.Range(0, m_Deck.Count);
            m_Deck.RemoveAt(r);
            play = new Play(gameObject, -1, CardAction.none, null);
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
            play = new Play(gameObject, m_Deck[m_CardIndex].value, m_action, enemy);
        }
    }
}
