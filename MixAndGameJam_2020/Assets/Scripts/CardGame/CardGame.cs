using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGame : MonoBehaviour
{
    PlayerInputs playerInputs;
    GameObject[] players;
    List<Play> m_Plays;
    //List<Play> m_PlaysInPlayerOrder;

    // Start is called before the first frame update
    void Start()
    {
        m_Plays = new List<Play>();
        players = GameObject.FindGameObjectsWithTag("Player");
        //m_PlaysInPlayerOrder = new List<Play>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void f_Conclusion()
    {
        for (int i = 0; i < m_Plays.Count; i++)
        {
            if (m_Plays[i].action == CardAction.attack)
            {
                if (m_Plays[i].chosenPlayer.GetComponent<CardPlayer>().play.action == CardAction.defense)
                {
                    if (m_Plays[i].value > m_Plays[i].chosenPlayer.GetComponent<CardPlayer>().play.value)
                    {
                        //m_Plays[i].chosenPlayer.GetComponent<CardPlayer>().
                    }
                    else
                    {
                        //me rompe la espada
                    }
                }
                if (m_Plays[i].chosenPlayer.GetComponent<CardPlayer>().play.action == CardAction.steal)
                {
                        //Le corto el robo y le rompa su carta de robo
                }
                if(m_Plays[i].chosenPlayer.GetComponent<CardPlayer>().play.action == CardAction.attack)
                {
                    if (m_Plays[i].value > m_Plays[i].chosenPlayer.GetComponent<CardPlayer>().play.value)
                    {
                        //Le rompo la espada
                    }
                    else
                    {
                        //me rompe la espada
                    }
                }
            }
        }
        for (int i = 0; i < m_Plays.Count; i++)
        {
            if (m_Plays[i].action == CardAction.steal)
            {
                if (m_Plays[i].chosenPlayer.GetComponent<CardPlayer>().play.action == CardAction.defense)
                {
                    //le robo
                }
                if (m_Plays[i].chosenPlayer.GetComponent<CardPlayer>().play.action == CardAction.steal)
                {
                    //le robo
                }
                if (m_Plays[i].chosenPlayer.GetComponent<CardPlayer>().play.action == CardAction.attack)
                {
                    if (m_Plays[i].value > m_Plays[i].chosenPlayer.GetComponent<CardPlayer>().play.value)
                    {
                        //Le rompo la espada
                    }
                    else
                    {
                        //me rompe la espada
                    }
                }
            }
        }

    }

    public void AddPlays(Play play)
    {
        foreach (GameObject item in players)
        {
            m_Plays.Add(item.GetComponent<CardPlayer>().play);
        }
        f_Conclusion();
    }
}

