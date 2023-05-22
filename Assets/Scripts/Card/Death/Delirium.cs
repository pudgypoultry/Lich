using System.Collections.Generic;
using UnityEngine;

public class Delerium : BaseCard
{
    private void Awake()
    {
        this.id = "deathDelirium";
        this.cardName = "Delirium";
        this.description = "The world spins around you. Your memory wavers. " +
                           "Words become detached from their meaning. " +
                           "How much longer do you have left?";
        this.rank = CardRank.Three;
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