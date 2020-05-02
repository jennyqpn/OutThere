using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeginningDialoge : MonoBehaviour
{
    public GameObject startText;
    public GameObject alreadyPickedUp;
    bool collected = false;
    bool triggering = false;
    public List<Item> items;

    private void Update() {
        if (triggering && !collected) {

            collected = true;
            startText.SetActive(true);

            foreach (Item i in items) {
                Inventory.instance.AddItem(i);
            }

            Switch();

            startText.SetActive(false);
        } else {
            alreadyPickedUp.SetActive(true);

            Switch();

            alreadyPickedUp.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider col) {
        if (col.tag == "Player") {
           triggering = true;
        }
    }

    IEnumerator Switch() {
        yield return new WaitForSecondsRealtime(10);
    }
}
