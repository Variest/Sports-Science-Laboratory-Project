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
        ToggleVE.onValueChanged.AddListener((Value) => { ClickedVEToggle(Value); });
        ToggleVT.onValueChanged.AddListener((Value) => { ClickedVTToggle(Value); });
        ToggleVO2.onValueChanged.AddListener((Value) => { ClickedVO2Toggle(Value); });
        ToggleVCO2.onValueChanged.AddListener((Value) => { ClickedVCO2Toggle(Value); });
        ToggleFr.onValueChanged.AddListener((Value) => { ClickedFrToggle(Value); });
        ToggleMET.onValueChanged.AddListener((Value) => { ClickedMETToggle(Value); });
        ToggleFc.onValueChanged.AddListener((Value) => { ClickedFcToggle(Value); });
        ToggleRER.onValueChanged.AddListener((Value) => { ClickedRERToggle(Value); });
        ToggleVEVO2.onValueChanged.AddListener((Value) => { ClickedVEVO2Toggle(Value); });
        ToggleVEVCO2.onValueChanged.AddListener((Value) => { ClickedVEVCO2Toggle(Value); });
        TogglePETCO2.onValueChanged.AddListener((Value) => { ClickedPETCO2Toggle(Value); });
        TogglePETO2.onValueChanged.AddListener((Value) => { ClickedPETO2Toggle(Value); });
        ToggleTE.onValueChanged.AddListener((Value) => { ClickedTEToggle(Value); });
        ToggleTI.onValueChanged.AddListener((Value) => { ClickedTIToggle(Value); });
        ToggleTITE.onValueChanged.AddListener((Value) => { ClickedTITEToggle(Value); });
        ToggleTToT.onValueChanged.AddListener((Value) => { ClickedTToTToggle(Value); });
        ToggleVO2FR.onValueChanged.AddListener((Value) => { ClickedVO2FRToggle(Value); });
        ToggleVO2FC.onValueChanged.AddListener((Value) => { ClickedVO2FCToggle(Value); });
        ToggleSpO2.onValueChanged.AddListener((Value) => { ClickedSpO2Toggle(Value); });
        ToggleFcmax.onValueChanged.AddListener((Value) => { ClickedFcmaxToggle(Value); });
        ToggleFcres.onValueChanged.AddListener((Value) => { ClickedFcresToggle(Value); });
        ToggleEE.onValueChanged.AddListener((Value) => { ClickedEEToggle(Value); });
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
    private void ClickedVEToggle(bool Value)
    {
        if(ToggleVE.isOn)
        {
            
                for (int i = 0; i < 10; i++)
                {
                    if (filledBoxes[i] == false)
                    {
                        if(VEtoggled == false)
                        {
                            Debug.Log("filledBoxes works");
                            BoxValue[i] = 1;
                            //textBoxes[i].text = "ve";
                            textBoxes[i].text = avatar.VE.ToString();
                            filledBoxes[i] = true;
                            VEtoggled = true;
                            ToggleVE.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                    }
                    else if(filledBoxes[i] == true & VEtoggled == false)
                    {
                       ToggleVE.isOn = false;
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
                    VEtoggled = false;
                }
            }
       
        
        }
        
    }
    private void ClickedVTToggle(bool Value)
    {
        if (ToggleVT.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (VTtoggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 2;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.VT.ToString();
                        filledBoxes[i] = true;
                        VTtoggled = true;
                        ToggleVT.isOn = false;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & VTtoggled == false)
                {
                    ToggleVT.isOn = false;
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
                    VTtoggled = false;
                }
            }


        }
    }
    private void ClickedVO2Toggle(bool Value)
    {
        if (ToggleVO2.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (VO2toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 3;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.VO2.ToString();
                        filledBoxes[i] = true;
                        VO2toggled = true;
                        ToggleVO2.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & VO2toggled == false)
                {
                    ToggleVO2.isOn = false;
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
                    VO2toggled = false;
                }
            }


        }
    }
    private void ClickedVCO2Toggle(bool Value)
    {
        if (ToggleVCO2.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (VCO2toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 4;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.VCO2.ToString();
                        filledBoxes[i] = true;
                        VCO2toggled = true;
                        ToggleVCO2.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & VCO2toggled == false)
                {
                    ToggleVCO2.isOn = false;
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
                    VCO2toggled = false;
                }
            }


        }
    }
    private void ClickedFrToggle(bool Value)
    {
        if (ToggleFr.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (frToggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 5;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.fr.ToString();
                        filledBoxes[i] = true;
                        frToggled = true;
                        ToggleFr.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & frToggled == false)
                {
                    ToggleFr.isOn = false;
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
                    frToggled = false;
                }
            }


        }
    }
    private void ClickedMETToggle(bool Value)
    {
        if (ToggleMET.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (METtoggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 6;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.MET.ToString();
                        filledBoxes[i] = true;
                        METtoggled = true;
                        ToggleMET.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & METtoggled == false)
                {
                    ToggleMET.isOn = false;
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
                    METtoggled = false;
                }
            }


        }
    }
    private void ClickedFcToggle(bool Value)
    {
        if (ToggleFc.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (FCtoggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 7;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.fc.ToString();
                        filledBoxes[i] = true;
                        FCtoggled = true;
                        ToggleFc.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & FCtoggled == false)
                {
                    ToggleFc.isOn = false;
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
                    FCtoggled = false;
                }
            }


        }
    }
    private void ClickedRERToggle(bool Value)
    {
        if (ToggleRER.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (RERtoggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 8;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.RER.ToString();
                        filledBoxes[i] = true;
                        RERtoggled = true;
                        ToggleRER.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & RERtoggled == false)
                {
                    ToggleRER.isOn = false;
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
                    RERtoggled = false;
                }
            }


        }
    }
    private void ClickedVEVO2Toggle(bool Value)
    {
        if (ToggleVEVO2.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (VEVO2toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 9;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.VeVO2.ToString();
                        filledBoxes[i] = true;
                        VEVO2toggled = true;
                        ToggleVEVO2.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & VEVO2toggled == false)
                {
                    ToggleVEVO2.isOn = false;
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
                    VEVO2toggled = false;
                }
            }


        }
    }
    private void ClickedVEVCO2Toggle(bool Value)
    {
        if (ToggleVEVCO2.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (VEVCO2toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 10;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.VeVCO2.ToString();
                        filledBoxes[i] = true;
                        VEVCO2toggled = true;
                        ToggleVEVCO2.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & VEVCO2toggled == false)
                {
                    ToggleVEVCO2.isOn = false;
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
                    VEVCO2toggled = false;
                    
                }
            }


        }
    }
    private void ClickedPETCO2Toggle(bool Value)
    {
        if (TogglePETCO2.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (PETCO2toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 11;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.petco2.ToString();
                        filledBoxes[i] = true;
                        PETCO2toggled = true;
                        TogglePETCO2.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & PETCO2toggled == false)
                {
                    TogglePETCO2.isOn = false;
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
                    PETCO2toggled = false;
                }
            }


        }
    }
    private void ClickedPETO2Toggle(bool Value)
    {
        if (TogglePETO2.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (PETO2toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 12;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.peto2.ToString();
                        filledBoxes[i] = true;
                        PETO2toggled = true;
                        TogglePETO2.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & PETO2toggled == false)
                {
                    TogglePETO2.isOn = false;
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
                    PETO2toggled = false;
                }
            }


        }
    }
    private void ClickedTEToggle(bool Value)
    {
        if (ToggleTE.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (TEtoggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 13;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.TE.ToString();
                        filledBoxes[i] = true;
                        TEtoggled = true;
                        ToggleTE.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & TEtoggled == false)
                {
                    ToggleTE.isOn = false;
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
                    TEtoggled = false;
                }
            }


        }
    }
    private void ClickedTIToggle(bool Value)
    {
        if (ToggleTI.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (TItoggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 14;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.TI.ToString();
                        filledBoxes[i] = true;
                        TItoggled = true;
                        ToggleTI.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & TItoggled == false)
                {
                    ToggleTI.isOn = false;
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
                    TItoggled = false;
                }
            }


        }
    }
    private void ClickedTITEToggle(bool Value)
    {
        if (ToggleTITE.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (TITEtoggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 15;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.TITE.ToString();
                        filledBoxes[i] = true;
                        TITEtoggled = true;
                        ToggleTITE.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & TITEtoggled == false)
                {
                    ToggleTITE.isOn = false;
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
                    TITEtoggled = false;
                }
            }


        }
    }
    private void ClickedTToTToggle(bool Value)
    {
        if (ToggleTToT.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (TToTtoggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 16;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.Ttot.ToString();
                        filledBoxes[i] = true;
                        TToTtoggled = true;
                        ToggleTToT.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & TToTtoggled == false)
                {
                    ToggleTToT.isOn = false;
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
                    TToTtoggled = false;
                }
            }


        }
    }
    private void ClickedVO2FRToggle(bool Value)
    {
        if (ToggleVO2FR.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (VO2FRtoggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 17;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.VO2fr.ToString();
                        filledBoxes[i] = true;
                        VO2FRtoggled = true;
                        ToggleVO2FR.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & VO2FRtoggled == false)
                {
                    ToggleVO2FR.isOn = false;
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
                    VO2FRtoggled = false;
                }
            }


        }
    }
    private void ClickedVO2FCToggle(bool Value)
    {
        if (ToggleVO2FC.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (VO2FCtoggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 18;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.VO2fc.ToString();
                        filledBoxes[i] = true;
                        VO2FCtoggled = true;
                        ToggleVO2FC.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & VO2FCtoggled == false)
                {
                    ToggleVO2FC.isOn = false;
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
                    VO2FCtoggled = false;
                }
            }


        }
    }
    private void ClickedSpO2Toggle(bool Value)
    {
        if (ToggleSpO2.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (SpO2toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 19;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.SpO2.ToString();
                        filledBoxes[i] = true;
                        SpO2toggled = true;
                        ToggleSpO2.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & SpO2toggled == false)
                {
                    ToggleSpO2.isOn = false;
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
                    SpO2toggled = false;
                }
            }


        }
    }
    private void ClickedFcmaxToggle(bool Value)
    {
        if (ToggleFcmax.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (FcMAXtoggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 20;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.FCmax.ToString();
                        filledBoxes[i] = true;
                        FcMAXtoggled = true;
                        ToggleFcmax.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & FcMAXtoggled == false)
                {
                    ToggleFcmax.isOn = false;
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
                    FcMAXtoggled = false;
                }
            }


        }
    }
    private void ClickedFcresToggle(bool Value)
    {
        if (ToggleFcres.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (FcREStoggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 21;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.FCres.ToString();
                        filledBoxes[i] = true;
                        FcREStoggled = true;
                        ToggleFcres.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & FcREStoggled == false)
                {
                    ToggleFcres.isOn = false;
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
                    FcREStoggled = false;
                }
            }


        }
    }
    private void ClickedEEToggle(bool Value)
    {
        if (ToggleEE.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (EEtoggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 22;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.EE.ToString();
                        filledBoxes[i] = true;
                        EEtoggled = true;
                        ToggleEE.isOn = true; //stops the loop from turning the toggle box off
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & EEtoggled == false)
                {
                    ToggleEE.isOn = false;
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
                    EEtoggled = false;
                }
            }


        }
    }


}
