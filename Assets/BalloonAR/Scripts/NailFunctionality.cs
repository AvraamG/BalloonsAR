using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailFunctionality : MonoBehaviour
{
    InteractionItem nailItem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Interactable")
        {
            if (nailItem == null)
            {
                nailItem = transform.parent.gameObject.GetComponent<InteractionItem>();
            }
            other.gameObject.GetComponent<Interactable>().InteractWithItem(nailItem);
        }
    }
}
