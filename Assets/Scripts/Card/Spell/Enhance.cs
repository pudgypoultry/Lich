using System.Collections.Generic;
using UnityEngine;

public class Enhance : BaseCard
{
    private void Awake()
    {
        this.id = "spellEnhance";
        this.cardName = "Enhance";
        this.description = "The mindless hordes of minions are only so useful. " +
                           "Some however may prove worthwhile with a small investment";
        this.type = CardType.Spell;
        this.cardImage = null;

        this.target = new List<CardType>()
        {
            CardType.Minion
        };

        this.keywords = new List<CardKeyword>()
        {
            CardKeyword.Minion,
            CardKeyword.Spell,
            CardKeyword.Alteration
        };
    }
}