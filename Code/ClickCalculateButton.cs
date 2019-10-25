using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickCalculateButton : MonoBehaviour {
    TestInput test;
    public Button calculateButton;
    public GameObject resultField;
	// Use this for initialization
	void Start () {
        test = resultField.GetComponent<TestInput>();
        calculateButton.onClick.AddListener(taskOnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void taskOnClick()
    {
        test.Calculate();
    }
}
