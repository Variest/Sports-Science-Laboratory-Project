using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDisabled : MonoBehaviour
{
    // the TSPanel object cannot be found via the menu manager as it begins the scene disabled
    //the plan is to make the object start off active but disable itself instantly
    public GameObject thisObj;

    void Start()
    {
        thisObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
