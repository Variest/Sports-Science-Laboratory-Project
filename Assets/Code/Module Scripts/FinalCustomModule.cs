using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FinalCustomModule : MonoBehaviour
{



    public string[] textBoxContent = new string[10];
    public Text[] textBoxes = new Text[10];
    public string[] nameBoxes = new string[10];



   
    public Button RPE_button; //1
    public Button Dyspnoea_button; //2
    public Button EE_button; //3
    public Button TE_button; //4
    public Button TI_button; //5
    public Button TToT_button; //6
    public Button VT_button; //7
    public Button fr_button; //8
    public Button PETCO2_button; //9
    public Button PETO2_button; //10
    public Button VE_button; //11
    public Button VO2_button; //12
    public Button VCO2_button; //13
    public Button RER_button; //14
    public Button MET_button; //15
    public Button VO2fr_button; //16
    public Button SpO2_button; //17
    public Button VEcap_button; //18
    public Button VEVO2_button; //19
    public Button VEVCO2_button; //20
    public Button FIO2_button; //21
    public Button FICO2_button; //22
    public Button FEO2_button; //23
    public Button FECO2_button; //24
    public Button BPd_button; //25
    public Button BPs_button; //26
    public Button MAP_button; //27
    public Button Bla_button; //28
    public Button CO_button; //29
    public Button Fcmax_button; //30
    public Button Fcres_button; //31
    public Button VO2fc_button; //32
    public Button Sv_button; //33
    public Button FEV1_button; //34
    public Button FVC_button; //35
    public Button FEV1FVC_button; //36
    public Button PImax_button; //37 
    public Button PEmax_button; //38
    public Button ERV_button; //39
    public Button FRC_button; //40
    public Button IC_button; //41
    public Button IRV_button; //42
    public Button PIF_button; //43
    public Button PEF_button; //44
    public Button RV_button; //45
    public Button TLC_button; //46
    public Button VC_button; //47 


    public CharacterAvatar avatar; //gets a reference to the character undergoing the module

    public bool[] filledBoxes = new bool[10]; //array that will hold a true or false value for whether there is a value currently entered into the box

    public List<int> BoxValue = new List<int>(); //a list that will contain an int relating to the equation that is active inside that box. 0-47

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

        avatar = GetComponent<CharacterAvatar>();
        //add listening events to each one of the toggle boxes 

        for (int i = 0; i < 10; i++)
        {
            BoxValue.Add(0);
        }
    }

    public void AttachButtons()
    {
        RPE_button.onClick.AddListener(Clicked_RPE_Toggle);
        Dyspnoea_button.onClick.AddListener(Clicked_Dys_Toggle);
        EE_button.onClick.AddListener(Clicked_EE_Toggle);
        TE_button.onClick.AddListener(Clicked_TE_Toggle);
        TI_button.onClick.AddListener(Clicked_TI_Toggle);
        TToT_button.onClick.AddListener(Clicked_TToT_Toggle);
        VT_button.onClick.AddListener(Clicked_VT_Toggle);
        fr_button.onClick.AddListener(Clicked_fr_Toggle);
        PETCO2_button.onClick.AddListener(Clicked_PETCO2_Toggle);
        PETO2_button.onClick.AddListener(Clicked_PETO2_Toggle);
        VE_button.onClick.AddListener(Clicked_VE_Toggle);
        VO2_button.onClick.AddListener(Clicked_VO2_Toggle);
        VCO2_button.onClick.AddListener(Clicked_VCO2_Toggle);
        RER_button.onClick.AddListener(Clicked_RER_Toggle);
        MET_button.onClick.AddListener(Clicked_MET_Toggle);
        SpO2_button.onClick.AddListener(Clicked_SpO2_Toggle);
        VO2fr_button.onClick.AddListener(Clicked_VO2fr_Toggle);
        VEcap_button.onClick.AddListener(Clicked_VEcap_Toggle);
        VEVO2_button.onClick.AddListener(Clicked_VEVO2_Toggle);
        VEVCO2_button.onClick.AddListener(Clicked_VEVCO2_Toggle);
        FIO2_button.onClick.AddListener(Clicked_FIO2_Toggle);
        FICO2_button.onClick.AddListener(Clicked_FICO2_Toggle);
        FEO2_button.onClick.AddListener(Clicked_FEO2_Toggle);
        FECO2_button.onClick.AddListener(Clicked_FECO2_Toggle);
        BPd_button.onClick.AddListener(Clicked_BPd_Toggle);
        BPs_button.onClick.AddListener(Clicked_BPs_Toggle);
        MAP_button.onClick.AddListener(Clicked_MAP_Toggle);
        Bla_button.onClick.AddListener(Clicked_Bla_Toggle);
        CO_button.onClick.AddListener(Clicked_CO_Toggle);
        Fcmax_button.onClick.AddListener(Clicked_FCmax_Toggle);
        Fcres_button.onClick.AddListener(Clicked_FCres_Toggle);
        VO2fc_button.onClick.AddListener(Clicked_VO2fc_Toggle);
        Sv_button.onClick.AddListener(Clicked_Sv_Toggle);
        FEV1_button.onClick.AddListener(Clicked_FEV1_Toggle);
        FVC_button.onClick.AddListener(Clicked_FVC_Toggle);
        FEV1FVC_button.onClick.AddListener(Clicked_FEV1FVC_Toggle);
        PImax_button.onClick.AddListener(Clicked_PImax_Toggle);
        PEmax_button.onClick.AddListener(Clicked_PEmax_Toggle);
        ERV_button.onClick.AddListener(Clicked_ERV_Toggle);
        FRC_button.onClick.AddListener(Clicked_FRC_Toggle);
        IC_button.onClick.AddListener(Clicked_IC_Toggle);
        IRV_button.onClick.AddListener(Clicked_IRV_Toggle);
        PIF_button.onClick.AddListener(Clicked_PIF_Toggle);
        PEF_button.onClick.AddListener(Clicked_PEF_Toggle);
        RV_button.onClick.AddListener(Clicked_RV_Toggle);
        TLC_button.onClick.AddListener(Clicked_TLC_Toggle);
        VC_button.onClick.AddListener(Clicked_VC_Toggle);
    }
    void Update()
    {

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
    private void Clicked_RPE_Toggle()
    {
        if (!RPE_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if(!RPE_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 1;
                        textBoxContent[i] = avatar.RPE.ToString();
                        //textBoxes[i].text = avatar.RPE.ToString();
                        nameBoxes[i] = "RPE ";
                        filledBoxes[i] = true;
                        RPE_toggled = true;
                        RPE_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                    }




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
                    textBoxContent[i] = "";
                    ////textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    RPE_toggled = false;
                    RPE_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }

    }
    private void Clicked_Dys_Toggle()
    {
        
        if (!dyspnoea_toggled) 
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!dyspnoea_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 2;
                        textBoxContent[i] = avatar.Dyspnoea.ToString();
                        //textBoxes[i].text = avatar.Dyspnoea.ToString();
                        nameBoxes[i] = "Dyspnoea ";
                        filledBoxes[i] = true;
                        dyspnoea_toggled = true;
                        Dyspnoea_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                    }
               


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
                    textBoxContent[i] = "";
                    //textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    nameBoxes[i] = "";
                    dyspnoea_toggled = false;
                    Dyspnoea_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }

    }
    private void Clicked_EE_Toggle()
    {
        
        if (!EE_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!EE_toggled)
                    {
                        BoxValue[i] = 3;
                        textBoxContent[i] = avatar.EE.ToString();
                        //textBoxes[i].text = avatar.EE.ToString();
                        nameBoxes[i] = "EE ";
                        filledBoxes[i] = true;
                        EE_toggled = true;
                        EE_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                    }

             

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
                    //textBoxes[i].text = "";
                    textBoxContent[i] = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    EE_toggled = false;
                    EE_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }

    }
    private void Clicked_TE_Toggle()
    {
        
        if (!TE_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!TE_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 4;
                        textBoxContent[i] = avatar.TE.ToString();
                        //textBoxes[i].text = avatar.TE.ToString();
                        nameBoxes[i] = "TE ";
                        filledBoxes[i] = true;
                        TE_toggled = true;
                        TE_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                    }



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
                    textBoxContent[i] = "";
                    //textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    TE_toggled = false;
                    TE_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }

    }
    private void Clicked_TI_Toggle()
    {
        
        if (!TI_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!TI_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 5;
                        textBoxContent[i] = avatar.TI.ToString();
                        //textBoxes[i].text = avatar.TI.ToString();
                        nameBoxes[i] = "TI ";
                        filledBoxes[i] = true;
                        TI_toggled = true;
                        TI_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                    }



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
                    textBoxContent[i] = "";
                    //textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    TI_toggled = false;
                    TI_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }

    }
    private void Clicked_TToT_Toggle()
    {
        
        if (!TToT_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!TToT_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 6;
                        textBoxContent[i] = avatar.Ttot.ToString();
                        //textBoxes[i].text = avatar.Ttot.ToString();
                        nameBoxes[i] = "TToT ";
                        filledBoxes[i] = true;
                        TToT_toggled = true;
                        TToT_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;

                    }



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
                    textBoxContent[i] = "";
                    //textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    TToT_toggled = false;
                    TToT_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }

    }
    private void Clicked_VT_Toggle()
    {
        
        if (!VT_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!VT_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 7;
                        textBoxContent[i] = avatar.VT.ToString();
                        //textBoxes[i].text = avatar.VT.ToString();
                        nameBoxes[i] = "VT ";
                        filledBoxes[i] = true;
                        VT_toggled = true;
                        VT_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                    }



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
                    nameBoxes[i] = "";
                    textBoxContent[i] = "";
                    //textBoxes[i].text = "";
                    BoxValue[i] = 0;
                    VT_toggled = false;
                    VT_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }
    }
    private void Clicked_fr_Toggle()
    {
        
        if (!fr_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!fr_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 8;
                        textBoxContent[i] = avatar.fr.ToString();
                        //textBoxes[i].text = avatar.fr.ToString();
                        nameBoxes[i] = "fr ";
                        filledBoxes[i] = true;
                        fr_toggled = true;
                        fr_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                    }



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
                    //textBoxes[i].text = "";
                    textBoxContent[i] = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    fr_toggled = false;
                    fr_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }

    }
    private void Clicked_PETCO2_Toggle()
    {
       
        if (!PETCO2_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!PETCO2_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 9;
                        textBoxContent[i] = avatar.petco2.ToString();
                       // textBoxes[i].text = avatar.petco2.ToString();
                        nameBoxes[i] = "petco2 ";
                        filledBoxes[i] = true;
                        PETCO2_toggled = true;
                        PETCO2_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                    }



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
                    textBoxContent[i] = "";
                    //textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    PETCO2_toggled = false;
                    PETCO2_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }
    }
    private void Clicked_PETO2_Toggle()
    {
        
        if (!PETO2_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!PETO2_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 10;
                        textBoxContent[i] = avatar.peto2.ToString();
                        //textBoxes[i].text = avatar.peto2.ToString();
                        nameBoxes[i] = "peto2 ";
                        filledBoxes[i] = true;
                        PETO2_toggled = true;
                        PETO2_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                    }



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
                    textBoxContent[i] = "";
                    //textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    PETO2_toggled = false;
                    PETO2_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }

    }
    private void Clicked_VE_Toggle()
    {
        
        if (!VE_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!VE_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 11;
                        textBoxContent[i] = avatar.VE.ToString();
                        //textBoxes[i].text = avatar.VE.ToString();
                        nameBoxes[i] = "VE ";
                        filledBoxes[i] = true;
                        VE_toggled = true;
                        VE_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                    }



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
                    textBoxContent[i] = "";
                    //textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    VE_toggled = false;
                    VE_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }
    }
    private void Clicked_VO2_Toggle()
    {
        
        if (!VO2_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!VO2_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 12;
                        textBoxContent[i] = avatar.VO2.ToString();
                        //textBoxes[i].text = avatar.VO2.ToString();
                        nameBoxes[i] = "VO2 ";
                        filledBoxes[i] = true;
                        VO2_toggled = true;
                        VO2_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;

                    }



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
                    textBoxContent[i] = "";
                    //textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    VO2_toggled = false;
                    VO2_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }

    }
    private void Clicked_VCO2_Toggle()
    {
       
        if (!VCO2_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!VCO2_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 13;
                        textBoxContent[i] = avatar.VCO2.ToString();

                        //textBoxes[i].text = avatar.VCO2.ToString();
                        nameBoxes[i] = "VCO2 ";
                        filledBoxes[i] = true;
                        VCO2_toggled = true;
                        VCO2_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                    }



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
                    textBoxContent[i] = "";
                    //textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    VCO2_toggled = false;
                    VCO2_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }

    }
    private void Clicked_RER_Toggle()
    {
       
        if (!RER_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!RER_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 14;
                        textBoxContent[i] = avatar.RER.ToString();
                        //textBoxes[i].text = avatar.RER.ToString();
                        nameBoxes[i] = "RER ";
                        filledBoxes[i] = true;
                        RER_toggled = true;
                        RER_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                    }



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
                    textBoxContent[i] = "";
                    //textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    RER_toggled = false;
                    RER_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }

    }
    private void Clicked_MET_Toggle()
    {
        if (!MET_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!MET_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 15;
                        textBoxContent[i] = avatar.MET.ToString();
                        //textBoxes[i].text = avatar.MET.ToString();
                        nameBoxes[i] = "MET ";
                        filledBoxes[i] = true;
                        MET_toggled = true;
                        MET_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                    }



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
                    textBoxContent[i] = "";
                    //textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    MET_toggled = false;
                    MET_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }

    }
    private void Clicked_VO2fr_Toggle()
    {
        if (!VO2fr_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!VO2fr_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 16;
                        textBoxContent[i] = avatar.VO2fr.ToString();
                        //textBoxes[i].text = avatar.VO2fr.ToString();
                        nameBoxes[i] = "VO2fr ";
                        filledBoxes[i] = true;
                        VO2fr_toggled = true;
                        VO2fr_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                    }



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
                    textBoxContent[i] = "";
                    //textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    VO2fr_toggled = false;
                    VO2fr_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }

    }
    private void Clicked_SpO2_Toggle()
    {
        if (!SpO2_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!SpO2_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 17;
                        textBoxContent[i] = avatar.SpO2.ToString();
                        //textBoxes[i].text = avatar.SpO2.ToString();
                        nameBoxes[i] = "SpO2 ";
                        filledBoxes[i] = true;
                        SpO2_toggled = true;
                        SpO2_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;

                    }


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
                    textBoxContent[i] = "";
                    //textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    SpO2_toggled = false;
                    SpO2_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }

    }
    private void Clicked_VEcap_Toggle()
    {
        if (!VEcap_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!VEcap_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 18;
                        textBoxContent[i] = avatar.Vecap.ToString();
                        //textBoxes[i].text = avatar.Vecap.ToString();
                        nameBoxes[i] = "VEcap ";
                        filledBoxes[i] = true;
                        VEcap_toggled = true;
                        VEcap_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                    }



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
                    textBoxContent[i] = "";
                    //textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    VEcap_toggled = false;
                    VEcap_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }

    }
    private void Clicked_VEVO2_Toggle()
    {
        if (!VEVO2_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!VEVO2_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 19;
                        textBoxContent[i] = avatar.VeVO2.ToString();
                        //textBoxes[i].text = avatar.VeVO2.ToString();
                        nameBoxes[i] = "VeVO2 ";
                        filledBoxes[i] = true;
                        VEVO2_toggled = true;
                        VEVO2_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                    }



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
                    textBoxContent[i] = "";
                    //textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    VEVO2_toggled = false;
                    VEVO2_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }

    }
    private void Clicked_VEVCO2_Toggle()
    {
        if (!VEVCO2_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!VEVCO2_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 20;
                        textBoxContent[i] = avatar.VeVCO2.ToString();
                        //textBoxes[i].text = avatar.VeVCO2.ToString();
                        nameBoxes[i] = "VEVCO2 ";
                        filledBoxes[i] = true;
                        VEVCO2_toggled = true;
                        VEVCO2_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                    }



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
                    textBoxContent[i] = "";
                    //textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    VEVCO2_toggled = false;
                    VEVCO2_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }

    }
    private void Clicked_FIO2_Toggle()
    {
        if (!FIO2_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!FIO2_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 21;
                        textBoxContent[i] = avatar.FIO2.ToString();
                        //textBoxes[i].text = avatar.FIO2.ToString();
                        nameBoxes[i] = "FIO2 ";
                        filledBoxes[i] = true;
                        FIO2_toggled = true;
                        FIO2_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                    }



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
                    textBoxContent[i] = "";
                    //textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    FIO2_toggled = false;
                    FIO2_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }

    }
    private void Clicked_FICO2_Toggle()
    {
        if (!FICO2_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!FICO2_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 22;
                        //textBoxes[i].text = "ve";
                        textBoxContent[i] = avatar.FICO2.ToString();
                        //textBoxes[i].text = avatar.FICO2.ToString();
                        nameBoxes[i] = "FICO2 ";
                        filledBoxes[i] = true;
                        FICO2_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                        FICO2_toggled = true;
                        // RPE_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }



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
                    textBoxContent[i] = "";
                    //textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    FICO2_toggled = false;
                    FICO2_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }

    }
    private void Clicked_FEO2_Toggle()
    {
        if (!FEO2_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!FEO2_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 23;
                        //textBoxes[i].text = "ve";
                        textBoxContent[i] = avatar.FEO2.ToString();
                        //textBoxes[i].text = avatar.FEO2.ToString();
                        nameBoxes[i] = "FEO2 ";
                        filledBoxes[i] = true;
                        FEO2_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                        FEO2_toggled = true;
                        // RPE_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }



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
                    textBoxContent[i] = "";
                    //textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    FEO2_toggled = false;
                    FEO2_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }

    }
    private void Clicked_FECO2_Toggle()
    {
        if (!FECO2_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!FECO2_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 24;
                        //textBoxes[i].text = "ve";
                        textBoxContent[i] = avatar.FECO2.ToString();
                        //textBoxes[i].text = avatar.FECO2.ToString();
                        nameBoxes[i] = "FECO2 ";
                        filledBoxes[i] = true;
                        FECO2_toggled = true;
                        FECO2_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                        // RPE_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }



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
                    textBoxContent[i] = "";
                    //textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    FECO2_toggled = false;
                    FECO2_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }

    }
    private void Clicked_BPd_Toggle()
    {
        if (!BPd_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!BPd_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 25;
                        //textBoxes[i].text = "ve";
                        textBoxContent[i] = avatar.BPd.ToString();
                        //textBoxes[i].text = avatar.BPd.ToString();
                        nameBoxes[i] = "BPd ";
                        filledBoxes[i] = true;
                        BPd_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                        BPd_toggled = true;
                        // RPE_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }



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
                    textBoxContent[i] = "";
                    //textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    BPd_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                    BPd_toggled = false;
                }
            }


        }

    }
    private void Clicked_BPs_Toggle()
    {
        if (!BPs_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!BPs_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 26;
                        //textBoxes[i].text = "ve";
                        textBoxContent[i] = avatar.BPs.ToString();
                        //textBoxes[i].text = avatar.BPs.ToString();
                        nameBoxes[i] = "BPs ";
                        filledBoxes[i] = true;
                        BPs_toggled = true;
                        BPs_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                        // RPE_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }




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
                    textBoxContent[i] = "";
                    //textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    BPs_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                    BPs_toggled = false;
                }
            }


        }

    }
    private void Clicked_MAP_Toggle()
    {
        if (!MAP_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!MAP_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 27;
                        //textBoxes[i].text = "ve";
                        textBoxContent[i] = avatar.MAP.ToString();
                        //textBoxes[i].text = avatar.MAP.ToString();
                        nameBoxes[i] = "MAP ";
                        filledBoxes[i] = true;
                        MAP_toggled = true;
                        MAP_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                        // RPE_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }



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
                    textBoxContent[i] = "";
                    //textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    MAP_toggled = false;
                    MAP_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }

    }
    private void Clicked_Bla_Toggle()
    {
        if (!Bla_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {

                    if (!Bla_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 28;
                        //textBoxes[i].text = "ve";
                        textBoxContent[i] = avatar.Bla.ToString();
                        //textBoxes[i].text = avatar.Bla.ToString();
                        nameBoxes[i] = "Bla ";
                        filledBoxes[i] = true;
                        Bla_toggled = true;
                        Bla_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                        // RPE_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }



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
                    textBoxContent[i] = "";
                    //textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    Bla_toggled = false;
                    Bla_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }

    }
    private void Clicked_CO_Toggle()
    {
        if (!CO_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!CO_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 29;
                        //textBoxes[i].text = "ve";
                        textBoxContent[i] = avatar.CO.ToString();
                        //textBoxes[i].text = avatar.CO.ToString();
                        nameBoxes[i] = "CO ";
                        filledBoxes[i] = true;
                        CO_toggled = true;
                        CO_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                        // RPE_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 

                    }



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
                    textBoxContent[i] = "";
                    //textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    CO_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                    CO_toggled = false;
                }
            }


        }

    }
    private void Clicked_FCmax_Toggle()
    {
        if (!Fcmax_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!Fcmax_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 30;
                        //textBoxes[i].text = "ve";
                        textBoxContent[i] = avatar.FCmax.ToString();
                        //textBoxes[i].text = avatar.FCmax.ToString();
                        nameBoxes[i] = "FCmax ";
                        filledBoxes[i] = true;
                        Fcmax_toggled = true;
                        Fcmax_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                        // RPE_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }



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
                    textBoxContent[i] = "";
                    //textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    Fcmax_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                    Fcmax_toggled = false;
                }
            }


        }

    }
    private void Clicked_FCres_Toggle()
    {
        if (!Fcres_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!Fcres_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 31;
                        //textBoxes[i].text = "ve";
                        textBoxContent[i] = avatar.FCres.ToString();
                        //textBoxes[i].text = avatar.FCres.ToString();
                        nameBoxes[i] = "FCres ";
                        filledBoxes[i] = true;
                        Fcres_toggled = true;
                        Fcres_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                        // RPE_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }



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
                    textBoxContent[i] = "";
                    //textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    Fcres_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                    Fcres_toggled = false;
                }
            }


        }

    }

    private void Clicked_VO2fc_Toggle()
    {
        if (!VO2fc_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!VO2fc_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 32;
                        //textBoxes[i].text = "ve";
                        textBoxContent[i] = avatar.VO2fc.ToString();
                        //textBoxes[i].text = avatar.VO2fc.ToString();
                        nameBoxes[i] = "VO2fc ";
                        filledBoxes[i] = true;
                        VO2fc_toggled = true;
                        VO2fc_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                        // RPE_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }



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
                    textBoxContent[i] = "";
                    //textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    VO2fc_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                    VO2fc_toggled = false;
                }
            }


        }

    }
    private void Clicked_Sv_Toggle()
    {
        if (!Sv_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!Sv_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 33;
                        //textBoxes[i].text = "ve";
                        textBoxContent[i] = avatar.SV.ToString();
                        //textBoxes[i].text = avatar.SV.ToString();
                        nameBoxes[i] = "SV ";
                        filledBoxes[i] = true;
                        Sv_toggled = true;
                        Sv_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                        // RPE_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }



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
                    textBoxContent[i] = "";
                    //textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    Sv_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                    Sv_toggled = false;
                }
            }


        }

    }
    private void Clicked_FEV1_Toggle()
    {
        if (!FEV1_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!FEV1_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 34;
                        //textBoxes[i].text = "ve";
                        textBoxContent[i] = avatar.FEV1.ToString();
                        //textBoxes[i].text = avatar.FEV1.ToString();
                        nameBoxes[i] = "FEV1 ";
                        filledBoxes[i] = true;
                        FEV1_toggled = true;
                        FEV1_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                        // RPE_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }



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
                    textBoxContent[i] = "";
                    //textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    FEV1_toggled = false;
                    FEV1_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }

    }
    private void Clicked_FVC_Toggle()
    {
        if (!FVC_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!FVC_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 35;
                        //textBoxes[i].text = "ve";
                        textBoxContent[i] = avatar.FVC.ToString();
                       // textBoxes[i].text = avatar.FVC.ToString();
                        nameBoxes[i] = "FVC ";
                        filledBoxes[i] = true;
                        FVC_toggled = true;
                        FVC_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                        // RPE_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }



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
                    textBoxContent[i] = "";
                    //textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    FVC_toggled = false;
                    FVC_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }

    }
    private void Clicked_FEV1FVC_Toggle()
    {
        if (!FEV1FVC_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!FEV1FVC_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 36;
                        //textBoxes[i].text = "ve";
                        textBoxContent[i] = avatar.FEV1FVC.ToString();
                        //textBoxes[i].text = avatar.FEV1FVC.ToString();
                        nameBoxes[i] = "FEV1FVC ";
                        filledBoxes[i] = true;
                        FEV1FVC_toggled = true;
                        FEV1FVC_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                        // RPE_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }



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
                    textBoxContent[i] = "";
                    //textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    FEV1FVC_toggled = false;
                    FEV1FVC_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }

    }
    private void Clicked_PImax_Toggle()
    {
        if (!PImax_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!PImax_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 37;
                        //textBoxes[i].text = "ve";
                        textBoxContent[i] = avatar.PImax.ToString();
                        //textBoxes[i].text = avatar.PImax.ToString();
                        nameBoxes[i] = "PImax ";
                        filledBoxes[i] = true;
                        PImax_toggled = true;
                        PImax_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                        // RPE_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }



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
                    textBoxContent[i] = "";
                    //textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    PImax_toggled = false;
                    PImax_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }

    }
    private void Clicked_PEmax_Toggle()
    {
        if (!PEmax_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!PEmax_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 38;
                        //textBoxes[i].text = "ve";
                        textBoxContent[i] = avatar.PEmax.ToString();
                        //textBoxes[i].text = avatar.PEmax.ToString();
                        nameBoxes[i] = "PEmax ";
                        filledBoxes[i] = true;
                        PEmax_toggled = true;
                        PEmax_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                        // RPE_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }



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
                    textBoxContent[i] = "";
                    //textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    PEmax_toggled = false;
                    PEmax_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }

    }
    private void Clicked_ERV_Toggle()
    {
        if (!ERV_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!ERV_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 39;
                        //textBoxes[i].text = "ve";
                        textBoxContent[i] = avatar.ERV.ToString();
                        //textBoxes[i].text = avatar.ERV.ToString();
                        nameBoxes[i] = "ERV ";
                        filledBoxes[i] = true;
                        ERV_toggled = true;
                        ERV_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                        // RPE_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }



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
                    textBoxContent[i] = "";
                    //textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    ERV_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                    ERV_toggled = false;
                }
            }


        }

    }
    private void Clicked_FRC_Toggle()
    {
        if (!FRC_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!FRC_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 40;
                        //textBoxes[i].text = "ve";
                        textBoxContent[i] = avatar.FRC.ToString();
                        //textBoxes[i].text = avatar.FRC.ToString();
                        nameBoxes[i] = "FRC ";
                        filledBoxes[i] = true;
                        FRC_toggled = true;
                        FRC_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                        // RPE_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }



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
                    textBoxContent[i] = "";
                    //textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    FRC_toggled = false;
                    FRC_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }

    }
    private void Clicked_IC_Toggle()
    {
        if (!IC_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!IC_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 41;
                        //textBoxes[i].text = "ve";
                        textBoxContent[i] = avatar.IC.ToString();
                        //textBoxes[i].text = avatar.IC.ToString();
                        nameBoxes[i] = "IC ";
                        filledBoxes[i] = true;
                        IC_toggled = true;
                        IC_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                        // RPE_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }



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
                    textBoxContent[i] = "";
                    //textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    IC_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                    IC_toggled = false;
                }
            }


        }

    }
    private void Clicked_IRV_Toggle()
    {
        if (!IRV_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!IRV_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 42;
                        //textBoxes[i].text = "ve";
                        textBoxContent[i] = avatar.IRV.ToString();
                        //textBoxes[i].text = avatar.IRV.ToString();
                        nameBoxes[i] = "IRV ";
                        filledBoxes[i] = true;
                        IRV_toggled = true;
                        IRV_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                        // RPE_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 

                    }



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
                    textBoxContent[i] = "";
                    //textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    IRV_toggled = false;
                    IRV_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }

    }
    private void Clicked_PIF_Toggle()
    {
        if (!PIF_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!PIF_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 43;
                        //textBoxes[i].text = "ve";
                        textBoxContent[i] = avatar.PIF.ToString();
                        //textBoxes[i].text = avatar.PIF.ToString();
                        nameBoxes[i] = "PIF ";
                        filledBoxes[i] = true;
                        PIF_toggled = true;
                        PIF_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                        // RPE_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }



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
                    textBoxContent[i] = "";
                    //textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    PIF_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                    PIF_toggled = false;
                }
            }


        }

    }
    private void Clicked_PEF_Toggle()
    {
        if (!PEF_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!PEF_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 44;
                        //textBoxes[i].text = "ve";
                        textBoxContent[i] = avatar.PEF.ToString();
                        //textBoxes[i].text = avatar.PEF.ToString();
                        nameBoxes[i] = "PEF ";
                        filledBoxes[i] = true;
                        PEF_toggled = true;
                        PEF_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                        // RPE_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }



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
                    textBoxContent[i] = "";
                    //textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    PEF_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                    PEF_toggled = false;
                }
            }


        }

    }
    private void Clicked_RV_Toggle()
    {
        if (!RV_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!RV_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 45;
                        //textBoxes[i].text = "ve";
                        textBoxContent[i] = avatar.RV.ToString();
                        //textBoxes[i].text = avatar.RV.ToString();
                        nameBoxes[i] = "RV ";
                        filledBoxes[i] = true;
                        RV_toggled = true;
                        RV_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                        // RPE_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }



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
                    textBoxContent[i] = "";
                    //textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    RV_toggled = false;
                    RV_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }

    }
    private void Clicked_TLC_Toggle()
    {
        if (!TLC_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!TLC_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 46;
                        //textBoxes[i].text = "ve";
                        textBoxContent[i] = avatar.TLC.ToString();
                        //textBoxes[i].text = avatar.TLC.ToString();
                        nameBoxes[i] = "TLC ";
                        filledBoxes[i] = true;
                        TLC_toggled = true;
                        TLC_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                        // RPE_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }



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
                    textBoxContent[i] = "";
                    //textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    TLC_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                    TLC_toggled = false;
                }
            }


        }

    }
    private void Clicked_VC_Toggle()
    {
        if (!VC_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!VC_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 47;
                        //textBoxes[i].text = "ve";
                        textBoxContent[i] = avatar.VC.ToString();
                       // textBoxes[i].text = avatar.VC.ToString();
                        nameBoxes[i] = "VC ";
                        VC_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                        filledBoxes[i] = true;
                        VC_toggled = true;
                        // RPE_toggle.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }



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
                    textBoxContent[i] = "";
                    //textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    VC_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                    VC_toggled = false;
                }
            }


        }

    }
    public void ResetAllValues() //reset every value in order to start from a clean state
    {
        for (int i = 0; i < 10; i++)
        {
            filledBoxes[i] = false;
            textBoxContent[i] = "";
            nameBoxes[i] = "";
            BoxValue[i] = 0;

        }
        RPE_toggled = false; //stops every single box from being filled by a single variable each time
        dyspnoea_toggled = false;
        EE_toggled = false;
        TE_toggled = false;
        TI_toggled = false;
        TToT_toggled = false;
        VT_toggled = false;
        fr_toggled = false;
        PETCO2_toggled = false;
        PETO2_toggled = false;
        VE_toggled = false;
        VO2_toggled = false;
        VCO2_toggled = false;
        RER_toggled = false;
        MET_toggled = false; //stops every single box from being filled by a single variable each time
        TToT_toggled = false;
        VO2fr_toggled = false;
        SpO2_toggled = false;
        VEcap_toggled = false;
        VEVO2_toggled = false;
        VEVCO2_toggled = false;
        FIO2_toggled = false;
        FICO2_toggled = false;
        FEO2_toggled = false;
        FECO2_toggled = false;
        BPd_toggled = false;
        BPs_toggled = false;
        MAP_toggled = false;
        Bla_toggled = false;
        CO_toggled = false;
        Fcmax_toggled = false;
        Fcres_toggled = false;
        VO2fc_toggled = false;
        Sv_toggled = false;
        FEV1_toggled = false;
        FVC_toggled = false;
        FEV1FVC_toggled = false;
        PImax_toggled = false;
        PEmax_toggled = false;
        ERV_toggled = false;
        FRC_toggled = false;
        IC_toggled = false;
        IRV_toggled = false;
        PIF_toggled = false;
        PEF_toggled = false;
        RV_toggled = false;
        TLC_toggled = false;
        VC_toggled = false;

    }



    
    //public bool FRC_toggled;
    //public bool IC_toggled;
    //public bool IRV_toggled;
    //public bool PIF_toggled;
    //public bool PEF_toggled;
    //public bool RV_toggled;
    //public bool TLC_toggled;
    //public bool VC_toggled;
}
