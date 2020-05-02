using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class forPlayer : MonoBehaviour
{
    private GameObject triggeringNpc;
    private bool triggering;
    public GameObject npcText;
    Sprite AMANIDLE, AMANBLUSH, AMANUPSET, ARTHURBLUSH, ARTHURIDLE, ARTHURUPSET,
        ASHLEYBLUSH, ASHLEYIDLE, ASHLEYUPSET, CORRANBLUSH, CORRANIDLE, CORRANUPSET,
        MARINABLUSH, MARINAIDLE, MARINAUPSET, RINYABLUSH, RINYAIDLE, RINYASAD, MERCHANT;

    void Update()
    {
        if (triggering)
        {
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                npcText.SetActive(true);
            }
        } else {
            npcText.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "npc")
        {
            triggering = true;
            triggeringNpc = other.gameObject;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "npc")
        {
            triggering = false;
            triggeringNpc = null;
        }
    }
}
