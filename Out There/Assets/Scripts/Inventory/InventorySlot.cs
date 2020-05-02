
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    Item item;
    public Image icon;
    public Button removeButton;
	public Text quantity;

    public void AddItem(Item newItem) {

        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
		quantity.text = item.quantity.ToString();
    }

    public void ClearSpot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
		quantity.text = "0";
    }

    public void onX() {
        Inventory.instance.RemoveItem(item);
	}

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }
}
