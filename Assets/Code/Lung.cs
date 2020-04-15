using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lung : MonoBehaviour
{
    public float FEV1 = 1.0f;   //forced expired volume in the first second of exhalation - INCREASES DURING EXERCISE
    public float FVC = 1.0f;    //maximum volume expired after exhalation - INCREASES DURING EXERCISE
    public float FVR;           //ratio of the two - FRACTION  

    public float ERV;           //expiratory reserve volume - maximum expiration at the end of tidal expiration - INCREASE
    public float IC;            //inspiratory capacity - maximum volume inspired following tidal expiration - INCREASE
    public float IRV;           //inspiratory reserve volume - maximum inspiration at the end of tidal inspiration - DECREASE

    public float MVV;           //maximal voluntary ventilation - measures ventilatory caspacity, requires deep breathing - ???
    public float PEF;           //peak expiratory flow rate - maximum flow available - INCREASE
    public float PEmax = 90;    //peak expiratory mouth pressure - pressure in mouth during expiration - INCREASE
    public float PIF;           //peak inspiratory flow rate - maximum flow available - RARELY MEASURED? - INCREASE
    public float PImax = 80;    //peak inspiratory mouth pressure - pressure in mouth during inspiration - INCREASE

    public float RV;            //residual volume - volume in lungs after maximum expiration - DECREASE
    public float TLC;           //total lung capacity - volume in lungers after maximum inspiration - SAME
    public float VC = 0;        //vital capacity - the greatest amount of air that can be expired after a maximal inspiration - INCREASE

    public float EILV;           //end inspiratory volume - INCREASE
    public float BEILV;          //BASE
    public float EELV;           //end exspiratory volume - DECREASE
    public float BEELV;          //BASE
    public float VT;             //tidal volume - INCREASE
    public float DH;             //dynamic hyperinflation

    //ON THE MODEL, WE HAVE || TLC, IC, IRV, DH || EILV, EELV, VT ||


    private float velocity = 0.0f;

    CharacterAvatar character;
    pvEquations vents;
    Cardio cardio;
    Exercise exercise;
    Timer timer;
    // Start is called before the first frame update
    public void Start()
    {
        character = GetComponent<CharacterAvatar>();
        vents = GetComponent<pvEquations>();
        cardio = GetComponent<Cardio>();
        exercise = GetComponent<Exercise>();
        timer = GetComponent<Timer>();
        setupfunction();
    }

    public void Update()
    {
        PImaxfunction();
        PEmaxfunction();

        if (timer.resetLUNG == true)
        {
            lungupdate();
            timer.resetLUNG = false;
        }   
        
        IC = (TLC - EELV); //INS. CAP
        IRV = (TLC - EILV); //INS. RES VOL
        ERV = (EELV - BEELV); //EXP. RES VOL
        VT = (EILV - EELV); //TIDAL VOLUME
        DH = EELV / BEELV;  //DYN. HYPINF.
    }

    void lungupdate()
    {

        switch (character.gender)
        {
            case 1:
                EILV = (TLC * (0.6f + (0.25f * (cardio.HR / cardio.HRmax))));
                EELV = (TLC * (0.5f + (0.1f * (cardio.HR / cardio.HRmax))));
                break;
            case 0:
                EILV = (TLC * (0.54f + (0.2f * (cardio.HR / cardio.HRmax))));
                EELV = (TLC * (0.4f + (0.05f * (cardio.HR / cardio.HRmax))));
                break;
            default:
                EILV = (TLC * (0.6f + (0.25f * (cardio.HR / cardio.HRmax))));
                EELV = (TLC * (0.5f + (0.1f * (cardio.HR / cardio.HRmax))));
                break;
        }

    }

    void setupfunction()
    {
        switch (character.gender)
        {
            case 1: //M
                    //litres
                ERV = 1.2f;
                EELV = 2.4f;
                EILV = 3;
                IC = 3.6f;
                IRV = 3;
                MVV = 160; //THIS COULD BE A VARIALBE
                PEF = 600; //THIS COULD BE A VARIABLE
                RV = 1.2f;
                TLC = 6.0f;
                VC = 4.8f;
                BEELV = EELV;
                BEILV = EILV;
                break;
            case 0: //F
                    //litres
                ERV = 0.8f;
                EELV = 1.8f;
                EILV = 2.3f;
                IC = 2.4f;
                IRV = 1.9f;
                MVV = 100;
                PEF = 430;
                RV = 1;
                TLC = 4.2f;
                VC = 3.2f;
                BEELV = EELV;
                BEILV = EILV;
                break;
            default: //M
                //litres
                ERV = 1.2f;
                EELV = 2.4f;
                EILV = 3;
                IC = 3.6f;
                IRV = 3;
                MVV = 160; //THIS COULD BE A VARIALBE
                PEF = 600; //THIS COULD BE A VARIABLE
                RV = 1.2f;
                TLC = 6;
                VC = 4.8f;
                BEELV = EELV;
                BEILV = EILV;
                break;
        }

        FEV1function();
        FVCfunction();
        FVRfunction();

        //MAYBE CHANGE THESE BASED ON THE EXERCISE TYPE?
        //FOR EXAMPLE, YOU ARE HUNCHED OVER WHILST CYCLING, DECREASING LUNG CAPACITY
    }

    void FEV1function() //changes things based on character settings
    {
        if(character.gender == 1)
        {
            FEV1 = ((0.043f * character.height) - (0.029f * character.age) - 2.49f);
        }
        else if(character.gender == 0)
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
    }

    void FVCfunction()
    {
        if (character.gender == 1)
        {
            FVC = ((0.0576f * character.height) - (0.026f * character.age) - 4.34f);
        }
        else if (character.gender == 0)
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
    }

    void FVRfunction()
    {
        FVR = (FEV1 / FVC);
    }

    void PImaxfunction()
    {
        PImax = (80 + (((cardio.HR / cardio.HRmax) / 100) * 220));
    }

    void PEmaxfunction()
    {
        PEmax = (90 + (((cardio.HR / cardio.HRmax) / 100) * 210));
    }
};
