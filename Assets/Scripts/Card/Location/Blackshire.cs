using System.Collections.Generic;

public class Blackshire : BaseCard
{
    private void Awake()
    {
        this.id = "locationBlackshire";
        this.cardName = "Blackshire";
        this.description = "Rotten, Corrupt to the core. But wealth passes through like a roaring river.";
        this.locationType = CardLocationType.City;
        this.rank = CardRank.One;
        this.type = CardType.Location;

        this.target = new List<CardTarget>
        {
            CardTarget.None
        };
        
        this.keywords = new List<CardKeyword>()
        {
            CardKeyword.Location,
        };
    }
}