﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Custom_Module_To_New_Scene : MonoBehaviour
{
    // Start is called before the first frame update
 
    public CharacterAvatar avatar;
    public Text[] textBoxes = new Text[10];
    public Text[] nameBoxes = new Text[10];
    FinalCustomModule custom_module;
    CustomModuleTester MetCart_module;
    pvcustommodule Pv_module;
    cardiocustommodule Cardio_Module;

    //booleans to determine which of the modules is being used.
    public bool Custom_ON;
    public bool MetCart_ON;
    public bool PV_ON;
    public bool Cardio_ON;
    public bool Advanced_ON;
    void Start()
    {
        custom_module = GetComponent<FinalCustomModule>();
        MetCart_module = GetComponent<CustomModuleTester>();
        Pv_module = GetComponent<pvcustommodule>();
        Cardio_Module = GetComponent<cardiocustommodule>();
        avatar = GetComponent<CharacterAvatar>();
        //adding the stuff to hopefully put the right values into the boxes on the new scene
  
    }

    // Update is called once per frame
    void Update()
    {
        if(Custom_ON && Advanced_ON)
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
    }

    void CustomUpdate()
    {
        for (int i = 0; i < 10; i++)
        {
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
    void MetCartUpdate()
    {
        for (int i = 0; i < 10; i++)
        {
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
    void PvUpdate()
    {
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
    void CardioUpdate()
    {
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
    void ResetValues()
    {
        for(int i = 0; i < 10; i++)
        {
            textBoxes[i].text = "";
            nameBoxes[i].text = "";
            Custom_ON = false;
            MetCart_ON = false;
            PV_ON = false;
            Cardio_ON = false;
        }
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
}
