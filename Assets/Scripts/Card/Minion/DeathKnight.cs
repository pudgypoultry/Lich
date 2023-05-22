using System.Collections.Generic;
using UnityEngine;

public class Knight : BaseCard
{
    private void Awake()
    {
        this.id = "minionKnight";
        this.cardName = "Death Knight";
        this.description = "Discovered in a long buried necropolis. Now a scourge let loose on the world.";
        this.rank = CardRank.Six;
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