using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Tools")
        {
            Debug.Log("Picked up");
            //add to inventory
            Destroy(col.gameObject);
        }
    }
}
