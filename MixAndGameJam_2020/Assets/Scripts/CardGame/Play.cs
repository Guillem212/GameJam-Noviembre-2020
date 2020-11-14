using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum CardAction { attack, defense, steal, none };

public struct Play
{
    public GameObject player;
    public int value;
    public CardAction action;
    public GameObject chosenPlayer;
    public bool win;

    public Play(GameObject player, int value, CardAction action, GameObject chosenPlayer, bool win)
    {
        this.player = player;
        this.value = value;
        this.action = action;
        this.chosenPlayer = chosenPlayer;
        this.win = win;
    }
}
