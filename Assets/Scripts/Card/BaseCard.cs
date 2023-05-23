using System;
using System.Collections.Generic;
using UnityEngine;

public class BaseCard : MonoBehaviour
{
    #region Properties

    [Header("Card Fields")]
    // Fields

    protected Player PlayerManager;
    
    public string cardName = string.Empty;
    
    public string id = string.Empty;
    
    public CardRarity rarity = CardRarity.Null;
    
    public CardType type = CardType.Null;
    
    public List<CardKeyword> keywords = new List<CardKeyword>();
    
    public CardDamageType damageType = CardDamageType.Null;

    public List<CardTarget> target = new List<CardTarget>();

    public CardLocationType locationType = CardLocationType.Null;
    
    public CardRank rank = CardRank.Null;

    public int attack = -1;
    
    public int defense = -1;

    // Display stuff
    [Header("Display Elements")] public Sprite cardBackground;
    public Sprite cardImage;

    [TextArea(1, 5)] public string description;

    #endregion

    #region Enums

    public enum CardType
    {
        Null,
        Item,
        Minion,
        Location,
        Event,
        Spell,
        Death,
    }

    public enum CardRarity
    {
        Null,
        Common,
        Uncommon,
        Rare,
        Legendary
    }

    public enum CardKeyword
    {
        Null,
        Death,
        Event,
        Goblin,
        Demon,
        Undead,
        Item,
        Location,
        Minion,
        Summon,
        Quest,
        Raid,
        RitualComponent,
        Alteration,
        Abjuration,
        Conjuration,
        Divination,
        Enchantment,
        Illusion,
        Invocation,
        Necromancy,
        Spell,
        Spirit,
        Tool,
    }

    public enum CardLocationType
    {
        Null,
        Hamlet,
        Village,
        Town,
        SmallCity,
        City,
        Metropolis,
        ReligiousSite
    }

    public enum CardTarget
    {
        Null,
        Self,
        None,
        All,
        Location,
        Minion,
        AllMinion,
        AllLocation,
        Event,
        AllEvent,
        Sacrifice,
        SelfAndLocation,
        SelfAndEvent
    }

    public enum CardDamageType
    {
        Null,
        Physical,
        Spiritual,
        Energy,
        Fire,
        Ice,
        Shock,
        Death,
    }

    // Consider changing this.
    public enum CardRank
    {
        Null,
        Zero,
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
    }

    #endregion

    #region Functions

    private void Start()
    {
        PlayerManager = GameObject.FindObjectOfType<Player>();
    }

    /// <summary>
    /// Makes a game object copy of the current card.
    /// </summary>
    /// <returns>Copy of current gameobject</returns>
    public virtual GameObject MakeCopy()
    {
        // We could make this shuffle directly into the deck instead
        GameObject selfCopy = Instantiate(gameObject, transform.parent);
        return selfCopy;
    }

    /// <summary>
    /// void Use() -
    /// Call when using card on ritual circle, Default Use
    /// </summary>
    public virtual void Use()
    {
        Debug.Log("YOU HAVEN'T MADE A USE FUNCTION FOR " + transform.name);
    }
    
    /// <summary>
    /// Called when the card is drawn.
    /// </summary>
    public virtual void UseOnDraw()
    {
        Debug.Log("YOU HAVEN'T MADE A USE_ON_DRAW FUNCTION FOR " + transform.name);
    }

    /// <summary>
    /// Called by sacrifice slot on turn end
    /// </summary>
    public virtual void UseOnSacrifice()
    {
        Debug.Log("YOU HAVEN'T MADE A USE_ON_SACRIFICE FUNCTION FOR " + transform.name);
    }
    
    /// <summary>
    /// Called by location slot on turn end
    /// </summary>
    public virtual void UseOnLocation()
    {
        Debug.Log("YOU HAVEN'T MADE A USE_ON_LOCATION FUNCTION FOR " + transform.name);
    }

    /// <summary>
    /// Called by Event slot on turn end
    /// </summary>
    public virtual void UseOnEvent()
    {
        Debug.Log("YOU HAVEN'T MADE A USE_ON_EVENT FUNCTION FOR " + transform.name);
    }

    /// <summary>
    /// Called by Quest slot on turn end
    /// </summary>
    public virtual void UseOnQuest()
    {
        Debug.Log("YOU HAVEN'T MADE A USE_ON_QUEST FUNCTION FOR " + transform.name);
    }

    /// <summary>
    /// Called by locations on turn end.
    /// </summary>
    public virtual void OnTurnEnd()
    {
        Debug.Log("YOU HAVEN'T MADE A ON_TURN_END FUNCTION FOR " + transform.name);
    }

    /// <summary>
    /// Returns the name of the current game object as a string
    /// </summary>
    /// <returns>GameObject as a string</returns>
    public override string ToString()
    {
        return transform.name;
    }

    #endregion

    #region Debug
    
    public void PrintDebugInfo()
    {
        Debug.Log(name + ": " + description + ", ID:" + id + ", Type: " + type + ", Rarity:" + rarity);
    }

    #endregion
}