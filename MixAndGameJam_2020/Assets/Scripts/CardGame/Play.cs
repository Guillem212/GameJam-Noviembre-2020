using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum CardAction { attack, defense, steal, none };

public struct Play
{
    public GameObject player;
    public Upgrade card;
    public CardAction action;
    public GameObject chosenPlayer;

    public Play(GameObject player, Upgrade card, CardAction action, GameObject chosenPlayer)
    {
        this.player = player;
        this.card = card;
        this.action = action;
        this.chosenPlayer = chosenPlayer;
    }
}
