using UnityEngine;

public class MineUpgrader : MonoBehaviour
{
    public Mine building;
    public GameObject[] buildingAssets;
    public double[] increaseRates;
    public int[] maxValues;
    private void Start()
    {
        increaseRates = new double[building.buildingLevel+2];
        maxValues = new int[building.buildingLevel+2];
        increaseRates[0] = 0.1;
        for (int i = 1; i < building.buildingLevel+2; i++)
        {
            increaseRates[i] = increaseRates[i - 1] * 1.8;
        }

        maxValues[0] = 100;
        for (int i = 1; i < building.buildingLevel+2; i++)
        {
            maxValues[i] = maxValues[i - 1] * 2;
        }
    }

    public void UpgradeBuilding()
    {
        building.buildingLevel++;

        Destroy(building.buildingAsset);
        building.buildingAsset = Instantiate(buildingAssets[building.buildingLevel - 1], transform.position, transform.rotation);
        building.buildingAsset.transform.parent = transform;
        building.buildingAsset.transform.localScale = Vector3.one;

        print("hi");
        building.increaseRate = increaseRates[building.buildingLevel - 1];
        building.maxValue = maxValues[building.buildingLevel - 1];
    }
}
