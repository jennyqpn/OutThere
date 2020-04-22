using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotState : MonoBehaviour
{
	public bool canGrow;
	public bool canPick;
	GameObject player;
	string flowerNum;

	//Plot Type
	public enum PlotType { Empty, Flower1, Flower2, Flower3, Flower4, Flower5, Flower6, Flower7 }
	public PlotType plotType;

	//Plant Growth
	public enum PlantGrowth { Empty, Seed, Growing, Grown }
	public PlantGrowth plantGrowth;

	// Start is called before the first frame update
	void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player");
		canGrow = false;
		canPick = false;
		flowerNum = "Empty";
    }

    // Update is called once per frame
    void Update()
    {
		Holding.Flowers flower = player.GetComponent<Holding>().flowers;
		if (canGrow)//If the player is on top of the plot and it is empty or has a grown flower on it
		{
			if (canPick)//If the plot has a grown flower on it
			{
				if (Input.GetMouseButtonDown(0) && canGrow)
				{
					canPick = false;
					GrownToEmpty(flowerNum);
				}
			}
			else if (Input.GetMouseButtonDown(0))//The plot is empty
			{
				if (flower != Holding.Flowers.None)//The player is holding a flower
				{
					canGrow = false;
				}

				switch (flower) {
					case Holding.Flowers.Flower1:
						plotType = PlotType.Flower1;
						plantGrowth = PlantGrowth.Seed;
						Debug.Log("1");
						flowerNum = "1";
						EmptyToSeed(flowerNum);
						break;
					case Holding.Flowers.Flower2:
						plotType = PlotType.Flower2;
						plantGrowth = PlantGrowth.Seed;
						Debug.Log("2");
						flowerNum = "2";
						EmptyToSeed(flowerNum);
						break;
					case Holding.Flowers.Flower3:
						plotType = PlotType.Flower3;
						plantGrowth = PlantGrowth.Seed;
						Debug.Log("3");
						flowerNum = "3";
						EmptyToSeed(flowerNum);
						break;
					case Holding.Flowers.Flower4:
						plotType = PlotType.Flower4;
						plantGrowth = PlantGrowth.Seed;
						Debug.Log("4");
						flowerNum = "4";
						EmptyToSeed(flowerNum);
						break;
					case Holding.Flowers.Flower5:
						plotType = PlotType.Flower5;
						plantGrowth = PlantGrowth.Seed;
						Debug.Log("5");
						flowerNum = "5";
						EmptyToSeed(flowerNum);
						break;
					case Holding.Flowers.Flower6:
						plotType = PlotType.Flower6;
						plantGrowth = PlantGrowth.Seed;
						Debug.Log("6");
						flowerNum = "6";
						EmptyToSeed(flowerNum);
						break;
					case Holding.Flowers.Flower7:
						plotType = PlotType.Flower7;
						plantGrowth = PlantGrowth.Seed;
						Debug.Log("7");
						flowerNum = "7";
						EmptyToSeed(flowerNum);
						break;
					case Holding.Flowers.None:
						Debug.Log("Empty");
						flowerNum = "Empty";
						break;
				}
			}
		}

		switch (plantGrowth)
		{
			case PlantGrowth.Seed:
				StartCoroutine(SeedToGrowing(flowerNum));
				break;
			case PlantGrowth.Growing:
				StartCoroutine(GrowingToGrown(flowerNum));
				break;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if(plotType == PlotType.Empty || canPick)
		{
			canGrow = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		canGrow = false;
	}

	void EmptyToSeed(string num)
	{
		gameObject.transform.Find("flower" + num + "Seed").gameObject.SetActive(true);
		gameObject.transform.Find("Empty Plot").gameObject.SetActive(false);
		plantGrowth = PlantGrowth.Seed;
	}

	IEnumerator SeedToGrowing(string num)
	{
		yield return new WaitForSeconds(5);
		gameObject.transform.Find("flower" + num + "Growing").gameObject.SetActive(true);
		gameObject.transform.Find("flower" + num + "Seed").gameObject.SetActive(false);
		plantGrowth = PlantGrowth.Growing;
	}

	IEnumerator GrowingToGrown(string num)
	{
		yield return new WaitForSeconds(5);
		gameObject.transform.Find("flower" + num + "Grown").gameObject.SetActive(true);
		gameObject.transform.Find("flower" + num + "Growing").gameObject.SetActive(false);
		plantGrowth = PlantGrowth.Grown;
		canPick = true;
	}

	void GrownToEmpty(string num)
	{
		gameObject.transform.Find("Empty Plot").gameObject.SetActive(true);
		gameObject.transform.Find("flower" + num + "Grown").gameObject.SetActive(false);
		plotType = PlotType.Empty;
		plantGrowth = PlantGrowth.Empty;
	}
}
