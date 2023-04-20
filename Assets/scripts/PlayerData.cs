using System;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int[] buildingLevels;
    public string[] buildingNames;
    public double[] resourceAmounts;
    public string[] resourceNames;
    public double mineAmount;
    public double factoryAmount;
    public DateTime closingTime;

    private void setInitial()
    {
        buildingLevels = new int[4] { 1, 1, 1, 1 };
        buildingNames = new string[4] { "Mine", "Factory", "Watch Tower", "Storage" };
        resourceAmounts = new double[2] { 0f, 0f };
        resourceNames = new string[2] { "Ores", "Bricks" };
        closingTime = DateTime.Now;
        mineAmount = 0;
        factoryAmount = 0;
    }

    private void Start()
    {
        LoadPlayerData();
    }

    private void LoadPlayerData()
    {
        if (PlayerPrefs.HasKey("ClosingTime"))
        {
            closingTime = DateTime.FromBinary(Convert.ToInt64(PlayerPrefs.GetString("ClosingTime")));
            mineAmount = PlayerPrefs.GetFloat("MineValue", 0f);
            factoryAmount = PlayerPrefs.GetFloat("FactoryValue", 0f);
            for (int i = 0; i < buildingLevels.Length; i++)
            {
                buildingLevels[i] = PlayerPrefs.GetInt("BuildingLevel_" + i.ToString(), 0);
            }
            for (int i = 0; i < resourceAmounts.Length; i++)
            {
                resourceAmounts[i] = PlayerPrefs.GetFloat("ResourceAmount_" + i.ToString(), 0f);
                resourceNames[i] = PlayerPrefs.GetString("Resource_" + i.ToString(), "No Resource");
            }
        }
        else
        {
            setInitial();
        }
    }

    private void SavePlayerData()
    {
        PlayerPrefs.SetString("ClosingTime", DateTime.Now.ToBinary().ToString());
        PlayerPrefs.SetFloat("MineValue", mineAmount);
        PlayerPrefs.SetFloat("FactoryValue", factoryAmount);
        for (int i = 0; i < buildingLevels.Length; i++)
        {
            PlayerPrefs.SetInt("BuildingLevel_" + i.ToString(), buildingLevels[i]);
        }
        for (int i = 0; i < resourceAmounts.Length; i++)
        {
            PlayerPrefs.SetFloat("ResourceAmount_" + i.ToString(), resourceAmounts[i]);
            PlayerPrefs.SetString("Resource_" + i.ToString(), resourceNames[i]);
        }
    }

    private void OnDestroy()
    {
        SavePlayerData();
    }
}
