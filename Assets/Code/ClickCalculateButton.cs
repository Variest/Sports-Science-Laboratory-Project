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

    private bool clicked;
    private int counter = 1;
    private float waitTime = 2.0f;
    private float timer = 0.0f;

    // Use this for initialization
    void Start () {
        test = resultField.GetComponent<TestInput>();
        calculateButton.onClick.AddListener(taskOnClick);
        hideButton.onClick.AddListener(hideOnClick);
    }
	
	// Update is called once per frame
	void Update () {
        if (counter > 1)
        { 
            timer += Time.deltaTime;

            if (timer > waitTime)
            {
                StartCoroutine(processTask());
                timer = timer - waitTime;
            }
        }
	}
    void taskOnClick()
    {
        if(counter == 1)
        {
            counter++;
        }
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

    IEnumerator processTask()
    {
        yield return new WaitForSeconds(2);
        test.Calculate();
    }
}

