using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Menu_Button_Linker : MonoBehaviour
{
    // currently the buttons work by constantly creating new menu managers, hopefully this script will allow us to keep it at a single permanent instance of it

    MenuManager menuManager;
    GameObject menuHolder; //the object holding the menu manager script
    Button thisButton; //the button that this script is attached to
    public int eventToAssign; //will use a case statement to assign events so that I can just reuse this script on every button despite assigning different functions to each one.

    //FUNCTIONS NEEDED TO BE PORTED + THEIR INTEGER CODE:
    //GoToTemplateSelection1 == 1
    //GoToTemplateSelection2 == 2
    //GoToTemplateSelection3 == 3
    //GoToVariables == 4
    //SetBasic == 5
    //GoToModuleChange == 6
    //GoToQuit == 7
    //GoToBackMainMenu == 8
    //GoToBackModules == 9
    //GoToMain == 10
    //GoToModuleSelection == 11
    //GoToAvatarCustomisation == 12
    void Start()
    {
        thisButton = GetComponent<Button>();
        menuHolder = GameObject.FindGameObjectWithTag("Menu_Manager");
        menuManager = menuHolder.GetComponent<MenuManager>();
        SetFunction();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetFunction() //will contain case statements to decide what function the onClick event of this button will lead to
    {
        switch (eventToAssign)
        {
            case 1:
                thisButton.onClick.AddListener(menuManager.GoToTemplateSelection1);
                break;
            case 2:
                thisButton.onClick.AddListener(menuManager.GoToTemplateSelection2);
                break;
            case 3:
                thisButton.onClick.AddListener(menuManager.GoToTemplateSelection3);
                break;
            case 4:
                thisButton.onClick.AddListener(menuManager.GoToVariables);
                break;
            case 5:
                thisButton.onClick.AddListener(menuManager.SetBasic);
                break;
            case 6:
                thisButton.onClick.AddListener(menuManager.GoToModuleChange);
                break;
            case 7:
                thisButton.onClick.AddListener(menuManager.GoToQuit);
                break;
            case 8:
                thisButton.onClick.AddListener(menuManager.GoToBackMainMenu);
                break;
            case 9:
                thisButton.onClick.AddListener(menuManager.GoToBackModules);
                break;
            case 10:
                thisButton.onClick.AddListener(menuManager.GoToMain);
                break;
            case 11:
                thisButton.onClick.AddListener(menuManager.GoToModuleSelection);
                break;
            case 12:
                thisButton.onClick.AddListener(menuManager.GoToAvatarCustomisation);
                break;


        }

    }
}
