using System.Collections.Generic;
using UnityEngine;


public class Haste : BaseCard
{
    private void Awake()
    {
        this.id = "spellHaste";
        this.cardName = "Haste";
        this.description = "With time so precious, one cannot afford to be idle.";
        this.type = CardType.Spell;

        this.target = new List<CardTarget>()
        {
            CardTarget.None
        };
        
        this.keywords = new List<CardKeyword>
        {
            CardKeyword.Spell,
            CardKeyword.Minion,
        };
    }

    public override void UseOnSacrifice()
    {
        //_player.myDeck.PutCardAtBottom();
        base.UseOnSacrifice();
    }
}