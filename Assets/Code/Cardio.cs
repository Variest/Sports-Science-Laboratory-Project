using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cardio : MonoBehaviour
{
    //BASIC MODULE
    public float Bla = 0.0f; //blood lactate 	        SOMEWHAT appropriately modelled
    public float BlaT; //CB blood lactate threshold     85% of max heart rate or 75% of VO2Max
    public float BPd; //I diastolic blood pressure  	INPUT 
    public float BPs; //I/M systolic blood pressure 	INPUT, and we have a DECENT way of modelling it;
    public float MAP; //CA mean arterial pressure =		(BPd + [0.3333(BPs-BPd)])
    public float HR; //M heart rate/fc -				measured, but we have a decent way of calculating it;
    public float HRmax; //CB heart rate maximum =		(220-age)
    public float OP; //CA oxygen pulse =				VO2/HR   

    //MEDIUM MODULE
    public float CO; //CA cardiac output =				SV*HR OR MAP/TPR
    public float HRres; //CB heart rate reserve =		HRmax-HRresting
    public float BP; //CA mean blood pressure =			CO*TPR
    public float SV; //CA stroke volume =				EDV-ESV
    public float HRrest; //I heart rate resting -	    input

    //ADVANCED MODULE
    public float EF; //CA ejection fraction =			(SV/EDV)*100
    public float EDV; //I/M end diastolic volume -		measured - MIGHT BE INPUT? (changes a little bit) ABOUT 120 mm, INCREASES BY 18% AT MAXIMAL EXERCISE
    public float ESV; //I/M end systolic volume -		measured - MIGHT BE INPUT? (changes a little bit) ABOUT 40-50 mm, DECREASES BY 21% AT MAXIMAL EXERCISE
     public float SW; //CA stroke work =				SV*MAP
    public float TPR; //CA total peripheral resistance = MAP/CO

    //FOR MODELLING 
    public float BlaTarget = 0.0f;
    public float HRtarg = 0.0f;
    public float BPsTarg = 0.0f;
    public float BPsBase;
    public float EDVbase;
    public float ESVbase;

    private float velocityBla = 0.0f; //FOR SMOOTHDAMP
    private float velocityHR = 0.0f; //FOR SMOOTHDAMP
    private float velocityBps = 0.0f; //FOR SMOOTHDAMP

    //OUTPUT
    public float BlaCond;
    public float HRCond;
    public int danger = 0;

    //EXTRA
    public float health = 0;
    public int healthsetting = 1;
    //level one is entirely self contained, aside from oxygen pulse needing VO2 from a different section
    //levels two and three are very codependent, however, with them needing variables from eachother

    //CARDIOVASCULAR MODULES
    //basic: Heart Rate (FC/HR), Oxygen Pulse (OP), Mean Arterial Pressure (MAP), Max Heart Rate (HRMax)
    //advanced: above + Blood Lactate (Bla), Cardiac Output (CO), Blood Pressure (Bpd, Bps), Stroke Volume (SV), Heart Rate Reserve (HRres), SPO2 (complicated thing from PVEquations)

    CharacterAvatar character; //declares character script
    pvEquations vents; //declares vents script
    Exercise exercise; //declares bike script
    Timer timer;
    GraphScriptHR graph;

    public void Start()
    {
        //sets scripts to variables to allow them to be connected.
        character = GetComponent<CharacterAvatar>();
        vents = GetComponent<pvEquations>();
        exercise = GetComponent<Exercise>();
        //timer = GetComponent<Timer>();
        graph = GetComponent<GraphScriptHR>();



        //
        HRmax = 220;
        HrRestFunction(80);
        BlatFunction();
        //character.gender = 1; //why would this be set here? we have a character already that the user inputs values for/has default values already
        //character.weight = 50;
        //character.age = 20;
        //


        //DEFAULT VALUES

        //BASE
        character.age = 20;
        character.gender = 1;
        character.weight = 50;
        character.BodyTemp = 36.0f;
        character.height = 170;  //150 cm, 1.5 m
        //EXERCISE
        exercise.module = 2;
        exercise.resistance = 5;
        exercise.rpm = 30;
        //TIMER
        timer.intervals = 5;
        timer.increase = 10;
        timer.limit = 100000;
        //CARDIO
        BPsFunction(120);
        BPdFunction(50);
        EdvFunction(120);
        EsvFunction(50);
        HRrest = 60;
        HRmax = 200;  
        Bla = 1.0f;
        BaseMath();
        HealthFunction(healthsetting);
        //PVE

    }

    public void Update()
    {
        //HR = Mathf.SmoothDamp(HR, HRtarg, ref velocityHR, timer.intervals);
        //BPs = Mathf.SmoothDamp(BPs, BPsTarg, ref velocityBps, timer.intervals);
        //Bla = Mathf.SmoothDamp(Bla, BlaTarget, ref velocityBla, timer.intervals);
   


        ////CALCULATION
        //if (timer.resetCARDIO == true)
        //{
        //    //every time the work being done increases (when the timer mini resets)
        //    //a lot of things need to be recalculated (HR, BPs) and some other stuff too
        //    MathFunc();
        //    timer.resetCARDIO = false;
        //}

        //if (HR >= HRmax)
        //{
        //    HR = HRmax;
        //}

        //if (Bla >= 5)
        //{
        //    BlaCond = 1;
        //    //pretty okay, maybe a bit tired

        //    if (Bla >= 10)
        //    {
        //        BlaCond = 2;
        //        //getting tired

        //        if (Bla >= 15)
        //        {
        //            BlaCond = 3;
        //            //legs very tired, an unhealthy person would probably give up

        //            if (Bla >= 20)
        //            {
        //                BlaCond = 4;
        //                //becoming dangerous; subject should stop or risk lasting injury
        //            }
        //        }
        //    }
        //}

        //EDV = (EDVbase * (1 + (((HR / HRmax) / 100) * 0.18f))); //this tracks the change of blood volume as HR changes
        //ESV = (ESVbase * (1 - (((HR / HRmax) / 100) * 0.21f)));

        if (HR >= HRmax)
        {
            HR = HRmax;
        }
        if(HR < HRrest)
        {
            HR = HRrest;
        }


        //CALCULATION
   

 

        EDV = (EDVbase * (1 + (((HR / HRmax) / 100) * 0.18f))); //this tracks the change of blood volume as HR changes
        ESV = (ESVbase * (1 - (((HR / HRmax) / 100) * 0.21f)));

    }

    //COMPUTING FUNCTIONS

    public void MathFunc()
    {
        BPsTargFunction();
        HrTargFunction();
        BlaTargFunction();

        //HOW TO USE SMOOTHDAMP
        //1 = START POSITION
        //2 = FINISH
        //3 = THIS IS THE WIERD ONE. JUST DO A 'PRIVATE FLOAT'
        //4 - TIME IN SECONDS


        SvFunction(); //update everything else for relevant stuff, the order is very important
        CoFunction();
        OpFunction();
        MapFunction();
        EfFunction();
        SwFunction();
        TprFunction();
        BpFunction();
        HrMaxFunction();
        HrResFunction();

        BaseMath();
    }

    void BaseMath()
    {
        SvFunction(); //update everything else for relevant stuff, the order is very important
        CoFunction();
        OpFunction();
        MapFunction();
        EfFunction();
        SwFunction();
        TprFunction();
        BpFunction();
        HrMaxFunction();
        HrResFunction();
        HealthFunction(healthsetting);

    }

    public void CardioResetfunc()
    {
        HR = Mathf.SmoothDamp(HR, HRrest, ref velocityHR, 10);
        BPs = Mathf.SmoothDamp(BPs, BPsBase, ref velocityBps, 10);
        Bla = Mathf.SmoothDamp(Bla, 1.0f, ref velocityBla, 10);
    }

    //FUNCTIONS LEVEL 1 - BASIC MODULE

    public void BPsFunction(float BPsfunc) //USE THIS ONE FOR INPUT
    {
        BPs = BPsfunc;
        character.BPs = BPs;
        BPsBase = BPsfunc;
    }

    void BPsTargFunction()
    {
        switch(character.gender)
        {
            case 1: //M         
                BPsTarg = (0.346f * exercise.bodyWork);
                break;
            case 0: //F  
                BPsTarg = (0.103f * exercise.bodyWork);
                break;
            default:
                break;
        }

        if (BPsTarg < BPsBase)
        {
            BPsTarg = BPsBase;
        }
    }

    public void BPdFunction(float BPdfunc)
    {
        BPd = BPdfunc; //INPUT
        character.BPd = BPd;
    }

    void HrTargFunction()
    {
        switch (character.gender)
        {
            case 1:
                HRtarg = ((0.32f * exercise.bodyWork) + (health * 0.9f));
                //HEALTHY PEOPLE CAN BE -0.9 AND UNHEALTHY +0.9
                break;
            case 0:
                HRtarg = ((0.43f * exercise.bodyWork) + (health * 0.15f));
                //+/- 0.15
                break;
        }
        //backup

        if(HRtarg < HRrest)
        {

            HRtarg = (HRrest + (0.1f * exercise.bodyWork));

            HRtarg = (HRrest + (0.05f * exercise.bodyWork));

        }

        if(HRtarg > HRmax)
        {
            HRtarg = HRmax;
            danger++;
        }
    }

    public void HrRestFunction(float HRrestfunc)
    {
        HRrest = HRrestfunc; //INPUT
    }

    void HrMaxFunction()
    {
        HRmax = (220 - character.age);
        
    }

    void MapFunction()
    {
        MAP = BPd + ((BPs - BPd) / 3);
        character.MAP = MAP;
    }

    void OpFunction()
    {
        OP = (vents.VO2 / HR);
        
    }
    
    void BlatFunction()
    {
        BlaT = (HRmax * 0.85f);
        character.BlaT = BlaT;
    }

    public void BlaTargFunction()
    {
        if(HR < BlaT)
        {
            HRCond = 0;
            BlaTarget = (Mathf.Pow((exercise.workDone/50), 2));

        }
        else if (HR >= BlaT)
        {
            HRCond = 1;
            BlaTarget = (Mathf.Pow((exercise.workDone / 25), 2));

            //NORMAL BL is like 1-2, but it can go up to 25 during intense exercise, but this is a worst-case scenario
            //normal people BL go up to like 10-15 before they give up. perhaps make this an option.
        }

    }

    //FUNCTIONS LEVEL 2 - MEDIUM MODULE

    void CoFunction()
    {
        CO = (SV * HR);
        character.CO = CO;
    }

    void BpFunction()
    {
        BP = (CO * TPR);
       
    }

    void SvFunction()
    {
        SV = (EDV - ESV);
        character.SV = SV;
    }

    void HrResFunction()
    {
        HRres = (HRmax - HRrest);
        
    }

    //FUNCTIONS LEVEL 3 - ADVANCED MODULE

    void EfFunction()
    {
        EF = ((SV / EDV) * 100);
        
    }

    public void EdvFunction(float EDVfunc)
    {
        EDV = EDVfunc; //INPUT, INCREASES BY UP TO 21%
        EDVbase = EDVfunc;        
    }

    public void EsvFunction(float ESVfunc)
    {
        ESV = ESVfunc; //INPUT, DECREASES BY UP TO 18%
        ESVbase = ESVfunc;
    }

    void SwFunction()
    {
        SW = (SV * MAP);
    }

    void TprFunction()
    {
        TPR = (MAP / CO);
    }

    void HealthFunction(int healthiness)
    {
        switch(healthiness)
        {
            case 1:
                //NORMAL PERSON, +0
                health = 0;
                break;
            case 2:
                //VERY UNHEALTHY -9
                health = -1;
                break;
            case 3:
                //MILDLY UNHEALTHY -4
                health = -0.5f;
                break;
            case 4:
                //VERY HEALTHY +9
                health = 1;
                break;
            case 5:
                //QUITE HEALTHY +4
                health = 0.5f;
                break;
        }
    }
    

    public void CalculateAll() //used to update manually rather than every frame, stops crashes as well as being easier to control from other scripts
    {
        // HR = Mathf.SmoothDamp(HR, HRtarg, ref velocityHR, timer.intervals); //will need to swap the timer intervals out for the version of the variable that's on the module_to_new_scene script
        // BPs = Mathf.SmoothDamp(BPs, BPsTarg, ref velocityBps, timer.intervals);
        // Bla = Mathf.SmoothDamp(Bla, BlaTarget, ref velocityBla, timer.intervals);

        MathFunc();

        if (HR >= HRmax)
        {
            HR = HRmax;
        }

        //this below isn't great code: every frame for a bla > 20 we would need to perform 4 if statements and change the value of blacond 4 times, as it would revert back to 1, then 2 - 3 - 4. This is inefficient when it could be achieved more easily
        //if (Bla >= 5)
        //{
        //    BlaCond = 1;
        //    //pretty okay, maybe a bit tired

        //    if (Bla >= 10)
        //    {
        //        BlaCond = 2;
        //        //getting tired

        //        if (Bla >= 15)
        //        {
        //            BlaCond = 3;
        //            //legs very tired, an unhealthy person would probably give up

        //            if (Bla >= 20)
        //            {
        //                BlaCond = 4;
        //                //becoming dangerous; subject should stop or risk lasting injury
        //            }
        //        }
        //    }
        //}

        //doing it this way will lower the amount of work the program has to do by setting the variables much less frequently 
        if(Bla >=5 & Bla < 10 & BlaCond != 1)
        {
            BlaCond = 1;
        }
        else if (Bla >= 10 & Bla < 15 & BlaCond != 2)
        {
            BlaCond = 2;
        }
        else if (Bla >= 15 & Bla < 20 & BlaCond != 3)
        {
            BlaCond = 3;
        }
        else if (Bla >= 20 & BlaCond != 4)
        {
            BlaCond = 4;
        }

        EDV = (EDVbase * (1 + (((HR / HRmax) / 100) * 0.18f))); //this tracks the change of blood volume as HR changes
        ESV = (ESVbase * (1 - (((HR / HRmax) / 100) * 0.21f)));
    }
    Cardio(){}
};