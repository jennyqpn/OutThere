using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotState : MonoBehaviour
{
	public bool canGrow;
	GameObject player;

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
    }

    // Update is called once per frame
    void Update()
    {
		Holding.Flowers flower = player.GetComponent<Holding>().flowers;
		if (canGrow)
		{

			if (Input.GetMouseButtonDown(0))
			{
				if (flower != Holding.Flowers.None)
				{
					canGrow = false;
				}

				switch (flower) {
					case Holding.Flowers.Flower1:
						plotType = PlotType.Flower1;
						plantGrowth = PlantGrowth.Seed;
						Debug.Log("1");
						break;
					case Holding.Flowers.Flower2:
						plotType = PlotType.Flower2;
						plantGrowth = PlantGrowth.Seed;
						Debug.Log("2");
						break;
					case Holding.Flowers.Flower3:
						plotType = PlotType.Flower3;
						plantGrowth = PlantGrowth.Seed;
						Debug.Log("3");
						break;
					case Holding.Flowers.Flower4:
						plotType = PlotType.Flower4;
						plantGrowth = PlantGrowth.Seed;
						Debug.Log("4");
						break;
					case Holding.Flowers.Flower5:
						plotType = PlotType.Flower5;
						plantGrowth = PlantGrowth.Seed;
						Debug.Log("5");
						break;
					case Holding.Flowers.Flower6:
						plotType = PlotType.Flower6;
						plantGrowth = PlantGrowth.Seed;
						Debug.Log("6");
						break;
					case Holding.Flowers.Flower7:
						plotType = PlotType.Flower7;
						plantGrowth = PlantGrowth.Seed;
						Debug.Log("7");
						break;
					case Holding.Flowers.None:
						Debug.Log("Empty");
						break;
				}
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if(plotType == PlotType.Empty)
		{
			canGrow = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (plotType == PlotType.Empty)
		{
			canGrow = false;
		}
	}
}
