﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    public bool isStartLab;
    public bool isAvatarCustomise;
    public bool isQuit;
    public bool isPulmonaryModule;
    public bool isCardiovascularModule;
    public bool isMetabolicModule;
    public bool isBasic;
    public bool isVariables;
    public bool isChangeModule;
    public bool isBackMainMenu;
    public bool isBackModules;
    public bool isModuleVariable;

    public static char selectedModule = ' ';
    public static char selectedTemplate = ' ';

    public GameObject avatarHolder; //the object that holds the avatar value within it
    public Custom_Module_To_New_Scene moduleChanger; //the code that allows the module values to be transferred between scenes

    public GameObject TSPanel; 
    public GameObject MSPanel;
    public GameObject CPanel;
    public GameObject PAPanel;
    public GameObject CAPanel;
    public GameObject MAPanel;

    public static MenuManager menuInstance;

    public void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        if (menuInstance == null)
        {
            menuInstance = this;
        }
        else
        {
            DestroyObject(gameObject);

        }
        avatarHolder = GameObject.FindGameObjectWithTag("Avatar_Holder"); //gets a reference for the persistent game object representing the avatar
        moduleChanger = avatarHolder.GetComponent<Custom_Module_To_New_Scene>(); //gets the persistent module changing code
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "Module Selection Scene")
        {
            TSPanel = GameObject.FindGameObjectWithTag("TS_Panel");
            MSPanel = GameObject.FindGameObjectWithTag("MS_Panel");
        }
    }
    public void GoToModuleSelection()
    {
        if (isStartLab)
        {
            SceneManager.LoadScene("Module Selection Scene");
        }
    }

    public void GoToAvatarCustomisation()
    {
        if (isAvatarCustomise)
        {
            SceneManager.LoadScene("Avatar Customisation Scene");
        }
    }

    public void GoToQuit()
    {
        if (isQuit)
        {
            if (Application.isEditor)
            {
                UnityEditor.EditorApplication.isPlaying = false;
            }
            else
            {
                Application.Quit();
            }
        }
    }

    public void GoToTemplateSelection1()
    {
        if (isPulmonaryModule)
        {
            selectedModule = 'P';
            moduleChanger.PV_ON = true;
            moduleChanger.Advanced_ON = true;
            //MSPanel.gameObject.SetActive(false);
            //TSPanel.gameObject.SetActive(true);
            MSPanel.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
            TSPanel.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }

    public void GoToTemplateSelection2()
    {
        if (isCardiovascularModule)
        {
            selectedModule = 'C';
            moduleChanger.Cardio_ON = true;
            moduleChanger.Advanced_ON = true;
            //MSPanel.gameObject.SetActive(false);
            //TSPanel.gameObject.SetActive(true);
            MSPanel.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
            TSPanel.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }

    public void GoToTemplateSelection3()
    { 
        if (isMetabolicModule)
        {
            selectedModule = 'M';
            moduleChanger.MetCart_ON = true;

            //MSPanel.gameObject.SetActive(false);
            //TSPanel.gameObject.SetActive(true);
            MSPanel.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
            TSPanel.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }

    public void SetBasic()
    {
        moduleChanger.Basic_ON = true;
        SceneManager.LoadScene("Main Scene");
    }
    //public void SetAdvanced()
    //{
    //    moduleChanger.Advanced_ON = true;
    //    SceneManager.LoadScene("MainScene");
    //}
    public void GoToVariables()
    {
        if(isVariables)
        {
            if(selectedModule != 'C' && selectedModule != 'M' && selectedModule != 'P')
            {
                moduleChanger.Custom_ON = true;
            }
            else
            {
                moduleChanger.Custom_ON = false;
            }
            moduleChanger.Advanced_ON = true;
            SceneManager.LoadScene("Variables Scene");
        }
    }

    public void GoToMain()
    {
        if(isBasic)
        {
            selectedTemplate = 'B';
            SceneManager.LoadScene("Main Scene");
        }
    }

    public void GoToModuleChange()
    {
        if (isChangeModule)
        {
            selectedModule = ' ';
            MSPanel.gameObject.SetActive(true);
            //TSPanel.gameObject.SetActive(false);
            TSPanel.gameObject.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        }
    }

    public void GoToBackMainMenu()
    {
        if (isBackMainMenu)
        {
            if (SceneManager.GetActiveScene().name == "Module Selection Scene")
            {
                if (TSPanel.GetComponent<RectTransform>().localScale == new Vector3(1, 1, 1))
                {
                    //MSPanel.gameObject.SetActive(true);
                    //TSPanel.gameObject.SetActive(false);
                    MSPanel.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    TSPanel.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
                    moduleChanger.ResetModuleValues();
                    selectedModule = ' ';
                }
                else
                {
                    SceneManager.LoadScene("Main Menu Scene");
                    moduleChanger.ResetModuleValues();
                }
            }
            else
            {
                SceneManager.LoadScene("Main Menu Scene");
                moduleChanger.ResetModuleValues();
            }
        }
    }

    public void GoToBackModules()
    {
        if (isBackModules)
        {
            SceneManager.LoadScene("Module Selection Scene");
            selectedModule = ' ';
            moduleChanger.ResetModuleValues();
            moduleChanger.Cardio_ON = false;
            moduleChanger.MetCart_ON = false;
            moduleChanger.PV_ON = false;
            moduleChanger.Custom_ON = false;
            selectedTemplate = ' ';

            //MSPanel.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            //TSPanel.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
            //MSPanel.gameObject.SetActive(true);
            //TSPanel.gameObject.SetActive(false);
        }
    }

    public void VariableSelect()
    {
        if (isModuleVariable)
        {
            
        }
    }

}
