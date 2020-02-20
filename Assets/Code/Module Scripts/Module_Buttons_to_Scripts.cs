using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module_Buttons_to_Scripts : MonoBehaviour
{

    GameObject avatarHolder;
    GameObject buttonHolder;

    Button_Holder buttonScript;

    Custom_Module_To_New_Scene moduleScripts;
    // Start is called before the first frame update
    void Start()
    {
        avatarHolder = GameObject.FindGameObjectWithTag("Avatar_Holder");
        buttonHolder = GameObject.FindGameObjectWithTag("Button_Holder");

        moduleScripts = avatarHolder.GetComponent<Custom_Module_To_New_Scene>();
        buttonScript = buttonHolder.GetComponent<Button_Holder>();
        ApplyAllButtons();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ApplyAllButtons()
    {
        ApplyCardioButtons();
        ApplyCustomButtons();
        ApplyMetCartButtons();
        ApplyPvButtons();
        AttachAllButtons();
    }
    void ApplyCustomButtons()
    {
        moduleScripts.custom_module.RPE_button = buttonScript.RPE_button_Custom; //1
        moduleScripts.custom_module.Dyspnoea_button = buttonScript.Dyspnoea_button_Custom; //2
        moduleScripts.custom_module.EE_button = buttonScript.EE_button_Custom; //3
        moduleScripts.custom_module.TE_button = buttonScript.TE_button_Custom; //4
        moduleScripts.custom_module.TI_button = buttonScript.TI_button_Custom; //5
        moduleScripts.custom_module.TToT_button = buttonScript.TToT_button_Custom; //6
        moduleScripts.custom_module.VT_button = buttonScript.VT_button_Custom; //7
        moduleScripts.custom_module.fr_button = buttonScript.fr_button_Custom; //8
        moduleScripts.custom_module.PETCO2_button = buttonScript.PETCO2_button_Custom; //9
        moduleScripts.custom_module.PETO2_button = buttonScript.PETO2_button_Custom; //10
        moduleScripts.custom_module.VE_button = buttonScript.VE_button_Custom; //11
        moduleScripts.custom_module.VO2_button = buttonScript.VO2_button_Custom; //12
        moduleScripts.custom_module.VCO2_button = buttonScript.VCO2_button_Custom; //13
        moduleScripts.custom_module.RER_button = buttonScript.RER_button_Custom; //14
        moduleScripts.custom_module.MET_button = buttonScript.MET_button_Custom; //15
        moduleScripts.custom_module.VO2fr_button = buttonScript.VO2fr_button_Custom; //16
        moduleScripts.custom_module.SpO2_button = buttonScript.SpO2_button_Custom; //17
        moduleScripts.custom_module.VEcap_button = buttonScript.VEcap_button_Custom; //18
        moduleScripts.custom_module.VEVO2_button = buttonScript.VEVO2_button_Custom; //19
        moduleScripts.custom_module.VEVCO2_button = buttonScript.VEVCO2_button_Custom; //20
        moduleScripts.custom_module.FIO2_button = buttonScript.FIO2_button_Custom; //21
        moduleScripts.custom_module.FICO2_button = buttonScript.FICO2_button_Custom; //22
        moduleScripts.custom_module.FEO2_button = buttonScript.FEO2_button_Custom; //23
        moduleScripts.custom_module.FECO2_button = buttonScript.FECO2_button_Custom; //24
        moduleScripts.custom_module.BPd_button = buttonScript.BPd_button_Custom; //25
        moduleScripts.custom_module.BPs_button = buttonScript.BPs_button_Custom; //26
        moduleScripts.custom_module.MAP_button = buttonScript.MAP_button_Custom; //27
        moduleScripts.custom_module.Bla_button = buttonScript.Bla_button_Custom; //28
        moduleScripts.custom_module.CO_button = buttonScript.CO_button_Custom; //29
        moduleScripts.custom_module.Fcmax_button = buttonScript.Fcmax_button_Custom; //30
        moduleScripts.custom_module.Fcres_button = buttonScript.Fcres_button_Custom; //31
        moduleScripts.custom_module.VO2fc_button = buttonScript.VO2fc_button_Custom; //32
        moduleScripts.custom_module.Sv_button = buttonScript.Sv_button_Custom; //33
        moduleScripts.custom_module.FEV1_button = buttonScript.FEV1_button_Custom; //34
        moduleScripts.custom_module.FVC_button = buttonScript.FVC_button_Custom; //35
        moduleScripts.custom_module.FEV1FVC_button = buttonScript.FEV1FVC_button_Custom; //36
        moduleScripts.custom_module.PImax_button = buttonScript.PImax_button_Custom; //37 
        moduleScripts.custom_module.PEmax_button = buttonScript.PEmax_button_Custom; //38
        moduleScripts.custom_module.ERV_button = buttonScript.ERV_button_Custom; //39
        moduleScripts.custom_module.FRC_button = buttonScript.FRC_button_Custom; //40
        moduleScripts.custom_module.IC_button = buttonScript.IC_button_Custom; //41
        moduleScripts.custom_module.IRV_button = buttonScript.IRV_button_Custom; //42
        moduleScripts.custom_module.PIF_button = buttonScript.PIF_button_Custom; //43
        moduleScripts.custom_module.PEF_button = buttonScript.PEF_button_Custom; //44
        moduleScripts.custom_module.RV_button = buttonScript.RV_button_Custom; //45
        moduleScripts.custom_module.TLC_button = buttonScript.TLC_button_Custom; //46
        moduleScripts.custom_module.VC_button = buttonScript.VC_button_Custom; //47 
}
    void ApplyPvButtons()
    {
        moduleScripts.Pv_module.FVC_button = buttonScript.FVC_button_PV;
        moduleScripts.Pv_module.FEV1_button = buttonScript.FEV1_button_PV;
        moduleScripts.Pv_module.FEV1FVC_button = buttonScript.FEV1FVC_button_PV;
        moduleScripts.Pv_module.PEF_button = buttonScript.PEF_button_PV;
        moduleScripts.Pv_module.PIF_button = buttonScript.PIF_button_PV;
        moduleScripts.Pv_module.PImax_button = buttonScript.PImax_button_PV;
        moduleScripts.Pv_module.PEmax_button = buttonScript.PEmax_button_PV;
        moduleScripts.Pv_module.VECap_button = buttonScript.VECap_button_PV;
        moduleScripts.Pv_module.ERV_button = buttonScript.ERV_button_PV;
        moduleScripts.Pv_module.FRC_button = buttonScript.FRC_button_PV;
        moduleScripts.Pv_module.IC_button = buttonScript.IC_button_PV;
        moduleScripts.Pv_module.IRV_button = buttonScript.IRV_button_PV;
        moduleScripts.Pv_module.RV_button = buttonScript.RV_button_PV;
        moduleScripts.Pv_module.TLC_button = buttonScript.TLC_button_PV;
        moduleScripts.Pv_module.VC_button = buttonScript.VC_button_PV;
}
    void ApplyCardioButtons()
    {
        moduleScripts.Cardio_Module.fc_button = buttonScript.fc_button_Cardio; //1
        moduleScripts.Cardio_Module.vo2fc_button = buttonScript.vo2fc_button_Cardio; //2
        moduleScripts.Cardio_Module.MAP_button = buttonScript.MAP_button_Cardio; //3
        moduleScripts.Cardio_Module.fcmax_button = buttonScript.fcmax_button_Cardio; //4
        moduleScripts.Cardio_Module.bla_button = buttonScript.bla_button_Cardio; //5
        moduleScripts.Cardio_Module.CO_button = buttonScript.CO_button_Cardio; //6
        moduleScripts.Cardio_Module.BPd_button = buttonScript.BPd_button_Cardio; //7
        moduleScripts.Cardio_Module.BPs_button = buttonScript.BPs_button_Cardio; //8
        moduleScripts.Cardio_Module.SV_button = buttonScript.SV_button_Cardio; //9
        moduleScripts.Cardio_Module.fcres_button = buttonScript.fcres_button_Cardio; //10
        moduleScripts.Cardio_Module.SpO2_button = buttonScript.SpO2_button_Cardio; //11
}
    void ApplyMetCartButtons()
    {
        moduleScripts.MetCart_module.VE_button = buttonScript.VE_button_MC;
        moduleScripts.MetCart_module.VT_button = buttonScript.VT_button_MC;
        moduleScripts.MetCart_module.VO2_button = buttonScript.VO2_button_MC;
        moduleScripts.MetCart_module.VCO2_button = buttonScript.VCO2_button_MC;
        moduleScripts.MetCart_module.FR_button = buttonScript.FR_button_MC;
        moduleScripts.MetCart_module.MET_button = buttonScript.MET_button_MC;
        moduleScripts.MetCart_module.Fc_button = buttonScript.Fc_button_MC;
        moduleScripts.MetCart_module.RER_button = buttonScript.RER_button_MC;
        moduleScripts.MetCart_module.VEVO2_button = buttonScript.VEVO2_button_MC;
        moduleScripts.MetCart_module.VEVCO2_button = buttonScript.VEVCO2_button_MC;
        moduleScripts.MetCart_module.PETCO2_button = buttonScript.PETCO2_button_MC;
        moduleScripts.MetCart_module.PETO2_button = buttonScript.PETO2_button_MC;
        moduleScripts.MetCart_module.TE_button = buttonScript.TE_button_MC;
        moduleScripts.MetCart_module.TI_button = buttonScript.TI_button_MC;
        moduleScripts.MetCart_module.TITE_button = buttonScript.TITE_button_MC;
        moduleScripts.MetCart_module.TToT_button = buttonScript.TToT_button_MC;
        moduleScripts.MetCart_module.VO2FR_button = buttonScript.VO2FR_button_MC;
        moduleScripts.MetCart_module.VO2FC_button = buttonScript.VO2FC_button_MC;
        moduleScripts.MetCart_module.SpO2_button = buttonScript.SpO2_button_MC;
        moduleScripts.MetCart_module.Fcmax_button = buttonScript.Fcmax_button_MC;
        moduleScripts.MetCart_module.Fcres_button = buttonScript.Fcres_button_MC;
        moduleScripts.MetCart_module.EE_button = buttonScript.EE_button_MC;
}
    void AttachAllButtons()
    {
        moduleScripts.Cardio_Module.AttachButtons();
        moduleScripts.Pv_module.AttachButtons();
        moduleScripts.MetCart_module.AttachButtons();
        moduleScripts.custom_module.AttachButtons();
    }
}
