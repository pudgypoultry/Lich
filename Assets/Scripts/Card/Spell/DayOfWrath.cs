using System.Collections.Generic;
using UnityEngine;


public class DayOfWrath : BaseCard
{
    private void Awake()
    {
        this.id = "spellDayOfWrath";
        this.cardName = "Day Of Wrath";
        this.description = "The destruction wrought today will be remembered. Only time will tell how.";
        this.type = CardType.Spell;

        this.target = new List<CardTarget>()
        {
            CardTarget.AllLocation
        };
        
        this.keywords = new List<CardKeyword>
        {
            CardKeyword.Spell,
            CardKeyword.Location
        };
    }

    public override void UseOnSacrifice()
    {
        //_player.myDeck.PutCardAtBottom();
        base.UseOnSacrifice();
    }
}