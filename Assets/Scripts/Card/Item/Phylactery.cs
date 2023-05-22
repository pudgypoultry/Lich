using System;
using System.Collections.Generic;

public class Phylactery : BaseCard
{
    private void Awake()
    {
        this.id = "itemPhylactery";
        this.cardName = "Phylactery";
        this.description = "Finally your goal lies in reach. " +
                           "Do you still have the remaining vitality to see it through?";
        this.rank = CardRank.Null;
        this.type = CardType.Item;
        this.cardBackground = null;
        this.cardImage = null;

        this.target = new List<CardTarget>
        {
            CardTarget.None,
        };

        this.keywords = new List<CardKeyword>
        {
            CardKeyword.Item,
            CardKeyword.RitualComponent,
            CardKeyword.Spirit,
        };
    }

    public override void UseOnQuest()
    {
        base.UseOnQuest();
    }
}
