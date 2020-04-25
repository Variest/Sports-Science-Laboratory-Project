using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Custom_Module_To_New_Scene : MonoBehaviour
{
    // Start is called before the first frame update

    public CharacterAvatar avatar;
    public InputField[] textBoxes = new InputField[10];
    public Text[] nameBoxes = new Text[10];
    public string[] nameBoxText = new string[10];
    public string[] namePopup = new string[10];
    public string[] longHand = new string[10];
    public GameObject moduleTextObject;
    public Text moduleNameText; //the name of the module that will be displayed at the top of the screen during the simulation.
    public FinalCustomModule customModule;
    public CustomModuleTester metCartModule;
    public pvcustommodule pvModule;
    public cardiocustommodule cardioModule;

    public pvEquations pulmonaryEquations;
    public Lung lungEquations;
    public Cardio cardioEquations;
    public Exercise exerciseEquations;

    public float timeElapsed; //takes the value from the testinput script
    //booleans to determine which of the modules is being used.
    public bool customOn;
    public bool metCartOn;
    public bool pvOn;
    public bool cardioOn;
    public bool advancedOn;
    public bool Basic_ON;
    public bool Timer_ON; //used to determine whether the simulation is currently running or not

    int intervalthing = 0; //test for the update
    public bool Update_ON = false; //used to stop crashes if the script tries to update too early
    void Start()
    {
        customModule = GetComponent<FinalCustomModule>();
        metCartModule = GetComponent<CustomModuleTester>();
        pvModule = GetComponent<pvcustommodule>();
        cardioModule = GetComponent<cardiocustommodule>();
        avatar = GetComponent<CharacterAvatar>();


        pulmonaryEquations = GetComponent<pvEquations>();
        lungEquations = GetComponent<Lung>();
        cardioEquations = GetComponent<Cardio>();
        exerciseEquations = GetComponent<Exercise>();
        //adding the stuff to hopefully put the right values into the boxes on the new scene

    }

    // Update is called once per frame
    void Update()
    {
        if (Update_ON)
        {
            // SetActorValues();
            if (customOn)
            {
                CustomUpdate();
            }
            if (metCartOn && advancedOn)
            {
                MetCartUpdate();
            }
            if (pvOn && advancedOn)
            {
                PvUpdate();
            }
            if (cardioOn && advancedOn)
            {
                CardioUpdate();
            }
            if (metCartOn && Basic_ON)
            {
                MetCartUpdateB();
            }
            if (pvOn && Basic_ON)
            {
                PvUpdateB();
            }
            if (cardioOn && Basic_ON)
            {
                CardioUpdateB();
            }

        }

    }

    IEnumerator WaitFor1(int i)
    {
        switch (i)
        {
            case 1:
                namePopup[i] = longHand[i];
                yield return new WaitForSecondsRealtime(1);
                longHand[i] = "";
                break;
            case 2:
                namePopup[i] = longHand[i];
                yield return new WaitForSecondsRealtime(1);
                longHand[i] = "";
                break;
            case 3:
                namePopup[i] = longHand[i];
                yield return new WaitForSecondsRealtime(1);
                longHand[i] = "";
                break;
            case 4:
                namePopup[i] = longHand[i];
                yield return new WaitForSecondsRealtime(1);
                longHand[i] = "";
                break;
            case 5:
                namePopup[i] = longHand[i];
                yield return new WaitForSecondsRealtime(1);
                longHand[i] = "";
                break;
            case 6:
                namePopup[i] = longHand[i];
                yield return new WaitForSecondsRealtime(1);
                longHand[i] = "";
                break;
            case 7:
                namePopup[i] = longHand[i];
                yield return new WaitForSecondsRealtime(1);
                longHand[i] = "";
                break;
            case 8:
                namePopup[i] = longHand[i];
                yield return new WaitForSecondsRealtime(1);
                longHand[i] = "";
                break;
            case 9:
                namePopup[i] = longHand[i];
                yield return new WaitForSecondsRealtime(1);
                longHand[i] = "";
                break;
            case 10:
                namePopup[i] = longHand[i];
                yield return new WaitForSecondsRealtime(1);
                longHand[i] = "";
                break;
            default:
                yield return new WaitForSecondsRealtime(1);
                break;
        }
    }

    void CustomUpdate()
    {
        for (int i = 0; i < 10; i++)
        {
            nameBoxText[i] = customModule.nameBoxes[i];
            moduleTextObject = GameObject.FindGameObjectWithTag("Module_Text_Box");
            moduleNameText = moduleTextObject.GetComponent<Text>();
            moduleNameText.text = "Custom Module";
        }
        if (Timer_ON)
        {
            exerciseEquations.ManualUpdate();
            cardioEquations.CalculateAll();
            lungEquations.CalculateAll();
            pulmonaryEquations.CalculateAll();
            for (int i = 0; i < 10; i++)
            {
                //Debug.Log("anime");


                if (customModule.filledBoxes[i] != false)
                {
                    switch (customModule.BoxValue[i])
                    {
                        case 1:
                            textBoxes[i].text = avatar.RPE.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                        case 2:
                            textBoxes[i].text = avatar.Dyspnoea.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                        case 3:
                            textBoxes[i].text = avatar.EE.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                        case 4:
                            textBoxes[i].text = avatar.TE.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                        case 5:
                            textBoxes[i].text = avatar.TI.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                        case 6:
                            textBoxes[i].text = avatar.Ttot.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                        case 7:
                            textBoxes[i].text = avatar.VT.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                        case 8:
                            textBoxes[i].text = avatar.fr.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                        case 9:
                            textBoxes[i].text = avatar.petco2.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                        case 10:
                            textBoxes[i].text = avatar.peto2.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                        case 11:
                            textBoxes[i].text = avatar.VE.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                        case 12:
                            textBoxes[i].text = avatar.VO2.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                        case 13:
                            textBoxes[i].text = avatar.VCO2.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                        case 14:
                            textBoxes[i].text = avatar.RER.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                        case 15:
                            textBoxes[i].text = avatar.MET.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                        case 16:
                            textBoxes[i].text = avatar.VO2fr.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                        case 17:
                            textBoxes[i].text = avatar.SpO2.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                        case 18:
                            textBoxes[i].text = avatar.Vecap.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                        case 19:
                            textBoxes[i].text = avatar.VeVO2.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                        case 20:
                            textBoxes[i].text = avatar.VeVCO2.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                        case 21:
                            textBoxes[i].text = avatar.FIO2.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                        case 22:
                            textBoxes[i].text = avatar.FICO2.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                        case 23:
                            textBoxes[i].text = avatar.FEO2.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                        case 24:
                            textBoxes[i].text = avatar.FECO2.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                        case 25:
                            textBoxes[i].text = avatar.BPd.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                        case 26:
                            textBoxes[i].text = avatar.BPs.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                        case 27:
                            textBoxes[i].text = avatar.MAP.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                        case 28:
                            textBoxes[i].text = avatar.Bla.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                        case 29:
                            textBoxes[i].text = avatar.CO.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                        case 30:
                            textBoxes[i].text = avatar.FCmax.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                        case 31:
                            textBoxes[i].text = avatar.FCres.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                        case 32:
                            textBoxes[i].text = avatar.VO2fc.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                        case 33:
                            textBoxes[i].text = avatar.SV.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                        case 34:
                            textBoxes[i].text = avatar.FEV1.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                        case 35:
                            textBoxes[i].text = avatar.FVC.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                        case 36:
                            textBoxes[i].text = avatar.FEV1FVC.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                        case 37:
                            textBoxes[i].text = avatar.PImax.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                        case 38:
                            textBoxes[i].text = avatar.PEmax.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                        case 39:
                            textBoxes[i].text = avatar.ERV.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                        case 40:
                            textBoxes[i].text = avatar.FRC.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                        case 41:
                            textBoxes[i].text = avatar.IC.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                        case 42:
                            textBoxes[i].text = avatar.IRV.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                        case 43:
                            textBoxes[i].text = avatar.PIF.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                        case 44:
                            textBoxes[i].text = avatar.PEF.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                        case 45:
                            textBoxes[i].text = avatar.RV.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                        case 46:
                            textBoxes[i].text = avatar.TLC.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                        case 47:
                            textBoxes[i].text = avatar.VC.ToString();
                            namePopup[i] = customModule.popupBoxes[i];
                            break;
                    }
                }
            }
        }


    }
    void MetCartUpdate()
    {
        for (int i = 0; i < 10; i++)
        {
            nameBoxText[i] = metCartModule.nameBoxes[i]; 
        }
        moduleTextObject = GameObject.FindGameObjectWithTag("Module_Text_Box");
        moduleNameText = moduleTextObject.GetComponent<Text>();
        moduleNameText.text = "Metabolic Cart";
        if (Timer_ON)
        {
            exerciseEquations.ManualUpdate();
            cardioEquations.CalculateAll();
            lungEquations.CalculateAll();
            pulmonaryEquations.CalculateAll();
            for (int i = 0; i < 10; i++)
            {
                //nameBoxText[i] = metCartModule.nameBoxes[i];
                if (metCartModule.filledBoxes[i] != false)
                {
                    switch (metCartModule.BoxValue[i])
                    {
                        case 1:
                            textBoxes[i].text = avatar.VE.ToString();
                            namePopup[i] = metCartModule.popUpBoxes[i];
                            break;
                        case 2:
                            textBoxes[i].text = avatar.VT.ToString();
                            namePopup[i] = metCartModule.popUpBoxes[i];
                            break;
                        case 3:
                            textBoxes[i].text = avatar.VO2.ToString();
                            namePopup[i] = metCartModule.popUpBoxes[i];
                            break;
                        case 4:
                            textBoxes[i].text = avatar.VCO2.ToString();
                            namePopup[i] = metCartModule.popUpBoxes[i];
                            break;
                        case 5:
                            textBoxes[i].text = avatar.fr.ToString();
                            namePopup[i] = metCartModule.popUpBoxes[i];
                            break;
                        case 6:
                            textBoxes[i].text = avatar.MET.ToString();
                            namePopup[i] = metCartModule.popUpBoxes[i];
                            break;
                        case 7:
                            textBoxes[i].text = avatar.fc.ToString();
                            namePopup[i] = metCartModule.popUpBoxes[i];
                            break;
                        case 8:
                            textBoxes[i].text = avatar.RER.ToString();
                            namePopup[i] = metCartModule.popUpBoxes[i];
                            break;
                        case 9:
                            textBoxes[i].text = avatar.VeVO2.ToString();
                            namePopup[i] = metCartModule.popUpBoxes[i];
                            break;
                        case 10:
                            textBoxes[i].text = avatar.VeVCO2.ToString();
                            namePopup[i] = metCartModule.popUpBoxes[i];
                            break;
                        case 11:
                            textBoxes[i].text = avatar.petco2.ToString();
                            namePopup[i] = metCartModule.popUpBoxes[i];
                            break;
                        case 12:
                            textBoxes[i].text = avatar.petco2.ToString();
                            namePopup[i] = metCartModule.popUpBoxes[i];
                            break;
                        case 13:
                            textBoxes[i].text = avatar.TE.ToString();
                            namePopup[i] = metCartModule.popUpBoxes[i];
                            break;
                        case 14:
                            textBoxes[i].text = avatar.TI.ToString();
                            namePopup[i] = metCartModule.popUpBoxes[i];
                            break;
                        case 15:
                            textBoxes[i].text = avatar.TITE.ToString();
                            namePopup[i] = metCartModule.popUpBoxes[i];
                            break;
                        case 16:
                            textBoxes[i].text = avatar.Ttot.ToString();
                            namePopup[i] = metCartModule.popUpBoxes[i];
                            break;
                        case 17:
                            textBoxes[i].text = avatar.VO2fr.ToString();
                            namePopup[i] = metCartModule.popUpBoxes[i];
                            break;
                        case 18:
                            textBoxes[i].text = avatar.VO2fc.ToString();
                            namePopup[i] = metCartModule.popUpBoxes[i];
                            break;
                        case 19:
                            textBoxes[i].text = avatar.SpO2.ToString();
                            namePopup[i] = metCartModule.popUpBoxes[i];
                            break;
                        case 20:
                            textBoxes[i].text = avatar.FCmax.ToString();
                            namePopup[i] = metCartModule.popUpBoxes[i];
                            break;
                        case 21:
                            textBoxes[i].text = avatar.FCres.ToString();
                            namePopup[i] = metCartModule.popUpBoxes[i];
                            break;
                        case 22:
                            textBoxes[i].text = avatar.EE.ToString();
                            namePopup[i] = metCartModule.popUpBoxes[i];
                            break;

                    }
                }
            }
        }

    }
    void PvUpdate()
    {

        for (int i = 0; i < 10; i++)
        {
            nameBoxText[i] = pvModule.nameBoxes[i];
            moduleTextObject = GameObject.FindGameObjectWithTag("Module_Text_Box"); //changes the value present inside the name box at the top of the main scene
            moduleNameText = moduleTextObject.GetComponent<Text>();
            moduleNameText.text = "Pulmonary Vents";
        }

        if (Timer_ON)
        {

            exerciseEquations.ManualUpdate();
            cardioEquations.CalculateAll();
            lungEquations.CalculateAll();
            pulmonaryEquations.CalculateAll();
            for (int i = 0; i < 10; i++)
            {

                if (pvModule.filledBoxes[i] != false)
                {
                    switch (pvModule.BoxValue[i])
                    {
                        case 1:
                            textBoxes[i].text = avatar.FVC.ToString();
                            namePopup[i] = pvModule.popupBoxes[i];
                            break;
                        case 2:
                            textBoxes[i].text = avatar.FEV1.ToString();
                            namePopup[i] = pvModule.popupBoxes[i];
                            break;
                        case 3:
                            textBoxes[i].text = avatar.FEV1FVC.ToString();
                            namePopup[i] = pvModule.popupBoxes[i];
                            break;
                        case 4:
                            textBoxes[i].text = avatar.PEF.ToString();
                            namePopup[i] = pvModule.popupBoxes[i];
                            break;
                        case 5:
                            textBoxes[i].text = avatar.PIF.ToString();
                            namePopup[i] = pvModule.popupBoxes[i];
                            break;
                        case 6:
                            textBoxes[i].text = avatar.PImax.ToString();
                            namePopup[i] = pvModule.popupBoxes[i];
                            break;
                        case 7:
                            textBoxes[i].text = avatar.PEmax.ToString();
                            namePopup[i] = pvModule.popupBoxes[i];
                            break;
                        case 8:
                            textBoxes[i].text = avatar.Vecap.ToString();
                            namePopup[i] = pvModule.popupBoxes[i];
                            break;
                        case 9:
                            textBoxes[i].text = avatar.ERV.ToString();
                            namePopup[i] = pvModule.popupBoxes[i];
                            break;
                        case 10:
                            textBoxes[i].text = avatar.FRC.ToString();
                            namePopup[i] = pvModule.popupBoxes[i];
                            break;
                        case 11:
                            textBoxes[i].text = avatar.IC.ToString();
                            namePopup[i] = pvModule.popupBoxes[i];
                            break;
                        case 12:
                            textBoxes[i].text = avatar.IRV.ToString();
                            namePopup[i] = pvModule.popupBoxes[i];
                            break;
                        case 13:
                            textBoxes[i].text = avatar.RV.ToString();
                            namePopup[i] = pvModule.popupBoxes[i];
                            break;
                        case 14:
                            textBoxes[i].text = avatar.TLC.ToString();
                            namePopup[i] = pvModule.popupBoxes[i];
                            break;
                        case 15:
                            textBoxes[i].text = avatar.VC.ToString();
                            namePopup[i] = pvModule.popupBoxes[i];
                            break;


                    }
                }
            }
        }

    }
    void CardioUpdate()
    {
        for (int i = 0; i < 10; i++)
        {
            nameBoxText[i] = cardioModule.nameBoxes[i];
            moduleTextObject = GameObject.FindGameObjectWithTag("Module_Text_Box");
            moduleNameText = moduleTextObject.GetComponent<Text>();
            moduleNameText.text = "Cardio";
        }
        if (Timer_ON)
        {

            exerciseEquations.ManualUpdate();
            cardioEquations.CalculateAll();
            lungEquations.CalculateAll();
            pulmonaryEquations.CalculateAll();
            for (int i = 0; i < 10; i++)
            {

                if (cardioModule.filledBoxes[i] != false)
                {
                    switch (cardioModule.BoxValue[i])
                    {
                        case 1:
                            textBoxes[i].text = avatar.fc.ToString();
                            namePopup[i] = cardioModule.popupBoxes[i];
                            break;
                        case 2:
                            textBoxes[i].text = avatar.VO2fc.ToString();
                            namePopup[i] = cardioModule.popupBoxes[i];
                            break;
                        case 3:
                            textBoxes[i].text = avatar.MAP.ToString();
                            namePopup[i] = cardioModule.popupBoxes[i];
                            break;
                        case 4:
                            textBoxes[i].text = avatar.FCmax.ToString();
                            namePopup[i] = cardioModule.popupBoxes[i];
                            break;
                        case 5:
                            textBoxes[i].text = avatar.Bla.ToString();
                            namePopup[i] = cardioModule.popupBoxes[i];
                            break;
                        case 6:
                            textBoxes[i].text = avatar.CO.ToString();
                            namePopup[i] = cardioModule.popupBoxes[i];
                            break;
                        case 7:
                            textBoxes[i].text = avatar.BPd.ToString();
                            namePopup[i] = cardioModule.popupBoxes[i];
                            break;
                        case 8:
                            textBoxes[i].text = avatar.BPs.ToString();
                            namePopup[i] = cardioModule.popupBoxes[i];
                            break;
                        case 9:
                            textBoxes[i].text = avatar.SV.ToString();
                            namePopup[i] = cardioModule.popupBoxes[i];
                            break;
                        case 10:
                            textBoxes[i].text = avatar.FCres.ToString();
                            namePopup[i] = cardioModule.popupBoxes[i];
                            break;
                        case 11:
                            textBoxes[i].text = avatar.SpO2.ToString();
                            namePopup[i] = cardioModule.popupBoxes[i];
                            break;


                    }
                }
            }
        }


    }

    void MetCartUpdateB()
    {
        nameBoxText[0] = "VE";
        nameBoxText[1] = "VT";
        nameBoxText[2] = "VO2";
        nameBoxText[3] = "VCO2";
        nameBoxText[4] = "fr";
        nameBoxText[5] = "MET";
        nameBoxText[6] = "fc";
        nameBoxText[7] = "RER";
        moduleTextObject = GameObject.FindGameObjectWithTag("Module_Text_Box");
        moduleNameText = moduleTextObject.GetComponent<Text>();
        moduleNameText.text = "Metabolic Cart";
        if (Timer_ON)
        {
            exerciseEquations.ManualUpdate();
            cardioEquations.CalculateAll();
            lungEquations.CalculateAll();
            pulmonaryEquations.CalculateAll();
            textBoxes[0].text = avatar.VE.ToString();
            textBoxes[1].text = avatar.VT.ToString();
            textBoxes[2].text = avatar.VO2.ToString();
            textBoxes[3].text = avatar.VCO2.ToString();
            textBoxes[4].text = avatar.fr.ToString();
            textBoxes[5].text = avatar.MET.ToString();
            textBoxes[6].text = avatar.fc.ToString();
            textBoxes[7].text = avatar.RER.ToString();
        }


    }
    void PvUpdateB()
    {
        nameBoxText[0] = "FVC";
        nameBoxText[1] = "FEV1";
        nameBoxText[2] = "FEV1/FVC";
        nameBoxText[3] = "PEF";
        nameBoxText[4] = "PIF";
        nameBoxText[5] = "VECap";
        moduleTextObject = GameObject.FindGameObjectWithTag("Module_Text_Box");
        moduleNameText = moduleTextObject.GetComponent<Text>();
        moduleNameText.text = "Pulmonary Vents";

        if (Timer_ON)
        {
            Debug.Log(avatar.FVC);

            //float sdTime = float.Parse(timeElapsed.ToString("F0"));
            //Debug.Log("The man is " + sdTime);
            if (timeElapsed >= intervalthing)
            {
                intervalthing++;
                pulmonaryEquations.timeInterval = intervalthing;
                exerciseEquations.ManualUpdate();
                cardioEquations.CalculateAll();
                lungEquations.CalculateAll();
                pulmonaryEquations.CalculateAll();
                //avatar.FVC = avatar.FVC * (intervalthing + 1);
                textBoxes[0].text = avatar.FVC.ToString();
                //avatar.FEV1 = avatar.FEV1 * (intervalthing + 1);
                textBoxes[1].text = avatar.FEV1.ToString();
                textBoxes[2].text = avatar.FEV1FVC.ToString();
                textBoxes[3].text = avatar.PEF.ToString();
                textBoxes[4].text = avatar.PIF.ToString();
                textBoxes[5].text = avatar.Vecap.ToString();
            }

        }


    }
    void CardioUpdateB()
    {
        nameBoxText[0] = "fc";
        nameBoxText[1] = "VO2/fc";
        nameBoxText[2] = "MAP";
        nameBoxText[3] = "fcmax";
        moduleTextObject = GameObject.FindGameObjectWithTag("Module_Text_Box");
        moduleNameText = moduleTextObject.GetComponent<Text>();
        moduleNameText.text = "Cardio";
        if (Timer_ON)
        {
            exerciseEquations.ManualUpdate();
            cardioEquations.CalculateAll();
            lungEquations.CalculateAll();
            pulmonaryEquations.CalculateAll();
            textBoxes[0].text = avatar.fc.ToString();
            textBoxes[1].text = avatar.VO2fc.ToString();
            textBoxes[2].text = avatar.MAP.ToString();
            textBoxes[3].text = avatar.FCmax.ToString();
        }


    }
    public void ResetValues()
    {

        for (int i = 0; i < 10; i++)
        {
            textBoxes[i].text = "";
            nameBoxes[i].text = "";

            customOn = false;
            metCartOn = false;
            pvOn = false;
            cardioOn = false;

            namePopup[i] = "";
            customOn= false;
            metCartOn = false;
            pvOn = false;
            cardioOn = false;

        }
        pvModule.ResetAllValues();
        cardioModule.ResetAllValues();
        metCartModule.ResetAllValues();
        customModule.ResetAllValues();
    }

    public void ResetModuleValues()
    {
        customOn = false;
        metCartOn = false;
        pvOn = false;
        cardioOn = false;
        pvModule.ResetAllValues();
        cardioModule.ResetAllValues();
        metCartModule.ResetAllValues();
        customModule.ResetAllValues();
    }
    void ButtonAssign()
    {
        if (customOn && advancedOn)
        {
            customModule.AttachButtons();
        }
        if (metCartOn && advancedOn)
        {
            metCartModule.AttachButtons();
        }
        if (pvOn && advancedOn)
        {
            pvModule.AttachButtons();
        }
        if (cardioOn && advancedOn)
        {
            cardioModule.AttachButtons();
        }
    }
}
  
