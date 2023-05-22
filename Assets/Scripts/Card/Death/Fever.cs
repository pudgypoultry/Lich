using System.Collections.Generic;
using UnityEngine;

public class Fever : BaseCard
{
    private void Awake()
    {
        this.id = "deathFever";
        this.cardName = "Fever";
        this.description = "Like roiling fire, your skin is clammy and pale. This is an ill omen.";
        this.rank = CardRank.Five;
        this.type = CardType.Death;
        this.cardImage = null;

        this.target = new List<CardTarget>()
        {
            CardTarget.Self
        };

        this.keywords = new List<CardKeyword>()
        {
            CardKeyword.Death,
            CardKeyword.Quest
        };
    }
}
