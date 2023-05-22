using System.Collections.Generic;
using UnityEngine;

public class Revenant : BaseCard
{
    private void Awake()
    {
        this.id = "minionRevenant";
        this.cardName = "Revenant";
        this.description = "A soul that has been infused with rage. Violent, and unwieldy. With direction however, efficient.";
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
            CardKeyword.Spirit,
            CardKeyword.Minion
        };
    }
}