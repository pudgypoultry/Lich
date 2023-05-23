using System.Collections.Generic;
using UnityEngine;

public class Charm : BaseCard
{
    private void Awake()
    {
        this.id = "spellCharm";
        this.cardName = "Charm";
        this.description = "Words spoken in alleys, often more impactful than those spoken from a podium.";
        this.rank = CardRank.Null;
        this.type = CardType.Spell;
        this.cardImage = null;

        this.target = new List<CardType>()
        {
            CardType.Event,
        };

        this.keywords = new List<CardKeyword>()
        {
            CardKeyword.Enchantment,
            CardKeyword.Event,
            CardKeyword.Spell,
            CardKeyword.Quest
        };
    }
}