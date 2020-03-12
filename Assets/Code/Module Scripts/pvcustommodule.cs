using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pvcustommodule : MonoBehaviour
{
    public Text[] textBoxes = new Text[10];
    public string[] textBoxContent = new string[10];
    public string[] nameBoxes = new string[10];
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


    public Button FVC_button;
    public Button FEV1_button;
    public Button FEV1FVC_button;
    public Button PEF_button;
    public Button PIF_button;
    public Button PImax_button;
    public Button PEmax_button;
    public Button VECap_button;
    public Button ERV_button;
    public Button FRC_button;
    public Button IC_button;
    public Button IRV_button;
    public Button RV_button;
    public Button TLC_button;
    public Button VC_button;

    

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
        for(int i = 0; i < 10; i++)
        {
            BoxValue.Add(0);
        }
       

    }

    public void AttachButtons()
    {
        //get the buttons from the UI 
        Debug.Log("Buttons attached");
        //add the onlick events to the buttons
        FVC_button.onClick.AddListener(ClickedFVCToggle);
        FEV1_button.onClick.AddListener(ClickedFEV1Toggle);
        FEV1FVC_button.onClick.AddListener(ClickedFEV1FVCToggle);
        PEF_button.onClick.AddListener(ClickedPEFToggle);
        PIF_button.onClick.AddListener(ClickedPIFToggle);
        PImax_button.onClick.AddListener(ClickedPImaxToggle);
        PEmax_button.onClick.AddListener(ClickedPEmaxToggle);
        VECap_button.onClick.AddListener(ClickedVECapToggle);
        ERV_button.onClick.AddListener(ClickedERVToggle);
        FRC_button.onClick.AddListener(ClickedFRCToggle);
        IC_button.onClick.AddListener(ClickedICToggle);
        IRV_button.onClick.AddListener(ClickedIRVToggle);
        RV_button.onClick.AddListener(ClickedRVToggle);
        TLC_button.onClick.AddListener(ClickedTLCToggle);
        VC_button.onClick.AddListener(ClickedVCToggle);
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
    private void ClickedFVCToggle()
    {
        Debug.Log("Hey this is kinda quirky tho :>>>");
        if (!FVC_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!FVC_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 1;
                        textBoxContent[i] = avatar.FVC.ToString();
                        //textBoxes[i].text = avatar.FVC.ToString();
                        nameBoxes[i] = "FVC ";
                        filledBoxes[i] = true;
                        FVC_toggled = true;
                        FVC_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;

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
                    //textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    FVC_toggled = false;
                    FVC_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }

    }
    private void ClickedFEV1Toggle()
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
                        BoxValue[i] = 2;
                        textBoxContent[i] = avatar.FEV1.ToString();
                        //textBoxes[i].text = avatar.FEV1.ToString();
                        nameBoxes[i] = "FEV1 ";
                        filledBoxes[i] = true;
                        FEV1_toggled = true;
                        FEV1_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
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
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    FEV1_toggled = false;
                    FEV1_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }

    }
    private void ClickedFEV1FVCToggle()
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
                        BoxValue[i] = 3;
                        textBoxContent[i] = avatar.FEV1FVC.ToString();
                        //textBoxes[i].text = avatar.FEV1FVC.ToString();
                        nameBoxes[i] = "FEV1FVC ";
                        filledBoxes[i] = true;
                        FEV1FVC_toggled = true;
                        FEV1FVC_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
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
    private void ClickedPEFToggle()
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
                        BoxValue[i] = 4;
                        textBoxContent[i] = avatar.PEF.ToString();
                        //textBoxes[i].text = avatar.PEF.ToString();
                        nameBoxes[i] = "PEF ";
                        filledBoxes[i] = true;
                        PEF_toggled = true;
                        PEF_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;

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
                    PEF_toggled = false;
                    PEF_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }

    }
    private void ClickedPIFToggle()
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
                        BoxValue[i] = 5;
                        textBoxContent[i] = avatar.PIF.ToString();
                        //textBoxes[i].text = avatar.PIF.ToString();
                        nameBoxes[i] = "PIF ";
                        filledBoxes[i] = true;
                        PIF_toggled = true;
                        PIF_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
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
                    PIF_toggled = false;
                    PIF_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }

    }
    private void ClickedPImaxToggle()
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
                        BoxValue[i] = 6;
                        textBoxContent[i] = avatar.PImax.ToString();
                        //textBoxes[i].text = avatar.PImax.ToString();
                        nameBoxes[i] = "PImax ";
                        filledBoxes[i] = true;
                        PImax_toggled = true;
                        PImax_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
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
                    PImax_toggled = false;
                    PImax_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }

    }
    private void ClickedPEmaxToggle()
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
                        BoxValue[i] = 7;
                        textBoxContent[i] = avatar.PEmax.ToString();
                        //textBoxes[i].text = avatar.PEmax.ToString();
                        nameBoxes[i] = "PEmax ";
                        filledBoxes[i] = true;
                        PEmax_toggled = true;
                        PEmax_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;

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
    private void ClickedVECapToggle()
    {
        if (!VECap_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!VECap_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 8;
                        textBoxContent[i] = avatar.Vecap.ToString();
                        //textBoxes[i].text = avatar.Vecap.ToString();
                        nameBoxes[i] = "VEcap ";
                        filledBoxes[i] = true;
                        VECap_toggled = true;
                        VECap_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
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
                    textBoxContent[i] = "";
                    //textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    VECap_toggled = false;
                    VECap_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }

    }
    private void ClickedERVToggle()
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
                        BoxValue[i] = 9;
                        textBoxContent[i] = avatar.ERV.ToString();
                        //textBoxes[i].text = avatar.ERV.ToString();
                        nameBoxes[i] = "ERV ";
                        filledBoxes[i] = true;
                        ERV_toggled = true;
                        ERV_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
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
                    ERV_toggled = false;
                    ERV_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }

    }
    private void ClickedFRCToggle()
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
                        BoxValue[i] = 10;
                        textBoxContent[i] = avatar.FRC.ToString();
                        //textBoxes[i].text = avatar.FRC.ToString();
                        nameBoxes[i] = "FRC ";
                        filledBoxes[i] = true;
                        FRC_toggled = true;
                        FRC_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
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
                    FRC_toggled = false;
                    FRC_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }

    }
    private void ClickedICToggle()
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
                        BoxValue[i] = 11;
                        textBoxContent[i] = avatar.IC.ToString();
                        //textBoxes[i].text = avatar.IC.ToString();
                        nameBoxes[i] = "IC";
                        filledBoxes[i] = true;
                        IC_toggled = true;
                        IC_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
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
                    IC_toggled = false;
                    IC_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }

    }
    private void ClickedIRVToggle()
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
                        BoxValue[i] = 12;
                        textBoxContent[i] = avatar.IRV.ToString();
                        //textBoxes[i].text = avatar.IRV.ToString();
                        nameBoxes[i] = "IRV ";
                        filledBoxes[i] = true;
                        IRV_toggled = true;
                        IRV_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
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
                    IRV_toggled = false;
                    IRV_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }

    }
    private void ClickedRVToggle()
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
                        BoxValue[i] = 13;
                        textBoxContent[i] = avatar.RV.ToString();
                        //textBoxes[i].text = avatar.RV.ToString();
                        nameBoxes[i] = "RV ";
                        filledBoxes[i] = true;
                        RV_toggled = true;
                        RV_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
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
                    RV_toggled = false;
                    RV_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }

    }
    private void ClickedTLCToggle()
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
                        BoxValue[i] = 14;
                        textBoxContent[i] = avatar.TLC.ToString();
                        //textBoxes[i].text = avatar.TLC.ToString();
                        nameBoxes[i] = "TLC ";
                        filledBoxes[i] = true;
                        TLC_toggled = true;
                        TLC_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
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
                    TLC_toggled = false;
                    TLC_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }

    }
    private void ClickedVCToggle()
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
                        BoxValue[i] = 15;
                        textBoxContent[i] = avatar.VC.ToString();
                        //textBoxes[i].text = avatar.VC.ToString();
                        nameBoxes[i] = "VC ";
                        filledBoxes[i] = true;
                        VC_toggled = true;
                        VC_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
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
                    VC_toggled = false;
                    VC_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
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
        FVC_toggled = false; //stops every single box from being filled by a single variable each time
        FEV1FVC_toggled = false;
        PEF_toggled = false;
        PIF_toggled = false;
        PImax_toggled = false;
        PEmax_toggled = false;
        VECap_toggled = false;
        ERV_toggled = false;
        FRC_toggled = false;
        IC_toggled = false;
        IRV_toggled = false;
        RV_toggled = false;
        TLC_toggled = false;
        VC_toggled = false;




    }
}
