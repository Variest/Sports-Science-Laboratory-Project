
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TestInput : MonoBehaviour {

    pvEquations ventCalc;
    public float StopwatchCounter = 0;
    //text boxes
  

    public InputField[] inputFields = new InputField[10];

    //boxes for storing the names of the variables being measured
    public Text[] nameBoxes = new Text[10];

    public GameObject avatarHolder;
    public Custom_Module_To_New_Scene customModule;
   
    //public InputField FEO2box;
    //public InputField FECO2box;
    //public InputField FIO2box;
    //public InputField FICO2box;
    //public InputField PBbox;
    //public InputField PH2Obox;
    //public InputField expTEMPbox;
    //public InputField VTbox;
    //public InputField TIbox;
    //public InputField FRbox;
    //public InputField weightTbox;
    //public InputField volTbox;
    //public InputField timeTbox;
    //public InputField durEPOCbox;
    public InputField tbTimeTbox;
    //public InputField consEPOCbox;
    //public InputField FEV1box;
    public Text resultField;
    //answer fields below
   

    
    public Dropdown tempChoser; // drop down list currently used to experiment with having the program take in different functions

    public GameObject calcScripts;

    public Text stopwatch;
    public Text stopwatchMinutes;
    public Text stopwatchHours;
    public Button playPause;
    public Button reset;
    public Button increaseTimeSpeed;
    public Button decreaseTimeSpeed;
    private bool play = false;
    public float timeSpeed = 1.0f;
    public float testTime = 0.0f;
    private float timerCalculations;
    float hours, minutes, seconds;
    float remainingSeconds;
    float secondsInHour = 3600;
    float secondsInMinute = 60;
    double minuteRounder;
    private int minutesInt;
    double hourRounder;
    private int hoursInt;
    //public Text popUp;

    public int functionChosen; //int value depending on which function you are trying to find the answer to
    // Use this for initialization
    void Start () {
        avatarHolder = GameObject.FindGameObjectWithTag("Avatar_Holder");
        customModule = avatarHolder.GetComponent<Custom_Module_To_New_Scene>();
        customModule.Update_ON = true;
        for(int i = 0; i < 10; i++)
        {
            customModule.textBoxes[i] = inputFields[i];
            customModule.nameBoxes[i] = nameBoxes[i];
            //Debug.Log(customModule.nameBoxText[i]);
           
        }
        resultField = GetComponent<Text>();
        ventCalc = calcScripts.GetComponent<pvEquations>();
       
        stopwatch.GetComponent<Text>();
        stopwatchMinutes.GetComponent<Text>();
        stopwatchHours.GetComponent<Text>();
        playPause.onClick.AddListener(PlayPause);
        reset.onClick.AddListener(Reset);
        increaseTimeSpeed.onClick.AddListener(plusTime);
        decreaseTimeSpeed.onClick.AddListener(minusTime);
       // popUp.GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {

        if(play == true)
        {
            calculateTime();
            System.Math.Floor(hourRounder);
            System.Math.Floor(minuteRounder);
            stopwatch.text = remainingSeconds.ToString("00.00");
            stopwatchMinutes.text = minutesInt.ToString("00");
            stopwatchHours.text = hoursInt.ToString("00");
            testTime += Time.deltaTime;//constantly updates testtime based off of runtime.
            customModule.timeElapsed = testTime;
            stopwatch.text = testTime.ToString("0.00");
           // Debug.Log("help");
        }
      
        for (int i = 0; i < 10; i++)
        {
            customModule.nameBoxes[i].text = customModule.nameBoxText[i];
            //Debug.Log(customModule.nameBoxText[i]);
        }
    }

    void PlayPause()
    {
        play ^= true;
        customModule.Timer_ON ^= true;
        for(int i = 0; i < 10; i++)
        {
            //inputFields[i].readOnly ^= true;
        }
  

    }

    void calculateTime()
    {
        testTime += Time.deltaTime * timeSpeed;//constantly updates testtime based off of runtime.
        timerCalculations = testTime;
        hours = timerCalculations / secondsInHour;
        hourRounder = (double)hours;
        hoursInt = (int)hourRounder;
        
        remainingSeconds = timerCalculations % secondsInHour;
        minutes = remainingSeconds/secondsInMinute;
        minuteRounder = (double)minutes;
        minutesInt = (int)minuteRounder;

        remainingSeconds %= secondsInMinute;
    }

    void Reset()
    {
        testTime = 0;
        minuteRounder = 0;
        hourRounder = 0;
        timerCalculations = 0;
        remainingSeconds = 0;
        seconds = 0;
        minutes = 0;
        hours = 0;
        minutesInt = 0;
        hoursInt = 0;
        timeSpeed = 1.0f;
        stopwatch.text = seconds.ToString("00.00");
        stopwatchMinutes.text = minutes.ToString("00");
        stopwatchHours.text = hours.ToString("00");
    }

    void plusTime()
    {
        timeSpeed = timeSpeed * 2;
        Debug.Log(timeSpeed);
        StartCoroutine(WaitFor2());
    }

    void minusTime()
    {
        timeSpeed = timeSpeed / 2;
        Debug.Log(timeSpeed);
        StartCoroutine(WaitFor2());
        /*for (int i = 0; i < 10; i++)
        {
            inputFields[i].text = "";
        }*/
    }

    IEnumerator WaitFor2()
    {
       // popUp.text = timeSpeed.ToString("00.00");
        yield return new WaitForSecondsRealtime(2);
       // popUp.text = "";
    }

    public void Calculate()
    {

    }
}

