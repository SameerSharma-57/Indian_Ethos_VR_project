using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class temp : MonoBehaviour
{
    // Start is called before the first frame update
    
        public List<InputDevice> devices = new List<InputDevice>();
    
    void Start()
    {
        InputDevices.GetDevices(devices);
       foreach (InputDevice device in devices)
        {
            Debug.Log(device.name + device.characteristics);
        }
        Debug.Log(devices.Count);
        
    }

    // Update is called once per frame
    void Update()
    {
       

    }
}
