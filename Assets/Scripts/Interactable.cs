using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private Vector3 targetPosition;
    private float originalHeight;
    private float slottedHeight;
    private bool slotted = false;

    [SerializeField] private float heightOffset = 0;
    [SerializeField] private float dragDelay = 100;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
        slottedHeight = transform.position.y + heightOffset;
        originalHeight = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(targetPosition.x, transform.position.y, targetPosition.z); 
        LerpToTarget();
    }

    private void LerpToTarget()
    {
        targetPosition.x = Mathf.Lerp(transform.position.x, targetPosition.x, dragDelay);
        targetPosition.z = Mathf.Lerp(transform.position.z, targetPosition.z, dragDelay);
        
    }

    public void ChangeTarget(Vector3 newTarget)
    {
        targetPosition = newTarget;
        // Debug.Log("I am moving from " + transform.position + "to " + targetPosition + "!");
    }

    public void PickUp(Vector3 pos)
    {
        transform.position = new Vector3(transform.position.x, pos.y, transform.position.z);
    }

    public void SetDown(Vector3 pos)
    {
        if (slotted)
        { 
            transform.position = new Vector3(pos.x, slottedHeight, pos.z);
        }

        else 
        {
            transform.position = new Vector3(pos.x, originalHeight, pos.z);
        }
    }



}
