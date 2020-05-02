using System.Collections;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject InvUI;
    Inventory inventory;

    public Transform itemsParent;

	bool canSwitch;
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
		canSwitch = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.I) && canSwitch)
        {
			canSwitch = false;
            InvUI.SetActive(!InvUI.activeSelf);
			StartCoroutine(Switch());
            UpdateUI();
        }
    }

    public void UpdateUI()
    {
        InventorySlot[] slots = GetComponentsInChildren<InventorySlot>();

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < Inventory.items.Count)
            {
                slots[i].AddItem(Inventory.items[i]);
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
