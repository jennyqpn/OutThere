using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveData : MonoBehaviour
{
	public struct plotInfo
	{
		public PlotState.PlotType plotType;
		public PlotState.PlantGrowth plantGrowth;
	}

	public static plotInfo[,] plotList = new plotInfo[5, 5];
	public static string lastScene;
    // Start is called before the first frame update
    void Start()
    {
		if (SceneManager.GetActiveScene().name == "Farm")
		{
			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < 5; j++)
				{
					plotList[i, j].plotType = PlotState.PlotType.Empty;
					plotList[i, j].plantGrowth = PlotState.PlantGrowth.Empty;
				}
			}
		}
	}

    // Update is called once per frame
    void Update()
    {
		string str = "";
        foreach(plotInfo info in plotList)
		{
			str += "[" + info.plotType + "," + info.plantGrowth + "] ";
		}
		Debug.Log(str + "\n");
    }
}
