using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cardio : MonoBehaviour
{
    //BASIC MODULE
    public float Bla = 1.0f; //blood lactate 	        SOMEWHAT appropriately modelled
    public float BlaT; //CB blood lactate threshold     85% of max heart rate or 75% of VO2Max
    public float BPd; //I diastolic blood pressure  	INPUT 
    public float BPs; //I/M systolic blood pressure 	INPUT, and we have a DECENT way of modelling it;
    public float MAP; //CA mean arterial pressure =		(BPd + [0.3333(BPs-BPd)])
    public float HR; //M heart rate -					measured, but we have a decent way of calculating it;
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
    public float BlaTarget;
    public float HRtarg;
    public float BPsTarg;
    public float BPsBase;
    public float EDVbase;
    public float ESVbase;

    private float velocity = 0.0f; //FOR SMOOTHDAMP

    //OUTPUT
    public float BlaCond = 0;
    public float HRCond = 0;

    //level one is entirely self contained, aside from oxygen pulse needing VO2 from a different section
    //levels two and three are very codependent, however, with them needing variables from eachother

    //CARDIOVASCULAR MODULES
    //basic: Heart Rate (FC/HR), Oxygen Pulse (OP), Mean Arterial Pressure (MAP), Max Heart Rate (HRMax)
    //advanced: above + Blood Lactate (Bla), Cardiac Output (CO), Blood Pressure (Bpd, Bps), Stroke Volume (SV), Heart Rate Reserve (HRres), SPO2 (complicated thing from PVEquations)

    //CharacterCustomiser character; //declares character script
    CharacterAvatar character;
    pvEquations vents; //declares vents script
    Module exercise; //declares bike script
    Timer timer;

    public void Start()
    {
        //sets scripts to variables to allow them to be connected.
        character = GetComponent<CharacterAvatar>();
        vents = GetComponent<pvEquations>();
        exercise = GetComponent<Module>();
        timer = GetComponent<Timer>();
    }

    public void Update() //IS THIS OK? IF NOT PUT IT IN THE MAIN UPDATE THING
    {
        //CALCULATION
        if(timer.recalculateCARDIO == true)
        {
            //every time the work being done increases (when the timer mini resets)
            //a lot of things need to be recalculated (HR, BPs) and some other stuff too
            MathFunc();
        }

        if (HR >= HRmax)
        {
            HR = HRmax;
        }

        if (Bla >= 5)
        {
            BlaCond = 1;
            //pretty okay, maybe a bit tired

            if (Bla >= 10)
            {
                BlaCond = 2;
                //getting tired

                if (Bla >= 15)
                {
                    BlaCond = 3;
                    //legs very tired, an unhealthy person would probably give up

                    if (Bla >= 20)
                    {
                        BlaCond = 4;
                        //becoming dangerous; subject should stop or risk lasting injury
                    }
                }
            }
        }

        EDV = (EDVbase * (1 + (((HR / HRmax) / 100) * 0.18f))); //this tracks the change of blood volume as HR changes
        ESV = (ESVbase * (1 - (((HR / HRmax) / 100) * 0.21f)));

        SVfunction(); //update everything else for relevant stuff, the order is very important
        COfunction();
        OPfunction();
        MAPfunction();
        EFfunction();
        SWfunction();
        TPRfunction();
        BPfunction();
    }

    //COMPUTING FUNCTIONS

    public void MathFunc()
    {
        BPsTargfunction();
        HRtargfunction();
        BlaTargfunction();

        HR = Mathf.SmoothDamp(HR, HRtarg, ref velocity, timer.intervals);
        BPs = Mathf.SmoothDamp(BPs, BPsTarg, ref velocity, timer.intervals);
        Bla = Mathf.SmoothDamp(Bla, BlaTarget, ref velocity, timer.intervals);

        //HOW TO USE SMOOTHDAMP
        //1 = START POSITION
        //2 = FINISH
        //3 = THIS IS THE WIERD ONE. JUST DO A 'PRIVATE FLOAT'
        //4 - TIME IN SECONDS

        timer.recalculateCARDIO = false;
    }

    public void CardioResetfunc()
    {
        HR = Mathf.SmoothDamp(HR, HRrest, ref velocity, 5);
        BPs = Mathf.SmoothDamp(BPs, BPsBase, ref velocity, 5);
    }

    //FUNCTIONS LEVEL 1 - BASIC MODULE

    public void BPsfunction(float BPsfunc) //USE THIS ONE FOR INPUT
    {
        BPs = BPsfunc;
        BPsBase = BPsfunc;
    }

    void BPsTargfunction()
    {
        if (character.gender == 1) //male
        {
            BPsTarg = (0.346f * exercise.BodyWork);
        }
        else if (character.gender == 0) //female
        {
            BPsTarg = (0.103f * exercise.BodyWork);
        }

        if (BPsTarg < BPsBase)
        {
            BPsTarg = BPsBase;
        }
    }

    public void BPdfunction(float BPdfunc)
    {
        BPd = BPdfunc; //INPUT
    }

    void HRtargfunction()
    {
        if (character.gender == 1) //male
        {
            HRtarg = (0.32f * exercise.BodyWork);
            //HEALTHY PEOPLE CAN BE -0.9 AND UNHEALTHY +0.9
        }
        else if (character.gender == 0) // female
        {
            HRtarg = (0.43f * exercise.BodyWork);
            //+/- 0.15
        }

        //backup
        if(HRtarg < HRrest)
        {
            HRtarg = (HRrest + (0.1f * exercise.BodyWork));
        }
    }

    public void HRrestfunction(float HRrestfunc)
    {
        HRrest = HRrestfunc; //INPUT
        HR = HRrestfunc;
    }

    void HRmaxfunction()
    {
        HRmax = (220 - character.age);
    }

    void MAPfunction()
    {
        MAP = BPd + ((BPs - BPd) / 3);
    }

    void OPfunction()
    {
        OP = (vents.VO2 / HR);
    }
    
    void BlaTfunction()
    {
        BlaT = (HRmax * 0.85f);
    }

    public void BlaTargfunction()
    {
        if (HR >= BlaT)
        {
            HRCond = 1;
            BlaTarget = (Mathf.Pow((exercise.WorkDone / 90), 2) + (timer.counter / 10));

            //NORMAL BL is like 1-2, but it can go up to 25 during intense exercise, but this is a worst-case scenario
            //normal people BL go up to like 10-15 before they give up. perhaps make this an option.
        }
        else
        {
            HRCond = 0;
            BlaTarget = (Mathf.Pow((exercise.WorkDone / 130), 2) + 1.0f + (timer.counter / 10));
        }
    }

    //FUNCTIONS LEVEL 2 - MEDIUM MODULE

    void COfunction()
    {
        CO = (SV * HR);
    }

    void BPfunction()
    {
        BP = (CO * TPR);
    }

    void SVfunction()
    {
        SV = (EDV - ESV);
    }

    void HRresfunction()
    {
        HRres = (HRmax - HRrest);
    }

    //FUNCTIONS LEVEL 3 - ADVANCED MODULE

    void EFfunction()
    {
        EF = ((SV / EDV) * 100);
    }

    public void EDVfunction(float EDVfunc)
    {
        EDV = EDVfunc; //INPUT, INCREASES BY UP TO 21%
        EDVbase = EDVfunc;        
    }

    public void ESVfunction(float ESVfunc)
    {
        ESV = ESVfunc; //INPUT, DECREASES BY UP TO 18%
        ESVbase = ESVfunc;
    }

    void SWfunction()
    {
        SW = (SV * MAP);
    }

    void TPRfunction()
    {
        TPR = (MAP / CO);
    }
    
    Cardio(){}
};
