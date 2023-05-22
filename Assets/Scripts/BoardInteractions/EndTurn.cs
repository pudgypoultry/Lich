using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurn : MonoBehaviour
{

    [SerializeField] private List<InteractableBox> locations = new List<InteractableBox>();
    [SerializeField] private Player thePlayer;

    void Update()
    {
        TestingButton();
    }

    private void TestingButton()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thePlayer.EndTurnProcess();
        }
    }
}
