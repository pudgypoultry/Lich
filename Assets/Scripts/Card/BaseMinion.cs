using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMinion : Interactable, ISlottable, IUsable
{
    protected Transform slottedParent;
    protected Collider potentialSlotCollider;
    // Implemented in Interactable since it's useful for general movement
    // protected IBox currentSlot;
    // protected IBox potentialSlot;
    // protected bool slotted;

    [Header("==Card Faces==")]
    [SerializeField] 
    protected SpriteRenderer frontFace;
    [SerializeField] 
    protected SpriteRenderer backFace;

    public Transform SlottedParent
    {
        get { return slottedParent; }
        set { slottedParent = value; }
    }

    public Collider PotentialSlotCollider
    { 
        get { return potentialSlotCollider; }
        set { potentialSlotCollider = value; }
    }

    public bool Slotted
    {
        get { return slotted; }
        set { slotted = value; }
    }

    List<BaseCard.CardType> CardTargets()
    {
        return Card().target;
    }

    public virtual void SlotIn(Collider col, IBox theSlot)
    {
        // Assume successful dock, set position to the resulting dock
        slottedHeight = theSlot.SlotHeightOffset;
        targetPosition = theSlot.FillSlot(col, this);
        transform.position = targetPosition;
    }

    // Every slottable card needs to be able to be removed from a slot
    public virtual void SlotOut()
    {
        if (Slotted)
        {
            CurrentSlot.EmptySlot(this);
            slotted = false;
        }
    }

    // Every slottable card needs to be able to be used by its slot
    public virtual void SlottedUse(IBox theSlot)
    {
        Debug.Log("You haven't given " + gameObject.name + "a SlottedUse()");
    }

    public virtual void UseOnDraw()
    {
        Card().UseOnDraw();
    }

    public virtual void UseOnSacrifice()
    {
        Card().UseOnSacrifice();
    }

    public virtual void UseOnLocation()
    {
        Card().UseOnLocation();
    }

    public virtual void UseOnEvent()
    {
        Card().UseOnEvent();
    }

    public virtual void UseOnQuest()
    {
        Card().UseOnQuest();
    }

    public virtual void OnTurnEnd()
    {
        Card().OnTurnEnd();
    }

    public override void PickUp()
    {
        if (slotted)
        {
            // Debug.Log(currentSlot);
            // Debug.Log(currentSlot.name);

            SlotOut();
        }

        currentSlot = null;
        desiredZRotation = 0;
        currentHeight = pickupHeight;

        if (transform.parent != originalParent)
        {
            transform.SetParent(originalParent);
        }
    }

    public override void SetDown()
    {
        if (potentialSlot != null)
        {
            foreach (BaseCard.CardType thingICanSlotInto in CardTargets())
            {
                if (potentialSlot.CardType() == thingICanSlotInto)
                {
                    Debug.Log(potentialSlot + "is where I'm trying to slot into");
                    currentSlot = potentialSlot;
                    SlotIn(potentialSlotCollider, currentSlot);
                    // currentSlot.FillSlot(potentialSlotCollider, this);
                    // Debug.Log(currentSlot.transform.parent);
                    potentialSlot = null;
                    slotted = true;
                    break;
                }
            }
        }

        if (slotted)
        {
            // targetPosition = new Vector3(currentSlot.transform.position.x, slottedHeight, currentSlot.transform.position.z + currentSlot.SlotZOffset);
            // transform.position = targetPosition;
            transform.parent = currentSlot.transform;
        }

        else
        {
            currentHeight = originalHeight;
            // transform.position = new Vector3(pos.x, originalHeight, pos.z);
        }

        if (slotted && currentSlot.CardType() == BaseCard.CardType.Location)
        {
            Debug.Log("Hey dumbass I'm still doin this");
            desiredZRotation = -90;
        }
        else
        {
            desiredZRotation = 0;
        }

    }

    protected void OnTriggerEnter(Collider col)
    {
        // Debug.Log(collision);
        IBox box = col.transform.parent.GetComponent<IBox>();
        if (box != null)
        {
            // Debug.Log("THIS IS MY HOLE IT WAS MADE FOR ME");
            potentialSlot = box;
            potentialSlotCollider = col;

            if (CardTargets().Contains(box.CardType())
                && (potentialSlot.CardType() == BaseCard.CardType.Location))
            {
                Debug.Log("made it here");
                desiredZRotation = -90;
            }
        }
    }

    protected void OnTriggerExit(Collider col)
    {
        IBox box = col.transform.parent.GetComponent<IBox>();
        if (box != null)
        {
            Debug.Log("Here we are currently");
            Debug.Log(box);
            Debug.Log(CardTargets());
            Debug.Log(box.CardType());
            Debug.Log(CardTargets().Contains(box.CardType()));
            if (CardTargets().Contains(box.CardType())
                && potentialSlot != null
                && (potentialSlot.CardType() == BaseCard.CardType.Location))
            {
                // Debug.Log(collision.gameObject.transform.parent.GetComponent<BaseCard>().type);
                desiredZRotation = 0;
            }
            // Debug.Log("THIS IS MY HOLE IT WAS MADE FOR ME");
            potentialSlot = null;
            potentialSlotCollider = null;
        }

        desiredZRotation = 0;
    }
}
