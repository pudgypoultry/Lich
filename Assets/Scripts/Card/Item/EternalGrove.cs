using System.Collections.Generic;
using UnityEngine;

public class EternalGrove : BaseCard
{
    private void Awake()
    {
        this.id = "itemEternalGrove";
        this.cardName = "Essence of the Eternal Grove";
        this.description = "Surrounded by death and decay, a lone tea maker, gardener, and caretaker of the dying.";
        this.rank = CardRank.Null;
        this.type = CardType.Item;
        this.cardImage = null;
        this.attack = -1;
        this.defense = -1;

        this.target = new List<CardTarget>()
        {
            CardTarget.Sacrifice,
        };

        this.keywords = new List<CardKeyword>()
        {
            CardKeyword.RitualComponent,
            CardKeyword.Item
        };
    }
}