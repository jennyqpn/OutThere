using UnityEngine;

public class InventoryUI : MonoBehaviour
{

    Inventory inventory;

    public Transform itemsParent;

    InventorySlot[] slots;

    public GameObject InvUI;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.I))
        {
            InvUI.SetActive(!InvUI.activeSelf);
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
}
