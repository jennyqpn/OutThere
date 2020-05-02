using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeginningDialoge : MonoBehaviour
{
    public static bool collected = false;
    bool triggering = false;
    public List<Item> items;

    private void Update() {

        if (triggering && !collected) {

            collected = true;

            foreach (Item i in items) {
                Inventory.instance.AddItem(i);
            }

        }
    }

    void OnTriggerEnter(Collider col) {
        if (col.tag == "Player") {
           triggering = true;
        }
    }
}
