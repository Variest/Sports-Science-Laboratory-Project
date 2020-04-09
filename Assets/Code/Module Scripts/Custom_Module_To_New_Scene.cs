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
    public GameObject moduleTextObject;
    public Text moduleNameText; //the name of the module that will be displayed at the top of the screen during the simulation.
    public FinalCustomModule custom_module;
    public CustomModuleTester MetCart_module;
    public pvcustommodule Pv_module;
    public cardiocustommodule Cardio_Module;

    public pvEquations pulmonaryEquations;
    public Lung lungEquations;
    public Cardio cardioEquations;
    public Exercise exerciseEquations;

    public float timeElapsed; //takes the value from the testinput script
    //booleans to determine which of the modules is being used.
    public bool Custom_ON;
    public bool MetCart_ON;
    public bool PV_ON;
    public bool Cardio_ON;
    public bool Advanced_ON;
    public bool Basic_ON;
    public bool Timer_ON; //used to determine whether the simulation is currently running or not

    int intervalthing =0; //test for the update
    public bool Update_ON = false; //used to stop crashes if the script tries to update too early
    void Start()
    {
        custom_module = GetComponent<FinalCustomModule>();
        MetCart_module = GetComponent<CustomModuleTester>();
        Pv_module = GetComponent<pvcustommodule>();
        Cardio_Module = GetComponent<cardiocustommodule>();
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
        if(Update_ON)
        {
           // SetActorValues();
            if (Custom_ON)
            {
                CustomUpdate();
            }
            if (MetCart_ON && Advanced_ON)
            {
                MetCartUpdate();
            }
            if (PV_ON && Advanced_ON)
            {
                PvUpdate();
            }
            if (Cardio_ON && Advanced_ON)
            {
                CardioUpdate();
            }
            if(MetCart_ON && Basic_ON)
            {
                MetCartUpdateB();
            }
            if (PV_ON && Basic_ON)
            {
                PvUpdateB();
            }
            if (Cardio_ON && Basic_ON)
            {
                CardioUpdateB();
            }

        }
  
    }

    void CustomUpdate()
    {
        for(int i = 0; i < 10; i++)
        {
            nameBoxText[i] = custom_module.nameBoxes[i];
            moduleTextObject = GameObject.FindGameObjectWithTag("Module_Text_Box");
            moduleNameText = moduleTextObject.GetComponent<Text>();
            moduleNameText.text = "Custom Module";
        }
        if(Timer_ON)
        {
            exerciseEquations.manualUpdate();
            cardioEquations.CalculateAll();
            lungEquations.CalculateAll();
            pulmonaryEquations.CalculateAll();
            for (int i = 0; i < 10; i++)
            {
                //Debug.Log("anime");

                
                if (custom_module.filledBoxes[i] != false)
                {
                    switch (custom_module.BoxValue[i])
                    {
                        case 1:
                            textBoxes[i].text = avatar.RPE.ToString();
                            break;
                        case 2:
                            textBoxes[i].text = avatar.Dyspnoea.ToString();
                            break;
                        case 3:
                            textBoxes[i].text = avatar.EE.ToString();
                            break;
                        case 4:
                            textBoxes[i].text = avatar.TE.ToString();
                            break;
                        case 5:
                            textBoxes[i].text = avatar.TI.ToString();
                            break;
                        case 6:
                            textBoxes[i].text = avatar.Ttot.ToString();
                            break;
                        case 7:
                            textBoxes[i].text = avatar.VT.ToString();
                            break;
                        case 8:
                            textBoxes[i].text = avatar.fr.ToString();
                            break;
                        case 9:
                            textBoxes[i].text = avatar.petco2.ToString();
                            break;
                        case 10:
                            textBoxes[i].text = avatar.peto2.ToString();
                            break;
                        case 11:
                            textBoxes[i].text = avatar.VE.ToString();
                            break;
                        case 12:
                            textBoxes[i].text = avatar.VO2.ToString();
                            break;
                        case 13:
                            textBoxes[i].text = avatar.VCO2.ToString();
                            break;
                        case 14:
                            textBoxes[i].text = avatar.RER.ToString();
                            break;
                        case 15:
                            textBoxes[i].text = avatar.MET.ToString();
                            break;
                        case 16:
                            textBoxes[i].text = avatar.VO2fr.ToString();
                            break;
                        case 17:
                            textBoxes[i].text = avatar.SpO2.ToString();
                            break;
                        case 18:
                            textBoxes[i].text = avatar.Vecap.ToString();
                            break;
                        case 19:
                            textBoxes[i].text = avatar.VeVO2.ToString();
                            break;
                        case 20:
                            textBoxes[i].text = avatar.VeVCO2.ToString();
                            break;
                        case 21:
                            textBoxes[i].text = avatar.FIO2.ToString();
                            break;
                        case 22:
                            textBoxes[i].text = avatar.FICO2.ToString();
                            break;
                        case 23:
                            textBoxes[i].text = avatar.FEO2.ToString();
                            break;
                        case 24:
                            textBoxes[i].text = avatar.FECO2.ToString();
                            break;
                        case 25:
                            textBoxes[i].text = avatar.BPd.ToString();
                            break;
                        case 26:
                            textBoxes[i].text = avatar.BPs.ToString();
                            break;
                        case 27:
                            textBoxes[i].text = avatar.MAP.ToString();
                            break;
                        case 28:
                            textBoxes[i].text = avatar.Bla.ToString();
                            break;
                        case 29:
                            textBoxes[i].text = avatar.CO.ToString();
                            break;
                        case 30:
                            textBoxes[i].text = avatar.FCmax.ToString();
                            break;
                        case 31:
                            textBoxes[i].text = avatar.FCres.ToString();
                            break;
                        case 32:
                            textBoxes[i].text = avatar.VO2fc.ToString();
                            break;
                        case 33:
                            textBoxes[i].text = avatar.SV.ToString();
                            break;
                        case 34:
                            textBoxes[i].text = avatar.FEV1.ToString();
                            break;
                        case 35:
                            textBoxes[i].text = avatar.FVC.ToString();
                            break;
                        case 36:
                            textBoxes[i].text = avatar.FEV1FVC.ToString();
                            break;
                        case 37:
                            textBoxes[i].text = avatar.PImax.ToString();
                            break;
                        case 38:
                            textBoxes[i].text = avatar.PEmax.ToString();
                            break;
                        case 39:
                            textBoxes[i].text = avatar.ERV.ToString();
                            break;
                        case 40:
                            textBoxes[i].text = avatar.FRC.ToString();
                            break;
                        case 41:
                            textBoxes[i].text = avatar.IC.ToString();
                            break;
                        case 42:
                            textBoxes[i].text = avatar.IRV.ToString();
                            break;
                        case 43:
                            textBoxes[i].text = avatar.PIF.ToString();
                            break;
                        case 44:
                            textBoxes[i].text = avatar.PEF.ToString();
                            break;
                        case 45:
                            textBoxes[i].text = avatar.RV.ToString();
                            break;
                        case 46:
                            textBoxes[i].text = avatar.TLC.ToString();
                            break;
                        case 47:
                            textBoxes[i].text = avatar.VC.ToString();
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
            nameBoxText[i] = MetCart_module.nameBoxes[i];
            moduleTextObject = GameObject.FindGameObjectWithTag("Module_Text_Box");
            moduleNameText = moduleTextObject.GetComponent<Text>();
            moduleNameText.text = "Metabolic Cart"; 

        }
        if (Timer_ON)
        {
            exerciseEquations.manualUpdate();
            cardioEquations.CalculateAll();
            lungEquations.CalculateAll();
            pulmonaryEquations.CalculateAll();
            for (int i = 0; i < 10; i++)
            {
                nameBoxText[i] = MetCart_module.nameBoxes[i];
                if (MetCart_module.filledBoxes[i] != false)
                {
                    switch (MetCart_module.BoxValue[i])
                    {
                        case 1:
                            textBoxes[i].text = avatar.VE.ToString();
                            break;
                        case 2:
                            textBoxes[i].text = avatar.VT.ToString();
                            break;
                        case 3:
                            textBoxes[i].text = avatar.VO2.ToString();
                            break;
                        case 4:
                            textBoxes[i].text = avatar.VCO2.ToString();
                            break;
                        case 5:
                            textBoxes[i].text = avatar.fr.ToString();
                            break;
                        case 6:
                            textBoxes[i].text = avatar.MET.ToString();
                            break;
                        case 7:
                            textBoxes[i].text = avatar.fc.ToString();
                            break;
                        case 8:
                            textBoxes[i].text = avatar.RER.ToString();
                            break;
                        case 9:
                            textBoxes[i].text = avatar.VeVO2.ToString();
                            break;
                        case 10:
                            textBoxes[i].text = avatar.VeVCO2.ToString();
                            break;
                        case 11:
                            textBoxes[i].text = avatar.petco2.ToString();
                            break;
                        case 12:
                            textBoxes[i].text = avatar.petco2.ToString();
                            break;
                        case 13:
                            textBoxes[i].text = avatar.TE.ToString();
                            break;
                        case 14:
                            textBoxes[i].text = avatar.TI.ToString();
                            break;
                        case 15:
                            textBoxes[i].text = avatar.TITE.ToString();
                            break;
                        case 16:
                            textBoxes[i].text = avatar.Ttot.ToString();
                            break;
                        case 17:
                            textBoxes[i].text = avatar.VO2fr.ToString();
                            break;
                        case 18:
                            textBoxes[i].text = avatar.VO2fc.ToString();
                            break;
                        case 19:
                            textBoxes[i].text = avatar.SpO2.ToString();
                            break;
                        case 20:
                            textBoxes[i].text = avatar.FCmax.ToString();
                            break;
                        case 21:
                            textBoxes[i].text = avatar.FCres.ToString();
                            break;
                        case 22:
                            textBoxes[i].text = avatar.EE.ToString();
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
            nameBoxText[i] = Pv_module.nameBoxes[i];
            moduleTextObject = GameObject.FindGameObjectWithTag("Module_Text_Box"); //changes the value present inside the name box at the top of the main scene
            moduleNameText = moduleTextObject.GetComponent<Text>();
            moduleNameText.text = "Pulmonary Vents";
        }

        if (Timer_ON)
        {

            exerciseEquations.manualUpdate();
            cardioEquations.CalculateAll();
            lungEquations.CalculateAll();
            pulmonaryEquations.CalculateAll();
            for (int i = 0; i < 10; i++)
            {
               
                if (Pv_module.filledBoxes[i] != false)
                {
                    switch (Pv_module.BoxValue[i])
                    {
                        case 1:
                            textBoxes[i].text = avatar.FVC.ToString();
                            break;
                        case 2:
                            textBoxes[i].text = avatar.FEV1.ToString();
                            break;
                        case 3:
                            textBoxes[i].text = avatar.FEV1FVC.ToString();
                            break;
                        case 4:
                            textBoxes[i].text = avatar.PEF.ToString();
                            break;
                        case 5:
                            textBoxes[i].text = avatar.PIF.ToString();
                            break;
                        case 6:
                            textBoxes[i].text = avatar.PImax.ToString();
                            break;
                        case 7:
                            textBoxes[i].text = avatar.PEmax.ToString();
                            break;
                        case 8:
                            textBoxes[i].text = avatar.Vecap.ToString();
                            break;
                        case 9:
                            textBoxes[i].text = avatar.ERV.ToString();
                            break;
                        case 10:
                            textBoxes[i].text = avatar.FRC.ToString();
                            break;
                        case 11:
                            textBoxes[i].text = avatar.IC.ToString();
                            break;
                        case 12:
                            textBoxes[i].text = avatar.IRV.ToString();
                            break;
                        case 13:
                            textBoxes[i].text = avatar.RV.ToString();
                            break;
                        case 14:
                            textBoxes[i].text = avatar.TLC.ToString();
                            break;
                        case 15:
                            textBoxes[i].text = avatar.VC.ToString();
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
            nameBoxText[i] = Cardio_Module.nameBoxes[i];
            moduleTextObject = GameObject.FindGameObjectWithTag("Module_Text_Box");
            moduleNameText = moduleTextObject.GetComponent<Text>();
            moduleNameText.text = "Cardio";
        }
        if (Timer_ON)
        {
          
            exerciseEquations.manualUpdate();
            cardioEquations.CalculateAll();
            lungEquations.CalculateAll();
            pulmonaryEquations.CalculateAll();
            for (int i = 0; i < 10; i++)
            {
                
                if (Cardio_Module.filledBoxes[i] != false)
                {
                    switch (Cardio_Module.BoxValue[i])
                    {
                        case 1:
                            textBoxes[i].text = avatar.fc.ToString();
                            break;
                        case 2:
                            textBoxes[i].text = avatar.VO2fc.ToString();
                            break;
                        case 3:
                            textBoxes[i].text = avatar.MAP.ToString();
                            break;
                        case 4:
                            textBoxes[i].text = avatar.FCmax.ToString();
                            break;
                        case 5:
                            textBoxes[i].text = avatar.Bla.ToString();
                            break;
                        case 6:
                            textBoxes[i].text = avatar.CO.ToString();
                            break;
                        case 7:
                            textBoxes[i].text = avatar.BPd.ToString();
                            break;
                        case 8:
                            textBoxes[i].text = avatar.BPs.ToString();
                            break;
                        case 9:
                            textBoxes[i].text = avatar.SV.ToString();
                            break;
                        case 10:
                            textBoxes[i].text = avatar.FCres.ToString();
                            break;
                        case 11:
                            textBoxes[i].text = avatar.SpO2.ToString();
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
            exerciseEquations.manualUpdate();
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
                exerciseEquations.manualUpdate();
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
            exerciseEquations.manualUpdate();
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
            Custom_ON = false;
            MetCart_ON = false;
            PV_ON = false;
            Cardio_ON = false;
        }
        Pv_module.ResetAllValues();
        Cardio_Module.ResetAllValues();
        MetCart_module.ResetAllValues();
        custom_module.ResetAllValues();
    }

    public void ResetModuleValues()
    {
        Custom_ON = false;
        MetCart_ON = false;
        PV_ON = false;
        Cardio_ON = false;
        Pv_module.ResetAllValues();
        Cardio_Module.ResetAllValues();
        MetCart_module.ResetAllValues();
        custom_module.ResetAllValues();
    }
    void ButtonAssign()
    {
        if (Custom_ON && Advanced_ON)
        {
           custom_module.AttachButtons();
        }
        if (MetCart_ON && Advanced_ON)
        {
            MetCart_module.AttachButtons();
        }
        if (PV_ON && Advanced_ON)
        {
           Pv_module.AttachButtons();
        }
        if (Cardio_ON && Advanced_ON)
        {
            Cardio_Module.AttachButtons();
        }
    }

    void SetActorValues() //will set the values of each variable within the actor to be equal to the variables present within the text boxes, meaning that the user can input the starting values for their chosen variables. May conflict with values that are made up by adding other values together???
    {
     
        if (Custom_ON)
        {
            for (int i = 0; i < 10; i++)
            {
                //Debug.Log("anime");


                if (custom_module.filledBoxes[i] != false)
                {
                    switch (custom_module.BoxValue[i])
                    {
                        case 1:
                            avatar.RPE = float.Parse(textBoxes[i].text);
                            break;
                        case 2:
                            avatar.Dyspnoea = int.Parse(textBoxes[i].text);
                            break;
                        case 3:
                            avatar.EE = float.Parse(textBoxes[i].text);
                            break;
                        case 4:
                            avatar.TE = float.Parse(textBoxes[i].text);
                            break;
                        case 5:
                            avatar.TI = float.Parse(textBoxes[i].text);
                            break;
                        case 6:
                            avatar.Ttot = float.Parse(textBoxes[i].text);
                            break;
                        case 7:
                           avatar.VT = float.Parse(textBoxes[i].text);
                            break;
                        case 8:
                            avatar.fr = float.Parse(textBoxes[i].text);
                            break;
                        case 9:
                            avatar.petco2 = float.Parse(textBoxes[i].text);
                            break;
                        case 10:
                            avatar.peto2 = float.Parse(textBoxes[i].text);
                            break;
                        case 11:
                            avatar.VE = float.Parse(textBoxes[i].text);
                            break;
                        case 12:
                           avatar.VO2 = float.Parse(textBoxes[i].text);
                            break;
                        case 13:
                            avatar.VCO2 = float.Parse(textBoxes[i].text);
                            break;
                        case 14:
                           avatar.RER = float.Parse(textBoxes[i].text);
                            break;
                        case 15:
                            avatar.MET = float.Parse(textBoxes[i].text);
                            break;
                        case 16:
                           avatar.VO2fr = float.Parse(textBoxes[i].text);
                            break;
                        case 17:
                            avatar.SpO2 = float.Parse(textBoxes[i].text);
                            break;
                        case 18:
                            avatar.Vecap = float.Parse(textBoxes[i].text);
                            break;
                        case 19:
                            avatar.VeVO2 = float.Parse(textBoxes[i].text);
                            break;
                        case 20:
                            avatar.VeVCO2 = float.Parse(textBoxes[i].text);
                            break;
                        case 21:
                            avatar.FIO2 = float.Parse(textBoxes[i].text);
                            break;
                        case 22:
                            avatar.FICO2 = float.Parse(textBoxes[i].text);
                            break;
                        case 23:
                            avatar.FEO2 = float.Parse(textBoxes[i].text);
                            break;
                        case 24:
                            avatar.FECO2 = float.Parse(textBoxes[i].text);
                            break;
                        case 25:
                            avatar.BPd = float.Parse(textBoxes[i].text);
                            break;
                        case 26:
                            avatar.BPs = float.Parse(textBoxes[i].text);
                            break;
                        case 27:
                            avatar.MAP = float.Parse(textBoxes[i].text);
                            break;
                        case 28:
                            avatar.Bla = float.Parse(textBoxes[i].text);
                            break;
                        case 29:
                            avatar.CO = float.Parse(textBoxes[i].text);
                            break;
                        case 30:
                            avatar.FCmax = float.Parse(textBoxes[i].text);
                            break;
                        case 31:
                           avatar.FCres = float.Parse(textBoxes[i].text);
                            break;
                        case 32:
                            avatar.VO2fc = float.Parse(textBoxes[i].text);
                            break;
                        case 33:
                          avatar.SV = float.Parse(textBoxes[i].text);
                            break;
                        case 34:
                           avatar.FEV1 = float.Parse(textBoxes[i].text);
                            break;
                        case 35:
                           avatar.FVC = float.Parse(textBoxes[i].text);
                            break;
                        case 36:
                            avatar.FEV1FVC = float.Parse(textBoxes[i].text);
                            break;
                        case 37:
                            avatar.PImax = float.Parse(textBoxes[i].text);
                            break;
                        case 38:
                            avatar.PEmax = float.Parse(textBoxes[i].text);
                            break;
                        case 39:
                            avatar.ERV = float.Parse(textBoxes[i].text);
                            break;
                        case 40:
                           avatar.FRC = float.Parse(textBoxes[i].text);
                            break;
                        case 41:
                            avatar.IC = float.Parse(textBoxes[i].text);
                            break;
                        case 42:
                            avatar.IRV = float.Parse(textBoxes[i].text);
                            break;
                        case 43:
                            avatar.PIF = float.Parse(textBoxes[i].text);
                            break;
                        case 44:
                            avatar.PEF = float.Parse(textBoxes[i].text);
                            break;
                        case 45:
                            avatar.RV = float.Parse(textBoxes[i].text);
                            break;
                        case 46:
                            avatar.TLC = float.Parse(textBoxes[i].text);
                            break;
                        case 47:
                            avatar.VC = float.Parse(textBoxes[i].text);
                            break;
                    }
                }
            }
        }
    
        if (MetCart_ON && Advanced_ON)
        {
            for (int i = 0; i < 10; i++)
            {
               
                if (MetCart_module.filledBoxes[i] != false)
                {
                    switch (MetCart_module.BoxValue[i])
                    {
                        case 1:
                            avatar.VE = float.Parse(textBoxes[i].text);
                            break;
                        case 2:
                            avatar.VT = float.Parse(textBoxes[i].text);
                            break;
                        case 3:
                            avatar.VO2 = float.Parse(textBoxes[i].text);
                            break;
                        case 4:
                            avatar.VCO2 = float.Parse(textBoxes[i].text);
                            break;
                        case 5:
                            avatar.fr = float.Parse(textBoxes[i].text);
                            break;
                        case 6:
                            avatar.MET = float.Parse(textBoxes[i].text);
                            break;
                        case 7:
                            avatar.fc = float.Parse(textBoxes[i].text);
                            break;
                        case 8:
                            avatar.RER = float.Parse(textBoxes[i].text);
                            break;
                        case 9:
                            avatar.VeVO2 = float.Parse(textBoxes[i].text);
                            break;
                        case 10:
                            avatar.VeVCO2 = float.Parse(textBoxes[i].text);
                            break;
                        case 11:
                            avatar.petco2 = float.Parse(textBoxes[i].text);
                            break;
                        case 12:
                            avatar.petco2 = float.Parse(textBoxes[i].text);
                            break;
                        case 13:
                            avatar.TE = float.Parse(textBoxes[i].text);
                            break;
                        case 14:
                            avatar.TI = float.Parse(textBoxes[i].text);
                            break;
                        case 15:
                            avatar.TITE = float.Parse(textBoxes[i].text);
                            break;
                        case 16:
                            avatar.Ttot = float.Parse(textBoxes[i].text);
                            break;
                        case 17:
                            avatar.VO2fr = float.Parse(textBoxes[i].text);
                            break;
                        case 18:
                            avatar.VO2fc = float.Parse(textBoxes[i].text);
                            break;
                        case 19:
                            avatar.SpO2 = float.Parse(textBoxes[i].text);
                            break;
                        case 20:
                            avatar.FCmax = float.Parse(textBoxes[i].text);
                            break;
                        case 21:
                            avatar.FCres = float.Parse(textBoxes[i].text);
                            break;
                        case 22:
                            avatar.EE = float.Parse(textBoxes[i].text);
                            break;

                    }
                }
            }
        }
        if (PV_ON && Advanced_ON)
        {
            for (int i = 0; i < 10; i++)
            {
                
                if (Pv_module.filledBoxes[i] != false)
                {
                    switch (Pv_module.BoxValue[i])
                    {
                        case 1:
                            avatar.FVC = float.Parse(textBoxes[i].text);
                            break;
                        case 2:
                            avatar.FEV1 = float.Parse(textBoxes[i].text);
                            break;
                        case 3:
                            avatar.FEV1FVC = float.Parse(textBoxes[i].text);
                            break;
                        case 4:
                            avatar.PEF = float.Parse(textBoxes[i].text);
                            break;
                        case 5:
                            avatar.PIF = float.Parse(textBoxes[i].text);
                            break;
                        case 6:
                            avatar.PImax = float.Parse(textBoxes[i].text);
                            break;
                        case 7:
                            avatar.PEmax = float.Parse(textBoxes[i].text);
                            break;
                        case 8:
                            avatar.Vecap = float.Parse(textBoxes[i].text);
                            break;
                        case 9:
                            avatar.ERV = float.Parse(textBoxes[i].text);
                            break;
                        case 10:
                            avatar.FRC = float.Parse(textBoxes[i].text);
                            break;
                        case 11:
                            avatar.IC = float.Parse(textBoxes[i].text);
                            break;
                        case 12:
                            avatar.IRV = float.Parse(textBoxes[i].text);
                            break;
                        case 13:
                            avatar.RV = float.Parse(textBoxes[i].text);
                            break;
                        case 14:
                            avatar.TLC = float.Parse(textBoxes[i].text);
                            break;
                        case 15:
                            avatar.VC = float.Parse(textBoxes[i].text);
                            break;


                    }
                }
            }
        }
        if (Cardio_ON && Advanced_ON)
        {
            for (int i = 0; i < 10; i++)
            {
                nameBoxText[i] = Cardio_Module.nameBoxes[i];
                if (Cardio_Module.filledBoxes[i] != false)
                {
                    switch (Cardio_Module.BoxValue[i])
                    {
                        case 1:
                            avatar.fc = float.Parse(textBoxes[i].text);
                            break;
                        case 2:
                            avatar.VO2fc = float.Parse(textBoxes[i].text);
                            break;
                        case 3:
                            avatar.MAP = float.Parse(textBoxes[i].text);
                            break;
                        case 4:
                            avatar.FCmax = float.Parse(textBoxes[i].text);
                            break;
                        case 5:
                            avatar.Bla = float.Parse(textBoxes[i].text);
                            break;
                        case 6:
                            avatar.CO = float.Parse(textBoxes[i].text);
                            break;
                        case 7:
                            avatar.BPd = float.Parse(textBoxes[i].text);
                            break;
                        case 8:
                            avatar.BPs = float.Parse(textBoxes[i].text);
                            break;
                        case 9:
                            avatar.SV = float.Parse(textBoxes[i].text);
                            break;
                        case 10:
                            avatar.FCres = float.Parse(textBoxes[i].text);
                            break;
                        case 11:
                            avatar.SpO2 = float.Parse(textBoxes[i].text);
                            break;


                    }
                }
            }
        }
        if (MetCart_ON && Basic_ON)
        {
            avatar.VE = float.Parse(textBoxes[0].text);
            avatar.VT = float.Parse(textBoxes[1].text);
            avatar.VO2 = float.Parse(textBoxes[2].text);
            avatar.VCO2 = float.Parse(textBoxes[3].text);
            avatar.fr = float.Parse(textBoxes[4].text);
            avatar.MET = float.Parse(textBoxes[5].text);
            avatar.fc = float.Parse(textBoxes[6].text);
            avatar.RER = float.Parse(textBoxes[7].text);
        }
        if (PV_ON && Basic_ON)
        {
            avatar.FVC = float.Parse(textBoxes[0].text);
            avatar.FEV1 = float.Parse(textBoxes[1].text);
            avatar.FEV1FVC = float.Parse(textBoxes[2].text);
            avatar.PEF = float.Parse(textBoxes[3].text);
            avatar.PIF = float.Parse(textBoxes[4].text);
            avatar.Vecap = float.Parse(textBoxes[5].text);
        }
        if (Cardio_ON && Basic_ON)
        {

            avatar.fc = float.Parse(textBoxes[0].text);
            avatar.VO2fc = float.Parse(textBoxes[1].text);
            avatar.MAP = float.Parse(textBoxes[2].text);
            avatar.FCmax = float.Parse(textBoxes[3].text);
        }
    }
}
