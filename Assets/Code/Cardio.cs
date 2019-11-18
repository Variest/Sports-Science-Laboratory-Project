using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cardio : MonoBehaviour
{
    //IMPORTANT INTEGERS
    //I = INPUT, M = MODELLED, CA = CALCULATED CONSTANTLY CB = CALCULATED ONCE
    public float Bla; //I/M! blood lactate -			what the fuck?
    public float BlaT; //CB blood lactate threshold -   85% of max heart rate or 75% of VO2Max
    public float BPd; //I diastolic blood pressure -	INPUT 
    public float BPs; //I/M systolic blood pressure -	INPUT, and we have a DECENT way of modelling it;
                                                        //MEN - (0.346*W + 135.76)
                                                        //WOMEN - (0.103*W + 155.72)
    public float MAP; //CA mean arterial pressure =		(BPd + [0.3333(BPs-BPd)])
    public float HR; //M heart rate -					   measured, but we have a decent way of calculating it;
                                                        //MEN - 4.7 BPM/10W
                                                        //WOMEN - 7.1 BPM/10W
    public float HRmax; //CB heart rate maximum =		(220-age)
    public float OP; //CA oxygen pulse =				VO2/HR
   

    //OTHER STUFF
    public float CO; //CA cardiac output =				SV*HR OR MAP/TPR
    public float HRres; //CB heart rate reserve =		HRmax-HRresting
    public float BP; //CA mean blood pressure =			CO*TPR
    public float SV; //CA stroke volume =				EDV-ESV
    public float HRrest; //I heart rate resting -	    input

    //LESS IMPORTANT
    public float EF; //CA ejection fraction =			(SV/EDV)*100
    public float EDV; //I/M end diastolic volume -		measured - MIGHT BE INPUT? (changes a little bit) ABOUT 120 mm, INCREASES BY 18% AT MAXIMAL EXERCISE
    public float ESV; //I/M end systolic volume -		measured - MIGHT BE INPUT? (changes a little bit) ABOUT 40-50 mm, DECREASES BY 21% AT MAXIMAL EXERCISE
                                                        //okay so what these are is: EDV - volume of blood in heart at maximum succ, ESV - volume of blood in heart after it squeezed.
                                                        //during exercise the heart generally just gets bigger - minimum pressure doesn't change, but everything else goes futher in it's direction.
                                                        //end systolic volume/pressure changes the most, though - Volume goes down whilst pressure goes up (more squeeze). EDV goes up a bit, P no change.
    public float SW; //CA stroke work =					SV*MAP
    public float TPR; //CA total peripheral resistance =	MAP/CO

    public float HRtarg; //TESTING CB
    public float BPsTarg; //TESTING CB
    public float BPsBase; //TESTING I
    public float EDVbase; //TESTING I
    public float ESVbase; //TESTING I

    //level one is entirely self contained, aside from oxygen pulse needing VO2 from a different section
    //levels two and three are very codependent, however, with them needing variables from eachother

    //CARDIOVASCULAR MODULES
    //basic: Heart Rate (FC/HR), Oxygen Pulse (OP), Mean Arterial Pressure (MAP), Max Heart Rate (HRMax)
    //advanced: above + Blood Lactate (Bla), Cardiac Output (CO), Blood Pressure (Bpd, Bps), Stroke Volume (SV), Heart Rate Reserve (HRres), SPO2 (complicated thing from PVEquations)

    CharacterCustomiser character; //declares character script
    pvEquations vents; //declares vents script
    Module exercise; //declares bike script
    Timer timer;

    public void Start()
    {
        //sets scripts to variables to allow them to be connected.
        character = GetComponent<CharacterCustomiser>();
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

        EDV = (EDVbase * (1 + (((HR / HRmax) / 100) * 0.18f))); //this tracks the change of blood volume as HR changes
        ESV = (ESVbase * (1 - (((HR / HRmax) / 100) * 0.21f)));

        //OUTPUT

        if (HR >= HRmax)
        {
            HR = HRmax;
            //DANGER! DANGER! - ANOTHER VISUAL THING
        }

        if (HR >= BlaT)
        {
            //IT'S STARTING TO HURT, Blood Lactate RISES EXPONENTIALLY - THIS IS A VISUAL THING
        }

        SVfunction(); //update everything else for relevant stuff
        COfunction();
        OPfunction();
        MAPfunction();
        EFfunction();
        SWfunction();
        TPRfunction();
        BPfunction();
    }

    public void MathFunc()
    {
        BPsTargfunction();
        HRfunction();
        Mathf.SmoothStep(HRrest, HRtarg, HR);
        Mathf.SmoothStep(BPsBase, BPsTarg, HR);
        //PROBLEM - SMOOTHSTEP MIGHT BE TOO FAST
        //BUT SMOOTHDAMP, WHICH I CAN CONTROL THE TIME OF, IS TOO COMPLICATED
        timer.recalculateCARDIO = false;
    }
    
    //FUNCTIONS LEVEL 1

    public void BPsfunction(float BPsfunc) //USE THIS ONE FOR INPUT
    {
        BPs = BPsfunc;
        BPsBase = BPsfunc;
    }

    void BPsTargfunction()
    {
        if (character.gender == true) //male
        {
            BPsTarg = (0.346f * exercise.BodyWork + BPsBase);
        }

        else if (character.gender == false) //female
        {
            BPsTarg = (0.103f * exercise.BodyWork + BPsBase);
        }
    }

    void BPdfunction(float BPdfunc)
    {
        BPd = BPdfunc; //INPUT
    }

    void Blafunction(float Blafunc)
    {
        Bla = Blafunc; //MODEL NEEDED
    }

    void HRfunction()
    {
        if (character.gender == true)
        {
            HRtarg = (HRrest + (4.7f * exercise.BodyWork) / 10);
        }

        else if (character.gender == false)
        {
            HRtarg = (HRrest + (7.1f * exercise.BodyWork) / 10);
        }
    }

    void MAPfunction()
    {
        MAP = BPd + ((BPs - BPd) / 3);
    }

    void OPfunction()
    {
        OP = (vents.VO2 / HR);
    }

    void HRmaxfunction()
    {
        HRmax = (220 - character.age);
    }

    void BlaTfunction()
    {
        BlaT = (HRmax * 0.85f);
    }

    //FUNCTIONS LEVEL 2

    void COfunction()
    {
        CO = (SV * HR);
    }

    void HRrestfunction(float HRrestfunc)
    {
        HRrest = HRrestfunc; //INPUT
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

    //FUNCTIONS LEVEL 3

    void EFfunction()
    {
        EF = ((SV / EDV) * 100);
    }

    void EDVfunction(float EDVfunc)
    {
        EDV = EDVfunc; //INPUT, INCREASES BY UP TO 21%
        EDVbase = EDVfunc;
        
    }

    void ESVfunction(float ESVfunc)
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
