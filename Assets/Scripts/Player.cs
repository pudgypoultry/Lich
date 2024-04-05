using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("===The Deck===")]
    public Deck myDeck;
    

    // The thing that lets players interact with objects on the board via the mouse
    [Header("===Mouse Interactivity===")]
    public MouseInteractionHandler boardManager;


    [Header("===GameBoard Slots===")]
    // The 4 slots that a location can be placed into and the locations currently filling those slots
    public List<GameObject> locationSlots;
    public List<GameObject> locations;

    // The 3 slots that a relic can be placed into and the locations currently filling those slots
    public List<GameObject> relicSlots;
    public List<GameObject> relics;

    public IBox ritualCircle;

    [Header("===Pieces In Play===")]
    // Tracks all cards currently in play
    public List<BaseCard> cardsInPlay = new List<BaseCard>();

    // Tracks all cards that have been discarded from play
    public List<BaseCard> cardsInGraveyard = new List<BaseCard>();

    // Tracks the immediate-use location

    [Header("===This is where cards end up when kicked out===")]
    public GameObject drawPosition;

    private List<GameObject> cardReferences;

    public bool isDead = false;

    public List<GameObject> allCards = new List<GameObject>();


    private void Start()
    {
        locationSlots = new List<GameObject> { null, null, null, null };
        locations = new List<GameObject> { null, null, null, null };
        relicSlots = new List<GameObject> { null, null, null };
        relics = new List<GameObject> { null, null, null };

        // Testing
        /*
        BaseCard currentCard = myDeck.Draw();
        Debug.Log("Current card is: " + currentCard.name);
        AddCardToPlay(currentCard);
        Debug.Log("Added " + currentCard.name + " to play!");
        Instantiate(currentCard, drawPosition.transform.position, Quaternion.identity);
        Debug.Log("Instantiated " + currentCard.name + " at location " + drawPosition);
        */
    }


    public void AddCardToPlay(BaseCard card)
    {
        cardsInPlay.Add(card);
    }

    public void RemoveCardFromPlay(BaseCard card)
    {
        cardsInPlay.Remove(card);
    }

    public void AddRelic(GameObject relic)
    {
        relics.Add(relic);
    }

    public void RemoveRelic(GameObject relic)
    {
        relics.Remove(relic);
    }

    public void AddLocation(GameObject box)
    {
        locations.Add(box);
    }

    public void RemoveLocation(GameObject box)
    {
        locations.Remove(box);
    }

    public void AddCardToGraveyard(BaseCard card)
    { 
        cardsInGraveyard.Add(card);
    }

    public void RemoveCardFromGraveyard(BaseCard card)
    {
        cardsInGraveyard.Add(card);
    }

    public BaseCard GetCardReferenceByID(string desiredCardID)
    {
        BaseCard return_card = null;

        foreach (BaseCard card in myDeck.cards)
        {
            if (card.id == desiredCardID)
            {
                return_card = card;
            }
        }

        return return_card;
    }

    public void EndTurnProcess()
    {
        Debug.Log("End of turn process has begun");
        // Turn off player control
        boardManager.TakeAwayControl();

        // If no cards in deck, lose
        if (myDeck.GetSize() == 0)
        {
            isDead = true;
            return;
        }

        // Check for relic effects that apply at end of turn

        if (relics.Count > 0)
        {
            foreach (GameObject obj in relics)
            {
                if (obj != null)
                {
                    IBox box = obj.GetComponent<IBox>();
                    if (box != null)
                    {
                        box.UseCardInSlot();
                    }
                }
            }
        }

        // Check for events via "cardsInPlay" and checking their CardType
        foreach (BaseCard card in cardsInPlay)
        {
            if (card.type == BaseCard.CardType.Event)
            { 
                // Run that card's end of turn effect
            }
        }

        // Loop through all locationSlots, and if they aren't null, call the box's SlottedCardUse()
        if (locations.Count > 0)
        {
            foreach (GameObject obj in locations)
            {
                if (obj != null)
                {
                    IBox box = obj.GetComponent<IBox>();
                    if (box != null)
                    {
                        box.UseCardInSlot();
                    }
                }
            }
        }

        // Draw a card, instantiate it, then place it in the middle of the play area
        BaseCard drawnCard = myDeck.Draw();
        Instantiate(drawnCard, drawPosition.transform.position, Quaternion.identity);
        AddCardToPlay(drawnCard);



        // Give back control to the player
        boardManager.GiveControl();

        Debug.Log("End of turn process has concluded");
    }

}

