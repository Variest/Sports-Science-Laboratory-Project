using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pvEquations : MonoBehaviour
{

    [Header("Character")]

    //will probably have a lot of these pulmonary variables within the character eventually, this is just a basic thing for now so that i can test some stuff
    public CharacterAvatar avatar;

    [Space(10)]
    [Header("Values used for inspiration and expiration of air")] //ALMOST DEALT WITH

    public float TI; //inspiratory time - HOPELESS
    public float TE; //expiratory time - HOPELESS
    public float TITE; //result for TI/TE - NEEDS TI AND TE
    public float breathTime; //total breath time - SAME AS TTOT? - ALSO NEEDS TI AND TE


    [Space(10)]
    [Header("Fractional Concentrations")] //DEALT WITH

    public float FECO2; //fractional concentration of expired carbon dioxide - MODELLED
    float FECO2P; //THIS IS A PLACEHOLDER FOR CALCULATION
    public float FICO2; //fractional concentration of inspired carbon dioxide - STATIC
    public float FEO2; //fractional concentration of expired oxygen - MODELLED
    float FEO2P; //ALSO A PLACEHOLDER
    public float FIO2; //fractional concentration of inspired oxygen - STATIC
    //THESE ALL APPEAR TO BE FIXED AT AROUND
    //FICO - 0.04, FIO - 20.95
    //FECO - 4.4, FEO - 16.4 (THIS ONE GOES UP)

    [Space(10)]
    [Header("Minute Ventilation")] //DEALT WITH

    public float veATPS; //minute ventilation in an ATPS environment - MODELLED
    public float veSTPD; //minute ventilation in an STPD environment - MODELLED
    public float veBTPS; //minute ventilation in a BTPS environment - MODELLED
    public float VE; //MODELLED

    public float VT; //tidal volume - USING 'VT' FROM 'LUNGS' INSTEAD - MODELLED

    public float MET; //metabolic equivalents - ???
    //STPD relates to standard temperature and pressure, dry. (0c, 760 mmHg)
    //BTPS relates to body temperature and pressure, saturated with water vapor
    //ATPS relates to ambient temperature and pressure, saturated with water

    [Space(10)]
    [Header("Oxygen Consumption")] //DEALT WITH - EPOC IGNORED

    public float VI; //used to calculate some stuff idk - MODELLED
    public float VO2; //value for oxygen consumption - MODELLED
    public float VO2maxAge;
    public float VO2maxHeight;
    public float VO2maxWeight;
    public float VO2fr; //oxygen breath value - MODELLED
    public float VCO2; //carbon dioxide output - MODELLED
    public float EPOC; //excess post-exercise oxygen consumption

    [Space(10)]
    [Header("End-Tidal Partial Pressures")] //IS THE SAME AS FRAC. CONC.

    public float PETCO2; //end-tidal carbon dioxide partial pressure - ISNT THIS JUST FECO2?
    public float PETO2; //end-tidal oxygen partial pressure - AND FEO2?

    [Space(10)]
    [Header("Respiratory variables")] //DEALT WITH

    public float fr; //respiratory rate - M
    public float RER; //respiratory exchange ratio - M
    public float RQ; //respiratory quotient - M

    [Space(10)]
    [Header("Ventilatory variables")] //DEALT WITH

    public float Vecap; //ventilatory capacity - M
    public float VeVO2; //ventilatory equivalent for oxygen - M
    public float VeVCO2; //ventilatory equivalent for carbon dioxide - M
    public float Ttot; //total breath time - SAME AS BREATHTIME? - I

    [Space(10)]
    [Header("Work Rate")]
    public float W; //USE 'BODYWORK' FROM 'EXERCISE' INSTEAD

    CharacterCustomiser Character;
    Cardio cardio;
    Exercise Exercise;
    Timer Timer;
    Lung Lungs;
    WaterVapourConversion WV;

    // Start is called before the first frame update
    public void Start()
    {
        Character = GetComponent<CharacterCustomiser>();
        cardio = GetComponent<Cardio>();
        Exercise = GetComponent<Exercise>();
        Timer = GetComponent<Timer>();
        Lungs = GetComponent<Lung>();
        avatar = GetComponent<CharacterAvatar>();
        WV = GetComponent<WaterVapourConversion>();

        //SETTING FRAC. CONC. VARIABLES TO THE 'NORMAL' LEVELS
        avatar.FICO2 = 0.04f;
        avatar.FIO2 = 20.95f;
        FEO2P = 16.4f;
        FECO2P = 4.4f;
        FEO2 = FEO2P;
        FECO2 = FECO2P;
        //EXPERIMENTAL VARIABLES
        avatar.TI = 1.5f;
        avatar.frMax = 60;
    }

    public void Update()
    {
        CalculateAll();
    }

    public void CalculateAll()
    {
        BreathFreq();
        BreathTime();
        ExpireTime();
        InspireExpireRatio();
        FECO2Func();
        FEO2Func();
        CalcVE();
        CalcVeATPS(Lungs.VT, avatar.TI);
        CalcVeSTPD(760, WV.waterVapour, WV.gasTemp); 
        CalcVeBTPS(760, WV.waterVapour, WV.gasTemp);
        calcVI();
        calcVCO2();
        OxygenConsumption();
        respiratoryExRatio();
        respiratoryQuotient();
        VentCapacity(avatar.FEV1);
        VentEquivOxygen();
        VentEquivCO2();
        calcEPOC(1, 1);
        calcMET(avatar.weight);
        OxygenBreath();
        VO2MaxAge();
        VO2MaxHeight();
        VO2MaxWeight();
    }

    public float ExpireTime()
    {
        //used to calculate the value for Expiratory time, or TE
        //calculated as total breath time - TI
        //breathTime value is a placeholder for now as we may need to calculate it another way later in the project, this is just to get some stuff written down

        avatar.TE = avatar.breathTime - avatar.TI;
        return avatar.TE;

    }

    public float InspireExpireRatio()
    {
        //used to find the ratio of inspiratory to expiratory time 
        //equation used is TI/TE
        avatar.TITE = avatar.TI / avatar.TE;
        return avatar.TITE;
    }

    public float BreathTime()
    {
        avatar.breathTime = (avatar.fr / 60);
        return avatar.breathTime;
    }

                                    //FRAC. CONC. FUNCTIONS

    public float FECO2Func()
    {
        FECO2 = (FECO2P + (((cardio.HR) / (cardio.HRmax)) * FEO2P));

        //PERC. OF EXHALED C02 = BASE EXHALED C02% + (HRMAX% OF EXHALED 02)
        //EVENTUALLY, HUMANS PUT OUT 1:1 CO2:O2, THIS IS JUST MODELLING THAT
        return avatar.FECO2;
    }

    public float FEO2Func()
    {
        avatar.FEO2 = ((FIO2) - (FECO2 + 0.15f));
        //PERCENTAGE OF EXHALED 02 = INHALED 02-EXHALED C02 (+0.15 FOR BALANCE) 
        return avatar.FEO2;
    }


                                    //MINUTE VENTILATION FUNCTIONS

    public float CalcVE()
    {
        avatar.VE = Lungs.VT * avatar.fr;
        return avatar.VE;
    }

    public float CalcVeATPS(float vol, float t)
    {
        //time is relevant here, will use the timer value
        avatar.veATPS = (vol / t) * 60;
        //avatar.veatps = (VE/60)*60?
        return avatar.veATPS;
    }

    public float CalcVeSTPD(float Pb, float PH2O, float expTemp)
    {
        //PH2O will be calculated from the water vapour pressure table she gave us depending on the gas temperature present
        avatar.veSTPD = avatar.veATPS * (((Pb - PH2O) / 760) * (273 / (273 + expTemp)));
        return avatar.veSTPD;
    }

    public float CalcVeBTPS(float Pb, float PH2O, float expTemp)
    {
        //pb is typically 760, ph20 is watervapour
        avatar.veBTPS = avatar.veATPS * (((Pb - PH2O) / (Pb - 47.08f)) * (310f / (273f + expTemp)));
        return avatar.veBTPS;
    }

                                //OXYGEN CONSUMPTION FUNCTIONS

    public float calcVI()
    {
        // VI = veSTPD * (((1 - FEO2 - FECO2) / (1 - FIO2 - FICO2)) * FIO2) - (VE * FEO2);
        //1 - FEO2 - FECO2) /  (1-FIO2 - FICO)
        avatar.VI = (1 - avatar.FEO2 - avatar.FECO2) / (1 - avatar.FIO2 - avatar.FICO2); //new vi equation mitch gave us
        return VI;
    }

    public float calcVCO2()
    {
        avatar.VCO2 = avatar.veSTPD * (avatar.FECO2 - avatar.FICO2);
        return VCO2;

    }

    public float OxygenConsumption()
    {
        //VO2 = (VI * (FIO2 / 100)) - (veSTPD * (FEO2 / 100)); //values are divided by 100 as they must be expressed as decimals instead of percentages
        //v02 = VE STPD * (((1 - FEO2 - FECO2) /  (1-FIO2 - FICO2)) * FIO2) - (VE STPD * FEO2)

        avatar.VO2 = avatar.veSTPD * (((1 - avatar.FEO2 - avatar.FECO2) / (1 - avatar.FIO2 - avatar.FICO2)) * avatar.FIO2) - (avatar.veSTPD * avatar.FEO2); //equation including the VI calculation within it
        //avatar.VO2 = avatar.veSTPD * ((avatar.VI * avatar.FIO2) - (avatar.veSTPD * avatar.FEO2)); 
        
        //it needs to be ML/KG
        avatar.VO2 *= 1000; 
        avatar.VO2 /= avatar.weight;
        return VO2;
    }
    
    public float VO2MaxAge()
    {
        if(avatar.gender == 0)
        {
            //female equations
            avatar.VO2maxAge = (42.83f - (0.371f * avatar.age));

        }
        else
        {
           avatar.VO2maxAge = (50.02f - (0.394f * avatar.age));
        }
        return avatar.VO2maxAge;
    }

    public float OxygenBreath()
    {
        avatar.VO2fr = avatar.VO2 / avatar.fr;
        return avatar.VO2fr;
    }

    public float VO2MaxHeight()
    {
        if(avatar.gender == 0)
        {
            float tempIBW = (62.6f * avatar.height / 100) - 45.5f; //height is divided by 100 as the calculation uses meters and my input is currently in cm
           avatar.VO2maxHeight = (avatar.VO2maxAge * tempIBW) / 1000;
        }
        else
        {
            float tempIBW = (71.6f * avatar.height / 100) - 51.8f; //height is divided by 100 as the calculation uses meters and my input is currently in cm
            avatar.VO2maxHeight = (avatar.VO2maxAge * tempIBW) / 1000;
        }
        return avatar.VO2maxHeight;

    }

    public float VO2MaxWeight()
    {
        avatar.VO2maxWeight = (avatar.VO2maxHeight * 1000f) / avatar.weight; //avatar weight should be in kg
        return avatar.VO2maxWeight;
    }

    public float calcEPOC(float EPOCduration, float EPOCconsumed)
    {
        //the epoc oxygen consumed will have to be calculated elsewhere, placeholder for now
        //will need a rest state and values relating to resting
        avatar.EPOC = EPOCconsumed - (avatar.VO2 * EPOCduration);
        return avatar.EPOC;
    }

                                        //ET PP FUNCTIONS



                                        //RESPIRATORY FUNCTIONS

    public float respiratoryExRatio()
    {
        avatar.RER = avatar.VCO2 / avatar.VO2;
        return RER;
    }

    public float respiratoryQuotient()
    {
        avatar.RQ = avatar.VCO2 / avatar.VO2;
        return RQ;
    }

    public float BreathFreq()
    {
        avatar.fr = (10 + (40 * (cardio.HR / cardio.HRmax)));
        return avatar.fr;
    }

                                        //VENTILATORY FUNCTIONS

    public float VentCapacity(float FEV1)
    {
        avatar.Vecap = FEV1 * 35;
        return avatar.Vecap;
        //the sheet says "FEV1 * 40 or FEV1 * 35" so I don't know which one she wants us to use here????????????
        //apparently there is no set variable that changes whether we use 40 or 35, however 35 is apparently the more common number to use and as such shall be the one we use
    }

    public float VentEquivOxygen()
    {
        avatar.VeVO2 = avatar.VE / avatar.VO2;
        return avatar.VeVO2;
    }

    public float VentEquivCO2()
    {
        avatar.VeVCO2 = avatar.VE / avatar.VCO2;
        return avatar.VeVCO2;
    }

    public float calcMET(float weight)
    {
        float temp = avatar.VO2 * 1000;
        float temp2 = temp / weight; //converting the VO2 value from litres into ml/kg
        avatar.MET = temp2 / 3.5f;
        return avatar.MET;

    }
}