using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Holding : MonoBehaviour
{
	public static string itemHolding;

	// Start is called before the first frame update
	void Start()
	{
		if (SceneManager.GetActiveScene().name == "Information")
		{
			itemHolding = "none";
		}
	}

    // Update is called once per frame
    void Update()
    {
		//Debug.Log(itemHolding);
    }
}
