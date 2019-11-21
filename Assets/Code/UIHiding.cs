using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        //Module Selection Scene
        if (TSPanel && MSPanel != false)
        {
            TSPanel.gameObject.SetActive(false);
            MSPanel.gameObject.SetActive(true);
        }
        else
        if (CPanel && PAPanel && CAPanel && MAPanel != false)
        {
            //Variable Selection Scene
            CPanel.gameObject.SetActive(true);
            PAPanel.gameObject.SetActive(false);
            CAPanel.gameObject.SetActive(false);
            MAPanel.gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
