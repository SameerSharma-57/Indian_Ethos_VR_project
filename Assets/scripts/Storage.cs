using System;
using UnityEngine;
public class Storage : MonoBehaviour
{
    public int buildingLevel;
    public string buildingName;
    public GameObject buildingAsset;
    public PlayerData playerData;
    public StorageUpgrader upgrader;
    public int maxValue;
    private void Start()
    {
        LoadLevel();
    }

    public void LoadLevel()
    {
        buildingLevel = playerData.buildingLevels[Array.IndexOf(playerData.buildingNames, buildingName)];
        buildingAsset = Instantiate(upgrader.buildingAssets[buildingLevel - 1], transform.position, transform.rotation);
        buildingAsset.transform.parent = transform;
        buildingAsset.transform.localScale = Vector3.one;
        maxValue = upgrader.maxValues[buildingLevel - 1];
    }
}
