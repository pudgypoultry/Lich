using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICard
{
    /*  
     *  ==========================================
     *            Monobehavior Basics
     *  ==========================================
     */

    Transform transform { get; }
    Transform OriginalParent { get; }
    GameObject gameObject { get; }


    /*  
     *  ==========================================
     *     Non-physical, Abstract Card Aspects
     *  ==========================================
     */

    BaseCard Card()
    {
        return gameObject.GetComponent<BaseCard>();
    }

    string Name()
    {
        return Card().name;
    }

    string CardID()
    {
        return Card().id;
    }

    BaseCard.CardType CardType()
    {
        return Card().type;
    }

    BaseCard.CardRank CardRank()
    {
        return Card().rank;
    }

    /*  
     *  ==========================================
     *          Interaction With 3D Space
     *  ==========================================
     */

    Vector3 TargetPosition { get; set; }
    Vector3 CurrentAngle { get; set; }
    float DesiredZRotation { get; set; }
    float PickupHeight { get; set; }
    float OriginalHeight { get; }
    float CurrentHeight { get; set; }
    float SlottedHeight { get; set; }
    float RotationSpeed { get; set; }
    bool CurrentlyBeingHeld { get; set; }

    // Every card needs to be able to move
    void LerpToTarget(float dragDelay){}

    // Every card should have the capability of rotating on the Z axis
    void RotateZ(){}

    // Every card should be able to be picked up
    virtual void PickUp(){}

    // Every card that can be picked up should be able to be put down
    virtual void SetDown(){}


}
