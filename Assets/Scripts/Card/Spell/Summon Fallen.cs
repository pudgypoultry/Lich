using System.Collections.Generic;
using UnityEngine;


public class SummonFallen : BaseCard
{
    private void Awake()
    {
        this.id = "spellSummonFallen";
        this.cardName = "Summon Fallen";
        this.description = "This world, in all it's failings, has left you a plentiful supply of cadavers. " +
                           "An army, ripe for the harvest.";
        this.type = CardType.Spell;

        this.target = new List<CardType>()
        {
            CardType.Ritual
        };
        
        this.keywords = new List<CardKeyword>
        {
            CardKeyword.Spell,
            CardKeyword.Undead,
            CardKeyword.Minion,
            CardKeyword.Summon
        };
    }

    public override void UseOnSacrifice()
    {
        //this.PlayerManager.myDeck.PutCardAtBottom();
        base.UseOnSacrifice();
    }
}