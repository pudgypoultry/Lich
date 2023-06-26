using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUsable
{
    Transform transform { get; }
    Transform OriginalParent { get; }
    GameObject gameObject { get; }

    BaseCard Card()
    {
        return gameObject.GetComponent<BaseCard>();
    }

    // Every minion needs to be able to slot into and out of locations
    virtual void SlotIn() {}
    virtual void SlotOut() {}

    // Every minion needs to have a Use() function
    virtual void Use() 
    {
        Card().Use();
    }

    // Every minion needs to have all possible UseOnBLANK() functions, but these should be overridable
    virtual void UseOnDraw()
    {
        Card().UseOnDraw();
    }

    virtual void UseOnSacrifice()
    {
        Card().UseOnSacrifice();
    }

    virtual void UseOnLocation()
    {
        Card().UseOnLocation();
    }

    virtual void UseOnEvent()
    {
        Card().UseOnEvent();
    }

    virtual void UseOnQuest()
    {
        Card().UseOnQuest();
    }

    virtual void OnTurnEnd()
    {
        Card().OnTurnEnd();
    }

}
