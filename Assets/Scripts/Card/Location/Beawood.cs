using System.Collections.Generic;

public class OakheartCathedral : BaseCard
{
    private void Awake()
    {
        this.id = "locationOakheartCathedral";
        this.cardName = "OakheartCathedral";
        this.description = "A holy site. One of the last to remain pure. A shame your salvation lies through it's corruption.";
        this.locationType = CardLocationType.ReligiousSite;
        this.type = CardType.Location;

        this.target = new List<CardType>
        {
            CardType.Null
        };
        
        this.keywords = new List<CardKeyword>()
        {
            CardKeyword.Location,
            CardKeyword.Quest
        };
    }
}
