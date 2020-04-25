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
        moduleScripts.customModule.RPE_button = buttonScript.RPE_button_Custom; //1
        moduleScripts.customModule.Dyspnoea_button = buttonScript.Dyspnoea_button_Custom; //2
        moduleScripts.customModule.EE_button = buttonScript.EE_button_Custom; //3
        moduleScripts.customModule.TE_button = buttonScript.TE_button_Custom; //4
        moduleScripts.customModule.TI_button = buttonScript.TI_button_Custom; //5
        moduleScripts.customModule.TToT_button = buttonScript.TToT_button_Custom; //6
        moduleScripts.customModule.VT_button = buttonScript.VT_button_Custom; //7
        moduleScripts.customModule.fr_button = buttonScript.fr_button_Custom; //8
        moduleScripts.customModule.PETCO2_button = buttonScript.PETCO2_button_Custom; //9
        moduleScripts.customModule.PETO2_button = buttonScript.PETO2_button_Custom; //10
        moduleScripts.customModule.VE_button = buttonScript.VE_button_Custom; //11
        moduleScripts.customModule.VO2_button = buttonScript.VO2_button_Custom; //12
        moduleScripts.customModule.VCO2_button = buttonScript.VCO2_button_Custom; //13
        moduleScripts.customModule.RER_button = buttonScript.RER_button_Custom; //14
        moduleScripts.customModule.MET_button = buttonScript.MET_button_Custom; //15
        moduleScripts.customModule.VO2fr_button = buttonScript.VO2fr_button_Custom; //16
        moduleScripts.customModule.SpO2_button = buttonScript.SpO2_button_Custom; //17
        moduleScripts.customModule.VEcap_button = buttonScript.VEcap_button_Custom; //18
        moduleScripts.customModule.VEVO2_button = buttonScript.VEVO2_button_Custom; //19
        moduleScripts.customModule.VEVCO2_button = buttonScript.VEVCO2_button_Custom; //20
        moduleScripts.customModule.FIO2_button = buttonScript.FIO2_button_Custom; //21
        moduleScripts.customModule.FICO2_button = buttonScript.FICO2_button_Custom; //22
        moduleScripts.customModule.FEO2_button = buttonScript.FEO2_button_Custom; //23
        moduleScripts.customModule.FECO2_button = buttonScript.FECO2_button_Custom; //24
        moduleScripts.customModule.BPd_button = buttonScript.BPd_button_Custom; //25
        moduleScripts.customModule.BPs_button = buttonScript.BPs_button_Custom; //26
        moduleScripts.customModule.MAP_button = buttonScript.MAP_button_Custom; //27
        moduleScripts.customModule.Bla_button = buttonScript.Bla_button_Custom; //28
        moduleScripts.customModule.CO_button = buttonScript.CO_button_Custom; //29
        moduleScripts.customModule.Fcmax_button = buttonScript.Fcmax_button_Custom; //30
        moduleScripts.customModule.Fcres_button = buttonScript.Fcres_button_Custom; //31
        moduleScripts.customModule.VO2fc_button = buttonScript.VO2fc_button_Custom; //32
        moduleScripts.customModule.Sv_button = buttonScript.Sv_button_Custom; //33
        moduleScripts.customModule.FEV1_button = buttonScript.FEV1_button_Custom; //34
        moduleScripts.customModule.FVC_button = buttonScript.FVC_button_Custom; //35
        moduleScripts.customModule.FEV1FVC_button = buttonScript.FEV1FVC_button_Custom; //36
        moduleScripts.customModule.PImax_button = buttonScript.PImax_button_Custom; //37 
        moduleScripts.customModule.PEmax_button = buttonScript.PEmax_button_Custom; //38
        moduleScripts.customModule.ERV_button = buttonScript.ERV_button_Custom; //39
        moduleScripts.customModule.FRC_button = buttonScript.FRC_button_Custom; //40
        moduleScripts.customModule.IC_button = buttonScript.IC_button_Custom; //41
        moduleScripts.customModule.IRV_button = buttonScript.IRV_button_Custom; //42
        moduleScripts.customModule.PIF_button = buttonScript.PIF_button_Custom; //43
        moduleScripts.customModule.PEF_button = buttonScript.PEF_button_Custom; //44
        moduleScripts.customModule.RV_button = buttonScript.RV_button_Custom; //45
        moduleScripts.customModule.TLC_button = buttonScript.TLC_button_Custom; //46
        moduleScripts.customModule.VC_button = buttonScript.VC_button_Custom; //47 
}
    void ApplyPvButtons()
    {
        moduleScripts.pvModule.FVC_button = buttonScript.FVC_button_PV;
        moduleScripts.pvModule.FEV1_button = buttonScript.FEV1_button_PV;
        moduleScripts.pvModule.FEV1FVC_button = buttonScript.FEV1FVC_button_PV;
        moduleScripts.pvModule.PEF_button = buttonScript.PEF_button_PV;
        moduleScripts.pvModule.PIF_button = buttonScript.PIF_button_PV;
        moduleScripts.pvModule.PImax_button = buttonScript.PImax_button_PV;
        moduleScripts.pvModule.PEmax_button = buttonScript.PEmax_button_PV;
        moduleScripts.pvModule.VECap_button = buttonScript.VECap_button_PV;
        moduleScripts.pvModule.ERV_button = buttonScript.ERV_button_PV;
        moduleScripts.pvModule.FRC_button = buttonScript.FRC_button_PV;
        moduleScripts.pvModule.IC_button = buttonScript.IC_button_PV;
        moduleScripts.pvModule.IRV_button = buttonScript.IRV_button_PV;
        moduleScripts.pvModule.RV_button = buttonScript.RV_button_PV;
        moduleScripts.pvModule.TLC_button = buttonScript.TLC_button_PV;
        moduleScripts.pvModule.VC_button = buttonScript.VC_button_PV;
}
    void ApplyCardioButtons()
    {
        moduleScripts.cardioModule.fc_button = buttonScript.fc_button_Cardio; //1
        moduleScripts.cardioModule.vo2fc_button = buttonScript.vo2fc_button_Cardio; //2
        moduleScripts.cardioModule.MAP_button = buttonScript.MAP_button_Cardio; //3
        moduleScripts.cardioModule.fcmax_button = buttonScript.fcmax_button_Cardio; //4
        moduleScripts.cardioModule.bla_button = buttonScript.bla_button_Cardio; //5
        moduleScripts.cardioModule.CO_button = buttonScript.CO_button_Cardio; //6
        moduleScripts.cardioModule.BPd_button = buttonScript.BPd_button_Cardio; //7
        moduleScripts.cardioModule.BPs_button = buttonScript.BPs_button_Cardio; //8
        moduleScripts.cardioModule.SV_button = buttonScript.SV_button_Cardio; //9
        moduleScripts.cardioModule.fcres_button = buttonScript.fcres_button_Cardio; //10
        moduleScripts.cardioModule.SpO2_button = buttonScript.SpO2_button_Cardio; //11
}
    void ApplyMetCartButtons()
    {
        moduleScripts.metCartModule.VE_button = buttonScript.VE_button_MC;
        moduleScripts.metCartModule.VT_button = buttonScript.VT_button_MC;
        moduleScripts.metCartModule.VO2_button = buttonScript.VO2_button_MC;
        moduleScripts.metCartModule.VCO2_button = buttonScript.VCO2_button_MC;
        moduleScripts.metCartModule.FR_button = buttonScript.FR_button_MC;
        moduleScripts.metCartModule.MET_button = buttonScript.MET_button_MC;
        moduleScripts.metCartModule.Fc_button = buttonScript.Fc_button_MC;
        moduleScripts.metCartModule.RER_button = buttonScript.RER_button_MC;
        moduleScripts.metCartModule.VEVO2_button = buttonScript.VEVO2_button_MC;
        moduleScripts.metCartModule.VEVCO2_button = buttonScript.VEVCO2_button_MC;
        moduleScripts.metCartModule.PETCO2_button = buttonScript.PETCO2_button_MC;
        moduleScripts.metCartModule.PETO2_button = buttonScript.PETO2_button_MC;
        moduleScripts.metCartModule.TE_button = buttonScript.TE_button_MC;
        moduleScripts.metCartModule.TI_button = buttonScript.TI_button_MC;
        moduleScripts.metCartModule.TITE_button = buttonScript.TITE_button_MC;
        moduleScripts.metCartModule.TToT_button = buttonScript.TToT_button_MC;
        moduleScripts.metCartModule.VO2FR_button = buttonScript.VO2FR_button_MC;
        moduleScripts.metCartModule.VO2FC_button = buttonScript.VO2FC_button_MC;
        moduleScripts.metCartModule.SpO2_button = buttonScript.SpO2_button_MC;
        moduleScripts.metCartModule.Fcmax_button = buttonScript.Fcmax_button_MC;
        moduleScripts.metCartModule.Fcres_button = buttonScript.Fcres_button_MC;
        moduleScripts.metCartModule.EE_button = buttonScript.EE_button_MC;
}
    void AttachAllButtons()
    {
        moduleScripts.cardioModule.AttachButtons();
        moduleScripts.pvModule.AttachButtons();
        moduleScripts.metCartModule.AttachButtons();
        moduleScripts.customModule.AttachButtons();
    }
}
