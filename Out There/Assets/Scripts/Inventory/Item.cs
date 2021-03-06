﻿using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName ="Inventory/Item")]
public class Item : ScriptableObject

{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefault = false;
	public int quantity = 0;


    public virtual void Use()
    {
		Holding.itemHolding = name;
        Debug.Log("Using: " + name);
    }

}
