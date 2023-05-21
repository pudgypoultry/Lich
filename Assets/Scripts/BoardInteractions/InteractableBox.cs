using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableBox : Interactable
{

    public void SlottedCardUse()
    {
        foreach (Transform card in cardsInSlots)
        {
            card.gameObject.GetComponent<BaseCard>().Use();
        }
    }

    public override void AddCardToSlot(Transform cardToAdd)
    {
        cardsInSlots.Add(cardToAdd);
        Debug.Log(transform.name + " just added " + cardToAdd.name + " to its slot!");
    }

    public void RemoveCardFromSlot(Transform cardToRemove)
    { 
        cardsInSlots.Remove(cardToRemove);
        Debug.Log(transform.name + " just removed " + cardToRemove.name + " from its slot!");
    }


}
