using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
                Inventory.instance.AddItem(item);
                Destroy(gameObject);
        }
    }
}
