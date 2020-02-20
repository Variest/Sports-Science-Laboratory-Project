﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cardiocustommodule : MonoBehaviour
{


    

    public Text[] textBoxes = new Text[10];
    public string[] nameBoxes = new string[10];
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


    public Button fc_button; //1
    public Button vo2fc_button; //2
    public Button MAP_button; //3
    public Button fcmax_button; //4
    public Button bla_button; //5
    public Button CO_button; //6
    public Button BPd_button; //7
    public Button BPs_button; //8
    public Button SV_button; //9
    public Button fcres_button; //10
    public Button SpO2_button; //11

    //public GameObject avatarHolder; //gameobject that will have the avatar script within it
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
        avatar = GetComponent<CharacterAvatar>();
        //add listening events to each one of the toggle boxes 
        
   

    }

    public void AttachButtons()
    {
        fc_button.onClick.AddListener(ClickedfcToggle);
        vo2fc_button.onClick.AddListener(Clickedvo2fcToggle);
        MAP_button.onClick.AddListener(ClickedMAPToggle);
        fcmax_button.onClick.AddListener(ClickedfcmaxToggle);
        bla_button.onClick.AddListener(ClickedblaToggle);
        CO_button.onClick.AddListener(ClickedCOToggle);
        BPd_button.onClick.AddListener(ClickedBPdToggle);
        BPs_button.onClick.AddListener(ClickedBPsToggle);
        SV_button.onClick.AddListener(ClickedSVToggle);
        fcres_button.onClick.AddListener(ClickedfcresToggle);
        SpO2_button.onClick.AddListener(ClickedSPO2Toggle);
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
    private void ClickedfcToggle()
    {
        if (!fc_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!fc_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 1;

                        textBoxes[i].text = avatar.fc.ToString();
                        nameBoxes[i] = "fc ";
                        filledBoxes[i] = true;
                        fc_toggled = true;

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
                    fc_toggled = false;
                }
            }


        }

    }

    private void Clickedvo2fcToggle()
    {
        if (!vo2fc_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!vo2fc_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 2;

                        textBoxes[i].text = avatar.VO2fc.ToString();
                        nameBoxes[i] = "vo2fc ";
                        filledBoxes[i] = true;
                        vo2fc_toggled = true;

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
                    vo2fc_toggled = false;
                }
            }


        }

    }
    private void ClickedMAPToggle()
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
                        BoxValue[i] = 3;

                        textBoxes[i].text = avatar.MAP.ToString();
                        nameBoxes[i] = "MAP ";
                        filledBoxes[i] = true;
                        MAP_toggled = true;

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
                    MAP_toggled = false;
                }
            }


        }

    }
    private void ClickedfcmaxToggle()
    {
        if (!fcmax_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!fcmax_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 4;

                        textBoxes[i].text = avatar.FCmax.ToString();
                        nameBoxes[i] = "fcmax ";
                        filledBoxes[i] = true;
                        fc_toggled = true;

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
                    fcmax_toggled = false;
                }
            }


        }

    }
    private void ClickedblaToggle()
    {
        if (!bla_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!bla_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 5;

                        textBoxes[i].text = avatar.Bla.ToString();
                        nameBoxes[i] = "bla ";
                        filledBoxes[i] = true;
                        bla_toggled = true;

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
                    bla_toggled = false;
                }
            }


        }

    }
    private void ClickedCOToggle()
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
                        BoxValue[i] = 6;

                        textBoxes[i].text = avatar.CO.ToString();
                        nameBoxes[i] = "CO ";
                        filledBoxes[i] = true;
                        CO_toggled = true;

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
                    CO_toggled = false;
                }
            }


        }

    }
    private void ClickedBPdToggle()
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
                        BoxValue[i] = 7;

                        textBoxes[i].text = avatar.BPd.ToString();
                        nameBoxes[i] = "BPd ";
                        filledBoxes[i] = true;
                        BPd_toggled = true;

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
                    BPd_toggled = false;
                }
            }


        }

    }
    private void ClickedBPsToggle()
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
                        BoxValue[i] = 8;

                        textBoxes[i].text = avatar.BPs.ToString();
                        nameBoxes[i] = "BPs ";
                        filledBoxes[i] = true;
                        BPs_toggled = true;

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
                    BPs_toggled = false;
                }
            }


        }

    }
    private void ClickedSVToggle()
    {
        if (!SV_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!SV_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 9;

                        textBoxes[i].text = avatar.SV.ToString();
                        nameBoxes[i] = "SV ";
                        filledBoxes[i] = true;
                        SV_toggled = true;

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
                    SV_toggled = false;
                }
            }


        }

    }
    private void ClickedfcresToggle()
    {
        if (!fcres_toggled)
        {

            for (int i = 0; i < 10; i++)
            {
                if (filledBoxes[i] == false)
                {
                    if (!fcres_toggled)
                    {
                        Debug.Log("filledBoxes works");
                        BoxValue[i] = 10;

                        textBoxes[i].text = avatar.FCres.ToString();
                        nameBoxes[i] = "fcres ";
                        filledBoxes[i] = true;
                        fcres_toggled = true;

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
                    fcres_toggled = false;
                }
            }


        }

    }
    private void ClickedSPO2Toggle()
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
                        BoxValue[i] = 11;

                        textBoxes[i].text = avatar.SpO2.ToString();
                        nameBoxes[i] = "SPO2 ";
                        filledBoxes[i] = true;
                        SpO2_toggled = true;

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
                    SpO2_toggled = false;
                }
            }


        }

    }
}
