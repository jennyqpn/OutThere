using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cheat : MonoBehaviour
{
    public GameObject cheatUI;
    bool on = false;
	bool canSwitch;
    public Text response;

    public NPC aman;
    public NPC arthur;
    public NPC ashley;
    public NPC corran;
    public NPC marina;
    public NPC merchant;
    public NPC rinya;

    void Start() 
    {
        canSwitch = true;
    }

    void Update() {
        Debug.Log("aman: " + aman.friendship);

        if (Input.GetKey(KeyCode.C) && canSwitch)
        {
            on = !on;
			if (on)
			{
				Cursor.visible = true;
				Cursor.lockState = CursorLockMode.None;
			}
			else
			{
				Cursor.visible = false;
				Cursor.lockState = CursorLockMode.Locked;
                response.text = "";
			}
			canSwitch = false;
            cheatUI.SetActive(!cheatUI.activeSelf);
			StartCoroutine(Switch());
        }
    }

    IEnumerator Switch()
	{
		yield return new WaitForSecondsRealtime(0.2f);
		canSwitch = true;
	}

    public void Aman()
    {
        aman.friendship++;
        response.text = "Aman's affection for you has increased to " + aman.friendship + "!";
    }

    public void Ashley()
    {
        ashley.friendship++;
        response.text = "Ashley's affection for you has increased to " + ashley.friendship + "!";
    }

    public void Arthur()
    {
        arthur.friendship++;
        response.text = "Arthur's affection for you has increased to " + arthur.friendship + "!";
    }

    public void Corran()
    {
        corran.friendship++;
        response.text = "Corran's affection for you has increased to " + corran.friendship + "!";
    }

    public void Marina()
    {
        marina.friendship++;
        response.text = "Marina's affection for you has increased to " + marina.friendship + "!";
    }

    public void Merchant()
    {
        merchant.friendship++;
        response.text = "Merchant's affection for you has increased to " + merchant.friendship + "!";
    }

    public void Rinya()
    {
        rinya.friendship++;
        response.text = "Rinya's affection for you has increased to " + rinya.friendship + "!";
    }

}
