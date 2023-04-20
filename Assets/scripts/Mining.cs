using System;
using UnityEngine;
using TMPro;
public class Mining : MonoBehaviour
{
    public TextMeshPro ValueDisplay;
    public Mine mine;
    public PlayerData playerData;

    // Start is called before the first frame update
    void Start()
    {
        playerData.mineAmount += (playerData.closingTime.Subtract(DateTime.Now).TotalSeconds) * mine.increaseRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerData.mineAmount < mine.maxValue)
        {
            playerData.mineAmount += mine.increaseRate * Time.smoothDeltaTime;
            ValueDisplay.text = Math.Truncate(playerData.mineAmount).ToString() + " / " + mine.maxValue.ToString();
        }
        else if (playerData.mineAmount > mine.maxValue)
        {
            playerData.mineAmount = mine.maxValue;
            ValueDisplay.text = Math.Truncate(playerData.mineAmount).ToString() + " / " + mine.maxValue.ToString();
        }
    }

}
