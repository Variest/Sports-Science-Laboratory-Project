using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomModuleTester : MonoBehaviour
{
    // ended up just turning this one into the full metabolic cart module, can't be fucked to rename it so this is staying

    //Metabolic Cart as example: 

    //variables used:
    //VE
    //VT
    //VO2
    //VCO2
    //fr
    //MET
    //fc
    //RER
    //VE/VO2
    //VE/VCO2
    //PETCO2
    //PETO2
    //TE
    //TI
    //TI/TE
    //TToT
    //VO2/fr
    //VO2/fc
    //SpO2
    //fcmax
    //fcres
    //EE

    //max of 10 variables on screen at once afaik - 
    //have 10 text boxes and just assign them based on what order
    //you clicked the things in? not fully sure how to implement that
    //will it just be a shit ton of if and case statements? a bit of a brainlet way to do it but I'm a brainlet so big lol

    //OUTLINE - HOW IT WILL WORK
    //-when the advanced module is selected it will display a list of all the variables and a tick box next to them
    //clicking the tick box will add that variable to the next empty box available
    //unclicking the tick box will need to remove that variable from the box - this will require me to track the values of which box each one has gone into.
    //need to be able to make the variables update as the rest of the program does too - will be the hardest part most likely as requires tracking which value needs to be assigned 
    //to each slot and have it written every update.
    //could make loads of int variables that say what box each value is in and if the array value for the box is equal to that it will write out that variable?
    //a bit messy but at this point i'll take whatever I'm given tbh.




    //public GameObject[] ResultBox = new GameObject[10]; //array holding each of the text elements that will display results on the screen

    public string[] textBoxContent = new string[10];
    public Text[] textBoxes = new Text[10];
    public string[] nameBoxes = new string[10];
   

    public Button VE_button;
    public Button VT_button;
    public Button VO2_button;
    public Button VCO2_button;
    public Button FR_button;
    public Button MET_button;
    public Button Fc_button;
    public Button RER_button;
    public Button VEVO2_button;
    public Button VEVCO2_button;
    public Button PETCO2_button;
    public Button PETO2_button;
    public Button TE_button;
    public Button TI_button;
    public Button TITE_button;
    public Button TToT_button;
    public Button VO2FR_button;
    public Button VO2FC_button;
    public Button SpO2_button;
    public Button Fcmax_button;
    public Button Fcres_button;
    public Button EE_button;



    public GameObject avatarHolder; //gameobject that will have the avatar script within it
    public CharacterAvatar avatar; //gets a reference to the character undergoing the module

    public bool[] filledBoxes = new bool[10]; //array that will hold a true or false value for whether there is a value currently entered into the box

    public List<int> BoxValue = new List<int>(); //a list that will contain an int relating to the equation that is active inside that box. 1-22

    public bool VE_toggled; //stops every single box from being filled by a single variable each time
    public bool VT_toggled;
    public bool VO2_toggled;
    public bool VCO2_toggled;
    public bool fr_toggled;
    public bool MET_toggled;
    public bool FC_toggled;
    public bool RER_toggled;
    public bool VEVO2_toggled;
    public bool VEVCO2_toggled;
    public bool PETCO2_toggled;
    public bool PETO2_toggled;
    public bool TE_toggled;
    public bool TI_toggled;
    public bool TITE_toggled;
    public bool TToT_toggled;
    public bool VO2FR_toggled;
    public bool VO2FC_toggled;
    public bool SpO2_toggled;
    public bool FcMAX_toggled;
    public bool FcRES_toggled;
    public bool EE_toggled;

    void Start()
    {

        avatar = avatarHolder.GetComponent<CharacterAvatar>();
        //add listening events to each one of the toggle boxes 
        for (int i = 0; i < 10; i++)
        {
            BoxValue.Add(0);
        }

    }

    public void AttachButtons()
    {
        VE_button.onClick.AddListener(ClickedVEToggle);
        VT_button.onClick.AddListener(ClickedVTToggle);
        VO2_button.onClick.AddListener(ClickedVO2Toggle);
        VCO2_button.onClick.AddListener(ClickedVCO2Toggle);
        FR_button.onClick.AddListener(ClickedFrToggle);
        MET_button.onClick.AddListener(ClickedMETToggle);
        Fc_button.onClick.AddListener(ClickedFcToggle);
        RER_button.onClick.AddListener(ClickedRERToggle);
        VEVO2_button.onClick.AddListener(ClickedVEVO2Toggle);
        VEVCO2_button.onClick.AddListener(ClickedVEVCO2Toggle);
        PETCO2_button.onClick.AddListener(ClickedPETCO2Toggle);
        PETO2_button.onClick.AddListener(ClickedPETO2Toggle);
        TE_button.onClick.AddListener(ClickedTEToggle);
        TI_button.onClick.AddListener(ClickedTIToggle);
        TITE_button.onClick.AddListener(ClickedTITEToggle);
        TToT_button.onClick.AddListener(ClickedTToTToggle);
        VO2FR_button.onClick.AddListener(ClickedVO2FRToggle);
        VO2FC_button.onClick.AddListener(ClickedVO2FCToggle);
        SpO2_button.onClick.AddListener(ClickedSpO2Toggle);
        Fcmax_button.onClick.AddListener(ClickedFcmaxToggle);
        Fcres_button.onClick.AddListener(ClickedFcresToggle);
        EE_button.onClick.AddListener(ClickedEEToggle);
    }
    // Update is called once per frame
    void Update()
    {
        //will probably update the values for each box here using a case statement inside a for loop? 
        //Debug.Log(BoxValue[0]);
        //for(int i = 0; i < 10; i++)
        //{
        //    if(filledBoxes[i] != false)
        //    {
        //        switch(BoxValue[i])
        //        {
        //            case 1:
        //                textBoxes[i].text = avatar.VE.ToString();
        //                break;
        //            case 2:
        //                textBoxes[i].text = avatar.VT.ToString();
        //                break;
        //            case 3:
        //                textBoxes[i].text = avatar.VO2.ToString();
        //                break;
        //            case 4:
        //                textBoxes[i].text = avatar.VCO2.ToString();
        //                break;
        //            case 5:
        //                textBoxes[i].text = avatar.fr.ToString();
        //                break;
        //            case 6:
        //                textBoxes[i].text = avatar.MET.ToString();
        //                break;
        //            case 7:
        //                textBoxes[i].text = avatar.fc.ToString(); 
        //                break;
        //            case 8:
        //                textBoxes[i].text = avatar.RER.ToString();
        //                break;
        //            case 9:
        //                textBoxes[i].text = avatar.VeVO2.ToString();
        //                break;
        //            case 10:
        //                textBoxes[i].text = avatar.VeVCO2.ToString();
        //                break;
        //            case 11:
        //                textBoxes[i].text = avatar.petco2.ToString(); 
        //                break;
        //            case 12:
        //                textBoxes[i].text = avatar.petco2.ToString();
        //                break;
        //            case 13:
        //                textBoxes[i].text = avatar.TE.ToString();
        //                break;
        //            case 14:
        //                textBoxes[i].text = avatar.TI.ToString();
        //                break;
        //            case 15:
        //                textBoxes[i].text = avatar.TITE.ToString();
        //                break;
        //            case 16:
        //                textBoxes[i].text = avatar.Ttot.ToString();
        //                break;
        //            case 17:
        //                textBoxes[i].text = avatar.VO2fr.ToString();
        //                break;
        //            case 18:
        //                textBoxes[i].text = avatar.VO2fc.ToString(); 
        //                break;
        //            case 19:
        //                textBoxes[i].text = avatar.SpO2.ToString(); 
        //                break;
        //            case 20:
        //                textBoxes[i].text = avatar.FCmax.ToString(); 
        //                break;
        //            case 21:
        //                textBoxes[i].text = avatar.FCres.ToString(); 
        //                break;
        //            case 22:
        //                textBoxes[i].text = avatar.EE.ToString(); 
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
    private void ClickedVEToggle()
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
                        BoxValue[i] = 1;

                        textBoxContent[i] = avatar.VE.ToString();
                        //textBoxes[i].text = avatar.VE.ToString();
                        nameBoxes[i] = "VE ";
                        filledBoxes[i] = true;
                        VE_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                        VE_toggled = true;

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
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    VE_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                    VE_toggled = false;
                }
            }
       
        
        }
        
    }
    private void ClickedVTToggle()
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
                        BoxValue[i] = 2;
                        textBoxContent[i] = avatar.VT.ToString();
                        //textBoxes[i].text = avatar.VT.ToString();
                        nameBoxes[i] = "VT ";
                        filledBoxes[i] = true;
                        VT_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                        VT_toggled = true;

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
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    VT_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                    VT_toggled = false;
                }
            }


        }
    }
    private void ClickedVO2Toggle()
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
                        BoxValue[i] = 3;
                        textBoxContent[i] = avatar.VO2.ToString();
                        //textBoxes[i].text = avatar.VO2.ToString();
                        nameBoxes[i] = "VO2 ";
                        filledBoxes[i] = true;
                        VO2_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                        VO2_toggled = true;

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
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    VO2_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                    VO2_toggled = false;
                }
            }


        }
    }
    private void ClickedVCO2Toggle()
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
                        BoxValue[i] = 4;
                        textBoxContent[i] = avatar.VCO2.ToString();
                        //textBoxes[i].text = avatar.VCO2.ToString();
                        nameBoxes[i] = "VCO2 ";
                        filledBoxes[i] = true;
                        VCO2_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                        VCO2_toggled = true;

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
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    VCO2_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                    VCO2_toggled = false;
                }
            }


        }
    }
    private void ClickedFrToggle()
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
                        BoxValue[i] = 5;
                        textBoxContent[i] = avatar.fr.ToString();
                        //textBoxes[i].text = avatar.fr.ToString();
                        nameBoxes[i] = "fr ";
                        filledBoxes[i] = true;
                        fr_toggled = true;
                        FR_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                       
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
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    fr_toggled = false;
                    FR_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }
    }
    private void ClickedMETToggle()
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
                        BoxValue[i] = 6;
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
                if (BoxValue[i] == 6)
                {
                    filledBoxes[i] = false;
                    textBoxContent[i] = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    MET_toggled = false;
                    MET_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }
    }
    private void ClickedFcToggle()
    {
        if (!FC_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!FC_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 7;
                        textBoxContent[i] = avatar.fc.ToString();
                        //textBoxes[i].text = avatar.fc.ToString();
                        nameBoxes[i] = "FC ";
                        filledBoxes[i] = true;
                        FC_toggled = true;
                        Fc_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
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
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    FC_toggled = false;
                    Fc_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }
    }
    private void ClickedRERToggle()
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
                        BoxValue[i] = 8;
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
                if (BoxValue[i] == 8)
                {
                    filledBoxes[i] = false;
                    textBoxContent[i] = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    RER_toggled = false;
                    RER_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }
    }
    private void ClickedVEVO2Toggle()
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
                        BoxValue[i] = 9;
                        textBoxContent[i] = avatar.VeVO2.ToString();
                        //textBoxes[i].text = avatar.VeVO2.ToString();
                        nameBoxes[i] = "VEVO2 ";
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
                if (BoxValue[i] == 9)
                {
                    filledBoxes[i] = false;
                    textBoxContent[i] = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    VEVO2_toggled = false;
                    VEVO2_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }
    }
    private void ClickedVEVCO2Toggle()
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
                        BoxValue[i] = 10;
                        textBoxContent[i] = avatar.VeVCO2.ToString();
                       // textBoxes[i].text = avatar.VeVCO2.ToString();
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
                if (BoxValue[i] == 10)
                {
                    filledBoxes[i] = false;
                    textBoxContent[i] = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    VEVCO2_toggled = false;
                    VEVCO2_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }
    }
    private void ClickedPETCO2Toggle()
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
                        BoxValue[i] = 11;
                        textBoxContent[i] = avatar.petco2.ToString();
                        //textBoxes[i].text = avatar.petco2.ToString();
                        nameBoxes[i] = "PETCO2 ";
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
                if (BoxValue[i] == 11)
                {
                    filledBoxes[i] = false;
                    textBoxContent[i] = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    PETCO2_toggled = false;
                    PETCO2_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }
    }
    private void ClickedPETO2Toggle()
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
                        BoxValue[i] = 12;
                        textBoxContent[i] = avatar.peto2.ToString();
                        //textBoxes[i].text = avatar.peto2.ToString();
                        nameBoxes[i] = "PETO2 ";
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
                if (BoxValue[i] == 12)
                {
                    filledBoxes[i] = false;
                    textBoxContent[i] = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    PETO2_toggled = false;
                    PETO2_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }
    }
    private void ClickedTEToggle()
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
                        BoxValue[i] = 13;
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
                if (BoxValue[i] == 13)
                {
                    filledBoxes[i] = false;
                    textBoxContent[i] = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    TE_toggled = false;
                    TE_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }
    }
    private void ClickedTIToggle()
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
                        BoxValue[i] = 14;
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
                if (BoxValue[i] == 14)
                {
                    filledBoxes[i] = false;
                    textBoxContent[i] = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    TI_toggled = false;
                    TI_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }
    }
    private void ClickedTITEToggle()
    {
        if (!TITE_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!TITE_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 15;
                        textBoxContent[i] = avatar.TITE.ToString();
                        //textBoxes[i].text = avatar.TITE.ToString();
                        nameBoxes[i] = "TITE ";
                        filledBoxes[i] = true;
                        TITE_toggled = true;
                        TITE_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
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
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    TITE_toggled = false;
                    TITE_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }
    }
    private void ClickedTToTToggle()
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
                        BoxValue[i] = 16;
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
                if (BoxValue[i] == 16)
                {
                    filledBoxes[i] = false;
                    textBoxContent[i] = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    TToT_toggled = false;
                    TToT_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }
    }
    private void ClickedVO2FRToggle()
    {
        if (!VO2FR_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!VO2FR_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 17;
                        textBoxContent[i] = avatar.VO2fr.ToString();
                        //textBoxes[i].text = avatar.VO2fr.ToString();
                        nameBoxes[i] = "VO2FR ";
                        filledBoxes[i] = true;
                        VO2FR_toggled = true;
                        VO2FR_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
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
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    VO2FR_toggled = false;
                    VO2FR_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }
    }
    private void ClickedVO2FCToggle()
    {
        if (!VO2FC_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!VO2FC_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 18;
                        textBoxContent[i] = avatar.VO2fc.ToString();
                        //textBoxes[i].text = avatar.VO2fc.ToString();
                        nameBoxes[i] = "VO2FC ";
                        filledBoxes[i] = true;
                        VO2FC_toggled = true;
                        VO2FC_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
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
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    VO2FC_toggled = false;
                    VO2FC_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }
    }
    private void ClickedSpO2Toggle()
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
                        BoxValue[i] = 19;
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
                if (BoxValue[i] == 19)
                {
                    filledBoxes[i] = false;
                    textBoxContent[i] = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    SpO2_toggled = false;
                    SpO2_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }
    }
    private void ClickedFcmaxToggle()
    {
        if (!FcMAX_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!FcMAX_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 20;
                        textBoxContent[i] = avatar.FCmax.ToString();
                        //textBoxes[i].text = avatar.FCmax.ToString();
                        nameBoxes[i] = "FCmax ";
                        filledBoxes[i] = true;
                        FcMAX_toggled = true;
                        Fcmax_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                        
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
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    FcMAX_toggled = false;
                    Fcmax_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }
    }
    private void ClickedFcresToggle()
    {
        if (!FcRES_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!FcRES_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 21;
                        textBoxContent[i] = avatar.FCres.ToString();
                       // textBoxes[i].text = avatar.FCres.ToString();
                        nameBoxes[i] = "FCres ";
                        filledBoxes[i] = true;
                        FcRES_toggled = true;
                        Fcres_button.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                       
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
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    FcRES_toggled = false;
                    Fcres_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                }
            }


        }
    }
    private void ClickedEEToggle()
    {
        if (!EE_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!EE_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 22;
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
                if (BoxValue[i] == 22)
                {
                    filledBoxes[i] = false;
                    textBoxContent[i] = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    EE_toggled = false;
                    EE_button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
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
        VE_toggled = false; //stops every single box from being filled by a single variable each time
        VT_toggled = false;
        VO2_toggled = false;
        VCO2_toggled = false;
        fr_toggled = false;
        MET_toggled = false;
        FC_toggled = false;
        RER_toggled = false;
        VEVO2_toggled = false;
        VEVCO2_toggled = false;
        PETCO2_toggled = false;
        PETO2_toggled = false;
        TE_toggled = false;
        TI_toggled = false;
        TITE_toggled = false; //stops every single box from being filled by a single variable each time
        TToT_toggled = false;
        VO2FR_toggled = false;
        VO2FC_toggled = false;
        SpO2_toggled = false;
        FcMAX_toggled = false;
        FcRES_toggled = false;
        EE_toggled = false;



    }

   
  
 
}
