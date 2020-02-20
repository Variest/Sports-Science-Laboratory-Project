
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TestInput : MonoBehaviour {

    pvEquations ventCalc;
    public float StopwatchCounter = 0;
    public InputField FEO2box;
    public InputField FECO2box;
    public InputField FIO2box;
    public InputField FICO2box;
    public InputField PBbox;
    public InputField PH2Obox;
    public InputField expTEMPbox;
    public InputField VTbox;
    public InputField TIbox;
    public InputField FRbox;
    public InputField weightTbox;
    public InputField volTbox;
    public InputField timeTbox;
    public InputField durEPOCbox;
    public InputField tbTimeTbox;
    public InputField consEPOCbox;
    public InputField FEV1box;
    public Text resultField;
    //answer fields below
    public InputField expiryTime;
    public InputField expiryRatio;
    public InputField VE;
    public InputField VI;
    public InputField VCO2;
    public InputField VO2;
    public InputField RER;
    public InputField RQ;
    public InputField Vecap;
    public InputField VeVO2;
    public InputField VeVCO2;
    public InputField EPOC;
    public InputField MET;
    public InputField VO2fr;

    
    public Dropdown tempChoser; // drop down list currently used to experiment with having the program take in different functions

    public GameObject calcScripts;

    public Text Stopwatch;
    public Text StopwatchMinutes;
    public Text StopwatchHours;
    public Button playPause;
    public Button reset;
    public Button increaseTimeSpeed;
    public Button decreaseTimeSpeed;
    private bool play = false;
    public float timeSpeed = 1.0f;
    public float testtime = 0.0f;
    private float timerCalculations;
    float hours, minutes, seconds;
    float remainingSeconds;
    float secondsInHour = 3600;
    float secondsInMinute = 60;
    double minuteRounder;
    private int minutesInt;
    double hourRounder;
    private int hoursInt;
    public int functionChosen; //int value depending on which function you are trying to find the answer to
    // Use this for initialization
    void Start () {
        resultField = GetComponent<Text>();
        ventCalc = calcScripts.GetComponent<pvEquations>();
        expiryTime.readOnly = true;
        expiryRatio.readOnly = true;
        VE.readOnly = true;
        VI.readOnly = true;
        VCO2.readOnly = true;
        VO2.readOnly = true;
        RER.readOnly = true;
        RQ.readOnly = true;
        Vecap.readOnly = true;
        VeVO2.readOnly = true;
        VeVCO2.readOnly = true;
        EPOC.readOnly = true;
        MET.readOnly = true;
        VO2fr.readOnly = true;
        Stopwatch.GetComponent<Text>();
        StopwatchMinutes.GetComponent<Text>();
        StopwatchHours.GetComponent<Text>();
        playPause.onClick.AddListener(PlayPause);
        reset.onClick.AddListener(Reset);
        increaseTimeSpeed.onClick.AddListener(plusTime);
        decreaseTimeSpeed.onClick.AddListener(minusTime);
    }
	
	// Update is called once per frame
	void Update () {

        if(play == true)
        {
            calculateTime();
            System.Math.Floor(hourRounder);
            System.Math.Floor(minuteRounder);
            Stopwatch.text = seconds.ToString("00.00");
            StopwatchMinutes.text = minutesInt.ToString("00");
            StopwatchHours.text = hoursInt.ToString("00");
        }
        

    }

    void PlayPause()
    {
        play ^= true;
    }

    void calculateTime()
    {
        testtime += Time.deltaTime * timeSpeed;//constantly updates testtime based off of runtime.
        timerCalculations = testtime;
        hours = timerCalculations / secondsInHour;
        hourRounder = (double)hours;
        hoursInt = (int)hourRounder;
        
        remainingSeconds = timerCalculations % secondsInHour;
        minutes = remainingSeconds/secondsInMinute;
        minuteRounder = (double)minutes;
        minutesInt = (int)minuteRounder;

        remainingSeconds = remainingSeconds % secondsInMinute;
        seconds = remainingSeconds;
    }

    void Reset()
    {
        testtime = 0;
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
        Stopwatch.text = seconds.ToString("00.00");
        StopwatchMinutes.text = minutes.ToString("00");
        StopwatchHours.text = hours.ToString("00");
    }

    void plusTime()
    {
        timeSpeed = timeSpeed + 1f;
        Debug.Log(timeSpeed);
    }

    void minusTime()
    {
        timeSpeed = timeSpeed - 1f;
        Debug.Log(timeSpeed);
    }
    public void Calculate()
    {
        //float temp1 = float.Parse(box1.text);
        // float temp2 = float.Parse(box2.text);
        //float temp3 = float.Parse(box3.text);
        //float answer = temp1 + temp2 + temp3;
        //resultField.text = answer.ToString();
       
        functionChosen = tempChoser.value;
        /*
        switch(functionChosen)
        {
            case (0):
                //will be used to handle the expire time function
                ventCalc.breathTime = float.Parse(tbTimeTbox.text);
                ventCalc.TI = float.Parse(TIbox.text);
                float temp = ventCalc.ExpireTime();
                resultField.text = temp.ToString();
                break;
            case (1):
                ventCalc.TI = float.Parse(box1.text);
                ventCalc.TE = float.Parse(box2.text);
                float temp1 = ventCalc.InspireExpireRatio();
                resultField.text = temp1.ToString();
                break;
        }
        */
        ventCalc.breathTime = float.Parse(tbTimeTbox.text);
        ventCalc.TI = float.Parse(TIbox.text);
        ventCalc.VT = float.Parse(VTbox.text);
        ventCalc.FICO2 = float.Parse(FICO2box.text);
        ventCalc.FECO2 = float.Parse(FECO2box.text);
        ventCalc.FEO2 = float.Parse(FEO2box.text);
        ventCalc.FIO2 = float.Parse(FIO2box.text);
        ventCalc.fr = float.Parse(FRbox.text);
        float tempWeight = float.Parse(weightTbox.text);
        float tempFEV = float.Parse(FEV1box.text);
        float tempPb = float.Parse(PBbox.text);
        float tempPH2O = float.Parse(PH2Obox.text);
        float tempExpTemperature = float.Parse(expTEMPbox.text);
        float tempEPOCduration = float.Parse(durEPOCbox.text);
        float tempEPOCconsume = float.Parse(consEPOCbox.text);
        float tempTime = float.Parse(timeTbox.text);
        float tempVolume = float.Parse(volTbox.text);
        //debugging for the actual equations and shit idk
        switch (functionChosen)
        {
            case (0):
                Debug.Log("VE(ATPS) = " + ventCalc.CalcVeATPS(tempVolume, tempTime));
                ventCalc.CalcVeSTPD(tempPb, tempPH2O, tempExpTemperature);
                ventCalc.CalcVeBTPS(tempPb, tempPH2O, tempExpTemperature);

                break;
            case (1):
                ventCalc.CalcVeATPS(tempVolume, tempTime);

                Debug.Log("VE(STPD) = " + ventCalc.CalcVeSTPD(tempPb, tempPH2O, tempExpTemperature));
                ventCalc.CalcVeBTPS(tempPb, tempPH2O, tempExpTemperature);
                break;
            case (2):
                ventCalc.CalcVeATPS(tempVolume, tempTime);
                ventCalc.CalcVeSTPD(tempPb, tempPH2O, tempExpTemperature);
                Debug.Log("VE(BTPS) = " + ventCalc.CalcVeBTPS(tempPb, tempPH2O, tempExpTemperature));
                break;
        }
        //Runs the calculate function for respective Value and changes it to a string to display it in a textbox
        expiryTime.text = ventCalc.ExpireTime().ToString();        
        expiryRatio.text = ventCalc.InspireExpireRatio().ToString();
        VE.text = ventCalc.CalcVE().ToString();

        //Debug.Log("VE(ATPS) = " + ventCalc.CalcVeATPS(tempVolume, tempTime));
        //Debug.Log("VE(STPD) = " + ventCalc.CalcVeSTPD(tempPb, tempPH2O, tempExpTemperature));
        // Debug.Log("VE(BTPS) = " + ventCalc.CalcVeBTPS(tempPb, tempPH2O, tempExpTemperature));

        VI.text = ventCalc.calcVI().ToString();
        VCO2.text = ventCalc.ExpireTime().ToString();
        VO2.text = ventCalc.OxygenConsumption().ToString();
        RER.text = ventCalc.respiratoryExRatio().ToString();
        RQ.text = ventCalc.respiratoryQuotient().ToString();
        Vecap.text = ventCalc.VentCapacity(tempFEV).ToString();
        VeVO2.text = ventCalc.VentEquivOxygen().ToString();
        VeVCO2.text = ventCalc.VentEquivCO2().ToString();
        EPOC.text = ventCalc.calcEPOC(tempEPOCduration, tempEPOCconsume).ToString();
        MET.text = ventCalc.calcMET(tempWeight).ToString();
        VO2fr.text = ventCalc.OxygenBreath().ToString();
    }
}

