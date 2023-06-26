using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Card trying to slot sometimes finds a NullReferenceException

public class Interactable : MonoBehaviour, ICard
{
    #region ICard Variables

    // Positioning
    protected Vector3 targetPosition;
    protected Vector3 currentAngle;

    [Header("==Drag Handling==")]
    // Height from board handling
    [SerializeField]
    protected float dragDelay;
    [SerializeField]
    protected float pickupHeight;
    [SerializeField]
    protected float originalHeight;
    [SerializeField]
    protected float slottedHeight;
    protected float currentHeight;

    protected bool currentlyBeingHeld;

    // Slot handling
    [SerializeField]
    protected Transform originalParent;
    protected bool slotted;
    protected IBox currentSlot;
    protected IBox potentialSlot;

    // Rotation handling
    protected float desiredZRotation;
    [SerializeField]
    protected float rotationSpeed;


    #endregion 

    #region ICard Getters/Setters
    public Transform OriginalParent
    { 
        get { return originalParent; }
    }
    public IBox CurrentSlot
    {
        get { return currentSlot; }
        set { currentSlot = value; }
    }
    public IBox PotentialSlot
    {
        get { return potentialSlot; }
        set { potentialSlot = value; }
    }
    public Vector3 TargetPosition
    {
        get { return targetPosition; }
        set { targetPosition = value; }
    }
    public Vector3 CurrentAngle
    {
        get { return currentAngle; }
        set { currentAngle = value; }
    }
    public float DesiredZRotation
    {
        get { return desiredZRotation; }
        set { desiredZRotation = value; }
    }
    public float PickupHeight
    {
        get { return pickupHeight; }
        set { pickupHeight = value; }
    }
    public float OriginalHeight
    {
        get { return originalHeight; }
    }
    public float CurrentHeight
    {
        get { return currentHeight; }
        set { currentHeight = value; }
    }
    public float SlottedHeight
    {
        get { return slottedHeight; }
        set { slottedHeight = value; }
    }
    public float RotationSpeed
    {
        get { return rotationSpeed; }
        set { rotationSpeed = value; }
    }
    public bool CurrentlyBeingHeld
    {
        get { return currentlyBeingHeld; }
        set { currentlyBeingHeld = value; }
    }
    #endregion

    public BaseCard Card()
    {
        return gameObject.GetComponent<BaseCard>();
    }

    public string Name()
    {
        return Card().name;
    }

    public string CardID()
    {
        return Card().id;
    }

    public BaseCard.CardType CardType()
    {
        return Card().type;
    }

    public BaseCard.CardRank CardRank()
    {
        return Card().rank;
    }

    protected virtual void Start()
    {
        slotted = false;
        targetPosition = transform.position;
        originalParent = transform.parent;
        currentHeight = originalHeight;
        currentAngle = new Vector3(0, 0, 0);
    }

    protected virtual void Update()
    {
        // transform.position = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
        if (!slotted)
        {
            LerpToTarget(dragDelay);
        }

        RotateZ();
        // Debug.Log(targetPosition);
    }

    void LerpToTarget(float dragDelay)
    {
        float x = Mathf.Lerp(transform.position.x, TargetPosition.x, dragDelay);
        float z = Mathf.Lerp(transform.position.z, TargetPosition.z, dragDelay);

        transform.position = new Vector3(x, currentHeight, z);
    }

    void RotateZ()
    {
        CurrentAngle = new Vector3(0, 0, Mathf.LerpAngle(CurrentAngle.z, DesiredZRotation, Time.deltaTime * RotationSpeed));
        transform.eulerAngles = CurrentAngle;
    }

    public virtual void PickUp()
    {
        desiredZRotation = 0;
        currentHeight = pickupHeight;
    }

    public virtual void SetDown()
    {
        currentHeight = originalHeight;
        desiredZRotation = 0;
    }

}
