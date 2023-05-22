using System.Collections.Generic;
using UnityEngine;

public class Wraith : BaseCard
{
    private void Awake()
    {
        this.id = "minionWraith";
        this.cardName = "Wraith";
        this.description = "Where shades find themselves torn between two planes of life, wraiths have harnessed that as a weapon.";
        this.rank = CardRank.Four;
        this.type = CardType.Minion;
        this.cardImage = null;
        this.attack = -1;
        this.defense = -1;

        this.target = new List<CardTarget>()
        {
            CardTarget.Location,
        };

        this.keywords = new List<CardKeyword>()
        {
            CardKeyword.Undead,
            CardKeyword.Spirit,
            CardKeyword.Minion
        };
    }
}