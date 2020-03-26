// Credits 
// This item was originaly created by Jarlan Perez
// It was accessed and downloaded from https://poly.google.com/view/drNqt_5ReeP
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartBoardBehavior : Interactable
{

    //TODO The dartBoard should award MorePoints if the interaction Item is a dart.
    public override void InteractWithItem(InteractionItem interactionItem)
    {

        if (OnItemInteractedWith != null)
        {
            OnItemInteractedWith(this);
        }
    }


}
