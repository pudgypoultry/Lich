using System.Collections.Generic;
using UnityEngine;

public class Cough : BaseCard
{
    private void Awake()
    {
        this.id = "deathCough";
        this.cardName = "Cough";
        this.description = "Your hankerchief, now stained with a visual reminder of your mortality. The end is near";
        this.rank = CardRank.Two;
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