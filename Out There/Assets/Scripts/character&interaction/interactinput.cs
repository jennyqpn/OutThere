using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactinput : MonoBehaviour
{
    public interactable focus;
    public LayerMask movementMask;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                interactable interact = hit.collider.GetComponent<interactable>();
                if (interact != null)
                {
                    SetFocus(interact);
                }
            }

        }

        
        
    }
    void SetFocus(interactable newFocus)
    {
        focus = newFocus;
    }
}
