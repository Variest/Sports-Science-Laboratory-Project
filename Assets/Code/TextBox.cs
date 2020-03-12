using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBox : MonoBehaviour
{
    GraphScriptHR Graph;
    Output output;
    public string Max;
    public string Var;
    public string bwc;
    public string cbh;
    public string bla;
    public string hr;
    public string et;
    public Text Variable;
    public Text MAX;
    public Text BWC;
    public Text CBH;
    public Text Bla;
    public Text HR;
    public Text ET;

    // Start is called before the first frame update
    public void Start()
    {
        Graph = GetComponent<GraphScriptHR>();
        output = GetComponent<Output>();
    }

    // Update is called once per frame
    public void Update()
    {
        Max = Graph.InputMax.ToString();
        Var = Graph.Variable;
        bla = output.Bla;

        Variable.text = Var;
        MAX.text = Max;
        BWC.text = output.Water;
        CBH.text = output.Heat;
        ET.text = output.Exercise;
        Bla.text = bla;
        HR.text = output.HR;
    }
}
