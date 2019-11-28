using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickCalculateButton : MonoBehaviour {
    TestInput test;
    public Button calculateButton;
    public GameObject resultField;
    public GameObject answerPanel;
    public GameObject inputPanel;
    public Button hideButton;
    // Use this for initialization
    void Start () {
        test = resultField.GetComponent<TestInput>();
        calculateButton.onClick.AddListener(taskOnClick);
        hideButton.onClick.AddListener(hideOnClick);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void taskOnClick()
    {
        test.Calculate();
        if (answerPanel || inputPanel != false)
        {
            answerPanel.SetActive(true);
            inputPanel.SetActive(false);
        }
        
    }

    void hideOnClick()
    {
        if (answerPanel || inputPanel != false)
        {
            answerPanel.SetActive(false);
            inputPanel.SetActive(true);
        }
    }
}

