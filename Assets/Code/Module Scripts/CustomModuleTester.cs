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

    public Text[] textBoxes = new Text[10];
    public string[] nameBoxes = new string[10];
    //these are the toggles that will be used to add each variable into the boxes
    public Toggle ToggleVE; //1
    public Toggle ToggleVT; //2
    public Toggle ToggleVO2; //3
    public Toggle ToggleVCO2; //4
    public Toggle ToggleFr; //5
    public Toggle ToggleMET; //6
    public Toggle ToggleFc; //7
    public Toggle ToggleRER; //8
    public Toggle ToggleVEVO2; //9
    public Toggle ToggleVEVCO2; //10
    public Toggle TogglePETCO2; //11
    public Toggle TogglePETO2; //12
    public Toggle ToggleTE; //13
    public Toggle ToggleTI; //14
    public Toggle ToggleTITE; //15
    public Toggle ToggleTToT; //16
    public Toggle ToggleVO2FR; //17
    public Toggle ToggleVO2FC; //18
    public Toggle ToggleSpO2; //19
    public Toggle ToggleFcmax; //20
    public Toggle ToggleFcres; //21
    public Toggle ToggleEE; //22

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

    public bool VEtoggled; //stops every single box from being filled by a single variable each time
    public bool VTtoggled;
    public bool VO2toggled;
    public bool VCO2toggled;
    public bool frToggled;
    public bool METtoggled;
    public bool FCtoggled;
    public bool RERtoggled;
    public bool VEVO2toggled;
    public bool VEVCO2toggled;
    public bool PETCO2toggled;
    public bool PETO2toggled;
    public bool TEtoggled;
    public bool TItoggled;
    public bool TITEtoggled;
    public bool TToTtoggled;
    public bool VO2FRtoggled;
    public bool VO2FCtoggled;
    public bool SpO2toggled;
    public bool FcMAXtoggled;
    public bool FcREStoggled;
    public bool EEtoggled;

    void Start()
    {

        avatar = avatarHolder.GetComponent<CharacterAvatar>();
        //add listening events to each one of the toggle boxes 
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
        if (!VEtoggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!VEtoggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 1;

                        textBoxes[i].text = avatar.VE.ToString();
                        nameBoxes[i] = "VE ";
                        filledBoxes[i] = true;
                        VEtoggled = true;

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
                    textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    VEtoggled = false;
                }
            }
       
        
        }
        
    }
    private void ClickedVTToggle()
    {
        if (!VTtoggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!VTtoggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 2;

                        textBoxes[i].text = avatar.VT.ToString();
                        nameBoxes[i] = "VT ";
                        filledBoxes[i] = true;
                        VTtoggled = true;

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
                    textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    VTtoggled = false;
                }
            }


        }
    }
    private void ClickedVO2Toggle()
    {
        if (!VO2toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!VO2toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 3;

                        textBoxes[i].text = avatar.VO2.ToString();
                        nameBoxes[i] = "VO2 ";
                        filledBoxes[i] = true;
                        VO2toggled = true;

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
                    textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    VO2toggled = false;
                }
            }


        }
    }
    private void ClickedVCO2Toggle()
    {
        if (!VCO2toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!VCO2toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 4;

                        textBoxes[i].text = avatar.VCO2.ToString();
                        nameBoxes[i] = "VCO2 ";
                        filledBoxes[i] = true;
                        VCO2toggled = true;

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
                    textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    VCO2toggled = false;
                }
            }


        }
    }
    private void ClickedFrToggle()
    {
        if (!frToggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!frToggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 5;

                        textBoxes[i].text = avatar.fr.ToString();
                        nameBoxes[i] = "fr ";
                        filledBoxes[i] = true;
                        frToggled = true;

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
                    textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    frToggled = false;
                }
            }


        }
    }
    private void ClickedMETToggle()
    {
        if (!METtoggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!METtoggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 6;

                        textBoxes[i].text = avatar.MET.ToString();
                        nameBoxes[i] = "MET ";
                        filledBoxes[i] = true;
                        METtoggled = true;

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
                    textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    METtoggled = false;
                }
            }


        }
    }
    private void ClickedFcToggle()
    {
        if (!FCtoggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!FCtoggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 7;

                        textBoxes[i].text = avatar.fc.ToString();
                        nameBoxes[i] = "FC ";
                        filledBoxes[i] = true;
                        FCtoggled = true;

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
                    textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    FCtoggled = false;
                }
            }


        }
    }
    private void ClickedRERToggle()
    {
        if (!RERtoggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!RERtoggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 8;

                        textBoxes[i].text = avatar.RER.ToString();
                        nameBoxes[i] = "RER ";
                        filledBoxes[i] = true;
                        RERtoggled = true;

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
                    textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    RERtoggled = false;
                }
            }


        }
    }
    private void ClickedVEVO2Toggle()
    {
        if (!VEVO2toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!VEVO2toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 9;

                        textBoxes[i].text = avatar.VeVO2.ToString();
                        nameBoxes[i] = "VEVO2 ";
                        filledBoxes[i] = true;
                        VEVO2toggled = true;

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
                    textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    VEVO2toggled = false;
                }
            }


        }
    }
    private void ClickedVEVCO2Toggle()
    {
        if (!VEVCO2toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!VEVCO2toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 10;

                        textBoxes[i].text = avatar.VeVCO2.ToString();
                        nameBoxes[i] = "VEVCO2 ";
                        filledBoxes[i] = true;
                        VEVCO2toggled = true;

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
                    textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    VEVCO2toggled = false;
                    
                }
            }


        }
    }
    private void ClickedPETCO2Toggle()
    {
        if (!PETCO2toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!PETCO2toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 11;

                        textBoxes[i].text = avatar.petco2.ToString();
                        nameBoxes[i] = "PETCO2 ";
                        filledBoxes[i] = true;
                        PETCO2toggled = true;

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
                    textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    PETCO2toggled = false;
                }
            }


        }
    }
    private void ClickedPETO2Toggle()
    {
        if (!PETO2toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!PETO2toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 12;

                        textBoxes[i].text = avatar.peto2.ToString();
                        nameBoxes[i] = "PETO2 ";
                        filledBoxes[i] = true;
                        PETO2toggled = true;

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
                    textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    PETO2toggled = false;
                }
            }


        }
    }
    private void ClickedTEToggle()
    {
        if (!TEtoggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!TEtoggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 13;

                        textBoxes[i].text = avatar.TE.ToString();
                        nameBoxes[i] = "TE ";
                        filledBoxes[i] = true;
                        TEtoggled = true;

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
                    textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    TEtoggled = false;
                }
            }


        }
    }
    private void ClickedTIToggle()
    {
        if (!TItoggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!TItoggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 14;

                        textBoxes[i].text = avatar.TI.ToString();
                        nameBoxes[i] = "TI ";
                        filledBoxes[i] = true;
                        TItoggled = true;

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
                    textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    TItoggled = false;
                }
            }


        }
    }
    private void ClickedTITEToggle()
    {
        if (!TITEtoggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!TITEtoggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 15;

                        textBoxes[i].text = avatar.TITE.ToString();
                        nameBoxes[i] = "TITE ";
                        filledBoxes[i] = true;
                        TITEtoggled = true;

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
                    textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    TITEtoggled = false;
                }
            }


        }
    }
    private void ClickedTToTToggle()
    {
        if (!TToTtoggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!TToTtoggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 16;

                        textBoxes[i].text = avatar.Ttot.ToString();
                        nameBoxes[i] = "TToT ";
                        filledBoxes[i] = true;
                        TToTtoggled = true;

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
                    textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    TToTtoggled = false;
                }
            }


        }
    }
    private void ClickedVO2FRToggle()
    {
        if (!VO2FRtoggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!VO2FRtoggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 17;

                        textBoxes[i].text = avatar.VO2fr.ToString();
                        nameBoxes[i] = "VO2FR ";
                        filledBoxes[i] = true;
                        VO2FRtoggled = true;

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
                    textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    VO2FRtoggled = false;
                }
            }


        }
    }
    private void ClickedVO2FCToggle()
    {
        if (!VO2FCtoggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!VO2FCtoggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 18;

                        textBoxes[i].text = avatar.VO2fc.ToString();
                        nameBoxes[i] = "VO2FC ";
                        filledBoxes[i] = true;
                        VO2FCtoggled = true;

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
                    textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    VO2FCtoggled = false;
                }
            }


        }
    }
    private void ClickedSpO2Toggle()
    {
        if (!SpO2toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!SpO2toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 19;

                        textBoxes[i].text = avatar.SpO2.ToString();
                        nameBoxes[i] = "SpO2 ";
                        filledBoxes[i] = true;
                        SpO2toggled = true;

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
                    textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    SpO2toggled = false;
                }
            }


        }
    }
    private void ClickedFcmaxToggle()
    {
        if (!FcMAXtoggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!FcMAXtoggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 20;

                        textBoxes[i].text = avatar.FCmax.ToString();
                        nameBoxes[i] = "FCmax ";
                        filledBoxes[i] = true;
                        FcMAXtoggled = true;

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
                    textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    FcMAXtoggled = false;
                }
            }


        }
    }
    private void ClickedFcresToggle()
    {
        if (!FcREStoggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!FcREStoggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 21;

                        textBoxes[i].text = avatar.FCres.ToString();
                        nameBoxes[i] = "FCres ";
                        filledBoxes[i] = true;
                        FcREStoggled = true;

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
                    textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    FcREStoggled = false;
                }
            }


        }
    }
    private void ClickedEEToggle()
    {
        if (!EEtoggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!EEtoggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 22;

                        textBoxes[i].text = avatar.EE.ToString();
                        nameBoxes[i] = "EE ";
                        filledBoxes[i] = true;
                        EEtoggled = true;

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
                    textBoxes[i].text = "";
                    nameBoxes[i] = "";
                    BoxValue[i] = 0;
                    EEtoggled = false;
                }
            }


        }
    }


}
