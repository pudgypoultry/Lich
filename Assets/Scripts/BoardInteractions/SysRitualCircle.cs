using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SysRitualCircle : MonoBehaviour, IBox
{
    protected Player gameManager;

    [Header("==Box Slot Handling==")]
    // Used for slotting cards into locations
    [SerializeField]
    protected int maxSlots = 1;
    protected int numSlotsFull;
    [SerializeField]
    protected float slotHeightOffset;
    [SerializeField]
    protected float slotZOffset;
    protected bool anySlotsFull;
    protected bool allSlotsFull;

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

    public BaseCard Card()
    {
        return null;
    }

    public BaseCard.CardType CardType()
    {
        return BaseCard.CardType.Ritual;
    }

    protected void Start()
    {
        gameManager = FindObjectOfType<Player>();
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

    public virtual Vector3 FillSlot(Collider col, ISlottable cardToSlot)
    {
        Debug.Log("Trying to be filled!");

        if (SlotColliders.Contains(col))
        {
            Debug.Log("made it here in the ritual circle");
            // Slotted parent needs to be set
            // Slotted needs to be set to true
            int index = SlotColliders.IndexOf(col);
            CardsInSlots[index] = cardToSlot;
            cardToSlot.SlottedParent = transform;
            cardToSlot.Slotted = true;
            cardToSlot.CurrentSlot = this;
            UseCardInSlot();

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
    public void EmptySlot(ISlottable cardToRemove)
    {
        Debug.Log("How, how did you do this, please explain to me");
    }

    // Every box needs to be able to use a card in its slot
    public void UseCardInSlot()
    {
        Debug.Log("Using Card's ability!");
        cardsInSlots[0].SlottedUse(this);
        //Destroy(cardsInSlots[0].gameObject);
    }
}
