using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Mining : MonoBehaviour
{
    public TextMeshPro ValueDisplay;
    public double increaseRate; //in double/seconds
    public int maxVal;
    private double cVal = -1;
    private DateTime prevTime;
    public double currentVal
    {
        get { return cVal; }
        set
        {
            cVal = value;
            ValueDisplay.text = Math.Truncate(cVal) + " / " + maxVal;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (currentVal == -1)
        {
            currentVal = 0;
        }
        else
        {
            prevTime = DateTime.FromBinary(Convert.ToInt64(PlayerPrefs.GetString("Closing Time")));
            currentVal += (prevTime.Subtract(DateTime.Now).TotalSeconds) * increaseRate;
        }
        ValueDisplay.text = currentVal.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentVal < maxVal)
        {
            currentVal += increaseRate * Time.smoothDeltaTime;
        }
        else if (currentVal > maxVal)
        {
            currentVal = maxVal;
        }
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetString("Closing Time", DateTime.Now.ToBinary().ToString());
    }
}
