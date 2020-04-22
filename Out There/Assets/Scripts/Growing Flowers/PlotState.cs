﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotState : MonoBehaviour
{
	public bool canGrow;
	public bool nextStage;
	GameObject player;
	GameObject saveData;
	SaveData.plotInfo[,] plotList;
	string flowerNum;
	public int plotX;
	public int plotY;

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
		saveData = GameObject.FindGameObjectWithTag("Save Data");
		canGrow = false;
		flowerNum = "Empty";
		nextStage = true;
		plotList = SaveData.plotList;

	}
    // Update is called once per frame
    void Update()
    {
		plotType = plotList[plotX - 1, plotY - 1].plotType;
		plantGrowth = plotList[plotX - 1, plotY - 1].plantGrowth;
		Holding.Flowers flower = player.GetComponent<Holding>().flowers;
		if (canGrow)//If the player is on top of the plot and it is empty or has a grown flower on it
		{
			if (plantGrowth == PlantGrowth.Grown)//If the plot has a grown flower on it
			{
				if (Input.GetMouseButtonDown(0) && canGrow)
				{
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
						plotList[plotX - 1, plotY - 1].plotType = PlotType.Flower1;
						Debug.Log("1");
						flowerNum = "1";
						EmptyToSeed(flowerNum);
						break;
					case Holding.Flowers.Flower2:
						plotList[plotX - 1, plotY - 1].plotType = PlotType.Flower2;
						Debug.Log("2");
						flowerNum = "2";
						EmptyToSeed(flowerNum);
						break;
					case Holding.Flowers.Flower3:
						plotList[plotX - 1, plotY - 1].plotType = PlotType.Flower3;
						Debug.Log("3");
						flowerNum = "3";
						EmptyToSeed(flowerNum);
						break;
					case Holding.Flowers.Flower4:
						plotList[plotX - 1, plotY - 1].plotType = PlotType.Flower4;
						Debug.Log("4");
						flowerNum = "4";
						EmptyToSeed(flowerNum);
						break;
					case Holding.Flowers.Flower5:
						plotList[plotX - 1, plotY - 1].plotType = PlotType.Flower5;
						Debug.Log("5");
						flowerNum = "5";
						EmptyToSeed(flowerNum);
						break;
					case Holding.Flowers.Flower6:
						plotList[plotX - 1, plotY - 1].plotType = PlotType.Flower6;
						Debug.Log("6");
						flowerNum = "6";
						EmptyToSeed(flowerNum);
						break;
					case Holding.Flowers.Flower7:
						plotList[plotX - 1, plotY - 1].plotType = PlotType.Flower7;
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

		if (nextStage)
		{
			switch (plantGrowth)
			{
				case PlantGrowth.Seed:
					Debug.Log("Seed");
					StartCoroutine(SeedToGrowing(flowerNum));
					break;
				case PlantGrowth.Growing:
					Debug.Log("Growing");
					StartCoroutine(GrowingToGrown(flowerNum));
					break;
			}
		}

	}

	private void OnTriggerEnter(Collider other)
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
		plotList[plotX - 1, plotY - 1].plantGrowth = PlantGrowth.Seed;
	}

	IEnumerator SeedToGrowing(string num)
	{
		nextStage = false;
		yield return new WaitForSeconds(5);
		gameObject.transform.Find("flower" + num + "Growing").gameObject.SetActive(true);
		gameObject.transform.Find("flower" + num + "Seed").gameObject.SetActive(false);
		plotList[plotX - 1, plotY - 1].plantGrowth = PlantGrowth.Growing;
		nextStage = true;
	}

	IEnumerator GrowingToGrown(string num)
	{
		nextStage = false;
		yield return new WaitForSeconds(5);
		gameObject.transform.Find("flower" + num + "Grown").gameObject.SetActive(true);
		gameObject.transform.Find("flower" + num + "Growing").gameObject.SetActive(false);
		plotList[plotX - 1, plotY - 1].plantGrowth = PlantGrowth.Grown;
		nextStage = true;
	}

	void GrownToEmpty(string num)
	{
		gameObject.transform.Find("Empty Plot").gameObject.SetActive(true);
		gameObject.transform.Find("flower" + num + "Grown").gameObject.SetActive(false);
		plotList[plotX - 1, plotY - 1].plotType = PlotType.Empty;
		plotList[plotX - 1, plotY - 1].plantGrowth = PlantGrowth.Empty;
	}
}
