using System.Collections.Generic;
using UnityEngine;

public class BookOfHours : BaseCard
{
    private void Awake()
    {
        this.id = "itemBookHours";
        this.cardName = "Book Of Hours";
        this.description = "Shutter the windows against the sea. Bank the fire against the cold. Listen to the rain rattle on the roof...";
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