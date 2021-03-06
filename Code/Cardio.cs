﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Cardiovascular Functions.cpp : This file contains the 'main' function. Program execution begins and ends there.

public class Cardio : MonoBehaviour
{
    //IMPORTANT INTEGERS
    float Bla; //blood lactate -				measured - we're on to something
    float BPd; //diastolic blood pressure -		PROBABLY INPUT - this tends not to change too much with exercise
    float HR; //heart rate -					measured, but we have a decent way of calculating it;
                                                //MEN - 4.7 BPM/10W
                                                //WOMEN - 7.1 BPM/10W
    float HRmax; //heart rate maximum =			(220-age)
    float MAP; //mean arterial pressure =		(BPd + [0.3333(BPs-BPd)])
    float OP; //oxygen pulse =					VO2/HR
    float BPs; //systolic blood pressure -		measured, we have a DECENT way of measuring it;
                                                //MEN - (0.346*W + 135.76)
                                                //WOMEN - (0.103*W + 155.72)

    //OTHER STUFF
    float CO; //cardiac output =				SV*HR OR MAP/TPR
    float BG; //glucose -						measured - ???? (dont need this anyway tbh)
    float HRres; //heart rate reserve =		    HRmax-HRresting
    float BP; //mean blood pressure =			CO*TPR
    float SV; //stroke volume =					EDV-ESV
    float HRrest; //heart rate resting -		input

    //LESS IMPORTANT
    float EF; //ejection fraction =				(SV/EDV)*100
    float EDV; //end diastolic volume -			measured - MIGHT BE INPUT? (changes a little bit)
    float ESV; //end systolic volume -			measured - MIGHT BE INPUT? (changes a little bit)
    float SW; //stroke work =					SV*MAP
    float TPR; //total peripheral resistance =	MAP/CO
   
    //level one is entirely self contained, aside from oxygen pulse needing VO2 from a different section
    //levels two and three are very codependent, however, with them needing variables from eachother

    CharacterCustomiser character;//declares character script
    Pulmonaryvents vents;//declares vents script
    Bike bike;// declares bike script
    //VO2 and AGE/GENDER and Wattage

 

    public void Start()
    {//sets scripts to variables to allow them to be connected.
    character = GetComponent<CharacterCustomiser>();
    vents = GetComponent<Pulmonaryvents>();
    bike = GetComponent<Bike>();  

    }

    //FUNCTIONS LEVEL 1

    void BPsfunction()
    {
        if(character.gender == true)
        {
            BPs = (0.346f * bike.wattage + 135.76f);
        }

        else if(character.gender == false)
        {
            BPs = (0.103f * bike.wattage + 155.72f);
        }
    }

    void BPdfunction(float BPdfunc)
    {
        BPd = BPdfunc;
    }

    void BLafunction(float Blafunc)
    {
        Bla = Blafunc;
    }

    void HRfunction()
    {
        if(character.gender == true)
        {
            HR = (4.7f * bike.wattage) / 10;
        }

        else if(character.gender == false)
        {
            HR = (7.1f * bike.wattage) / 10;
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
