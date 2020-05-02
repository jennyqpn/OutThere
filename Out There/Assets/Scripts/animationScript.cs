using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class animationScript : MonoBehaviour
{
    public Animator player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            player.SetBool("walking", true);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            player.SetBool("run", true);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            player.SetBool("walking", false);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            player.SetBool("run", false);
        }


    }
}
