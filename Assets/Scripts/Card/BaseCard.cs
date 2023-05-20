using UnityEngine;

namespace Card
{
    public abstract class BaseCard
    {
        #region Properties

        [Header("Card Fields")]
        // Fields
        public string name;
        public string id;
        public CardRarity rarity;
        public CardType type;
        public CardKeyword[] keywords;
        
        // Display stuff
        [Header("Display Elements")]
        public Sprite cardBackground;
        public Sprite cardImage;

        [TextArea(1,5)]
        public string description;

        #endregion

        #region Enums

        public enum CardType
        {
            Item,
            Minion,
            Location,
            Event,
            Spell
        }

        public enum CardRarity
        {
            Common,
            Uncommon,
            Rare,
            Legendary
        }

        public enum CardKeyword
        {
            Tool,
            Item,
            Death,
            Minion,
            Location,
            Event,
            Quest,
            Raid,
            Spell
        }

        public enum CardTarget
        {
            Self,
            None,
            All,
            Location,
            AllLocation,
            Event,
            AllEvent,
            SelfAndLocation,
            SelfAndEvent
        }

        #endregion

        #region Functions

        public abstract BaseCard MakeCopy();
        public abstract void Use();

        public override string ToString()
        {
            return this.name;
        }

        #endregion

        #region Debug
    
        public void PrintDebugInfo()
        {
            Debug.Log(name + ": " + description + ", ID:" + id + ", Type: " + type + ", Rarity:" + rarity);
        }

        #endregion
    }
}
