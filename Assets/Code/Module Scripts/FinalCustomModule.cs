using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FinalCustomModule : MonoBehaviour
{
    //this is the true custom module that can take any value the user wants
    //I really enjoy this project!!! :)

    //VARIABLE LIST:

    /*
     RPE
     Dyspnoea
     EE
     TE
     TI
     TToT
     VT
     fr
     PETCO2
     PETO2
     VE
     VO2
     VCO2
     RER
     MET
     VO2/fr
     SpO2
     VECAP
     VE/VO2
     VEVCO2
     FIO2
     FICO2
     FEO2
     FECO2
     BPd
     BPs
     MAP
     Bla -unless Blac is a real thing in which case ???????????????????????????????????????????????
     CO
     Fcmax
     Fcres
     VO2/fc
     Sv
     FEV1
     FVC
     FEV1/FVC
     PImax
     PEmax
     ERV
     FRC
     IC
     IRV
     Vecap - here twice for some reason???
     PIF
     PEF
     RV
     TLC
     VC
     */
    public Text RBox1; //these are the 10 text boxes that the final values are shown in
    public Text RBox2;
    public Text RBox3;
    public Text RBox4;
    public Text RBox5;
    public Text RBox6;
    public Text RBox7;
    public Text RBox8;
    public Text RBox9;
    public Text RBox10;

    public Text[] textBoxes = new Text[10];

    public Toggle RPE_toggle; //1
    public Toggle Dyspnoea_toggle; //2
    public Toggle EE_toggle; //3
    public Toggle TE_toggle; //4
    public Toggle TI_toggle; //5
    public Toggle TToT_toggle; //6
    public Toggle VT_toggle; //7
    public Toggle fr_toggle; //8
    public Toggle PETCO2_toggle; //9
    public Toggle PETO2_toggle; //10
    public Toggle VE_toggle; //11
    public Toggle VO2_toggle; //12
    public Toggle VCO2_toggle; //13
    public Toggle RER_toggle; //14
    public Toggle MET_toggle; //15
    public Toggle VO2fr_toggle; //16
    public Toggle SpO2_toggle; //17
    public Toggle VEcap_toggle; //18
    public Toggle VEVO2_toggle; //19
    public Toggle VEVCO2_toggle; //20
    public Toggle FIO2_toggle; //21
    public Toggle FICO2_toggle; //22
    public Toggle FEO2_toggle; //23
    public Toggle FECO2_toggle; //24
    public Toggle BPd_toggle; //25
    public Toggle BPs_toggle; //26
    public Toggle MAP_toggle; //27
    public Toggle Bla_toggle; //28
    public Toggle CO_toggle; //29
    public Toggle Fcmax_toggle; //30
    public Toggle Fcres_toggle; //31
    public Toggle VO2fc_toggle; //32
    public Toggle Sv_toggle; //33
    public Toggle FEV1_toggle; //34
    public Toggle FVC_toggle; //35
    public Toggle FEV1FVC_toggle; //36
    public Toggle PImax_toggle; //37 
    public Toggle PEmax_toggle; //38
    public Toggle ERV_toggle; //39
    public Toggle FRC_toggle; //40
    public Toggle IC_toggle; //41
    public Toggle IRV_toggle; //42
    //public Toggle VEcap_toggle; //vecap is on her list twice with different letters capitalised so big ?????? from me
    public Toggle PIF_toggle; //43
    public Toggle PEF_toggle; //44
    public Toggle RV_toggle; //45
    public Toggle TLC_toggle; //46
    public Toggle VC_toggle; //47 AHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH IT'S SO LONG AHHHHHHHHHHHHHHHHHHHHHHHH


    public CharacterAvatar avatar; //gets a reference to the character undergoing the module

    public bool[] filledBoxes = new bool[10]; //array that will hold a true or false value for whether there is a value currently entered into the box

    public List<int> BoxValue = new List<int>(); //a list that will contain an int relating to the equation that is active inside that box. 0-21

    public bool RPE_toggled; //used to let the program tell if each of the functions has been toggled into the program
    public bool dyspnoea_toggled;
    public bool EE_toggled;
    public bool TE_toggled;
    public bool TI_toggled;
    public bool TToT_toggled;
    public bool VT_toggled;
    public bool fr_toggled;
    public bool PETCO2_toggled;
    public bool PETO2_toggled;
    public bool VE_toggled;
    public bool VO2_toggled;
    public bool VCO2_toggled;
    public bool RER_toggled;
    public bool MET_toggled;
    public bool VO2fr_toggled;
    public bool SpO2_toggled;
    public bool VEcap_toggled;
    public bool VEVO2_toggled;
    public bool VEVCO2_toggled;
    public bool FIO2_toggled;
    public bool FICO2_toggled;
    public bool FEO2_toggled;
    public bool FECO2_toggled;
    public bool BPd_toggled;
    public bool BPs_toggled;
    public bool MAP_toggled;
    public bool Bla_toggled;
    public bool CO_toggled;
    public bool Fcmax_toggled;
    public bool Fcres_toggled;
    public bool VO2fc_toggled;
    public bool Sv_toggled;
    public bool FEV1_toggled;
    public bool FVC_toggled;
    public bool FEV1FVC_toggled;
    public bool PImax_toggled;
    public bool PEmax_toggled;
    public bool ERV_toggled;
    public bool FRC_toggled;
    public bool IC_toggled;
    public bool IRV_toggled;
    public bool PIF_toggled;
    public bool PEF_toggled;
    public bool RV_toggled;
    public bool TLC_toggled;
    public bool VC_toggled;

    void Start()
    {


        //add listening events to each one of the toggle boxes 
        RPE_toggle.onValueChanged.AddListener((Value) => { Clicked_RPE_Toggle(Value); });
        Dyspnoea_toggle.onValueChanged.AddListener((Value) => { Clicked_Dys_Toggle(Value); });
        EE_toggle.onValueChanged.AddListener((Value) => { Clicked_EE_Toggle(Value); });
        TE_toggle.onValueChanged.AddListener((Value) => { Clicked_TE_Toggle(Value); });
        TI_toggle.onValueChanged.AddListener((Value) => { Clicked_TI_Toggle(Value); });
        TToT_toggle.onValueChanged.AddListener((Value) => { Clicked_TToT_Toggle(Value); });
        VT_toggle.onValueChanged.AddListener((Value) => { Clicked_VT_Toggle(Value); });
        fr_toggle.onValueChanged.AddListener((Value) => { Clicked_fr_Toggle(Value); });
        PETCO2_toggle.onValueChanged.AddListener((Value) => { Clicked_PETCO2_Toggle(Value); });
        PETO2_toggle.onValueChanged.AddListener((Value) => { Clicked_PETO2_Toggle(Value); });
        VE_toggle.onValueChanged.AddListener((Value) => { Clicked_VE_Toggle(Value); });
        VO2_toggle.onValueChanged.AddListener((Value) => { Clicked_VO2_Toggle(Value); });
        VCO2_toggle.onValueChanged.AddListener((Value) => { Clicked_VCO2_Toggle(Value); });
        RER_toggle.onValueChanged.AddListener((Value) => { Clicked_RER_Toggle(Value); });
        MET_toggle.onValueChanged.AddListener((Value) => { Clicked_MET_Toggle(Value); });
        SpO2_toggle.onValueChanged.AddListener((Value) => { Clicked_VO2fr_Toggle(Value); });
        VEcap_toggle.onValueChanged.AddListener((Value) => { Clicked_VEcap_Toggle(Value); });
        VEVO2_toggle.onValueChanged.AddListener((Value) => { Clicked_VEVO2_Toggle(Value); });
        VEVCO2_toggle.onValueChanged.AddListener((Value) => { Clicked_VEVCO2_Toggle(Value); });
        FIO2_toggle.onValueChanged.AddListener((Value) => { Clicked_FIO2_Toggle(Value); });
        FICO2_toggle.onValueChanged.AddListener((Value) => { Clicked_FICO2_Toggle(Value); });
        FEO2_toggle.onValueChanged.AddListener((Value) => { Clicked_FEO2_Toggle(Value); });
        FECO2_toggle.onValueChanged.AddListener((Value) => { Clicked_FECO2_Toggle(Value); });
        BPd_toggle.onValueChanged.AddListener((Value) => { Clicked_BPd_Toggle(Value); });
        BPs_toggle.onValueChanged.AddListener((Value) => { Clicked_BPs_Toggle(Value); });
        MAP_toggle.onValueChanged.AddListener((Value) => { Clicked_MAP_Toggle(Value); });
        Bla_toggle.onValueChanged.AddListener((Value) => { Clicked_Bla_Toggle(Value); });
        CO_toggle.onValueChanged.AddListener((Value) => { Clicked_CO_Toggle(Value); });
        Fcmax_toggle.onValueChanged.AddListener((Value) => { Clicked_FCmax_Toggle(Value); });
        Fcres_toggle.onValueChanged.AddListener((Value) => { Clicked_FCres_Toggle(Value); });
        VO2fc_toggle.onValueChanged.AddListener((Value) => { Clicked_VO2fc_Toggle(Value); });
        Sv_toggle.onValueChanged.AddListener((Value) => { Clicked_Sv_Toggle(Value); });
        FEV1_toggle.onValueChanged.AddListener((Value) => { Clicked_FEV1_Toggle(Value); });
        FVC_toggle.onValueChanged.AddListener((Value) => { Clicked_FVC_Toggle(Value); });
        FEV1FVC_toggle.onValueChanged.AddListener((Value) => { Clicked_FEV1FVC_Toggle(Value); });
        PImax_toggle.onValueChanged.AddListener((Value) => { Clicked_PImax_Toggle(Value); });
        PEmax_toggle.onValueChanged.AddListener((Value) => { Clicked_PEmax_Toggle(Value); });
        ERV_toggle.onValueChanged.AddListener((Value) => { Clicked_ERV_Toggle(Value); });
        FRC_toggle.onValueChanged.AddListener((Value) => { Clicked_FRC_Toggle(Value); });
        IC_toggle.onValueChanged.AddListener((Value) => { Clicked_IC_Toggle(Value); });
        IRV_toggle.onValueChanged.AddListener((Value) => { Clicked_IRV_Toggle(Value); });
        PIF_toggle.onValueChanged.AddListener((Value) => { Clicked_PIF_Toggle(Value); });
        PEF_toggle.onValueChanged.AddListener((Value) => { Clicked_PEF_Toggle(Value); });
        RV_toggle.onValueChanged.AddListener((Value) => { Clicked_RV_Toggle(Value); });
        TLC_toggle.onValueChanged.AddListener((Value) => { Clicked_TLC_Toggle(Value); });
        VC_toggle.onValueChanged.AddListener((Value) => { Clicked_VC_Toggle(Value); });
    }

    void Update()
    {
        //Debug.Log(BoxValue[0]);
        //for (int i = 0; i < 10; i++)
        //{
        //    if (filledBoxes[i] != false)
        //    {
        //        switch (BoxValue[i])
        //        {
        //            case 1:
        //                textBoxes[i].text = avatar.RPE.ToString();
        //                break;
        //            case 2:
        //                textBoxes[i].text = avatar.Dyspnoea.ToString();
        //                break;
        //            case 3:
        //                textBoxes[i].text = avatar.EE.ToString();
        //                break;
        //            case 4:
        //                textBoxes[i].text = avatar.TE.ToString();
        //                break;
        //            case 5:
        //                textBoxes[i].text = avatar.TI.ToString();
        //                break;
        //            case 6:
        //                textBoxes[i].text = avatar.Ttot.ToString();
        //                break;
        //            case 7:
        //                textBoxes[i].text = avatar.VT.ToString();
        //                break;
        //            case 8:
        //                textBoxes[i].text = avatar.fr.ToString();
        //                break;
        //            case 9:
        //                textBoxes[i].text = avatar.petco2.ToString();
        //                break;
        //            case 10:
        //                textBoxes[i].text = avatar.peto2.ToString();
        //                break;
        //            case 11:
        //                textBoxes[i].text = avatar.VE.ToString();
        //                break;
        //            case 12:
        //                textBoxes[i].text = avatar.VO2.ToString();
        //                break;
        //            case 13:
        //                textBoxes[i].text = avatar.VCO2.ToString();
        //                break;
        //            case 14:
        //                textBoxes[i].text = avatar.RER.ToString();
        //                break;
        //            case 15:
        //                textBoxes[i].text = avatar.MET.ToString();
        //                break;
        //            case 16:
        //                textBoxes[i].text = avatar.VO2fr.ToString();
        //                break;
        //            case 17:
        //                textBoxes[i].text = avatar.SpO2.ToString();
        //                break;
        //            case 18:
        //                textBoxes[i].text = avatar.Vecap.ToString();
        //                break;
        //            case 19:
        //                textBoxes[i].text = avatar.VeVO2.ToString();
        //                break;
        //            case 20:
        //                textBoxes[i].text = avatar.VeVCO2.ToString();
        //                break;
        //            case 21:
        //                textBoxes[i].text = avatar.FIO2.ToString();
        //                break;
        //            case 22:
        //                textBoxes[i].text = avatar.FICO2.ToString();
        //                break;
        //            case 23:
        //                textBoxes[i].text = avatar.FEO2.ToString();
        //                break;
        //            case 24:
        //                textBoxes[i].text = avatar.FECO2.ToString();
        //                break;
        //            case 25:
        //                textBoxes[i].text = avatar.BPd.ToString();
        //                break;
        //            case 26:
        //                textBoxes[i].text = avatar.BPs.ToString();
        //                break;
        //            case 27:
        //                textBoxes[i].text = avatar.MAP.ToString();
        //                break;
        //            case 28:
        //                textBoxes[i].text = avatar.Bla.ToString();
        //                break;
        //            case 29:
        //                textBoxes[i].text = avatar.CO.ToString();
        //                break;
        //            case 30:
        //                textBoxes[i].text = avatar.FCmax.ToString();
        //                break;
        //            case 31:
        //                textBoxes[i].text = avatar.FCres.ToString();
        //                break;
        //            case 32:
        //                textBoxes[i].text = avatar.VO2fc.ToString();
        //                break;
        //            case 33:
        //                textBoxes[i].text = avatar.SV.ToString();
        //                break;
        //            case 34:
        //                textBoxes[i].text = avatar.FEV1.ToString();
        //                break;
        //            case 35:
        //                textBoxes[i].text = avatar.FVC.ToString();
        //                break;
        //            case 36:
        //                textBoxes[i].text = avatar.FEV1FVC.ToString();
        //                break;
        //            case 37:
        //                textBoxes[i].text = avatar.PImax.ToString();
        //                break;
        //            case 38:
        //                textBoxes[i].text = avatar.PEmax.ToString();
        //                break;
        //            case 39:
        //                textBoxes[i].text = avatar.ERV.ToString();
        //                break;
        //            case 40:
        //                textBoxes[i].text = avatar.FRC.ToString();
        //                break;
        //            case 41:
        //                textBoxes[i].text = avatar.IC.ToString();
        //                break;
        //            case 42:
        //                textBoxes[i].text = avatar.IRV.ToString();
        //                break;
        //            case 43:
        //                textBoxes[i].text = avatar.PIF.ToString();
        //                break;
        //            case 44:
        //                textBoxes[i].text = avatar.PEF.ToString();
        //                break;
        //            case 45:
        //                textBoxes[i].text = avatar.RV.ToString();
        //                break;
        //            case 46:
        //                textBoxes[i].text = avatar.TLC.ToString();
        //                break;
        //            case 47:
        //                textBoxes[i].text = avatar.VC.ToString();
        //                break;
        //        }
        //    }
        //}
    }

    public void ManualUpdate()
    {
        for (int i = 0; i < 10; i++)
        {
            if (filledBoxes[i] != false)
            {
                switch (BoxValue[i])
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
    private void Clicked_RPE_Toggle(bool Value)
    {
        if (RPE_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (RPE_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 1;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.RPE.ToString();
                        filledBoxes[i] = true;
                        RPE_toggled = true;
                        RPE_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & RPE_toggled == false)
                {
                    RPE_toggle.isOn = false;
                }
            }


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 1)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    RPE_toggled = false;
                }
            }


        }

    }
    private void Clicked_Dys_Toggle(bool Value)
    {
        if (Dyspnoea_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if(filledBoxes[i] == false)
                {
                    if (dyspnoea_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 2;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.Dyspnoea.ToString();
                        filledBoxes[i] = true;
                        dyspnoea_toggled = true;
                        Dyspnoea_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & dyspnoea_toggled == false)
                {
                    Dyspnoea_toggle.isOn = false;
                }
            }


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 2)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    dyspnoea_toggled = false;
                }
            }


        }

    }
    private void Clicked_EE_Toggle(bool Value)
    {
        if (EE_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (EE_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 3;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.EE.ToString();
                        filledBoxes[i] = true;
                        EE_toggled = true;
                        EE_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & EE_toggled == false)
                {
                    EE_toggle.isOn = false;
                }
            }


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 3)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    EE_toggled = false;
                }
            }


        }

    }
    private void Clicked_TE_Toggle(bool Value)
    {
        if (TE_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (TE_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 4;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.TE.ToString();
                        filledBoxes[i] = true;
                        TE_toggled = true;
                        TE_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & TE_toggled == false)
                {
                    TE_toggle.isOn = false;
                }
            }


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 4)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    TE_toggled = false;
                }
            }


        }

    }
    private void Clicked_TI_Toggle(bool Value)
    {
        if (TI_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (TI_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 5;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.TI.ToString();
                        filledBoxes[i] = true;
                        TI_toggled = true;
                        TI_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & TI_toggled == false)
                {
                    TI_toggle.isOn = false;
                }
            }


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 5)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    TI_toggled = false;
                }
            }


        }

    }
    private void Clicked_TToT_Toggle(bool Value)
    {
        if (TToT_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (TToT_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 6;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.Ttot.ToString();
                        filledBoxes[i] = true;
                        TToT_toggled = true;
                        TToT_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & TToT_toggled == false)
                {
                    TToT_toggle.isOn = false;
                }
            }


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 6)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    TToT_toggled = false;
                }
            }


        }

    }
    private void Clicked_VT_Toggle(bool Value)
    {
        if (VT_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (VT_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 7;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.VT.ToString();
                        filledBoxes[i] = true;
                        VT_toggled = true;
                        VT_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & VT_toggled == false)
                {
                    VT_toggle.isOn = false;
                }
            }


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 7)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    VT_toggled = false;
                }
            }


        }

    }
    private void Clicked_fr_Toggle(bool Value)
    {
        if (fr_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (fr_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 8;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.fr.ToString();
                        filledBoxes[i] = true;
                        fr_toggled = true;
                        fr_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & fr_toggled == false)
                {
                    fr_toggle.isOn = false;
                }
            }


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 8)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    fr_toggled = false;
                }
            }


        }

    }
    private void Clicked_PETCO2_Toggle(bool Value)
    {
        if (PETCO2_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (PETCO2_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 9;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.petco2.ToString();
                        filledBoxes[i] = true;
                        PETCO2_toggled = true;
                        PETCO2_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & PETCO2_toggled == false)
                {
                    PETCO2_toggle.isOn = false;
                }
            }


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 9)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    PETCO2_toggled = false;
                }
            }


        }

    }
    private void Clicked_PETO2_Toggle(bool Value)
    {
        if (PETO2_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (PETO2_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 10;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.peto2.ToString();
                        filledBoxes[i] = true;
                        PETO2_toggled = true;
                        PETO2_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & PETO2_toggled == false)
                {
                    PETO2_toggle.isOn = false;
                }
            }


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 10)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    PETO2_toggled = false;
                }
            }


        }

    }
    private void Clicked_VE_Toggle(bool Value)
    {
        if (VE_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (VE_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 11;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.VE.ToString();
                        filledBoxes[i] = true;
                        VE_toggled = true;
                        VE_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & VE_toggled == false)
                {
                    VE_toggle.isOn = false;
                }
            }


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 11)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    VE_toggled = false;
                }
            }


        }

    }
    private void Clicked_VO2_Toggle(bool Value)
    {
        if (VO2_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (VO2_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 12;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.VO2.ToString();
                        filledBoxes[i] = true;
                        VO2_toggled = true;
                        VO2_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & VO2_toggled == false)
                {
                    VO2_toggle.isOn = false;
                }
            }


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 12)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    VO2_toggled = false;
                }
            }


        }

    }
    private void Clicked_VCO2_Toggle(bool Value)
    {
        if (VCO2_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (VCO2_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 13;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.VCO2.ToString();
                        filledBoxes[i] = true;
                        VCO2_toggled = true;
                        VCO2_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & VCO2_toggled == false)
                {
                   VCO2_toggle.isOn = false;
                }

            }
           


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 13)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    VCO2_toggled = false;
                }
            }


        }

    }
    private void Clicked_RER_Toggle(bool Value)
    {
        if (RER_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (RER_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 14;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.RER.ToString();
                        filledBoxes[i] = true;
                        RER_toggled = true;
                        RER_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & RER_toggled == false)
                {
                    RER_toggle.isOn = false;
                }
            }


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 14)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    RER_toggled = false;
                }
            }


        }

    }
    private void Clicked_MET_Toggle(bool Value)
    {
        if (MET_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (MET_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 15;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.MET.ToString();
                        filledBoxes[i] = true;
                        MET_toggled = true;
                        MET_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & MET_toggled == false)
                {
                    MET_toggle.isOn = false;
                }
            }


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 15)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    MET_toggled = false;
                }
            }


        }

    }
    private void Clicked_VO2fr_Toggle(bool Value)
    {
        if (VO2fr_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (VO2fr_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 16;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.VO2fr.ToString();
                        filledBoxes[i] = true;
                        VO2fr_toggled = true;
                        VO2fr_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & VO2fr_toggled == false)
                {
                    VO2fr_toggle.isOn = false;
                }
            }


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 16)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    VO2fr_toggled = false;
                }
            }


        }

    }
    private void Clicked_SpO2_Toggle(bool Value)
    {
        if (SpO2_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (SpO2_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 17;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.SpO2.ToString();
                        filledBoxes[i] = true;
                        SpO2_toggled = true;
                        SpO2_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & SpO2_toggled == false)
                {
                    SpO2_toggle.isOn = false;
                }
            }


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 17)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    SpO2_toggled = false;
                }
            }


        }

    }
    private void Clicked_VEcap_Toggle(bool Value)
    {
        if (VEcap_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (VEcap_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 18;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.Vecap.ToString();
                        filledBoxes[i] = true;
                        VEcap_toggled = true;
                        VEcap_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & VEcap_toggled == false)
                {
                    VEcap_toggle.isOn = false;
                }
            }


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 18)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    VEcap_toggled = false;
                }
            }


        }

    }
    private void Clicked_VEVO2_Toggle(bool Value)
    {
        if (VEVO2_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (VEVO2_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 19;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.VeVO2.ToString();
                        filledBoxes[i] = true;
                        VEVO2_toggled = true;
                        VEVO2_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & VEVO2_toggled == false)
                {
                    VEVO2_toggle.isOn = false;
                }
            }


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 19)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    VEVO2_toggled = false;
                }
            }


        }

    }
    private void Clicked_VEVCO2_Toggle(bool Value)
    {
        if (VEVCO2_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (VEVCO2_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 20;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.VeVCO2.ToString();
                        filledBoxes[i] = true;
                        VEVCO2_toggled = true;
                        VEVCO2_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & VEVCO2_toggled == false)
                {
                    VEVCO2_toggle.isOn = false;
                }
            }


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 20)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    VEVCO2_toggled = false;
                }
            }


        }

    }
    private void Clicked_FIO2_Toggle(bool Value)
    {
        if (FIO2_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (FIO2_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 21;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.FIO2.ToString();
                        filledBoxes[i] = true;
                        FIO2_toggled = true;
                        FIO2_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & FIO2_toggled == false)
                {
                    FIO2_toggle.isOn = false;
                }
            }


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 21)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    FIO2_toggled = false;
                }
            }


        }

    }
    private void Clicked_FICO2_Toggle(bool Value)
    {
        if (FICO2_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (FICO2_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 22;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.FICO2.ToString();
                        filledBoxes[i] = true;
                        FICO2_toggled = true;
                        FICO2_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & FICO2_toggled == false)
                {
                    FICO2_toggle.isOn = false;
                }
            }


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 22)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    FICO2_toggled = false;
                }
            }


        }

    }
    private void Clicked_FEO2_Toggle(bool Value)
    {
        if (FEO2_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (FEO2_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 23;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.FEO2.ToString();
                        filledBoxes[i] = true;
                        FEO2_toggled = true;
                        FEO2_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & FEO2_toggled == false)
                {
                    FEO2_toggle.isOn = false;
                }
            }


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 23)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    FEO2_toggled = false;
                }
            }


        }

    }
    private void Clicked_FECO2_Toggle(bool Value)
    {
        if (FECO2_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (FECO2_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 24;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.FECO2.ToString();
                        filledBoxes[i] = true;
                        FECO2_toggled = true;
                        FECO2_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & FECO2_toggled == false)
                {
                    FECO2_toggle.isOn = false;
                }
            }


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 24)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    FECO2_toggled = false;
                }
            }


        }

    }
    private void Clicked_BPd_Toggle(bool Value)
    {
        if (BPd_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (BPd_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 25;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.BPd.ToString();
                        filledBoxes[i] = true;
                        BPd_toggled = true;
                        BPd_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & BPd_toggled == false)
                {
                    BPd_toggle.isOn = false;
                }
            }


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 25)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    BPd_toggled = false;
                }
            }


        }

    }
    private void Clicked_BPs_Toggle(bool Value)
    {
        if (BPs_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (BPs_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 26;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.BPs.ToString();
                        filledBoxes[i] = true;
                        BPs_toggled = true;
                        BPs_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & BPs_toggled == false)
                {
                    BPs_toggle.isOn = false;
                }
            }


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 26)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    BPs_toggled = false;
                }
            }


        }

    }
    private void Clicked_MAP_Toggle(bool Value)
    {
        if (MAP_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (MAP_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 27;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.MAP.ToString();
                        filledBoxes[i] = true;
                        MAP_toggled = true;
                        MAP_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & MAP_toggled == false)
                {
                    MAP_toggle.isOn = false;
                }
            }


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 27)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    MAP_toggled = false;
                }
            }


        }

    }
    private void Clicked_Bla_Toggle(bool Value)
    {
        if (Bla_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (Bla_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 28;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.Bla.ToString();
                        filledBoxes[i] = true;
                        Bla_toggled = true;
                        Bla_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & Bla_toggled == false)
                {
                    Bla_toggle.isOn = false;
                }
            }


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 28)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    Bla_toggled = false;
                }
            }


        }

    }
    private void Clicked_CO_Toggle(bool Value)
    {
        if (CO_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (CO_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 29;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.CO.ToString();
                        filledBoxes[i] = true;
                        CO_toggled = true;
                        CO_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & CO_toggled == false)
                {
                    CO_toggle.isOn = false;
                }
            }


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 29)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    CO_toggled = false;
                }
            }


        }

    }
    private void Clicked_FCmax_Toggle(bool Value)
    {
        if (Fcmax_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (Fcmax_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 30;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.FCmax.ToString();
                        filledBoxes[i] = true;
                        Fcmax_toggled = true;
                        Fcmax_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & Fcmax_toggled == false)
                {
                    Fcmax_toggle.isOn = false;
                }
            }


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 30)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    Fcmax_toggled = false;
                }
            }


        }

    }
    private void Clicked_FCres_Toggle(bool Value)
    {
        if (Fcres_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (Fcres_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 31;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.FCres.ToString();
                        filledBoxes[i] = true;
                        Fcres_toggled = true;
                        Fcres_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & Fcres_toggled == false)
                {
                    Fcres_toggle.isOn = false;
                }
            }


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 31)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    Fcres_toggled = false;
                }
            }


        }

    }

    private void Clicked_VO2fc_Toggle(bool Value)
    {
        if (VO2fc_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (VO2fc_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 32;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.VO2fc.ToString();
                        filledBoxes[i] = true;
                        VO2fc_toggled = true;
                        VO2fc_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & VO2fc_toggled == false)
                {
                    VO2fc_toggle.isOn = false;
                }
            }


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 32)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    VO2fc_toggled = false;
                }
            }


        }

    }
    private void Clicked_Sv_Toggle(bool Value)
    {
        if (Sv_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (Sv_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 33;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.SV.ToString();
                        filledBoxes[i] = true;
                        Sv_toggled = true;
                        Sv_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & Sv_toggled == false)
                {
                    Sv_toggle.isOn = false;
                }
            }


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 33)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    Sv_toggled = false;
                }
            }


        }

    }
    private void Clicked_FEV1_Toggle(bool Value)
    {
        if (FEV1_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (FEV1_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 34;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.FEV1.ToString();
                        filledBoxes[i] = true;
                        FEV1_toggled = true;
                        FEV1_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & FEV1_toggled == false)
                {
                    FEV1_toggle.isOn = false;
                }
            }


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 34)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    FEV1_toggled = false;
                }
            }


        }

    }
    private void Clicked_FVC_Toggle(bool Value)
    {
        if (FVC_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (FVC_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 35;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.FVC.ToString();
                        filledBoxes[i] = true;
                        FVC_toggled = true;
                        FVC_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & FVC_toggled == false)
                {
                    FVC_toggle.isOn = false;
                }
            }


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 35)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    FVC_toggled = false;
                }
            }


        }

    }
    private void Clicked_FEV1FVC_Toggle(bool Value)
    {
        if (FEV1FVC_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (FEV1FVC_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 36;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.FEV1FVC.ToString();
                        filledBoxes[i] = true;
                        FEV1FVC_toggled = true;
                        FEV1FVC_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & FEV1FVC_toggled == false)
                {
                    FEV1FVC_toggle.isOn = false;
                }
            }


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 36)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    FEV1FVC_toggled = false;
                }
            }


        }

    }
    private void Clicked_PImax_Toggle(bool Value)
    {
        if (PImax_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (PImax_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 37;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.PImax.ToString();
                        filledBoxes[i] = true;
                        PImax_toggled = true;
                        PImax_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & PImax_toggled == false)
                {
                    PImax_toggle.isOn = false;
                }
            }


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 37)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    PImax_toggled = false;
                }
            }


        }

    }
    private void Clicked_PEmax_Toggle(bool Value)
    {
        if (PEmax_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (PEmax_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 38;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.PEmax.ToString();
                        filledBoxes[i] = true;
                        PEmax_toggled = true;
                        PEmax_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & PEmax_toggled == false)
                {
                    PEmax_toggle.isOn = false;
                }
            }


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 38)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    PEmax_toggled = false;
                }
            }


        }

    }
    private void Clicked_ERV_Toggle(bool Value)
    {
        if (ERV_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (ERV_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 39;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.ERV.ToString();
                        filledBoxes[i] = true;
                        ERV_toggled = true;
                        ERV_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & ERV_toggled == false)
                {
                    ERV_toggle.isOn = false;
                }
            }


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 39)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    ERV_toggled = false;
                }
            }


        }

    }
    private void Clicked_FRC_Toggle(bool Value)
    {
        if (FRC_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (FRC_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 40;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.FRC.ToString();
                        filledBoxes[i] = true;
                        FRC_toggled = true;
                        FRC_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & FRC_toggled == false)
                {
                    FRC_toggle.isOn = false;
                }
            }


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 40)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    FRC_toggled = false;
                }
            }


        }

    }
    private void Clicked_IC_Toggle(bool Value)
    {
        if (IC_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (IC_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 41;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.IC.ToString();
                        filledBoxes[i] = true;
                        IC_toggled = true;
                        IC_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & IC_toggled == false)
                {
                    IC_toggle.isOn = false;
                }
            }


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 41)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    IC_toggled = false;
                }
            }


        }

    }
    private void Clicked_IRV_Toggle(bool Value)
    {
        if (IRV_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (IRV_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 42;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.IRV.ToString();
                        filledBoxes[i] = true;
                        IRV_toggled = true;
                        IRV_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & IRV_toggled == false)
                {
                    IRV_toggle.isOn = false;
                }
            }


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 42)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    IRV_toggled = false;
                }
            }


        }

    }
    private void Clicked_PIF_Toggle(bool Value)
    {
        if (PIF_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (PIF_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 43;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.PIF.ToString();
                        filledBoxes[i] = true;
                        PIF_toggled = true;
                        PIF_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & PIF_toggled == false)
                {
                    PIF_toggle.isOn = false;
                }
            }


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 43)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    PIF_toggled = false;
                }
            }


        }

    }
    private void Clicked_PEF_Toggle(bool Value)
    {
        if (PEF_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (PEF_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 44;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.PEF.ToString();
                        filledBoxes[i] = true;
                        PEF_toggled = true;
                        PEF_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & PEF_toggled == false)
                {
                    PEF_toggle.isOn = false;
                }
            }


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 44)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    PEF_toggled = false;
                }
            }


        }

    }
    private void Clicked_RV_Toggle(bool Value)
    {
        if (RV_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (RV_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 45;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.RV.ToString();
                        filledBoxes[i] = true;
                        RV_toggled = true;
                        RV_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & RV_toggled == false)
                {
                    RV_toggle.isOn = false;
                }
            }


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 45)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    RV_toggled = false;
                }
            }


        }

    }
    private void Clicked_TLC_Toggle(bool Value)
    {
        if (TLC_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (TLC_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 46;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.TLC.ToString();
                        filledBoxes[i] = true;
                        TLC_toggled = true;
                        TLC_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & TLC_toggled == false)
                {
                    TLC_toggle.isOn = false;
                }
            }


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 46)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    TLC_toggled = false;
                }
            }


        }

    }
    private void Clicked_VC_Toggle(bool Value)
    {
        if (VC_toggle.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (PEF_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 47;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.VC.ToString();
                        filledBoxes[i] = true;
                        VC_toggled = true;
                        VC_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & VC_toggled == false)
                {
                    VC_toggle.isOn = false;
                }
            }


        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (BoxValue[i] == 47)
                {
                    filledBoxes[i] = false;
                    textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    VC_toggled = false;
                }
            }


        }

    }
}
