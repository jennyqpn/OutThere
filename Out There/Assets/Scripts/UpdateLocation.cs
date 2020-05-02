using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpdateLocation : MonoBehaviour
{
	GameObject player;
	GameObject[] spawns;
	GameObject spawn;
	// Start is called before the first frame update
	void Start()
    {
		//string currentScene = SceneManager.GetActiveScene().name;
		string lastScene = SaveData.lastScene;
		//Debug.Log(currentScene + " " + lastScene);
		player = GameObject.FindGameObjectWithTag("Player");
		spawns = GameObject.FindGameObjectsWithTag("spawn");
		spawn = null;
		int i = 0;
		while(i < spawns.Length && spawn == null)
		{
			if(spawns[i].name == lastScene)
			{
				spawn = spawns[i];
			}
			i++;
		}

		/*switch (currentScene)
		{
			case "Farm":
				switch (lastScene)
				{
					case "Town":*/
		if (lastScene != "Information")
		{
			transform.position = spawn.transform.position;
		}
					/*	break;
					case "Wilderness":
						break;
					case "Information":
						break;
				}
				break;
		}*/
	}

    // Update is called once per frame
    void Update()
    {
		//Debug.Log(gameObject.transform.position);
	}
}
