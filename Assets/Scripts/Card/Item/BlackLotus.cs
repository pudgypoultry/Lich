using System.Collections.Generic;
using UnityEngine;

public class BlackLotus : BaseCard
{
    private void Awake()
    {
        this.id = "itemBlackLotus";
        this.cardName = "Black Lotus";
        this.description = "No one petal claims beauty for the lotus.";
        this.rank = CardRank.Null;
        this.type = CardType.Item;
        this.cardImage = null;
        this.attack = -1;
        this.defense = -1;

        this.target = new List<CardType>()
        {
            CardType.Ritual,
        };

        this.keywords = new List<CardKeyword>()
        {
            CardKeyword.Item,
            CardKeyword.RitualComponent
        };
    }
}