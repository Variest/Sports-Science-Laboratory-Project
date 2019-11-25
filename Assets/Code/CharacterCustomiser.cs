using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCustomiser : MonoBehaviour
{
        public int gender = 0; //drop down gives int values, 0 = FEMALE 1 = MALE
        public int race = 0; //0 = WHITE, 1 = BLACK, 2 = ASIAN
        public int age = 16;
        public float height = 0.0f;
        public float weight = 0.0f;
        //Class Variables
        bool swimwear = false;
        bool gasMaskOn = false;

    public Dropdown ddSex; //drop down box that allows the user to change the sex of the avatar
    public Dropdown ddRace; //drop down box that allows the user to change the race of the avatar
    public InputField ageInput; //input box that will get the age value of the avatar 
    public InputField weightInput; //input box that will get the weight value of the avatar 
    public InputField heightInput; //input box that will get the height value of the avatar 

    public GameObject avatar;
    public CharacterAvatar avatarVariables;
    public Button ChangeAvatar;
    //we use these variables to set a minimum and maximum age value for the user to enter. 16 currently min, will ask for a max value from mitch
    public float minAge = 16;
    public float maxAge;
    //same as before, setting max and min variables for the height, will ask mitch for sensible parameters 
    public float minHeight;
    public float maxHeight;
    //max and min weight
    public float minWeight;
    public float maxWeight;

    // Start is called before the first frame update
    void Start()
    {   //Declares and sets the button
        Button btn = GetComponent<Button>();
        //avatar = GameObject.Find("Avatar");
        avatarVariables = avatar.GetComponent<CharacterAvatar>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
          
    }

    void TaskOnClick()
    {//What happens when the button is clicked
        gender = ddSex.value;
        avatarVariables.gender = gender;
        race = ddRace.value;
        avatarVariables.race = race;
        avatarVariables.age = Mathf.Clamp(float.Parse(ageInput.text), minAge, maxAge);
        avatarVariables.weight = Mathf.Clamp(float.Parse(weightInput.text), minWeight, maxWeight);
        avatarVariables.height = Mathf.Clamp(float.Parse(heightInput.text), minHeight, maxHeight);

        if (gender == 0)//compares gender and then runs a switch to determine avatar type.
        {
            switch (race)
            {
                case 0:
                    
                    Debug.Log("White Female");
                    break;
                case 1:
                    Debug.Log("Black Female");
                    break;
                case 2:
                    Debug.Log("Asian Female");
                    break;
                default:
                    break;
            }
        }
        else
        {
            switch (race)
            {
                case 0:
                    Debug.Log("White Male");
                    break;
                case 1:
                    Debug.Log("Black Male");
                    break;
                case 2:
                    Debug.Log("Asian Male");
                    break;
                default:
                    break;
            }
        }
        if(avatarVariables.gender == 0 & avatarVariables.race == 0)
        {
            //white female
            avatarVariables.spriteRenderer.sprite = avatarVariables.spriteWFemale;
        }
        else if (avatarVariables.gender == 0 & avatarVariables.race == 1)
        {
            //black female
            avatarVariables.spriteRenderer.sprite = avatarVariables.spriteBFemale;
        }
        else if (avatarVariables.gender == 0 & avatarVariables.race == 2)
        {
            //asian female
            avatarVariables.spriteRenderer.sprite = avatarVariables.spriteAFemale;
        }
        else if (avatarVariables.gender == 1 & avatarVariables.race == 0)
        {
            //white male
            avatarVariables.spriteRenderer.sprite = avatarVariables.spriteWMale;
        }
        else if (avatarVariables.gender == 1 & avatarVariables.race == 1)
        {
            //black male
            avatarVariables.spriteRenderer.sprite = avatarVariables.spriteBMale;
        }
        else if (avatarVariables.gender == 1 & avatarVariables.race == 2)
        {
            avatarVariables.spriteRenderer.sprite = avatarVariables.spriteAMale;
            //asian male
        }
    }
}
