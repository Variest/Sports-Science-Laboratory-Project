using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleUpdater : MonoBehaviour
{

    //will use a timer to update the modules at intervals
    //probably wont be the actual one we use in the final version, just using this as a way to see how it might work and plan out the functionality

    public CharacterAvatar avatar; //we N E E D this
    public GameObject moduleHolder; //will we just have a gameobject that contains the script with the module we are using? seems like an easy way to do it

    public pvEquations pvSheet; //equation sheet for the pulmonary variables
    public int selectedModule; //0 metabolic, 1 pv, 2 cardio, 3 custom
    public bool isBasic;
    public float Timer = 0.0f; //shows the amount of time that has passed. 
    public float intervalTimer = 0.0f; //timer used to time the intervals that have passed

    private float waitTime = 2.0f; //the amount of time the program waits before updating values

    bool pauseTimer;

    public PVModulebasic basic_PV;
    public pvcustommodule advanced_PV;
    public cardiomodulebasic basic_Cardio;
    public cardiocustommodule advanced_Cardio;
    public MetabolicCartModule basic_meta;
    public CustomModuleTester advanced_meta;
    public FinalCustomModule custom_module;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!pauseTimer)
        {
            Timer += Time.deltaTime; //as long as the timer is not paused it will continue to update the timer
            intervalTimer += Time.deltaTime;

            if(intervalTimer > waitTime)
            {
                StartCoroutine(processTask());
                intervalTimer = intervalTimer - waitTime;
            }
        }
    }

    IEnumerator processTask()
    {
        yield return new WaitForSeconds(2);
        testCalculate();
    }

    void testCalculate()
    {
        int roundedTimer = Mathf.RoundToInt(Timer); //might not use this - but it will round the timer down to an integer so it may result in some less ridiculous numbers when performing calculations
        //it would update a "time" variable within the sheets used to calculate all the variables here - dunno how that's gonna be used yet so will just leave it as a nice little comment for now
        pvSheet.CalculateAll(); //function within the sheets to update every variable within them - guarantees that we never have any values wrong because we didn't fully update stuff.
        if(selectedModule ==0)
        {
            if(isBasic)
            {
                basic_meta.ManualUpdate();
            }
            else
            {
                advanced_meta.ManualUpdate();
            }
        }
        else if(selectedModule == 1)
        {
            if (isBasic)
            {
                basic_PV.ManualUpdate();
            }
            else
            {
                advanced_PV.ManualUpdate();
            }
        }
        else if (selectedModule == 2)
        {
            if (isBasic)
            {
                basic_Cardio.ManualUpdate();
            }
            else
            {
                advanced_Cardio.ManualUpdate();
            }
        }
        else if (selectedModule == 3)
        {
            custom_module.ManualUpdate();
        }
        //will probably be a function on a separate sheet in the real version - i just want to see how it could work with a fake function for now

        //From what I can tell, we don't seem to properly know how time passing changes most of the variables, if at all. 
        //We might need to ask Mitch about this again to try and get the proper values, because I feel it is better to pester her a bit and get correct values 
        //than rely on google and potentially find wrong values that mess the project up. 

    }
}
