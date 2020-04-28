﻿using System.Collections;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{

    Inventory inventory;

    public Transform itemsParent;

    InventorySlot[] slots;

    public GameObject InvUI;

	bool canSwitch;
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
		canSwitch = true;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.I) && canSwitch)
        {
			canSwitch = false;
            InvUI.SetActive(!InvUI.activeSelf);
			StartCoroutine(Switch());
        }
    }

    void UpdateUI()
    {   
        for(int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }else
            {
                slots[i].ClearSpot();
            }
        }
        Debug.Log("Updating UI...");
    }

	IEnumerator Switch()
	{
		yield return new WaitForSecondsRealtime(0.2f);
		canSwitch = true;
	}
}
