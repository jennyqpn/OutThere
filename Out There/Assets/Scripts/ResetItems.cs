using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetItems : MonoBehaviour
{
	public List<Item> items;
	// Start is called before the first frame update
	void Start()
    {
		foreach (Item i in items)
		{
			i.quantity = 0;
		}
		Inventory.items = new List<Item>();
	}
}
