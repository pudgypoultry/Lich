using System.Collections.Generic;
using UnityEngine;


public class Sleep : BaseCard
{
    private void Awake()
    {
        this.id = "spellSleep";
        this.cardName = "Sleep";
        this.description = "Lul their minds into the plane of dreams, so that you may go about your work in peace.";
        this.type = CardType.Spell;

        this.target = new List<CardType>()
        {
            CardType.Location,
            CardType.Event,
            CardType.Ritual
        };
        
        this.keywords = new List<CardKeyword>
        {
            CardKeyword.Spell,
        };
    }

    public override void UseOnSacrifice()
    {
        //_player.myDeck.PutCardAtBottom();
        base.UseOnSacrifice();
    }
}