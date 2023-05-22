using System.Collections.Generic;
using UnityEngine;

public class Ghoul : BaseCard
{
    private void Awake()
    {
        this.id = "minionGhoul";
        this.cardName = "Ghoul";
        this.description = "Unlike their shambling kin. These are but empty shells. Prime subjects for manufactured souls.";
        this.rank = CardRank.Three;
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