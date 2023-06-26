using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBox
{
    Transform transform { get; }
    GameObject gameObject { get; }

    int MaxSlots { get; }
    int NumSlotsFull { get; set; }
    float SlotHeightOffset { get; set; }
    float SlotZOffset { get; set; }
    bool AnySlotsFull { get; set; }
    bool AllSlotsFull { get; set; }
    List<ISlottable> CardsInSlots { get; set; }
    List<Collider> SlotColliders { get; set; }
    List<Vector3> SlotPositions { get; set; }

    BaseCard Card()
    {
        return gameObject.GetComponent<BaseCard>();
    }

    BaseCard.CardType CardType()
    {
        return Card().type;
    }

    // Every box needs a way to fill a slot
    // Returns position that card needs to sit in
    Vector3 FillSlot(Collider col, ISlottable cardToSlot) 
    {

        if (SlotColliders.Contains(col))
        { 
            // Slotted parent needs to be set
            // Slotted needs to be set to true
            int index = SlotColliders.IndexOf(col);
            CardsInSlots[index] = cardToSlot;
            cardToSlot.SlottedParent = transform;
            cardToSlot.Slotted = true;
            cardToSlot.CurrentSlot = this;
            NumSlotsFull++;
            AnySlotsFull = true;
            AllSlotsFull = true;
            for (int i = 0; i < CardsInSlots.Count; i++)
            {
                if (CardsInSlots[i] == null)
                {
                    AllSlotsFull = false;
                }
            }
            
        }
        return new Vector3(col.transform.position.x, SlotHeightOffset, col.transform.position.z);
    }

    // Every box needs a way to empty a slot
    void EmptySlot(ISlottable cardToRemove) 
    { 
        int index = CardsInSlots.IndexOf(cardToRemove);
        CardsInSlots[index] = null;
        cardToRemove.SlottedParent = null;
        cardToRemove.Slotted = false;
        cardToRemove.CurrentSlot = null;

        NumSlotsFull--; 
        AllSlotsFull = false;
        AnySlotsFull = false;
        for (int i = 0; i < CardsInSlots.Count; i++)
        {
            if (CardsInSlots[i] != null)
            {
                AnySlotsFull = true;
            }
        }
    }

    // Every box needs to be able to use a card in its slot
    void UseCardInSlot() { }

}
