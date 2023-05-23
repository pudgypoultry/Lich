using System.Collections.Generic;
using UnityEngine;

public class Fatigue : BaseCard
{
    private void Awake()
    {
        this.id = "deathFatigue";
        this.cardName = "Fatigue";
        this.description = "The body grows weak. Worn down by the unseen ravager.";
        this.rank = CardRank.Four;
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