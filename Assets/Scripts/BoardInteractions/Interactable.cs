using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private Vector3 targetPosition;
    private float originalHeight;
    private float slottedHeight;
    private GameObject potentialSlot;
    private GameObject currentSlot;
    private Transform originalParent;
    private bool slotted = false;
    private List<Transform> cardsInSlots = new List<Transform>();

    [SerializeField] private float heightOffset = 0;
    [SerializeField] private float dragDelay = 100;
    [SerializeField] private List<string> validBoxes;
    [SerializeField] private List<string> boxTypes;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
        slottedHeight = transform.position.y + heightOffset;
        originalHeight = transform.position.y;
        originalParent = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
        if (!slotted)
        {
            LerpToTarget();
        }

    }

    private void LerpToTarget()
    {

        if (slotted)
        {
            ChangeTarget(currentSlot.transform.parent.position);
        }

        // targetPosition.x = Mathf.Lerp(transform.position.x, targetPosition.x, dragDelay);
        // targetPosition.z = Mathf.Lerp(transform.position.z, targetPosition.z, dragDelay);

        float x = Mathf.Lerp(transform.position.x, targetPosition.x, dragDelay);
        float z = Mathf.Lerp(transform.position.z, targetPosition.z, dragDelay);

        transform.position = new Vector3(x, transform.position.y, z);
    }

    public void ChangeTarget(Vector3 newTarget)
    {
        targetPosition = newTarget;
        // Debug.Log("I am moving from " + transform.position + "to " + targetPosition + "!");
    }

    public void PickUp(Vector3 pos)
    {
        currentSlot = null;
        slotted = false;
        transform.position = new Vector3(transform.position.x, pos.y, transform.position.z);

        if (transform.parent != originalParent)
        { 
            transform.parent = originalParent; 
        }
    }

    public void SetDown(Vector3 pos)
    {
        // ADD RULES HERE FOR WHEN WE'RE ALLOWED TO SLOT
        if (potentialSlot != null)
        {
            foreach (string boxType in validBoxes)
            {
                if (potentialSlot.transform.parent.GetComponent<Interactable>().boxTypes.Contains(boxType))
                {
                    currentSlot = potentialSlot;
                    currentSlot.transform.parent.GetComponent<Interactable>().AddCardToSlot(transform);
                    Debug.Log(currentSlot.transform.parent);
                    potentialSlot = null;
                    slotted = true;
                    break;
                }
            }
        }
        
        if (slotted)
        {
            targetPosition = new Vector3(currentSlot.transform.parent.position.x, slottedHeight, currentSlot.transform.parent.position.z);
            transform.position = targetPosition;
            transform.parent = currentSlot.transform;
        }

        else 
        {
            transform.position = new Vector3(pos.x, originalHeight, pos.z);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision);
        if (collision.gameObject.CompareTag("Slot"))
        {
            // Debug.Log("THIS IS MY HOLE IT WAS MADE FOR ME");
            potentialSlot = collision.gameObject;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Slot"))
        {
            // Debug.Log("THIS IS MY HOLE IT WAS MADE FOR ME");
            potentialSlot = null;
        }
    }

    public void AddCardToSlot(Transform cardToAdd)
    {
        cardsInSlots.Add(cardToAdd);
        Debug.Log(transform.name + " just added " + cardToAdd.name + " to its slot!");
    }


}
