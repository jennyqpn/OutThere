using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class forNPC : MonoBehaviour
{
    private GameObject triggeringNpc;
    private bool triggering;
    public GameObject npcText;
    public NPC npc;
    public Image spriteUI;
    public Text textUI;
    public SpriteRenderer spriteRenderer;

    void Update()
    {
        if (triggering)
        {
            npcText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Interaction();
            }

        }
        else
        {
            npcText.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            triggering = true;
            triggeringNpc = other.gameObject;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            triggering = false;
            triggeringNpc = null;
        }
    }

    void Interaction()
    {
        if (npc.friendship == 0) //if not met yet
        {
            spriteUI.GetComponent<Image>().sprite = npc.icon[0];
            textUI.text = npc.dialogue[0];
        }
        else if (npc.friendship < 0 && npc.friendship > 4)
        { //if medium friend
            int ran = Random.Range(1, 5);
            if (ran >= 3 && ran <= 5) //if "upset text"
            {
                spriteUI.GetComponent<Image>().sprite = npc.icon[1];
                textUI.text = npc.dialogue[ran];
            }
            else
            {
                spriteUI.GetComponent<Image>().sprite = npc.icon[0];
                textUI.text = npc.dialogue[ran];
            }
        }

        else
        {
            int ran = Random.Range(1, 8);
            if (ran >= 3 && ran <= 5) //if "upset text"
            {
                spriteUI.GetComponent<Image>().sprite = npc.icon[1];
                textUI.text = npc.dialogue[ran];
            }
            else if (ran >= 6 && ran <= 8) //if "blush text"
            {
                spriteUI.GetComponent<Image>().sprite = npc.icon[2];
                textUI.text = npc.dialogue[ran];
            }
            else
            {
                spriteUI.GetComponent<Image>().sprite = npc.icon[0];
                textUI.text = npc.dialogue[ran];
            }
        }
        npc.friendship++;
    }
}

