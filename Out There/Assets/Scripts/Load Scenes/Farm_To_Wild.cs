﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Farm_To_Wild : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.gameObject.tag);

        if(col.gameObject.CompareTag("Player"))
        {
			SaveData.lastScene = "Farm";
			SceneManager.LoadScene("Wilderness");
        }
    }
}
