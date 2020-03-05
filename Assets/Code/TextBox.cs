﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBox : MonoBehaviour
{
    GraphScriptHR Graph;
    Output output;
    string Max;
    string Var;
    string bwc;
    string cbh;
    string bla;
    string hr;
    string et;
    public Text Variable;
    public Text MAX;
    public Text BWC;
    public Text CBH;
    public Text Bla;
    public Text HR;
    public Text ET;

    // Start is called before the first frame update
    void Start()
    {
        Graph = GetComponent<GraphScriptHR>();
        output = GetComponent<Output>();
    }

    // Update is called once per frame
    void Update()
    {
        Max = Graph.InputMax.ToString();
        Var = Graph.Variable;
        hr = output.HR;

        Variable.text = Var;
        MAX.text = Max;
        BWC.text = output.Water;
        CBH.text = output.Heat;
        Bla.text = output.Bla;
        HR.text = hr;
        ET.text = output.Exercise;
    }
}
