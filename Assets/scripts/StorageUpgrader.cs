using UnityEngine;

public class StorageUpgrader : MonoBehaviour
{
    public Storage building;
    public GameObject[] buildingAssets;
    public int[] maxValues;

    private void Start()
    {
        maxValues = new int[building.buildingLevel + 2];
        maxValues[0] = 1000;
        for (int i = 1; i < building.buildingLevel + 2; i++)
        {
            maxValues[i] = maxValues[i - 1] * 2;
        }
    }

    public virtual void UpgradeBuilding()
    {
        // Increase the building level
        building.buildingLevel++;

        // Change the building asset
        Destroy(building.buildingAsset);
        building.buildingAsset = Instantiate(buildingAssets[building.buildingLevel - 1], transform.position, transform.rotation);
        building.buildingAsset.transform.localScale = Vector3.one;
        building.maxValue = maxValues[building.buildingLevel - 1];
    }
}
