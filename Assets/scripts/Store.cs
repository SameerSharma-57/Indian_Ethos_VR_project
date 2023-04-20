using System;
using UnityEngine;
using TMPro;
public class Store : MonoBehaviour
{
    public Storage storage;
    public TextMeshPro ValueDisplay;
    public TextMeshPro Heading;
    public PlayerData playerData;

    // Start is called before the first frame update
    void Start()
    {
        setValues();
    }

    void setValues()
    {
        string displayText="|";
        double total=0;
        for (int i = 0; i < playerData.resourceNames.Length; i++)
        {
            displayText += playerData.resourceNames[i] +":"+ playerData.resourceAmounts[i].ToString() + " | ";
            total += playerData.resourceAmounts[i];
        }
        Heading.text = "Storage : " + total.ToString() + "/" + storage.maxValue.ToString();
    }

    public void saveOres()
    {
        double total = 0;
        for (int i = 0; i < playerData.resourceNames.Length; i++)
        {
            total += playerData.resourceAmounts[i];
        }
        if (storage.maxValue >=( total + playerData.mineAmount))
        {
            playerData.resourceAmounts[Array.IndexOf(playerData.resourceNames, "Ores")] += playerData.mineAmount;
            playerData.mineAmount = 0;
        }
        else
        {
            playerData.resourceAmounts[Array.IndexOf(playerData.resourceNames, "Ores")] += (storage.maxValue - total);
            playerData.mineAmount -= (storage.maxValue - total);
        }

    }
}
