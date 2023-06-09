using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteractionHandler : MonoBehaviour
{

    private Vector3 mousePosition;
    private Vector3 dragPos;
    private Interactable current_object;
    private LayerMask ignoreThese;
    private LayerMask dragLayer;
    private bool canSelect = true;

    Interactable current_selected_object;
    [SerializeField] private Camera playerCam;
    [SerializeField] private float dragDistance;

    // Start is called before the first frame update
    void Start()
    {
        ignoreThese = LayerMask.GetMask("SlotLayer", "DragLayer");
        dragLayer = LayerMask.GetMask("DragLayer");
    }

    // Update is called once per frame
    void Update()
    {
        if (canSelect)
        {
            CastRay();
            DeselectObject();
            MoveObject(dragPos);
        }

    }

    public void CastRay()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = playerCam.nearClipPlane;
        Ray ray = playerCam.ScreenPointToRay(mousePos);
        RaycastHit hit;
        GameObject obj;

        // Grab the  object
        if (Physics.Raycast(ray, out hit, 100, ~ignoreThese))
        {
            // Debug.Log("Should be not the drag layer: " + hit.transform);
            // Debug.Log("Parent is: " + hit.transform.parent);
            obj = hit.collider.gameObject;

            if (Input.GetMouseButtonDown(0) && obj.GetComponent<Interactable>() != null)
            {
                SelectObject(obj.GetComponent<Interactable>());
                // Debug.Log(current_object.name);
            }
        }

        // Get position of colission between ray and drag plane, used to "pick up" card
        if (Physics.Raycast(ray, out hit, 100, dragLayer /* Ignore everything but DragLayer */))
        {
            // Debug.Log("Should be the drag layer: " + hit.transform);
            dragPos = hit.point;
        }
    }

    private void SelectObject(Interactable objectToSet)
    {
        current_object = objectToSet;
        current_object.PickUp();
    }

    private void DeselectObject()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (current_object != null)
            {
                current_object.SetDown();
                current_object = null;
                // Debug.Log(current_object.name);
            }
        }
    }

    private void MoveObject(Vector3 targetPosition)
    {
        if (current_object != null)
        {
            current_object.GetComponent<Interactable>().TargetPosition = targetPosition;
        }
    }

    public void GiveControl()
    {
        canSelect = true;
    }

    public void TakeAwayControl()
    {
        canSelect = false;
    }

}
