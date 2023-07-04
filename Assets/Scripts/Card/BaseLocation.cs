using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseLocation : Interactable, IBox, ISlottable
{
    [Header("==Card Faces==")]
    [SerializeField]
    protected SpriteRenderer frontFace;
    [SerializeField]
    protected SpriteRenderer backFace;

    [Header("==Box Slot Handling==")]
    // Used for slotting cards into locations
    [SerializeField]
    protected int maxSlots;
    protected int numSlotsFull;
    [SerializeField]
    protected float slotHeightOffset;
    [SerializeField]
    protected float slotZOffset;
    protected bool anySlotsFull;
    protected bool allSlotsFull;
    protected bool shouldBeActive = false;

    protected List<ISlottable> cardsInSlots;
    [SerializeField]
    protected List<Collider> slotColliders;
    protected List<Vector3> slotPositions;

    // Slotting into system locations
    protected Transform slottedParent;
    protected Collider potentialSlotCollider;

    public int MaxSlots
    {
        get { return maxSlots; }
        set { maxSlots = value; }
    }
    public int NumSlotsFull
    {
        get { return numSlotsFull; }
        set { numSlotsFull = value; }
    }
    public float SlotHeightOffset
    {
        get { return slotHeightOffset; }
        set { slotHeightOffset = value; }
    }
    public float SlotZOffset
    {
        get { return slotZOffset; }
        set { slotZOffset = value; }
    }
    public bool AnySlotsFull
    {
        get { return anySlotsFull; }
        set { anySlotsFull = value; }
    }
    public bool AllSlotsFull
    {
        get { return allSlotsFull; }
        set { allSlotsFull = value; }
    }
    public List<ISlottable> CardsInSlots
    {
        get { return cardsInSlots; }
        set { cardsInSlots = value; }
    }
    public List<Collider> SlotColliders
    {
        get { return slotColliders; }
        set { slotColliders = value; }
    }
    public List<Vector3> SlotPositions
    {
        get { return slotPositions; }
        set { slotPositions = value; }
    }

    // Checking for system location slot
    public bool Slotted
    {
        get { return slotted; }
        set { slotted = value; }
    }
    public Transform SlottedParent
    {
        get { return slottedParent; }
        set { slottedParent = value; }
    }

    protected override void Start()
    {
        targetPosition = transform.position;
        originalParent = transform.parent;
        currentHeight = originalHeight;
        currentAngle = new Vector3(0, 0, 0);

        slotPositions = new List<Vector3>();
        cardsInSlots = new List<ISlottable>();

        for (int i = 0; i < maxSlots; i++)
        {
            if (slotColliders[i] == null)
            {
                Debug.Log("Hey fix this dumbass there's no collider");
            }
            else 
            {
                Debug.Log(slotPositions);
                slotPositions.Add(slotColliders[i].transform.position);
                cardsInSlots.Add(null);
            }
        }
    }

    protected override void Update()
    {
        base.Update();
        if (slotted)
        {
            shouldBeActive = true;
        }
        else
        {
            shouldBeActive = false;
        }
        if (shouldBeActive)
        {
            for (int i = 0; i < maxSlots; i++)
            {
                slotColliders[i].gameObject.SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < maxSlots; i++)
            {
                slotColliders[i].gameObject.SetActive(false);
            }
        }
    }

    List<BaseCard.CardType> CardTargets()
    {
        return Card().target;
    }

    public Vector3 FillSlot(Collider col, ISlottable cardToSlot)
    {
        Debug.Log("Attempting to fill slot!");
        int index = -1;
        if (SlotColliders.Contains(col))
        {
            // Slotted parent needs to be set
            // Slotted needs to be set to true
            index = slotColliders.IndexOf(col);
            Debug.Log("===Index of card list in location + card trying to be slotted");
            Debug.Log(index);
            Debug.Log(cardsInSlots[index]);
            Debug.Log(cardToSlot);
            cardsInSlots[index] = cardToSlot;
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


            Debug.Log("Turning off collider: " + index);
            TurnOffCollider(index);
        }

        if (index == -1)
        {
            return new Vector3(col.transform.position.x, SlotHeightOffset, col.transform.position.z);
        }
        else 
        {
            return new Vector3(slotPositions[index].x, SlotHeightOffset, slotPositions[index].z);
        }
    }

    public void EmptySlot(ISlottable cardToRemove)
    {
        Debug.Log("Attempting to empty slot!");
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
        TurnOnCollider(index);
    }

    public virtual void UseCardInSlot()
    {
        for (int i = 0; i < maxSlots; i++)
        {
            Debug.Log("Using card!");
            UseCardInSlot(i);
        }
    }

    public virtual void UseCardInSlot(int slotPosition)
    {
        if (cardsInSlots[slotPosition] != null)
        { 
            cardsInSlots[slotPosition].SlottedUse(this);
        }
    }

    public override void PickUp()
    {
        for (int i = 0; i < maxSlots; i++)
        {
            if (cardsInSlots[i] != null)
            {
                cardsInSlots[i].transform.SetParent(originalParent);
                cardsInSlots[i].SlotOut();
                TurnOffCollider(i);
            }
        }

        if (slotted)
        {
            // Debug.Log(currentSlot);
            // Debug.Log(currentSlot.name);

            SlotOut();
        }

        currentSlot = null;
        currentHeight = pickupHeight;

        if (transform.parent != originalParent)
        {
            transform.SetParent(originalParent);
        }

    }

    public override void SetDown()
    {
        currentHeight = originalHeight;

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

        for (int i = 0; i < maxSlots; i++)
        {
            slotPositions[i] = slotColliders[i].transform.position;
            if (slotted)
            {
                TurnOnCollider(i);
            }

        }

    }

    public virtual void SlotIn(Collider col, IBox theSlot)
    {
        // Successfully dock, and upon success, set position to the resulting dock
        if (CardTargets().Contains(theSlot.CardType()) && !Slotted)
        {
            transform.position = theSlot.FillSlot(col, this);
        }
    }

    // Every slottable card needs to be able to be removed from a slot
    public virtual void SlotOut()
    {
        if (Slotted)
        {
            CurrentSlot.EmptySlot(this);
        }
    }

    // Every slottable card needs to be able to be used by its slot
    public virtual void SlottedUse(IBox theSlot)
    {
        Debug.Log("You what the fuck");
    }

    public void TurnOnCollider(int index)
    {
        Debug.Log("Trying to turn on collider");
        slotColliders[index].enabled = true;
    }

    public void TurnOffCollider(int index)
    {
        Debug.Log("Trying to turn off the fucking collider");
        slotColliders[index].enabled = false;
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
            }
        }
    }

    protected void OnTriggerExit(Collider col)
    {
        IBox box = col.transform.parent.GetComponent<IBox>();
        if (box != null)
        {
            Debug.Log("Here we are currently");
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
