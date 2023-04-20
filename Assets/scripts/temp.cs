using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class temp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevices(devices);
        foreach (var item in devices)
        {
            print(item.name);
        }
        print(devices.Count);
    }


    public void printhello()
    {
        print("hello");
    }
}
