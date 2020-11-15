using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CardGame : MonoBehaviour
{
    int m_jackpotValue;
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

            foreach (Play play in plays_Against_player)
            {
                int indexOfTheCardPlayed = player_play.card.value;

                if (play.action == CardAction.attack)
                {
                    if (player_play.action == CardAction.defense)
                    {
                        indexOfTheCardPlayed -= play.card.value;
                        if (indexOfTheCardPlayed < 0)
                        {
                            //Destruimos la jugada y la carta de player_play.
                            player.GetComponent<CardPlayer>().m_Deck.Remove(player_play.card);
                            m_jackpotValue += player_play.card.value;
                            player_play = new Play(gameObject, null, CardAction.none, null);
                        }
                        else if (indexOfTheCardPlayed == 0)
                        {
                            //Destruimos todas las cartas involucradas.
                            player.GetComponent<CardPlayer>().m_Deck.Remove(player_play.card);
                            m_jackpotValue += player_play.card.value;
                            player_play = new Play(gameObject, null, CardAction.none, null);
                            player_play.chosenPlayer.GetComponent<CardPlayer>().m_Deck.Remove(play.card);
                            m_jackpotValue += play.card.value;
                            player_play.chosenPlayer.GetComponent<CardPlayer>().play = new Play(gameObject, null, CardAction.none, null);
                        }
                        else
                        {
                            //Se destruye la carta que te ataca.
                            player_play.chosenPlayer.GetComponent<CardPlayer>().m_Deck.Remove(play.card);
                            m_jackpotValue += play.card.value;
                            player_play.chosenPlayer.GetComponent<CardPlayer>().play = new Play(gameObject, null, CardAction.none, null);
                        }
                    }
                    else if (player_play.action == CardAction.attack)
                    {
                        //Se destruyen ambas cartas
                        player.GetComponent<CardPlayer>().m_Deck.Remove(player_play.card);
                        m_jackpotValue += player_play.card.value;
                        player_play = new Play(gameObject, null, CardAction.none, null);
                        player_play.chosenPlayer.GetComponent<CardPlayer>().m_Deck.Remove(play.card);
                        m_jackpotValue += play.card.value;
                        player_play.chosenPlayer.GetComponent<CardPlayer>().play = new Play(gameObject, null, CardAction.none, null);
                    }
                    else if (player_play.action == CardAction.steal)
                    {
                        //Destruir la player_play
                        player_play.chosenPlayer.GetComponent<CardPlayer>().m_Deck.Remove(play.card);
                        m_jackpotValue += play.card.value;
                        player_play.chosenPlayer.GetComponent<CardPlayer>().play = new Play(gameObject, null, CardAction.none, null);

                    }
                }
            }
        }

        //Steal Cards
        List<GameObject> m_thieves = new List<GameObject>();
        List<GameObject> m_victims = new List<GameObject>();
        foreach (GameObject player in m_players)
        {
            Play player_play = player.GetComponent<CardPlayer>().play;
            List<Play> plays_Against_player = player.GetComponent<CardPlayer>().m_playAgainstMe;

            List<Play> plays_thatWantToStealToMe_IcantBeliveYouDoneThis = new List<Play>();
            Stack<Play> plays_stealing_against = new Stack<Play>();
            Upgrade Aux_up = new Upgrade();
            Aux_up.value = -1;
            Play lowest_play = new Play(null, Aux_up, CardAction.none, null);
            List<int> index_doned = new List<int>();
            for (int i = 0; i < plays_Against_player.Count; i++)
            {
                if (plays_Against_player[i].action == CardAction.steal)
                {
                    plays_thatWantToStealToMe_IcantBeliveYouDoneThis.Add(plays_Against_player[i]);
                }
            }

            for (int i = 0; i < plays_thatWantToStealToMe_IcantBeliveYouDoneThis.Count; i++)
            {
                if (lowest_play.card.value > plays_thatWantToStealToMe_IcantBeliveYouDoneThis[i].card.value)
                {
                    lowest_play = plays_thatWantToStealToMe_IcantBeliveYouDoneThis[i];
                }
                if (i == plays_thatWantToStealToMe_IcantBeliveYouDoneThis.Count - 1)
                {
                    plays_stealing_against.Push(lowest_play);
                    plays_thatWantToStealToMe_IcantBeliveYouDoneThis.Remove(lowest_play);
                    i = 0;
                }
            }
            for (int i = 0; i < plays_stealing_against.Count; i++)
            {
                if (player.GetComponent<CardPlayer>().m_Deck.Count > 0)
                {
                    plays_stealing_against.Peek().player.GetComponent<CardPlayer>().m_stole = (player.GetComponent<CardPlayer>().m_Deck[Random.Range(0, player.GetComponent<CardPlayer>().m_Deck.Count)]);
                    plays_stealing_against.Pop();
                }
            }
        }

        foreach (GameObject player in m_players)
        {
            if(player.GetComponent<CardPlayer>().m_stole != null)
            {
                player.GetComponent<CardPlayer>().m_Deck.Add(player.GetComponent<CardPlayer>().m_stole);
                player.GetComponent<CardPlayer>().m_stole = null;
            }
        }
    }
}

