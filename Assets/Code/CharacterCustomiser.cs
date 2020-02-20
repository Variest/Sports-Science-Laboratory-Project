
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCustomiser : UIHiding
{
    public bool gender = false; //false for female, true for male
    public int race = 0; //0 = white, 1 = black, 2 = asian
    public float age = 16f;
    public float height = 0.0f; //PLEASE PUT THIS IN CENTIMETRES
    public float weight = 0.0f; //kg

    public GameObject avatarHolder; //won't let me just drag the avatar script in so will need a gameobject to get the component from.
    public CharacterAvatar avatar; //the avatar that will store the values for the experiment
    //Class Variables
    //bool swimwear = false;
    //bool gasMarkOn = false;

    public Button ChangeAvatar;
    public Button GenderM;
    public Button GenderF;
    public Button RaceW;
    public Button RaceB;
    public Button RaceA;
    public Slider Age;
    public Slider Height;
    public Slider Weight;
    public Text HeightT;
    public Text WeightT;
    public Text AgeT;

    public Button Confirm;
    // Start is called before the first frame update
    void Start()
    {
        //Declares and sets the buttons and toggles
        avatarHolder = GameObject.FindGameObjectWithTag("Avatar_Holder");
        SliderPanel.gameObject.SetActive(false);
        GenderPanel.gameObject.SetActive(true);
        RacePanel.gameObject.SetActive(true);

        avatar = avatarHolder.GetComponent<CharacterAvatar>();
        Button maleButton = GenderM.GetComponent<Button>();
        maleButton.onClick.AddListener(MaleChanger);

        Button femaleButton = GenderF.GetComponent<Button>();
        femaleButton.onClick.AddListener(FemaleChanger);

        Button whiteButton = RaceW.GetComponent<Button>();
        whiteButton.onClick.AddListener(WhiteRaceChanger);

        Button blackButton = RaceB.GetComponent<Button>();
        blackButton.onClick.AddListener(BlackRaceChanger);

        Button asianButton = RaceA.GetComponent<Button>();
        asianButton.onClick.AddListener(AsianRaceChanger);

        Button confirm = Confirm.GetComponent<Button>();
        confirm.onClick.AddListener(SliderToggle);

        if (WhiteM || BlackM || AsianM || WhiteF || BlackF || AsianF != false)
        {
            WhiteM.gameObject.SetActive(false);
            BlackM.gameObject.SetActive(false);
            AsianM.gameObject.SetActive(false);
            WhiteF.gameObject.SetActive(false);
            BlackF.gameObject.SetActive(false);
            AsianF.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        avatar.age = Age.value; //sets the values within the avatar, since the equations are set to store variables there.
        avatar.height = Height.value;
        avatar.weight = Weight.value;
        AgeT.text = Age.value.ToString();
        HeightT.text = Height.value.ToString();
        WeightT.text = Weight.value.ToString();
        //age = Age.value;
        //height = Height.value;
        //weight = Weight.value;

    }

    void SliderToggle()
    {
        SliderPanel.gameObject.SetActive(true);
        GenderPanel.gameObject.SetActive(false);
        RacePanel.gameObject.SetActive(false);
    }

    void MaleChanger()
    {
        if (WhiteM && BlackM && AsianM && WhiteF && BlackF && AsianF != false)
        {
            WhiteM.gameObject.SetActive(false);
            BlackM.gameObject.SetActive(false);
            AsianM.gameObject.SetActive(false);
            WhiteF.gameObject.SetActive(false);
            BlackF.gameObject.SetActive(false);
            AsianF.gameObject.SetActive(false);
        }
        gender = true;
        avatar.gender = 1; //avatar's gender is stored as an int, 0 for female 1 for male.
        switch (race)
        {
            case 0:
                WhiteM.gameObject.SetActive(true);
                break;
            case 1:
                BlackM.gameObject.SetActive(true);
                break;
            case 2:
                AsianM.gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }

    void FemaleChanger()
    {
        if (WhiteM && BlackM && AsianM && WhiteF && BlackF && AsianF != false)
        {
            WhiteM.gameObject.SetActive(false);
            BlackM.gameObject.SetActive(false);
            AsianM.gameObject.SetActive(false);
            WhiteF.gameObject.SetActive(false);
            BlackF.gameObject.SetActive(false);
            AsianF.gameObject.SetActive(false);
        }
        gender = false;
        avatar.gender = 0;
        switch (race)
        {
            case 0:
                WhiteF.gameObject.SetActive(true);
                break;
            case 1:
                BlackF.gameObject.SetActive(true);
                break;
            case 2:
                AsianF.gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }

    void WhiteRaceChanger()
    {
        if (WhiteM && BlackM && AsianM && WhiteF && BlackF && AsianF != false)
        {
            WhiteM.gameObject.SetActive(false);
            BlackM.gameObject.SetActive(false);
            AsianM.gameObject.SetActive(false);
            WhiteF.gameObject.SetActive(false);
            BlackF.gameObject.SetActive(false);
            AsianF.gameObject.SetActive(false);
        }
        race = 0;
        avatar.race = 0;
        switch (gender)
        {
            case false:
                WhiteF.gameObject.SetActive(true);
                break;
            case true:
                WhiteM.gameObject.SetActive(true);
                break;
        }
    }

    void BlackRaceChanger()
    {
        if (WhiteM && BlackM && AsianM && WhiteF && BlackF && AsianF != false)
        {
            WhiteM.gameObject.SetActive(false);
            BlackM.gameObject.SetActive(false);
            AsianM.gameObject.SetActive(false);
            WhiteF.gameObject.SetActive(false);
            BlackF.gameObject.SetActive(false);
            AsianF.gameObject.SetActive(false);
        }
        race = 1;
        avatar.race = 1;
        switch (gender)
        {
            case false:
                BlackF.gameObject.SetActive(true);
                break;
            case true:
                BlackM.gameObject.SetActive(true);
                break;
        }
    }

    void AsianRaceChanger()
    {
        if (WhiteM && BlackM && AsianM && WhiteF && BlackF && AsianF != false)
        {
            WhiteM.gameObject.SetActive(false);
            BlackM.gameObject.SetActive(false);
            AsianM.gameObject.SetActive(false);
            WhiteF.gameObject.SetActive(false);
            BlackF.gameObject.SetActive(false);
            AsianF.gameObject.SetActive(false);
        }
        race = 2;
        avatar.race = 2;
        switch (gender)
        {
            case false:
                AsianF.gameObject.SetActive(true);
                break;
            case true:
                AsianM.gameObject.SetActive(true);
                break;
        }
    }
}