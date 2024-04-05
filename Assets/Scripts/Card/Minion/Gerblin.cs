using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Gerblin : BaseCard
{
    private void Awake()
    {

        this.id = "minionGerblin";
        this.cardName = "Gerblin";
        this.description = "He's a good ol' gerbly boi.";
        this.rank = CardRank.One;
        this.type = CardType.Minion;
        this.cardBackground = null;
        this.cardImage = null;
        this.attack = 1;
        this.defense = 1;

        this.target = new List<CardType>()
        {
            CardType.Location,
            CardType.Event,
            CardType.Ritual
        };
        
        this.keywords = new List<CardKeyword>()
        {
            CardKeyword.Goblin,
            CardKeyword.Minion
        };

    }

    public override void UseOnLocation()
    {
        base.UseOnLocation();
    }

    public override void Use()
    {
        Debug.Log(this.name + " is using it's ability on sacrifice!");
        // Need to wait and allow animation to play before destroy once implemented
        Destroy(this.gameObject);
    }
}