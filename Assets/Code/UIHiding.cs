﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHiding : MonoBehaviour
{

    public GameObject TSPanel;
    public GameObject MSPanel;
    public GameObject CPanel;
    public GameObject PAPanel;
    public GameObject CAPanel;
    public GameObject MAPanel;

    public Image WhiteM;
    public Image BlackM;
    public Image AsianM;
    public Image WhiteF;
    public Image BlackF;
    public Image AsianF;

    // Start is called before the first frame update
    void Start()
    {
        //Module Selection Scene
        if (TSPanel && MSPanel != false)
        {
            TSPanel.gameObject.SetActive(false);
            MSPanel.gameObject.SetActive(true);
        }
        else
        if (CPanel && PAPanel && CAPanel && MAPanel != false)
        {
            //Variable Selection Scene
            CPanel.gameObject.SetActive(true);
            PAPanel.gameObject.SetActive(false);
            CAPanel.gameObject.SetActive(false);
            MAPanel.gameObject.SetActive(false);
        }

        if (WhiteM && BlackM && AsianM && WhiteF && BlackF && AsianF != false)
        {
            WhiteM.gameObject.SetActive(false);
            BlackM.gameObject.SetActive(false);
            AsianM.gameObject.SetActive(false);
            WhiteF.gameObject.SetActive(false);
            BlackF.gameObject.SetActive(false);
            AsianF.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
