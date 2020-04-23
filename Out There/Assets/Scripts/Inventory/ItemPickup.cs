using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            var itemPickedUp = Inventory.instance.AddItem(item);
            if (itemPickedUp)
            {
                Debug.Log("Item picked up! " + "It is: " + item.name);
                Destroy(gameObject);
            } 
            else
            {
                Debug.Log("You have no space!");
            }
        }
    }
}
