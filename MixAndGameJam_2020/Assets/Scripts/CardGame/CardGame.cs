using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CardGame : MonoBehaviour
{
    GameObject[] m_players;
    public float TIME = 10f;
    //List<Play> m_PlaysInPlayerOrder;

    // Start is called before the first frame update
    void Start()
    {
        m_players = GameObject.FindGameObjectsWithTag("Player");

        InputManagerSystem.m_InputManagerSystem.f_SetCurrentActionMap("CardsSelected");
        StartCoroutine(startFight(TIME));
    }

    private IEnumerator startFight(float timeToStartFigth)
    {
        yield return new WaitForSeconds(timeToStartFigth);
        foreach (GameObject player in m_players)
        {
            player.GetComponent<CardPlayer>().f_LaunchPlay();
        }
        f_ConcludePlay();
    }

    private void f_ConcludePlay()
    {
        foreach (GameObject player in m_players)
        {
            Play player_play = player.GetComponent<CardPlayer>().play;
            List<Play> plays_Against_player = player.GetComponent<CardPlayer>().m_playAgainstMe;


            foreach (Play play in plays_Against_player)
            {
                int indexOfTheCardPlayed = player_play.card.value;

                if (play.action == CardAction.attack)
                {
                    if(player_play.action == CardAction.defense)
                    {
                        indexOfTheCardPlayed -= play.card.value;
                        if (indexOfTheCardPlayed < 0)
                        {
                            //Destruimos la jugada y la carta de player_play.
                            player.GetComponent<CardPlayer>().play = new Play(gameObject, null, CardAction.none, null);
                            player.GetComponent<CardPlayer>().m_Deck.Remove(player_play.card);
                        }
                        else if (indexOfTheCardPlayed == 0)
                        {
                            //Destruimos todas las cartas involucradas.
                            player.GetComponent<CardPlayer>().m_Deck.Remove(player_play.card);
                            player_play.chosenPlayer.GetComponent<CardPlayer>().m_Deck.Remove(play.card);
                        }
                        else
                        {
                            //Se destruye la carta que te ataca.
                            player_play.chosenPlayer.GetComponent<CardPlayer>().m_Deck.Remove(play.card);
                        }
                    }
                    else if(player_play.action == CardAction.attack)
                    {
                        player.GetComponent<CardPlayer>().m_Deck.Remove(player_play.card);
                        player_play.chosenPlayer.GetComponent<CardPlayer>().m_Deck.Remove(play.card);
                        /* indexOfTheCardPlayed -= play.card.value;

                         if (indexOfTheCardPlayed < 0)
                         {
                             //Destruimos la jugada y la carta de player_play.
                             player_play.chosenPlayer.GetComponent<CardPlayer>().m_Deck.Remove(play.card);
                         }
                         else if (indexOfTheCardPlayed == 0)
                         {
                             //Destruimos todas las cartas involucradas.
                             player.GetComponent<CardPlayer>().m_Deck.Remove(player_play.card);
                             player_play.chosenPlayer.GetComponent<CardPlayer>().m_Deck.Remove(play.card);
                         }
                         else
                         {
                             //Se destruyen todas las cartas involucradas.
                         }
                        */
                    }
                    else if(player_play.action == CardAction.steal)
                    {
                        //Destruir la player_play
                        player_play.chosenPlayer.GetComponent<CardPlayer>().m_Deck.Remove(play.card);
                    }
                }
                else if (play.action == CardAction.steal)
                { 

                    if (player_play.action == CardAction.steal)
                    {

                    }
                }
            }
        }
    }
}

