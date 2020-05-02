using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotState : MonoBehaviour
{
	public bool canGrow;
	public bool nextStage;
	GameObject player;
	SaveData.plotInfo[,] plotList;
	string flowerNum;
	public int plotX;
	public int plotY;
	public List<Item> flowerItems;


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
		plotList = SaveData.plotList;
		canGrow = plotList[plotX-1,plotY-1].canGrow;
		flowerNum = plotList[plotX - 1, plotY - 1].flowerNum;
		nextStage = true;
		plotType = plotList[plotX - 1, plotY - 1].plotType;
		plantGrowth = plotList[plotX - 1, plotY - 1].plantGrowth;
		if(plotType != PlotType.Empty)
		{
			gameObject.transform.Find("flower" + flowerNum + plantGrowth.ToString()).gameObject.SetActive(true);
			gameObject.transform.Find("Empty Plot").gameObject.SetActive(false);
		}
	}
    // Update is called once per frame
    void Update()
    {
		plotList[plotX - 1, plotY - 1].canGrow = canGrow;
		plotList[plotX - 1, plotY - 1].flowerNum = flowerNum;
		plotList[plotX - 1, plotY - 1].plotType = plotType;
		plotList[plotX - 1, plotY - 1].plantGrowth = plantGrowth;
		string item = Holding.itemHolding;
		List<Item> items = Inventory.items;
		if (canGrow)//If the player is on top of the plot and it is empty or has a grown flower on it
		{
			if (plantGrowth == PlantGrowth.Grown)//If the plot has a grown flower on it
			{
				if (Input.GetMouseButtonDown(0) && canGrow)
				{
					Item newItem = flowerItems[Int32.Parse(flowerNum) - 1];
					Inventory.instance.AddItem(newItem);
					Inventory.instance.AddItem(newItem);
					GrownToEmpty(flowerNum);
				}

			}
			else if (Input.GetMouseButtonDown(0))//The plot is empty
			{
				if (!item.StartsWith("Flower"))//The player is holding a flower
				{
					canGrow = false;
				}

				switch (item) {
					case "Flower 1":
						plotType = PlotType.Flower1;
						//Debug.Log("1");
						flowerNum = "1";
						EmptyToSeed(flowerNum);
						lowerQuantity(items, item);
						break;
					case "Flower 2":
						plotType = PlotType.Flower2;
						//Debug.Log("2");
						flowerNum = "2";
						EmptyToSeed(flowerNum);
						lowerQuantity(items, item);
						break;
					case "Flower 3":
						plotType = PlotType.Flower3;
						//Debug.Log("3");
						flowerNum = "3";
						EmptyToSeed(flowerNum);
						lowerQuantity(items, item);
						break;
					case "Flower 4":
						plotType = PlotType.Flower4;
						//Debug.Log("4");
						flowerNum = "4";
						EmptyToSeed(flowerNum);
						lowerQuantity(items, item);
						break;
					case "Flower 5":
						plotType = PlotType.Flower5;
						//Debug.Log("5");
						flowerNum = "5";
						EmptyToSeed(flowerNum);
						lowerQuantity(items, item);
						break;
					case "Flower 6":
						plotType = PlotType.Flower6;
						//Debug.Log("6");
						flowerNum = "6";
						EmptyToSeed(flowerNum);
						lowerQuantity(items, item);
						break;
					case "Flower  7":
						plotType = PlotType.Flower7;
						//Debug.Log("7");
						flowerNum = "7";
						EmptyToSeed(flowerNum);
						lowerQuantity(items, item);
						break;
					default:
						//Debug.Log("Empty");
						flowerNum = "Empty";
						break;
				}
			}
		}

		if (nextStage)
		{
			switch (plantGrowth)
			{
				case PlantGrowth.Seed:
					//Debug.Log("Seed");
					StartCoroutine(SeedToGrowing(flowerNum));
					break;
				case PlantGrowth.Growing:
					//Debug.Log("Growing");
					StartCoroutine(GrowingToGrown(flowerNum));
					break;
			}
		}

	}

	void lowerQuantity(List<Item> items, string item)
	{
		for(int i = 0; i < items.Count; i++)
		{
			if (items[i].name == item)
			{
				if (items[i].quantity <= 1)
				{
					if (i != items.Count - 1)
					{
						Holding.itemHolding = items[i + 1].name;
					}
					else
					{
						Holding.itemHolding = "none";
					}
				}
				Inventory.instance.RemoveItem(items[i]);
				break;
			}
		}
	}
	private void OnTriggerStay(Collider other)
	{
		if(plotType == PlotType.Empty || plantGrowth == PlantGrowth.Grown)
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
		nextStage = false;
		yield return new WaitForSeconds(5);
		gameObject.transform.Find("flower" + num + "Growing").gameObject.SetActive(true);
		gameObject.transform.Find("flower" + num + "Seed").gameObject.SetActive(false);
		plantGrowth = PlantGrowth.Growing;
		nextStage = true;
	}

	IEnumerator GrowingToGrown(string num)
	{
		nextStage = false;
		yield return new WaitForSeconds(5);
		gameObject.transform.Find("flower" + num + "Grown").gameObject.SetActive(true);
		gameObject.transform.Find("flower" + num + "Growing").gameObject.SetActive(false);
		plantGrowth = PlantGrowth.Grown;
		nextStage = true;
	}

	void GrownToEmpty(string num)
	{
		gameObject.transform.Find("Empty Plot").gameObject.SetActive(true);
		gameObject.transform.Find("flower" + num + "Grown").gameObject.SetActive(false);
		plotType = PlotType.Empty;
		plantGrowth = PlantGrowth.Empty;
	}
}
