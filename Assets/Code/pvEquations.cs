using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pvEquations : MonoBehaviour
{

    [Header("Character")]
    //will probably have a lot of these pulmonary variables within the character eventually, this is just a basic thing for now so that i can test some stuff
    CharacterAvatar avatar;
    [Space(10)]
    [Header("Values used for inspiration and expiration of air")]
    public float TI; //inspiratory time
    public float TE; //expiratory time
    public float TITE; //result for TI/TE
    public float breathTime; //total breath time


    [Space(10)]
    [Header("Fractional Concentrations")]
    public float FECO2; //fractional concentration of expired carbon dioxide
    public float FICO2; //fractional concentration of inspired carbon dioxide 
    public float FEO2; //fractional concentration of expired oxygen
    public float FIO2; //fractional concentration of inspired oxygen

    [Space(10)]

    [Header("Minute Ventilation")]


    public float veATPS; //minute ventilation in an ATPS environment
    public float veSTPD; //minute ventilation in an STPD environment
    public float veBTPS; //minute ventilation in a BTPS environment
    public float VE;

    public float VT; //tidal volume

    public float MET; //metabolic equivalents
    //STPD relates to standard temperature and pressure, dry. (0c, 760 mmHg)
    //BTPS relates to body temperature and pressure, saturated with water vapor
    //ATPS relates to ambient temperature and pressure, saturated with water

    [Space(10)]
    [Header("Oxygen Consumption")]

    public float VI; //used to calculate some stuff idk
    public float VO2; //value for oxygen consumption
    public float VO2maxAge;
    public float VO2maxHeight;
    public float VO2maxWeight;
    public float VO2fr; //oxygen breath value
    public float VCO2; //carbon dioxide output
    public float EPOC; //excess post-exercise oxygen consumption
    [Space(10)]
    [Header("End-Tidal Partial Pressures")]

    public float PETCO2; //end-tidal carbon dioxide partial pressure
    public float PETO2; //end-tidal oxygen partial pressure

    [Space(10)]
    [Header("Respiratory variables")]
    public float fr; //respiratory rate
    public float RER; //respiratory exchange ratio
    public float RQ; //respiratory quotient
    [Space(10)]
    [Header("Ventilatory variables")]
    public float Vecap; //ventilatory capacity
    public float VeVO2; //ventilatory equivalent for oxygen
    public float VeVCO2; //ventilatory equivalent for carbon dioxide
    public float Ttot; //total breath time

    [Space(10)]
    [Header("Work Rate")]
    public float W; //work rate

    public void CalculateAll()
    {
        ExpireTime();
        InspireExpireRatio();
        CalcVE();
        CalcVeATPS(5,5);
        CalcVeSTPD(1, 1, 1); //will fill in real values later 
        CalcVeBTPS(1, 1, 1);
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
    public float CalcVE()
    {
        avatar.VE = avatar.VT * avatar.fr;
        return avatar.VE;
    }
    public float CalcVeATPS(float vol, float t)
    {
        //time is relevant here, will use the timer value
        avatar.veATPS = (vol / t) * 60;
        return avatar.veATPS;
    }

    public float CalcVeSTPD(float Pb, float PH2O, float expTemp)
    {
        //PH2O will be calculated from the water vapour pressure table she gave us depending on the gas temperature present
        avatar.veSTPD = avatar.veATPS * (((Pb - PH2O) / 760) * (273 / 273 + expTemp));
        return avatar.veSTPD;
    }

    public float CalcVeBTPS(float Pb, float PH2O, float expTemp)
    {
        avatar.veBTPS = avatar.veATPS * ((Pb - PH2O) / (Pb - 47.08f) * (310f) / (273f + expTemp));
        return avatar.veBTPS;
    }

    public float calcVI()
    {
        // VI = veSTPD * (((1 - FEO2 - FECO2) / (1 - FIO2 - FICO2)) * FIO2) - (VE * FEO2);
        //1 - FEO2 - FECO2) /  (1-FIO2 - FICO2
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
        return VO2;
    }
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
    public float calcEPOC(float EPOCduration, float EPOCconsumed)
    {
        //the epoc oxygen consumed will have to be calculated elsewhere, placeholder for now
        //will need a rest state and values relating to resting
        avatar.EPOC = EPOCconsumed - (avatar.VO2 * EPOCduration);
        return avatar.EPOC;
    }
    public float calcMET(float weight)
    {
        float temp = avatar.VO2 * 1000;
        float temp2 = temp / weight; //converting the VO2 value from litres into ml/kg
        avatar.MET = temp2 / 3.5f;
        return avatar.MET;

    }
    public float OxygenBreath()
    {
        avatar.VO2fr = avatar.VO2 / avatar.fr;
        return avatar.VO2fr;
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


}