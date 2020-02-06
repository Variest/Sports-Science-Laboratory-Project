using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIHiding : MonoBehaviour
{

    public GameObject TSPanel;
    public GameObject MSPanel;
    public GameObject CPanel;
    public GameObject PAPanel;
    public GameObject CAPanel;
    public GameObject MAPanel;
    public GameObject SliderPanel;
    public GameObject GenderPanel;
    public GameObject RacePanel;

    public Image WhiteM;
    public Image BlackM;
    public Image AsianM;
    public Image WhiteF;
    public Image BlackF;
    public Image AsianF;



    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Module Selection Scene")
        {
            TSPanel.gameObject.SetActive(false);
            MSPanel.gameObject.SetActive(true);
        }
        else
            if (SceneManager.GetActiveScene().name == "Variables Scene")
        {
            if (MenuManager.selectedModule == ' ')
            {
                CPanel.gameObject.SetActive(true);
                PAPanel.gameObject.SetActive(false);
                CAPanel.gameObject.SetActive(false);
                MAPanel.gameObject.SetActive(false);
            }
            else
                if (MenuManager.selectedModule == 'P')
            {
                CPanel.gameObject.SetActive(false);
                PAPanel.gameObject.SetActive(true);
                CAPanel.gameObject.SetActive(false);
                MAPanel.gameObject.SetActive(false);
            }
            else
                if (MenuManager.selectedModule == 'C')
            {
                CPanel.gameObject.SetActive(false);
                PAPanel.gameObject.SetActive(false);
                CAPanel.gameObject.SetActive(true);
                MAPanel.gameObject.SetActive(false);
            }
            else
                if (MenuManager.selectedModule == 'M')
            {
                CPanel.gameObject.SetActive(false);
                PAPanel.gameObject.SetActive(false);
                CAPanel.gameObject.SetActive(false);
                MAPanel.gameObject.SetActive(true);
            }
        }
        else
            if (SceneManager.GetActiveScene().name == "Avatar Customisation Scene")
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

    }
}

