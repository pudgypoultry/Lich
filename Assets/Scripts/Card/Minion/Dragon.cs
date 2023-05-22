using System.Collections.Generic;
using UnityEngine;

public class Dragon : BaseCard
{
    private void Awake()
    {
        this.id = "minionDragon";
        this.cardName = "Zombie Dragon";
        this.description = "Magicks infused in such ancient bones can only be expected to enact the creatures bestial wrath.";
        this.rank = CardRank.Eight;
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