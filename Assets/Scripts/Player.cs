using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Deck myDeck;

    // The thing that lets players interact with objects on the board via the mouse
    public MouseInteractionHandler boardManager;

    public bool isDead = false;

    // The 4 slots that a location can be placed into and the locations currently filling those slots
    public List<InteractableBox> locationSlots;
    public List<InteractableBox> locations;

    // The 3 slots that a relic can be placed into and the locations currently filling those slots
    public List<InteractableBox> relicSlots;
    public List<InteractableBox> relics;

    // Tracks all cards currently in play
    public List<BaseCard> cardsInPlay = new List<BaseCard>();

    // Tracks all cards that have been discarded from play
    public List<BaseCard> cardsInGraveyard = new List<BaseCard>();

    // Tracks the immediate-use location
    public InteractableBox ritualCircle;

    public GameObject drawPosition;


    private void Start()
    {
        locationSlots = new List<InteractableBox> { null, null, null, null };
        locations = new List<InteractableBox> { null, null, null, null };
        relicSlots = new List<InteractableBox> { null, null, null };
        relics = new List<InteractableBox> { null, null, null };

        // Testing

        BaseCard currentCard = myDeck.Draw();
        Debug.Log("Current card is: " + currentCard.name);
        AddCardToPlay(currentCard);
        Debug.Log("Added " + currentCard.name + " to play!");
        Instantiate(currentCard, drawPosition.transform.position, Quaternion.identity);
        Debug.Log("Instantiated " + currentCard.name + " at location " + drawPosition);


    }


    public void AddCardToPlay(BaseCard card)
    {
        cardsInPlay.Add(card);
    }

    public void RemoveCardFromPlay(BaseCard card)
    {
        cardsInPlay.Remove(card);
    }

    public void AddRelic(InteractableBox relic)
    {
        relics.Add(relic);
    }

    public void RemoveRelic(InteractableBox relic)
    {
        relics.Remove(relic);
    }

    public void AddLocation(InteractableBox box)
    {
        relics.Add(box);
    }

    public void RemoveLocation(InteractableBox box)
    {
        relics.Remove(box);
    }

    public void AddCardToGraveyard(BaseCard card)
    { 
        cardsInGraveyard.Add(card);
    }

    public void RemoveCardFromGraveyard(BaseCard card)
    {
        cardsInGraveyard.Add(card);
    }

    public void EndTurnProcess()
    {
        // Turn off player control
        boardManager.TakeAwayControl();

        // Check for relic effects that apply at end of turn
        foreach (InteractableBox relic in relics)
        {
            if (relic != null)
            { 
                // Run that relic's end turn effect
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
        foreach (InteractableBox box in locations)
        {
            if (box != null)
            {
                box.SlottedCardUse();
            }
        }

        // If no cards in deck, lose
        if (myDeck.GetSize() == 0)
        {
            isDead = true;
            return;
        }

        // Draw a card, instantiate it, then place it in the middle of the play area
        BaseCard drawnCard = myDeck.Draw();
        Instantiate(drawnCard, drawPosition.transform.position, Quaternion.identity);
        AddCardToPlay(drawnCard);



        // Give back control to the player
        boardManager.GiveControl();


    }

}

