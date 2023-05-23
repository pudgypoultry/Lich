using System.Collections.Generic;
using UnityEngine;

public class Demon : BaseCard
{
    private void Awake()
    {
        this.id = "minionDemon";
        this.cardName = "Lord Of The Pit";
        this.description = "These things come at a cost, My summoning begins your debt, Necromancer";
        this.rank = CardRank.Seven;
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
            CardKeyword.Demon,
            CardKeyword.Minion
        };
    }
}