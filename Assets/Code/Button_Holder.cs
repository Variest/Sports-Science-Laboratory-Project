using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Holder : MonoBehaviour
{
    [Header("PV_Custom_Buttons")]
    public Button FVC_button_PV;
    public Button FEV1_button_PV;
    public Button FEV1FVC_button_PV;
    public Button PEF_button_PV;
    public Button PIF_button_PV;
    public Button PImax_button_PV;
    public Button PEmax_button_PV;
    public Button VECap_button_PV;
    public Button ERV_button_PV;
    public Button FRC_button_PV;
    public Button IC_button_PV;
    public Button IRV_button_PV;
    public Button RV_button_PV;
    public Button TLC_button_PV;
    public Button VC_button_PV;

    [Header("Cardio_Custom_Buttons")]
    public Button fc_button_Cardio; //1
    public Button vo2fc_button_Cardio; //2
    public Button MAP_button_Cardio; //3
    public Button fcmax_button_Cardio; //4
    public Button bla_button_Cardio; //5
    public Button CO_button_Cardio; //6
    public Button BPd_button_Cardio; //7
    public Button BPs_button_Cardio; //8
    public Button SV_button_Cardio; //9
    public Button fcres_button_Cardio; //10
    public Button SpO2_button_Cardio; //11

    [Header("MET_Cart_Buttons")]
    public Button VE_button_MC;
    public Button VT_button_MC;
    public Button VO2_button_MC;
    public Button VCO2_button_MC;
    public Button FR_button_MC;
    public Button MET_button_MC;
    public Button Fc_button_MC;
    public Button RER_button_MC;
    public Button VEVO2_button_MC;
    public Button VEVCO2_button_MC;
    public Button PETCO2_button_MC;
    public Button PETO2_button_MC;
    public Button TE_button_MC;
    public Button TI_button_MC;
    public Button TITE_button_MC;
    public Button TToT_button_MC;
    public Button VO2FR_button_MC;
    public Button VO2FC_button_MC;
    public Button SpO2_button_MC;
    public Button Fcmax_button_MC;
    public Button Fcres_button_MC;
    public Button EE_button_MC;

    [Header("Custom_Buttons")]
    public Button RPE_button_Custom; //1
    public Button Dyspnoea_button_Custom; //2
    public Button EE_button_Custom; //3
    public Button TE_button_Custom; //4
    public Button TI_button_Custom; //5
    public Button TToT_button_Custom; //6
    public Button VT_button_Custom; //7
    public Button fr_button_Custom; //8
    public Button PETCO2_button_Custom; //9
    public Button PETO2_button_Custom; //10
    public Button VE_button_Custom; //11
    public Button VO2_button_Custom; //12
    public Button VCO2_button_Custom; //13
    public Button RER_button_Custom; //14
    public Button MET_button_Custom; //15
    public Button VO2fr_button_Custom; //16
    public Button SpO2_button_Custom; //17
    public Button VEcap_button_Custom; //18
    public Button VEVO2_button_Custom; //19
    public Button VEVCO2_button_Custom; //20
    public Button FIO2_button_Custom; //21
    public Button FICO2_button_Custom; //22
    public Button FEO2_button_Custom; //23
    public Button FECO2_button_Custom; //24
    public Button BPd_button_Custom; //25
    public Button BPs_button_Custom; //26
    public Button MAP_button_Custom; //27
    public Button Bla_button_Custom; //28
    public Button CO_button_Custom; //29
    public Button Fcmax_button_Custom; //30
    public Button Fcres_button_Custom; //31
    public Button VO2fc_button_Custom; //32
    public Button Sv_button_Custom; //33
    public Button FEV1_button_Custom; //34
    public Button FVC_button_Custom; //35
    public Button FEV1FVC_button_Custom; //36
    public Button PImax_button_Custom; //37 
    public Button PEmax_button_Custom; //38
    public Button ERV_button_Custom; //39
    public Button FRC_button_Custom; //40
    public Button IC_button_Custom; //41
    public Button IRV_button_Custom; //42
    public Button PIF_button_Custom; //43
    public Button PEF_button_Custom; //44
    public Button RV_button_Custom; //45
    public Button TLC_button_Custom; //46
    public Button VC_button_Custom; //47 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
