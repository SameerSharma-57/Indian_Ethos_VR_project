using System;
using UnityEngine;
public class Mine : MonoBehaviour
{
    public double increaseRate;
    public int maxValue;
    public MineUpgrader upgrader;
    public int buildingLevel;
    public string buildingName;
    public GameObject buildingAsset;
    public PlayerData playerData;
    public void LoadLevel()
    {
        buildingLevel = playerData.buildingLevels[Array.IndexOf(playerData.buildingNames, buildingName)];
        buildingAsset = Instantiate(upgrader.buildingAssets[buildingLevel - 1], transform.position, transform.rotation);
        buildingAsset.transform.parent = transform;
        buildingAsset.transform.localScale = Vector3.one;
        increaseRate = upgrader.increaseRates[buildingLevel - 1];
        maxValue = upgrader.maxValues[buildingLevel - 1];
    }
    private void Start()
    {
        LoadLevel();
    }

}
