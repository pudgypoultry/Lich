using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurn : MonoBehaviour
{

    [SerializeField] private List<InteractableBox> locations = new List<InteractableBox>();

    void Update()
    {
        TestingButton();
    }

    private void EndTurnProcesses()
    {
        foreach (InteractableBox box in locations)
        {
            box.SlottedCardUse();
        }
    }

    private void TestingButton()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EndTurnProcesses();
        }
    }
}
