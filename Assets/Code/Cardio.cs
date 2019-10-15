using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

// Cardiovascular Functions.cpp : This file contains the 'main' function. Program execution begins and ends there.

public class Cardio
{
    //IMPORTANT INTEGERS
    float Bla; //blood lactate -				measured
    float BPd; //diastolic blood pressure -		measured
    float HR; //heart rate -					measured
    float HRmax; //heart rate maximum =			(220-age)
    float MAP; //mean arterial pressure =		(BPd + [0.3333(BPs-BPd)])
    float OP; //oxygen pulse =					VO2/HR
    float BPs; //systolic blood pressure -		measured

    //OTHER STUFF
    float CO; //cardiac output =				SV*HR OR MAP/TPR
    float BG; //glucose -						measured
    float HRres; //heart rate reserve =		    HRmax-HRresting
    float BP; //mean blood pressure =			CO*TPR
    float SV; //stroke volume =					EDV-ESV
    float HRrest; //heart rate resting -		input

    //LESS IMPORTANT
    float EF; //ejection fraction =				(SV/EDV)*100
    float EDV; //end diastolic volume -			measured
    float ESV; //end systolic volume -			measured
    float SW; //stroke work =					SV*MAP
    float TPR; //total peripheral resistance =	MAP/CO

    //level one is entirely self contained, aside from oxygen pulse needing VO2 from a different section
    //levels two and three are very codependent, however, with them needing variables from eachother

    //VO2 and AGE - DELETE LATER, ONCE FUSED
    CharacterCustomiser character;
    character.getcomponent<CharacterCustomiser>();
    Pulmonaryvents vents;
    vents.getcomponent<Pulmonaryvents>();

    //FUNCTIONS LEVEL 1

    void BPsfunction(float BPsfunc)
    {
        BPs = BPsfunc;
    }

    void BPdfunction(float BPdfunc)
    {
        BPd = BPdfunc;
    }

    void BLafunction(float Blafunc)
    {
        Bla = Blafunc;
    }

    void HRfunction(float HRfunc)
    {
        HR = HRfunc;
    }

    void MAPfunction()
    {
        MAP = BPd + ((BPs - BPd)/3);
    }

    void OPfunction()
    {
        OP = (vents.V02 / HR);
    }

    void HRmaxfunction()
    {
        HRmax = (220 - character.age);
    }

    //FUNCTIONS LEVEL 2

    void COfunction()
    {
        CO = (SV * HR);
    }

    void BGfunction(float BGfunc)
    {
        BG = BGfunc;
    }

    void HRrestfunction(float HRrestfunc)
    {
        HRrest = HRrestfunc;
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
        EDV = EDVfunc;
    }

    void ESVfunction(float ESVfunc)
    {
        ESV = ESVfunc;
    }

    void SWfunction()
    {
        SW = (SV * MAP);
    }

    void TPRfunction()
    {
        TPR = (MAP / CO);
    }

    Cardio() { }
};
