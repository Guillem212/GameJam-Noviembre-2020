using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGame : MonoBehaviour
{
    public enum cardType { attack, defense, steal };
    PlayerInputs playerInputs;
    List<Play> m_Plays;
    //List<Play> m_PlaysInPlayerOrder;

    // Start is called before the first frame update
    void Start()
    {
        m_Plays = new List<Play>();
        //m_PlaysInPlayerOrder = new List<Play>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void f_Conclusion()
    {
        foreach (Play playedCardByPlayer in m_Plays)
        {
            if(playedCardByPlayer.type == cardType.attack)
            {
               /* if(m_Plays[playedCardByPlayer.chosenPlayer-1].type == cardType.defense)
                {
                    m_Plays[playedCardByPlayer.chosenPlayer - 1].
                }*/
            }
        }
    }

    public void AddPlay(Play play)
    {
        m_Plays.Add(play);
        if(m_Plays.Count == 2) //InputManagerSystem.m_InputManagerSystem.m_players.Count
        {
            int index = 0;
            while(m_Plays.Count != 0)
            {
                if(m_Plays[index].player == index + 1)
                {
                    //m_PlaysInPlayerOrder.Add(m_Plays[index]);
                    m_Plays.RemoveAt(index);
                    index = 0;
                }
                index++;
            }
            f_Conclusion();
        }
    }

    public struct Play
    {
        public int player;
        public int value;
        public cardType type;
        public GameObject chosenPlayer;
        public bool win;


        public Play(int player, int value, cardType type, GameObject chosenPlayer, bool win)
        {
            this.player = player;
            this.value = value;
            this.type = type;
            this.chosenPlayer = chosenPlayer;
            this.win = win;
        }
    }
}

