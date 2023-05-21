using System;
using System.Collections.Generic;
using UnityEngine;


public class SummonGerblin : BaseCard
{
    private void Awake()
    {
        this.id = "spellSummonGerblin";
        this.cardName = "Summon Gerblin";
        this.description = "Some call it a raiding party, But these fools just call it a party.";
        this.type = CardType.Spell;
        this.cardBackground = null;
        this.cardImage = null;

        this.target = new List<CardTarget>()
        {
            CardTarget.None
        };
        
        this.keywords = new List<CardKeyword>
        {
            CardKeyword.Spell,
            CardKeyword.Goblin,
            CardKeyword.Minion,
            CardKeyword.Summon
        };
    }

    public override void UseOnSacrifice()
    {
        base.UseOnSacrifice();
    }
}
