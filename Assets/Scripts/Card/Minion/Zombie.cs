using System.Collections.Generic;
using UnityEngine;

public class Zombie : BaseCard
{
    private void Awake()
    {
        this.id = "minionZombie";
        this.cardName = "Zombie";
        this.description = "A failed experiment. You should have known such weak magicks would not hold the path to your salvation.";
        this.rank = CardRank.Two;
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
            CardKeyword.Minion
        };
    }
}