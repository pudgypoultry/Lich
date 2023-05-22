using System.Collections.Generic;
using UnityEngine;

public class Vampire : BaseCard
{
    private void Awake()
    {
        this.id = "minionVampire";
        this.cardName = "Vampire";
        this.description = "Clinging to life by a thread. Shackled to it by hunger. Shame really, they got half the job done.";
        this.rank = CardRank.Five;
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