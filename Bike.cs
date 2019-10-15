using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bike : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class bike
{
    //HEART RATE INCREASE STUFF
    //FOR MEN: 4.7 BPM/10W
    //FOR WOMEN 7.6 BPM/10W
	float wattage;
    float resistance;
    float RPM;

    bike()
    {
        resistance = 40; //this needs a function for putting in information
        RPM = 0;
    }

    void wattagefunc()
    {
        wattage = (RPM * resistance);
    }
};