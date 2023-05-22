﻿using System.Collections.Generic;

public class Beawood : BaseCard
{
    private void Awake()
    {
        this.id = "locationBeawood";
        this.cardName = "Beawood";
        this.description = "A small little village on the nations edge. " +
                           "Small as it may be, it held religious significance in the past.";
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
