using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static List<Item> items = new List<Item>();
    public int space = 20;

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public static Inventory instance;
    private void Awake()
    {
		instance = this;
    }

    public void AddItem (Item item)
    {
		if (items.Contains(item))
		{
			int itemIndex = items.IndexOf(item);
			items[itemIndex].quantity += 1;
		}else if (items.Count < 9) {
            items.Add(item);
			int itemIndex = items.IndexOf(item);
			items[itemIndex].quantity += 1;
			if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
        }
		int itemI = items.IndexOf(item);

		Debug.Log(items[itemI].quantity);
    }
    public void RemoveItem(Item item)
    {
		int itemIndex = items.IndexOf(item);
		items[itemIndex].quantity -= 1;

		if (items[itemIndex].quantity <= 0)
		{
			items.Remove(item);
		}

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}
