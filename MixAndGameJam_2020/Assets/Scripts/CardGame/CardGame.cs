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
                        m_Plays[i].win = true;
                    }
                }
            }
        }
        foreach (Play playByPlayer in m_Plays)
        {
            if(playByPlayer.action == CardAction.attack)
            {
                if(playByPlayer.chosenPlayer.GetComponent<CardPlayer>().play.action == CardAction.defense)
                {
                    if(playByPlayer.value > playByPlayer.chosenPlayer.GetComponent<CardPlayer>().play.value)
                    {
                        playByPlayer.win = true;
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

