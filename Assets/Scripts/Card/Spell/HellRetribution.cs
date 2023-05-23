using System.Collections.Generic;
using UnityEngine;


public class HellRetribution : BaseCard
{
    private void Awake()
    {
        this.id = "spellHellRetribution";
        this.cardName = "Hell's Retribution";
        this.description = "The heaven's have wrath. But the denizens below have a fury unmatched.";
        this.type = CardType.Spell;

        this.target = new List<CardTarget>()
        {
            CardTarget.Location
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