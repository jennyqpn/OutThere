using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpdateLocation : MonoBehaviour
{

	// Start is called before the first frame update
	void Start()
    {
		string currentScene = SceneManager.GetActiveScene().name;
		string lastScene = SaveData.lastScene;
		Debug.Log(currentScene + " " + lastScene);
		switch (currentScene)
		{
			case "Farm":
				switch (lastScene)
				{
					case "Town":
						break;
					case "Wilderness":
						break;
					case "Information":
						StartCoroutine(SetSpawn(244, 1, 257));
						break;
				}
				break;
		}
	}

    // Update is called once per frame
    void Update()
    {
		Debug.Log(gameObject.transform.position);
	}

	IEnumerator SetSpawn(int x, int y, int z)
	{
		yield return new WaitForSeconds(.5f);
		transform.position = new Vector3(x, y, z);
		
	}
}
