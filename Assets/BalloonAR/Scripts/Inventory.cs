using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InteractionItem> allItems;
    private int availableMoney;
    public int Money
    {
        get
        {
            return availableMoney;
        }
    }

    public void AddMoney(int ammount)
    {
        availableMoney += ammount;
    }

}
