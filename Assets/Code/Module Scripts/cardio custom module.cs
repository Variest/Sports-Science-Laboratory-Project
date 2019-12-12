using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cardiocustommodule : MonoBehaviour
{


    

    public Text[] textBoxes = new Text[10];
    /*
     * fc
     * vo2fc
     * MAP
     * fcmax
     * blac
     * co
     * bpd
     * bps
     * sv
     * fcres
     * spo2
     */
    public Toggle Toggle_fc; //1
    public Toggle Toggle_vo2fc; //2
    public Toggle Toggle_MAP; //3
    public Toggle Toggle_fcmax; //4
    public Toggle Toggle_bla; //5
    public Toggle Toggle_CO; //6
    public Toggle Toggle_BPd; //7
    public Toggle Toggle_BPs; //8
    public Toggle Toggle_SV; //9
    public Toggle Toggle_fcres; //10
    public Toggle Toggle_SpO2; //11

    public GameObject avatarHolder; //gameobject that will have the avatar script within it
    public CharacterAvatar avatar; //gets a reference to the character undergoing the module

    public bool[] filledBoxes = new bool[10]; //array that will hold a true or false value for whether there is a value currently entered into the box

    public List<int> BoxValue = new List<int>(); //a list that will contain an int relating to the equation that is active inside that box. 1-22

    public bool fc_toggled; //stops every single box from being filled by a single variable each time
    public bool vo2fc_toggled;
    public bool MAP_toggled;
    public bool fcmax_toggled;
    public bool bla_toggled;
    public bool CO_toggled;
    public bool BPd_toggled;
    public bool BPs_toggled;
    public bool SV_toggled;
    public bool fcres_toggled;
    public bool SpO2_toggled;
    void Start()
    {
        avatar = avatarHolder.GetComponent<CharacterAvatar>();
        //add listening events to each one of the toggle boxes 
        Toggle_fc.onValueChanged.AddListener((Value) => { ClickedfcToggle(Value); });
        Toggle_vo2fc.onValueChanged.AddListener((Value) => { Clickedvo2fcToggle(Value); });
        Toggle_MAP.onValueChanged.AddListener((Value) => { ClickedMAPToggle(Value); });
        Toggle_fcmax.onValueChanged.AddListener((Value) => { ClickedfcmaxToggle(Value); });
        Toggle_bla.onValueChanged.AddListener((Value) => { ClickedblaToggle(Value); });
        Toggle_CO.onValueChanged.AddListener((Value) => { ClickedCOToggle(Value); });
        Toggle_BPd.onValueChanged.AddListener((Value) => { ClickedBPdToggle(Value); });
        Toggle_BPs.onValueChanged.AddListener((Value) => { ClickedBPsToggle(Value); });
        Toggle_SV.onValueChanged.AddListener((Value) => { ClickedSVToggle(Value); });
        Toggle_fcres.onValueChanged.AddListener((Value) => { ClickedfcresToggle(Value); });
        Toggle_SpO2.onValueChanged.AddListener((Value) => { ClickedSPO2Toggle(Value); });

    }

    // Update is called once per frame
    void Update()
    {
        //for (int i = 0; i < 10; i++)
        //{
        //    if (filledBoxes[i] != false)
        //    {
        //        switch (BoxValue[i])
        //        {
        //            case 1:
        //                textBoxes[i].text = avatar.fc.ToString();
        //                break;
        //            case 2:
        //                textBoxes[i].text = avatar.VO2fc.ToString();
        //                break;
        //            case 3:
        //                textBoxes[i].text = avatar.MAP.ToString();
        //                break;
        //            case 4:
        //                textBoxes[i].text = avatar.FCmax.ToString();
        //                break;
        //            case 5:
        //                textBoxes[i].text = avatar.Bla.ToString();
        //                break;
        //            case 6:
        //                textBoxes[i].text = avatar.CO.ToString();
        //                break;
        //            case 7:
        //                textBoxes[i].text = avatar.BPd.ToString();
        //                break;
        //            case 8:
        //                textBoxes[i].text = avatar.BPs.ToString();
        //                break;
        //            case 9:
        //                textBoxes[i].text = avatar.SV.ToString();
        //                break;
        //            case 10:
        //                textBoxes[i].text = avatar.FCres.ToString();
        //                break;
        //            case 11:
        //                textBoxes[i].text = avatar.SpO2.ToString();
        //                break;


        //        }
        //    }
        //}
    
}

    public void ManualUpdate()
    {
        //can be called by the timer any time it wants to update the values in the boxes
        for (int i = 0; i < 10; i++)
        {
            if (filledBoxes[i] != false)
            {
                switch (BoxValue[i])
                {
                    case 1:
                        textBoxes[i].text = avatar.fc.ToString();
                        break;
                    case 2:
                        textBoxes[i].text = avatar.VO2fc.ToString();
                        break;
                    case 3:
                        textBoxes[i].text = avatar.MAP.ToString();
                        break;
                    case 4:
                        textBoxes[i].text = avatar.FCmax.ToString();
                        break;
                    case 5:
                        textBoxes[i].text = avatar.Bla.ToString();
                        break;
                    case 6:
                        textBoxes[i].text = avatar.CO.ToString();
                        break;
                    case 7:
                        textBoxes[i].text = avatar.BPd.ToString();
                        break;
                    case 8:
                        textBoxes[i].text = avatar.BPs.ToString();
                        break;
                    case 9:
                        textBoxes[i].text = avatar.SV.ToString();
                        break;
                    case 10:
                        textBoxes[i].text = avatar.FCres.ToString();
                        break;
                    case 11:
                        textBoxes[i].text = avatar.SpO2.ToString();
                        break;


                }
            }
        }
    }
    private void ClickedfcToggle(bool Value)
    {
        if (Toggle_fc.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (fc_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 1;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.fc.ToString();
                        filledBoxes[i] = true;
                        fc_toggled = true;
                        Toggle_fc.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & fc_toggled == false)
                {
                    Toggle_fc.isOn = false;
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
                    fc_toggled = false;
                }
            }


        }

    }

    private void Clickedvo2fcToggle(bool Value)
    {
        if (Toggle_vo2fc.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (vo2fc_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 2;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.VO2fc.ToString();
                        filledBoxes[i] = true;
                        vo2fc_toggled = true;
                        Toggle_vo2fc.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & vo2fc_toggled == false)
                {
                    Toggle_vo2fc.isOn = false;
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
                    vo2fc_toggled = false;
                }
            }


        }

    }
    private void ClickedMAPToggle(bool Value)
    {
        if (Toggle_MAP.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (MAP_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 3;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.MAP.ToString();
                        filledBoxes[i] = true;
                        MAP_toggled = true;
                        Toggle_MAP.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & MAP_toggled == false)
                {
                    Toggle_MAP.isOn = false;
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
                    MAP_toggled = false;
                }
            }


        }

    }
    private void ClickedfcmaxToggle(bool Value)
    {
        if (Toggle_fcmax.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (fcmax_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 4;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.FCmax.ToString();
                        filledBoxes[i] = true;
                        fcmax_toggled = true;
                        Toggle_fcmax.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & fcmax_toggled == false)
                {
                    Toggle_fcmax.isOn = false;
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
                    fcmax_toggled = false;
                }
            }


        }

    }
    private void ClickedblaToggle(bool Value)
    {
        if (Toggle_bla.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (bla_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 5;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.Bla.ToString();
                        filledBoxes[i] = true;
                        bla_toggled = true;
                        Toggle_bla.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & bla_toggled == false)
                {
                    Toggle_bla.isOn = false;
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
                    bla_toggled = false;
                }
            }


        }

    }
    private void ClickedCOToggle(bool Value)
    {
        if (Toggle_CO.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (CO_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 6;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.CO.ToString();
                        filledBoxes[i] = true;
                        CO_toggled = true;
                        Toggle_CO.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & CO_toggled == false)
                {
                    Toggle_CO.isOn = false;
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
                    CO_toggled = false;
                }
            }


        }

    }
    private void ClickedBPdToggle(bool Value)
    {
        if (Toggle_BPd.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (BPd_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 7;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.BPd.ToString();
                        filledBoxes[i] = true;
                        BPd_toggled = true;
                        Toggle_BPd.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & BPd_toggled == false)
                {
                    Toggle_BPd.isOn = false;
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
                    BPd_toggled = false;
                }
            }


        }

    }
    private void ClickedBPsToggle(bool Value)
    {
        if (Toggle_BPs.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (BPs_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 8;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.BPs.ToString();
                        filledBoxes[i] = true;
                        BPs_toggled = true;
                        Toggle_BPs.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & BPs_toggled == false)
                {
                    Toggle_BPs.isOn = false;
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
                    BPs_toggled = false;
                }
            }


        }

    }
    private void ClickedSVToggle(bool Value)
    {
        if (Toggle_SV.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (SV_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 9;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.SV.ToString();
                        filledBoxes[i] = true;
                        SV_toggled = true;
                        Toggle_SV.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & SV_toggled == false)
                {
                    Toggle_SV.isOn = false;
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
                    SV_toggled = false;
                }
            }


        }

    }
    private void ClickedfcresToggle(bool Value)
    {
        if (Toggle_fcres.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (fcres_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 10;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.FCres.ToString();
                        filledBoxes[i] = true;
                        fcres_toggled = true;
                        Toggle_fcres.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & fcres_toggled == false)
                {
                    Toggle_fcres.isOn = false;
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
                    fcres_toggled = false;
                }
            }


        }

    }
    private void ClickedSPO2Toggle(bool Value)
    {
        if (Toggle_SpO2.isOn)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (SpO2_toggled == false)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 11;
                        //textBoxes[i].text = "ve";
                        textBoxes[i].text = avatar.SpO2.ToString();
                        filledBoxes[i] = true;
                        SpO2_toggled = true;
                        Toggle_SpO2.isOn = true;
                        //this box will desplay the avatar's VE value 
                    }

                }
                else if (filledBoxes[i] == true & SpO2_toggled == false)
                {
                    Toggle_SpO2.isOn = false;
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
                    SpO2_toggled = false;
                }
            }


        }

    }
}
