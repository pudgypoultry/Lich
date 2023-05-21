using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCard : MonoBehaviour
{
    #region Properties

    [Header("Card Fields")]
    // Fields
    public string cardName;
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
        Spell,
        Death
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

    public virtual GameObject MakeCopy()
    {
        // We could make this shuffle directly into the deck instead
        GameObject selfCopy = Instantiate(gameObject, transform.parent);
        return selfCopy;
    }

    public virtual void Use()
    {
        Debug.Log("YOU HAVEN'T MADE A USE FUNCTION FOR " + transform.name);
    }

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

