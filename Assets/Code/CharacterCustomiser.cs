using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCustomiser : MonoBehaviour
{
        public bool gender = false; //false for female, true for male
        public int race = 0; //0 = white, 1 = black, 2 = asian
        public float age = 16f;
        public float height = 0.0f; //PLEASE PUT THIS IN CENTIMETRES
        public float weight = 0.0f;
        //Class Variables
        bool swimwear = false;
        bool gasMarkOn = false;

    public Button ChangeAvatar;
    public Toggle GenderM;
    public Toggle GenderF;
    public Toggle RaceW;
    public Toggle RaceB;
    public Toggle RaceA;
    public Slider Age;
    public Slider Height;
    public Slider Weight;
    public Toggle Swim;
    public Toggle GasMask;
    // Start is called before the first frame update
    void Start()
    {  
        //Declares and sets the buttons and toggles
        Button btn = ChangeAvatar.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        Toggle maleToggle = GenderM.GetComponent<Toggle>();
        maleToggle.onValueChanged.AddListener(OnClickTask);

        Toggle femaleToggle = GenderF.GetComponent<Toggle>();
        femaleToggle.onValueChanged.AddListener(OnClickTask);

        Toggle whiteToggle = RaceW.GetComponent<Toggle>();
        whiteToggle.onValueChanged.AddListener(OnClickRaceTask);

        Toggle blackToggle = RaceB.GetComponent<Toggle>();
        blackToggle.onValueChanged.AddListener(OnClickRaceTask);

        Toggle asianToggle = RaceA.GetComponent<Toggle>();
        asianToggle.onValueChanged.AddListener(OnClickRaceTask);
    }

    // Update is called once per frame
    void Update(){}

    void OnClickTask(bool sex)
    {
        if (GenderM.isOn == true)
        {
            sex = true;
        }
        else if (GenderF.isOn == true)
        {
            sex = false;
        }

        gender = sex;
    }

    void OnClickRaceTask(bool Ethnicity)
    {
        if (RaceW.isOn == true)
        {
            race = 0;
        }
        else if (RaceB.isOn == true)
        {
            race = 1;
        }
        else if (RaceA.isOn == true)
        {
            race = 2;
        }
    }

    void TaskOnClick()
    {//What happens when the button is clicked

        if(GenderM.isOn == false && GenderF.isOn == false)
        {
            Debug.Log("Please enter in all the details of your test subject.");
        }
        else
        {

            age = Age.value;
            height = Height.value;
            weight = Weight.value;
            if (GasMask.isOn == true)
            {
                gasMarkOn = true;
            }

            if (Swim.isOn == true)
            {
                swimwear = true;
            }

            if(gender == false)//compares gender and then runs a switch to determine avatar type.
            {
                switch (race)
                {
                    case 0:
                        Debug.Log("White Female");
                        Debug.Log(age);
                        Debug.Log(height);
                        Debug.Log(weight);
                        if(swimwear == true)
                        {
                        Debug.Log("Swimwear is being worn");
                        }
                        if (gasMarkOn == true)
                        {
                            Debug.Log("Gas Mask is being worn");
                        }

                        break;
                    case 1:
                        Debug.Log("Black Female");
                        Debug.Log(age);
                        Debug.Log(height);
                        Debug.Log(weight);
                        if (swimwear == true)
                        {
                            Debug.Log("Swimwear is being worn");
                        }
                        if (gasMarkOn == true)
                        {
                            Debug.Log("Gas Mask is being worn");
                        }
                        break;
                    case 2:
                        Debug.Log("Asian Female");
                        Debug.Log(age);
                        Debug.Log(height);
                        Debug.Log(weight);
                        if (swimwear == true)
                        {
                            Debug.Log("Swimwear is being worn");
                        }
                        if (gasMarkOn == true)
                        {
                            Debug.Log("Gas Mask is being worn");
                        }
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
                        Debug.Log(age);
                        Debug.Log(height);
                        Debug.Log(weight);
                        if (swimwear == true)
                        {
                            Debug.Log("Swimwear is being worn");
                        }
                        if (gasMarkOn == true)
                        {
                            Debug.Log("Gas Mask is being worn");
                        }
                        break;
                     case 1:
                        Debug.Log("Black Male");
                        Debug.Log(age);
                        Debug.Log(height);
                        Debug.Log(weight);
                        if (swimwear == true)
                        {
                            Debug.Log("Swimwear is being worn");
                        }
                        if (gasMarkOn == true)
                        {
                            Debug.Log("Gas Mask is being worn");
                        }
                        break;
                     case 2:
                        Debug.Log("Asian Male");
                        Debug.Log(age);
                        Debug.Log(height);
                        Debug.Log(weight);
                        if (swimwear == true)
                        {
                            Debug.Log("Swimwear is being worn");
                        }
                        if (gasMarkOn == true)
                        {
                            Debug.Log("Gas Mask is being worn");
                        }
                        break;
                     default:
                        break;
                }
            }

        }
        
    }
}
