using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (Inventory.items.Count < 9) {
                Inventory.instance.AddItem(item);
                Destroy(gameObject);
            }
            else {
                Debug.Log("inventory full");
            }
        }
    }
}
