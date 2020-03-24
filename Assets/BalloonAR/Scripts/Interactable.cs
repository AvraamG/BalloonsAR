using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public abstract class Interactable : MonoBehaviour
{
    public static Action<Interactable> OnItemInteractedWith;


    protected int pointsWorth = 0;
    public int PointsWorth
    {
        get
        {
            return pointsWorth;
        }
    }

    //NOTE ask for an item to do future interactions based on item characteristics. 
    abstract public void InteractWithItem(InteractionItem interactionItem);
}
