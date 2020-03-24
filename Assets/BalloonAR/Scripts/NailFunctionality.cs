using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailFunctionality : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            //TODO This is going to be ->Item instead of ballon
            other.gameObject.GetComponent<BalloonBehavior>().InteractWithItem();
            Debug.Log("touched an item");
        }
    }
}
