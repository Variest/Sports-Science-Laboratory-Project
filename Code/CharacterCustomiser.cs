using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCustomiser : MonoBehaviour
{
        public bool gender = false;
        public int race = 0;
        public int age = 16;
        public float height = 0.0f;
        public float weight = 0.0f;
        //Class Variables
        bool swimwear = false;
        bool gasMarkOn = false;

    public Button ChangeAvatar;
    // Start is called before the first frame update
    void Start()
    {   //Declares and sets the button
        Button btn = ChangeAvatar.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
          
    }

    void TaskOnClick()
    {//What happens when the button is clicked
        if(gender == false)//compares gender and then runs a switch to determine avatar type.
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
    }
}
