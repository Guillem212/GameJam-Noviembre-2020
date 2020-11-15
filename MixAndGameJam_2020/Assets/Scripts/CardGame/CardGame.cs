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

        GameManager.m_GameManager.m_InputManagerSystem.f_SetCurrentActionMap("CardsSelected");
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
            Stack<Play> plays_stealing_against = new Stack<Play>();
            Upgrade Aux_up = new Upgrade();
            Aux_up.value = -1;
            Play lowest_play = new Play(null, Aux_up, CardAction.none, null);
            for (int i = 0; i < plays_Against_player.Count; i++)
            {
                if (plays_Against_player[i].action == CardAction.steal)
                {
                    if(plays_Against_player[i] )
                }
            }



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
                            player.GetComponent<CardPlayer>().m_Deck.Remove(player_play.card);
                            player_play = new Play(gameObject, null, CardAction.none, null);
                        }
                        else if (indexOfTheCardPlayed == 0)
                        {
                            //Destruimos todas las cartas involucradas.
                            player.GetComponent<CardPlayer>().m_Deck.Remove(player_play.card);
                            player_play = new Play(gameObject, null, CardAction.none, null);
                            player_play.chosenPlayer.GetComponent<CardPlayer>().m_Deck.Remove(play.card);
                            player_play.chosenPlayer.GetComponent<CardPlayer>().play = new Play(gameObject, null, CardAction.none, null);
                        }
                        else
                        {
                            //Se destruye la carta que te ataca.
                            player_play.chosenPlayer.GetComponent<CardPlayer>().m_Deck.Remove(play.card);
                            player_play.chosenPlayer.GetComponent<CardPlayer>().play = new Play(gameObject, null, CardAction.none, null);
                        }
                    }
                    else if(player_play.action == CardAction.attack)
                    {
                        //Se destruyen ambas cartas
                        player.GetComponent<CardPlayer>().m_Deck.Remove(player_play.card);
                        player_play = new Play(gameObject, null, CardAction.none, null);
                        player_play.chosenPlayer.GetComponent<CardPlayer>().m_Deck.Remove(play.card);
                        player_play.chosenPlayer.GetComponent<CardPlayer>().play = new Play(gameObject, null, CardAction.none, null);
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

