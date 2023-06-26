using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISlottable
{
    Transform transform { get; }
    GameObject gameObject { get; }

    Transform OriginalParent { get; }
    IBox CurrentSlot { get; set; }
    IBox PotentialSlot { get; set; }
    Transform SlottedParent { get; set; }
    bool Slotted { get; set; }

    BaseCard Card()
    {
        return gameObject.GetComponent<BaseCard>();
    }

    List<BaseCard.CardType> CardTargets()
    {
        return Card().target;
    }

    // Every slottable card needs to be able to be added to a slot
    virtual void SlotIn(Collider col, IBox theSlot)
    {
        // Successfully dock, and upon success, set position to the resulting dock
        if (CardTargets().Contains(theSlot.CardType()) && !Slotted)
        {
            transform.position =  theSlot.FillSlot(col, this);
        }
    }

    // Every slottable card needs to be able to be removed from a slot
    virtual void SlotOut()
    {
        if (Slotted)
        {
            CurrentSlot.EmptySlot(this);
        }
    }

    // Every slottable card needs to be able to be used by its slot
    virtual void SlottedUse(IBox theSlot)
    {
        Debug.Log("You haven't given " + gameObject.name + "a SlottedUse()");
    }

}
