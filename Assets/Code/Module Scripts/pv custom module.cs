using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pvcustommodule : MonoBehaviour
{
    public Text[] textBoxes = new Text[10];
    /*
  
        FVC
        FEV1
        FEV1FVC
        PEF
        PIF
        PImax
        PEmax
        VECap
        ERV
        FRC
        IC
        IRV
        RV
        TLC
        VC
     */
    public Toggle Toggle_FVC; //1
    public Toggle Toggle_FEV1; //2
    public Toggle Toggle_FEV1FVC; //3
    public Toggle Toggle_PEF; //4
    public Toggle Toggle_PIF; //5
    public Toggle Toggle_PImax; //6
    public Toggle Toggle_PEmax; //7
    public Toggle Toggle_VECap; //8
    public Toggle Toggle_ERV; //9
    public Toggle Toggle_FRC; //10
    public Toggle Toggle_IC; //11
    public Toggle Toggle_IRV; //12
    public Toggle Toggle_RV; //13
    public Toggle Toggle_TLC; //14
    public Toggle Toggle_VC; //15

    public GameObject avatarHolder; //gameobject that will have the avatar script within it
    public CharacterAvatar avatar; //gets a reference to the character undergoing the module

    public bool[] filledBoxes = new bool[10]; //array that will hold a true or false value for whether there is a value currently entered into the box

    public List<int> BoxValue = new List<int>(); //a list that will contain an int relating to the equation that is active inside that box. 1-22

    public bool FVC_toggled; //stops every single box from being filled by a single variable each time
    public bool FEV1_toggled;
    public bool FEV1FVC_toggled;
    public bool PEF_toggled;
    public bool PIF_toggled;
    public bool PImax_toggled;
    public bool PEmax_toggled;
    public bool VECap_toggled;
    public bool ERV_toggled;
    public bool FRC_toggled;
    public bool IC_toggled;
    public bool IRV_toggled;
    public bool RV_toggled;
    public bool TLC_toggled;
    public bool VC_toggled;
    void Start()
    {
        avatar = avatarHolder.GetComponent<CharacterAvatar>();
        //add listening events to each one of the toggle boxes 
        Toggle_FVC.onValueChanged.AddListener((Value) => { ClickedFVCToggle(Value); });
        Toggle_FEV1.onValueChanged.AddListener((Value) => { ClickedFEV1Toggle(Value); });
        Toggle_FEV1FVC.onValueChanged.AddListener((Value) => { ClickedFEV1FVCToggle(Value); });
        Toggle_PEF.onValueChanged.AddListener((Value) => { ClickedPEFToggle(Value); });
        Toggle_PIF.onValueChanged.AddListener((Value) => { ClickedPIFToggle(Value); });
        Toggle_PImax.onValueChanged.AddListener((Value) => { ClickedPImaxToggle(Value); });
        Toggle_PEmax.onValueChanged.AddListener((Value) => { ClickedPEmaxToggle(Value); });
        Toggle_VECap.onValueChanged.AddListener((Value) => { ClickedVECapToggle(Value); });
        Toggle_ERV.onValueChanged.AddListener((Value) => { ClickedERVToggle(Value); });
        Toggle_FRC.onValueChanged.AddListener((Value) => { ClickedFRCToggle(Value); });
        Toggle_IC.onValueChanged.AddListener((Value) => { ClickedICToggle(Value); });
        Toggle_IRV.onValueChanged.AddListener((Value) => { ClickedIRVToggle(Value); });
        Toggle_RV.onValueChanged.AddListener((Value) => { ClickedRVToggle(Value); });
        Toggle_TLC.onValueChanged.AddListener((Value) => { ClickedTLCToggle(Value); });
        Toggle_VC.onValueChanged.AddListener((Value) => { ClickedVCToggle(Value); });

    }

    // Update is called once per frame
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
    private void ClickedFVCToggle(bool Value)
    {
        if (Toggle_FVC.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (FVC_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 1;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.FVC.ToString();
                        filledBoxes[i] = true;
                        FVC_toggled = true;
                        Toggle_FVC.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & FVC_toggled == false)
                {
                    Toggle_FVC.isOn = false;
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
                    FVC_toggled = false;
                }
            }


        }

    }
    private void ClickedFEV1Toggle(bool Value)
    {
        if (Toggle_FEV1.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (FEV1_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 2;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.FEV1.ToString();
                        filledBoxes[i] = true;
                        FEV1_toggled = true;
                        Toggle_FEV1.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & FEV1_toggled == false)
                {
                    Toggle_FEV1.isOn = false;
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
                    FEV1_toggled = false;
                }
            }


        }

    }
    private void ClickedFEV1FVCToggle(bool Value)
    {
        if (Toggle_FEV1FVC.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (FEV1FVC_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 3;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.FEV1FVC.ToString();
                        filledBoxes[i] = true;
                        FEV1_toggled = true;
                        Toggle_FEV1FVC.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & FEV1FVC_toggled == false)
                {
                    Toggle_FEV1FVC.isOn = false;
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
                    FEV1FVC_toggled = false;
                }
            }


        }

    }
    private void ClickedPEFToggle(bool Value)
    {
        if (Toggle_PEF.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (PEF_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 4;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.PEF.ToString();
                        filledBoxes[i] = true;
                        PEF_toggled = true;
                        Toggle_PEF.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & PEF_toggled == false)
                {
                    Toggle_PEF.isOn = false;
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
                    PEF_toggled = false;
                }
            }


        }

    }
    private void ClickedPIFToggle(bool Value)
    {
        if (Toggle_PIF.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (PIF_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 5;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.PIF.ToString();
                        filledBoxes[i] = true;
                        PIF_toggled = true;
                        Toggle_PIF.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & PIF_toggled == false)
                {
                    Toggle_PIF.isOn = false;
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
                    PIF_toggled = false;
                }
            }


        }

    }
    private void ClickedPImaxToggle(bool Value)
    {
        if (Toggle_PImax.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (PImax_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 6;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.PImax.ToString();
                        filledBoxes[i] = true;
                        PImax_toggled = true;
                        Toggle_PImax.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & PImax_toggled == false)
                {
                    Toggle_PImax.isOn = false;
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
                    PImax_toggled = false;
                }
            }


        }

    }
    private void ClickedPEmaxToggle(bool Value)
    {
        if (Toggle_PEmax.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (PEmax_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 7;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.PEmax.ToString();
                        filledBoxes[i] = true;
                        PEmax_toggled = true;
                        Toggle_PEmax.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & PEmax_toggled == false)
                {
                    Toggle_PEmax.isOn = false;
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
                    PEmax_toggled = false;
                }
            }


        }

    }
    private void ClickedVECapToggle(bool Value)
    {
        if (Toggle_VECap.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (VECap_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 8;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.Vecap.ToString();
                        filledBoxes[i] = true;
                        VECap_toggled = true;
                        Toggle_VECap.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & VECap_toggled == false)
                {
                    Toggle_VECap.isOn = false;
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
                    VECap_toggled = false;
                }
            }


        }

    }
    private void ClickedERVToggle(bool Value)
    {
        if (Toggle_ERV.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (ERV_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 9;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.ERV.ToString();
                        filledBoxes[i] = true;
                        ERV_toggled = true;
                        Toggle_ERV.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & ERV_toggled == false)
                {
                    Toggle_ERV.isOn = false;
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
                    ERV_toggled = false;
                }
            }


        }

    }
    private void ClickedFRCToggle(bool Value)
    {
        if (Toggle_FRC.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (FRC_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 10;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.FRC.ToString();
                        filledBoxes[i] = true;
                        FRC_toggled = true;
                        Toggle_FRC.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & FRC_toggled == false)
                {
                    Toggle_FRC.isOn = false;
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
                    FRC_toggled = false;
                }
            }


        }

    }
    private void ClickedICToggle(bool Value)
    {
        if (Toggle_IC.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (IC_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 11;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.IC.ToString();
                        filledBoxes[i] = true;
                        IC_toggled = true;
                        Toggle_IC.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & IC_toggled == false)
                {
                    Toggle_IC.isOn = false;
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
                    IC_toggled = false;
                }
            }


        }

    }
    private void ClickedIRVToggle(bool Value)
    {
        if (Toggle_IRV.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (IRV_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 12;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.IRV.ToString();
                        filledBoxes[i] = true;
                        IRV_toggled = true;
                        Toggle_IRV.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & IRV_toggled == false)
                {
                    Toggle_IRV.isOn = false;
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
                    IRV_toggled = false;
                }
            }


        }

    }
    private void ClickedRVToggle(bool Value)
    {
        if (Toggle_RV.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (RV_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 13;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.RV.ToString();
                        filledBoxes[i] = true;
                        RV_toggled = true;
                        Toggle_RV.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & RV_toggled == false)
                {
                    Toggle_RV.isOn = false;
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
                    RV_toggled = false;
                }
            }


        }

    }
    private void ClickedTLCToggle(bool Value)
    {
        if (Toggle_TLC.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (TLC_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 14;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.TLC.ToString();
                        filledBoxes[i] = true;
                        TLC_toggled = true;
                        Toggle_TLC.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & TLC_toggled == false)
                {
                    Toggle_TLC.isOn = false;
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
                    TLC_toggled = false;
                }
            }


        }

    }
    private void ClickedVCToggle(bool Value)
    {
        if (Toggle_VC.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (VC_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 15;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.VC.ToString();
                        filledBoxes[i] = true;
                        VC_toggled = true;
                        Toggle_VC.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & VC_toggled == false)
                {
                    Toggle_VC.isOn = false;
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
                    VC_toggled = false;
                }
            }


        }

    }
}
