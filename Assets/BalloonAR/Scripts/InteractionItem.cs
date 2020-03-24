using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractionItem : MonoBehaviour
{
    protected int quantity;
    protected int purchasePrice;
    public int PurchasePrice
    {
        get
        {
            return purchasePrice;
        }
    }

    public abstract void InitializeItem();
    public abstract void UseItem();
}
