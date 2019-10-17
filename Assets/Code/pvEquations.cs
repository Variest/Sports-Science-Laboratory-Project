using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pvEquations : MonoBehaviour
{

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
    public float ExpireTime()
    {
        //used to calculate the value for Expiratory time, or TE
        //calculated as total breath time - TI
        //breathTime value is a placeholder for now as we may need to calculate it another way later in the project, this is just to get some stuff written down

        TE = breathTime - TI;
        return TE;

    }
    public float InspireExpireRatio()
    {
        //used to find the ratio of inspiratory to expiratory time 
        //equation used is TI/TE
        TITE = TI / TE;
        return TITE;
    }
    public float CalcVE()
    {
        VE = VT * fr;
        return VE;
    }
    public float CalcVeATPS(float vol, float t)
    {
        veATPS = (vol / t) * 60;
        return veATPS;
    }

    public float CalcVeSTPD(float Pb, float PH2O, float expTemp)
    {
        //PH2O will be calculated from the water vapour pressure table she gave us depending on the gas temperature present
        veSTPD = veATPS * (((Pb - PH2O) / 760) * (273 / 273 + expTemp));
        return veSTPD;
    }

    public float CalcVeBTPS(float Pb, float PH2O, float expTemp)
    {
        veBTPS = veATPS * ((Pb - PH2O) / (Pb - 47.08f) * (310f) / (273f + expTemp));
        return veBTPS;
    }

    public float calcVI()
    {
        VI = veSTPD * (((1 - FEO2 - FECO2) / (1 - FIO2 - FICO2)) * FIO2) - (VE * FEO2);
        return VI;
    }
    public float calcVCO2()
    {
        VCO2 = veSTPD * (FECO2 - FICO2);
        return VCO2;

    }
    public float OxygenConsumption()
    {
        VO2 = (VI * (FIO2 / 100)) - (veSTPD * (FEO2 / 100)); //values are divided by 100 as they must be expressed as decimals instead of percentages
        return VO2;
    }
    public float respiratoryExRatio()
    {
        RER = VCO2 / VO2;
        return RER;
    }
    public float respiratoryQuotient()
    {
        RQ = VCO2 / VO2;
        return RQ;
    }
    public float VentCapacity(float FEV1)
    {
        Vecap = FEV1 * 40;
        return Vecap;
        //the sheet says "FEV1 * 40 or FEV1 * 35" so I don't know which one she wants us to use here????????????
    }
    public float VentEquivOxygen()
    {
        VeVO2 = VE / VO2;
        return VeVO2;
    }
    public float VentEquivCO2()
    {
        VeVCO2 = VE / VCO2;
        return VeVCO2;
    }
    public float calcEPOC(float EPOCduration, float EPOCconsumed)
    {
        //the epoc oxygen consumed will have to be calculated elsewhere, placeholder for now
        //will need a rest state and values relating to resting
        EPOC = EPOCconsumed - (VO2 * EPOCduration);
        return EPOC;
    }
    public float calcMET(float weight)
    {
        float temp = VO2 * 1000;
        float temp2 = temp / weight; //converting the VO2 value from litres into ml/kg
        MET = temp2 / 3.5f;
        return MET;

    }
    public float OxygenBreath()
    {
        VO2fr = VO2 / fr;
        return VO2fr;
    }

}