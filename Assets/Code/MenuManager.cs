using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public bool isStartLab;
    public bool isAvatarCustomise;
    public bool isQuit;
    public bool isPulmonaryModule;
    public bool isCardiovascularModule;
    public bool isMetabolicModule;
    public bool isCustomModule;
    public bool isChangeModule;
    public bool isBasic;
    public bool isAdvanced;

    public char selectedModule;
    public char selectedTemplate;

    public GameObject TSPanel;
    public GameObject MSPanel;
    public GameObject CPanel;
    public GameObject PAPanel;
    public GameObject CAPanel;
    public GameObject MAPanel;

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
            Application.Quit();
        }
    }

    public void GoToTemplateSelection()
    {
        if (isPulmonaryModule)
        {
            selectedModule = 'P';
            MSPanel.gameObject.SetActive(false);
            TSPanel.gameObject.SetActive(true);
        }
        else
            if (isCardiovascularModule)
        {
            selectedModule = 'C';
            MSPanel.gameObject.SetActive(false);
            TSPanel.gameObject.SetActive(true);
        }
        else
            if (isMetabolicModule)
        {
            selectedModule = 'M';
            MSPanel.gameObject.SetActive(false);
            TSPanel.gameObject.SetActive(true);
        }
    }

    public void GoToVariables()
    {
        if(isCustomModule)
        {
            SceneManager.LoadScene("Variables Scene");
            CPanel.gameObject.SetActive(true);
            PAPanel.gameObject.SetActive(false);
            CAPanel.gameObject.SetActive(false);
            MAPanel.gameObject.SetActive(false);
        }
        else
        if (isAdvanced)
        {
            selectedTemplate = 'A';
            SceneManager.LoadScene("Variables Scene");

            if (selectedModule == 'P')
            {
                CPanel.gameObject.SetActive(false);
                PAPanel.gameObject.SetActive(true);
                CAPanel.gameObject.SetActive(false);
                MAPanel.gameObject.SetActive(false);
            }
            else
                if (selectedModule == 'C')
            {
                CPanel.gameObject.SetActive(false);
                PAPanel.gameObject.SetActive(false);
                CAPanel.gameObject.SetActive(true);
                MAPanel.gameObject.SetActive(false);
            }
            else
                if (selectedModule == 'M')
            {
                CPanel.gameObject.SetActive(false);
                PAPanel.gameObject.SetActive(false);
                CAPanel.gameObject.SetActive(false);
                MAPanel.gameObject.SetActive(true);
            }
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
            MSPanel.gameObject.SetActive(true);
            TSPanel.gameObject.SetActive(false);
        }
    }

}
