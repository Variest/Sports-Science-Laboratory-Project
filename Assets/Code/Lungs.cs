using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lung : MonoBehaviour
{
    public float FEV1 = 1.0f; //forced expired volume in the first second of exhalation
    public float FVC = 1.0f; //maximum volume expired after exhalation
    public float FVR; //ratio of the two

    public float ERV; //expiratory reserve volume - maximum expiration at the end of tidal expiration
    public float FRC; //functional residual capaciy - volume in lungers after tidal expiration
    public float IC; //inspiratory capacity - maximum volume inspired following tidal expiration
    public float IRV; //inspiratory reserve volume - maximum inspiration at the end of tidal inspiration
    public float MVV; //maximal voluntary ventilation - measures ventilatory caspacity, requires deep breathing
    public float PEF; //peak expiratory flow rate - maximum flow available
    public float PEmax; //peak expiratory mouth pressure - pressure in mouth during expiration
    public float PIF; //peak inspiratory flow rate - maximum flow available - RARELY MEASURED?
    public float PImax; //peak inspiratory mouth pressure - pressure in mouth during inspiration
    public float RV; //residual volume - volume in lungs after maximum expiration
    public float TLC; //total lung capacity - volume in lungers after maximum inspiration
    public float VC; //vital capacity - the greatest amount of air that can be expired after a maximal inspiration
       

    CharacterCustomiser character;
    pvEquations vents;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterCustomiser>();
        vents = GetComponent<pvEquations>();
    }

    void setupfunction()
    {
        if (character.gender == true) //M
        {
            ERV = 1200;
            FRC = 2400;
            IC = 3600;
            IRV = 3000;
            MVV = 160000; //THIS COULD BE A VARIALBE
            PEF = 600000; //THIS COULD BE A VARIABLE
            RV = 1200;
            TLC = 6000;
            VC = 4800;
        }
        else if (character.gender == false) //F
        {
            ERV = 800;
            FRC = 1800;
            IC = 2400;
            IRV = 19000;
            MVV = 100000;
            PEF = 430000;
            RV = 1000;
            TLC = 4200;
            VC = 3200;
        };
    }

    void FEV1function() //changes things based on character settings
    {
        if(character.gender == true)
        {
            FEV1 = ((0.043f * character.height) - (0.029f * character.age) - 2.49f);
        }
        else if(character.gender == false)
        {
            FEV1 = ((0.0395f * character.height) - (0.025f * character.age) - 2.6f);
        };
        
        if(character.race == 1)
        {
            FEV1 *= 0.93f;
        }
        else if(character.race == 2)
        {
            FEV1 *= 0.87f;
        };

        FVRfunction(); //after this changes, FVR is assumed to change, so needs to be recalculated
    }

    void FVCfunction()
    {
        if (character.gender == true)
        {
            FVC = ((0.0576f * character.height) - (0.026f * character.age) - 4.34f);
        }
        else if (character.gender == false)
        {
            FVC = ((0.0443f * character.height) - (0.026f * character.age) - 2.89f);
        };

        if (character.race == 1)
        {
            FVC *= 0.93f;
        }
        else if (character.race == 2)
        {
            FVC *= 0.87f;
        };

        FVRfunction();
    }

    void FVRfunction()
    {
        FVR = (FEV1 / FVC);
    }

    Lung(){}
};
