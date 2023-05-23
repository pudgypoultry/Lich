using System.Collections.Generic;
using UnityEngine;

public class BookOfHours : BaseCard
{
    private void Awake()
    {
        this.id = "itemBookHours";
        this.cardName = "Book Of Hours";
        this.description = "Shutter the windows against the sea. Bank the fire against the cold. Listen to the rain rattle on the roof...";
        this.rank = CardRank.Null;
        this.type = CardType.Item;
        this.cardImage = null;
        this.attack = -1;
        this.defense = -1;

        this.target = new List<CardType>()
        {
            CardType.Null
        };

        this.keywords = new List<CardKeyword>()
        {
            CardKeyword.Item
        };
    }
}