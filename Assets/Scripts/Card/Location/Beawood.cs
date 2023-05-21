using System.Collections.Generic;

public class Beawood : BaseCard
{
    private void Awake()
    {
        this.id = "locationBeawood";
        this.cardName = "Beawood";
        this.description = "He's a good ol' gerbly boi.";
        this.locationType = CardLocationType.Village;
        this.rank = CardRank.One;
        this.type = CardType.Location;
        this.cardBackground = null;
        this.cardImage = null;
        this.attack = -1; // Set to -1 for now
        this.defense = -1; // set to -1 for now
        
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
