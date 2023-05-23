using System.Collections.Generic;
using UnityEngine;

public class Shade : BaseCard
{
    private void Awake()
    {
        this.id = "minionShade";
        this.cardName = "Shade";
        this.description = "A spirit, poorly bound. Regularly flickers from this life to the next.";
        this.rank = CardRank.Two;
        this.type = CardType.Minion;
        this.cardImage = null;
        this.attack = -1;
        this.defense = -1;

        this.target = new List<CardType>()
        {
            CardType.Location,
            CardType.Ritual
        };

        this.keywords = new List<CardKeyword>()
        {
            CardKeyword.Undead,
            CardKeyword.Spirit,
            CardKeyword.Minion
        };
    }
}