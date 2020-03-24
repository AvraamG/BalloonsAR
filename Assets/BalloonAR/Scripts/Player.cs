using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Player : MonoBehaviour
{
    public static Action<int> OnTotalMoneyUpdated;
    public static Action<int> OnMoneyGained;

    int level;


    private Inventory inventory;


    private void Awake()
    {
        InitializePlayer();
    }
    /// <summary>
    /// This should take the info from either PlayerPrefs or DB.
    /// </summary>
    void InitializePlayer()
    {
        Interactable.OnItemInteractedWith += HandleItemInteractedWith;

        level = 1;
        inventory = this.GetComponent<Inventory>();
    }

    private void HandleItemInteractedWith(Interactable interactable)
    {
        inventory.AddMoney(interactable.PointsWorth);

        if (OnTotalMoneyUpdated != null)
        {
            OnTotalMoneyUpdated(inventory.Money);
        }

        if (OnMoneyGained != null)
        {
            OnMoneyGained(interactable.PointsWorth);
        }
    }


    //TODO think how the change of the items is going to happen.
    //Some items are infinite like the nail but some are finite like the darts.
    public void SetCurrentInteractionItem()
    {

    }


    public InteractionItem currentInteractionItem;


}
