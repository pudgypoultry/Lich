using System.Collections.Generic;
using UnityEngine;

public class Skeleton : BaseCard
{
    private void Awake()
    {
        this.id = "minionSkeleton";
        this.cardName = "Skeleton";
        this.description = "Simple constructs, and a painful reminder of things to come.";
        this.rank = CardRank.One;
        this.type = CardType.Minion;
        this.cardImage = null;
        this.attack = -1;
        this.defense = -1;

        this.target = new List<CardType>()
        {
            CardType.Location,
            CardType.Ritual
        };

        this.keywords = new List<CardKeyword>()
        {
            CardKeyword.Undead,
            CardKeyword.Minion
        };
    }
}