using System;
using System.Collections.Generic;
using UnityEngine;

public class Death : BaseCard
{
    private void Awake()
    {
        this.id = "deathDeath";
        this.cardName = "Death";
        this.description = "A woman, A black dog, final breaths. This is the end of your story. Death was inevitable, " +
                           "But the undying mistress is rarely willing to be usurped.";
        this.rank = CardRank.One;
        this.type = CardType.Death;
        this.cardImage = null;

        this.target = new List<CardType>()
        {
            CardType.Null
        };

        this.keywords = new List<CardKeyword>()
        {
            CardKeyword.Death,
            CardKeyword.Quest
        };
    }
}
