using System.Collections.Generic;
using UnityEngine;

public class ItemDeath : BaseCard
{
    private void Awake()
    {
        this.id = "itemDeath";
        this.cardName = "Death";
        this.description = "The deed is done. Your death was inevitable. But now you sit among their ranks, unending.";
        this.rank = CardRank.Zero;
        this.type = CardType.Item;
        this.cardBackground = null;
        this.cardImage = null;

        this.target = new List<CardType>()
        {
            CardType.Ritual
        };

        this.keywords = new List<CardKeyword>()
        {
            CardKeyword.Death,
            CardKeyword.Item,
            CardKeyword.Spirit,
            CardKeyword.Quest
        };
    }
}