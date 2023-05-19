using UnityEngine;

namespace Card
{
    public abstract class Card : MonoBehaviour
    {
        #region Properties

        [Header("Card Fields")]
        // Fields
        public new string name;
        public string id;
        
        
        // Display stuff
        public Sprite cardBackground;
        public Sprite cardImage;

        public CardRarity rarity;
        public CardType type;

        public CardKeyword[] keywords;
        
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

        #endregion

        #region Functions

        protected Card()
        {
            
        }

        public abstract Card MakeCopy();
        public abstract void Use();

        #endregion

        #region Debug
    
        public void PrintDebugInfo()
        {
            Debug.Log(name + ": " + description + ", ID:" + id + ", Type: " + type + ", Rarity:" + rarity);
        }

        #endregion
    }
}
