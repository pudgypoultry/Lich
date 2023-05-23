using System.Collections.Generic;
using UnityEngine;

public class RitualOfStorms : BaseCard
{
    private void Awake()
    {
        this.id = "spellRitualOfStorms";
        this.cardName = "Ritual Of Storms";
        this.description = "The sky like glass, shattered and sundered, for but an instant. A display of power is given.";
        this.rank = CardRank.Null;
        this.type = CardType.Spell;
        this.cardImage = null;

        this.target = new List<CardType>()
        {
            CardType.Location,
            CardType.Ritual
        };

        this.keywords = new List<CardKeyword>()
        {
            CardKeyword.Location,
            CardKeyword.Conjuration,
            CardKeyword.Spell
        };
    }
}