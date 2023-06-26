using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldInteractable : MonoBehaviour
{
    protected Vector3 targetPosition;
    protected Vector3 currentAngle;

    [Header("==Positioning==")]
    [SerializeField] protected float originalHeight;
    [SerializeField] protected float slottedHeight;
    [SerializeField] protected float pickupHeight;
    protected float currentHeight;

    protected GameObject potentialSlot;
    protected GameObject currentSlot;
    protected Transform originalParent;

    protected bool slotted = false;


    [SerializeField] protected List<Transform> cardsInSlots = new List<Transform>();
    protected BaseCard cardData;


    [Header("==Card Faces==")]
    [SerializeField] protected SpriteRenderer frontFace;
    [SerializeField] protected SpriteRenderer backFace;

    [Header("==Slotting==")]
    [SerializeField] protected int maxSlots;
    public List<BaseCard.CardType> validBoxes;
    public List<BaseCard.CardKeyword> boxTypes;

    [Header("==Dragging Control==")]
    [SerializeField] protected float heightOffset = 1;
    protected float originalHeightOffset = 1;
    protected float currentDesiredZRotation = 0;
    [SerializeField] protected float desiredPickupZRotation = -90;
    [SerializeField] protected float rotSpeedFactor = 5;

    // This shouldn't be here, it should be grabbed from the card allowing a slot
    [SerializeField] protected float slottedZOffset = 1;
    [SerializeField] protected float dragDelay = 100;




    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
        slottedHeight = transform.position.y + heightOffset;
        originalHeightOffset = heightOffset;
        originalParent = transform.parent;
        currentHeight = originalHeight;
        currentAngle = new Vector3(0, 0, 0);
        cardData = GetComponent<BaseCard>();
        validBoxes = new List<BaseCard.CardType>();
        boxTypes = new List<BaseCard.CardKeyword>();
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
        if (!slotted)
        {
            LerpToTarget();
        }

        currentAngle = new Vector3(0, 0, Mathf.LerpAngle(currentAngle.z, currentDesiredZRotation, Time.deltaTime * rotSpeedFactor));
        transform.eulerAngles = currentAngle;
        // Debug.Log(targetPosition);
    }

    private void LerpToTarget()
    {
        /*
        if (slotted)
        {
            ChangeTarget(currentSlot.transform.parent.position);
        }
        */

        // targetPosition.x = Mathf.Lerp(transform.position.x, targetPosition.x, dragDelay);
        // targetPosition.z = Mathf.Lerp(transform.position.z, targetPosition.z, dragDelay);

        float x = Mathf.Lerp(transform.position.x, targetPosition.x, dragDelay);
        float z = Mathf.Lerp(transform.position.z, targetPosition.z, dragDelay);

        transform.position = new Vector3(x, currentHeight, z);
    }

    public void ChangeTarget(Vector3 newTarget)
    {
        targetPosition = newTarget;
        // Debug.Log("I am moving from " + transform.position + "to " + targetPosition + "!");
    }
    /*
    public virtual void PickUp(Vector3 pos)
    {
        if (slotted)
        {
            // Debug.Log(currentSlot);
            // Debug.Log(currentSlot.name);

            currentSlot.transform.parent.GetComponent<Interactable>().RemoveCardFromSlot(transform);
            slotted = false;

        }

        currentSlot = null;

        // currentDesiredZRotation = desiredPickupZRotation;
        // currentAngle = new Vector3(0, 0, desiredPickupZRotation);
        currentDesiredZRotation = 0;
        currentHeight = pickupHeight;

        if (transform.parent != originalParent)
        {
            transform.parent = originalParent;
        }
    }

    public void SetDown(Vector3 pos)
    {
        if (potentialSlot != null)
        {
            foreach (BaseCard.CardType thingICanSlotInto in transform.GetComponent<BaseCard>().target)
            {
                if (potentialSlot.transform.parent.GetComponent<BaseCard>().type == thingICanSlotInto)
                {
                    Debug.Log(potentialSlot + "is where I'm trying to slot into");
                    currentSlot = potentialSlot;
                    currentSlot.transform.parent.GetComponent<Interactable>().AddCardToSlot(transform);
                    // Debug.Log(currentSlot.transform.parent);
                    potentialSlot = null;
                    slotted = true;
                    break;
                }
            }
        }

        if (slotted)
        {
            targetPosition = new Vector3(currentSlot.transform.position.x, slottedHeight, currentSlot.transform.position.z + slottedZOffset);
            transform.position = targetPosition;
            transform.parent = currentSlot.transform;
        }

        else
        {
            currentHeight = originalHeight;
            // transform.position = new Vector3(pos.x, originalHeight, pos.z);
        }

        if (slotted
            && (currentSlot.transform.parent.GetComponent<BaseCard>().type == BaseCard.CardType.Location || currentSlot.transform.parent.GetComponent<BaseCard>().type == BaseCard.CardType.SystemRelicSlot))
        {
            Debug.Log("Hey dumbass I'm still doin this");
            currentDesiredZRotation = -90;
        }
        else
        {
            currentDesiredZRotation = 0;
        }

    }

    private void OnTriggerEnter(Collider collision)
    {
        // Debug.Log(collision);
        if (collision.gameObject.CompareTag("Slot"))
        {
            // Debug.Log("THIS IS MY HOLE IT WAS MADE FOR ME");
            potentialSlot = collision.gameObject;

            if (cardData.target.Contains(potentialSlot.transform.parent.GetComponent<BaseCard>().type)
                && (potentialSlot.transform.parent.GetComponent<BaseCard>().type == BaseCard.CardType.Location || potentialSlot.transform.parent.GetComponent<BaseCard>().type == BaseCard.CardType.SystemRelicSlot))
            {
                // Debug.Log(collision.gameObject.transform.parent.GetComponent<BaseCard>().type);
                currentDesiredZRotation = -90;
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Slot"))
        {

            if (cardData.target.Contains(potentialSlot.transform.parent.GetComponent<BaseCard>().type)
                && (potentialSlot.transform.parent.GetComponent<BaseCard>().type == BaseCard.CardType.Location || potentialSlot.transform.parent.GetComponent<BaseCard>().type == BaseCard.CardType.SystemRelicSlot))
            {
                // Debug.Log(collision.gameObject.transform.parent.GetComponent<BaseCard>().type);
                currentDesiredZRotation = 0;
            }
            // Debug.Log("THIS IS MY HOLE IT WAS MADE FOR ME");
            potentialSlot = null;
        }

        currentDesiredZRotation = 0;
    }

    public virtual void AddCardToSlot(Transform cardToAdd)
    {
        if (cardsInSlots.Count < maxSlots)
        {
            cardsInSlots.Add(cardToAdd);
            Debug.Log(transform.name + " just added " + cardToAdd.name + " to its slot!");
        }
        else
        {
            Debug.Log(transform.name + " has no empty slots!");
        }
    }

    public GameObject GetCurrentSlot()
    {
        return currentSlot;
    }

    public List<Transform> GetCardsInSlots()
    {
        return cardsInSlots;
    }

    public void SlottedCardUse()
    {
        foreach (Transform card in cardsInSlots)
        {
            card.gameObject.GetComponent<BaseCard>().Use();
        }
    }

    /*
    public override void AddCardToSlot(Transform cardToAdd)
    {
        cardsInSlots.Add(cardToAdd);

        Debug.Log(transform.name + " just added " + cardToAdd.name + " to its slot!");
    }
    */

    public void RemoveCardFromSlot(Transform cardToRemove)
    {
        cardsInSlots.Remove(cardToRemove);
        Debug.Log(transform.name + " just removed " + cardToRemove.name + " from its slot!");
    }
}
