using System.Collections.Generic;
using UnityEngine;

public class NeowsLament : BaseCard
{
    private void Awake()
    {
        this.id = "itemNeowsLament";
        this.cardName = "Neow\'s Lament";
        this.description = "A gift, bestowed by a stranger, custodian of the Spire. Three souls to feed the ever beating heart.";
        this.rank = CardRank.Null;
        this.type = CardType.Item;
        this.cardImage = null;
        this.attack = -1;
        this.defense = -1;

        this.target = new List<CardTarget>()
        {
            CardTarget.Location,
        };

        this.keywords = new List<CardKeyword>()
        {
            CardKeyword.Item,
            CardKeyword.Enchantment
        };
    }
}