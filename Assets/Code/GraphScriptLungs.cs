using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphScriptLungs : MonoBehaviour
{
    private RectTransform GraphContain;
    [SerializeField] private Sprite RedCirc;
    [SerializeField] private Sprite GreenCirc;
    public GameObject[] circlesEELV;
    public GameObject[] circlesEILV;
    public RectTransform[] transformsEELV;
    public RectTransform[] transformsEILV;
    public GameObject[] movement;
    public int graphcountEELV = 0;
    public int graphcountEILV = 0;
    public int graphcountmovement = 0;
    Cardio cardioGet;
    BodyHeat heatGet;
    Timer timerGet;
    Exercise exerciseGet;
    Lung lungGet;
    CharacterAvatar characterGet;
    public float Inputer;
    public string Varer;
    public int counter;
    //
    public Text TLCtxt;
    public Text ICtxt;
    public Text IRVtxt;
    public Text ERVtxt;
    public Text VTtxt;
    public Text DHtxt;
    public Text EILVtxt;
    public Text EELVtxt;

    // Start is called before the first frame update
    void Start()
    {
        cardioGet = GetComponent<Cardio>();
        heatGet = GetComponent<BodyHeat>();
        timerGet = GetComponent<Timer>();
        exerciseGet = GetComponent<Exercise>();
        characterGet = GetComponent<CharacterAvatar>();
        lungGet = GetComponent<Lung>();
        circlesEILV = new GameObject[10];
        circlesEELV = new GameObject[10];
        transformsEILV = new RectTransform[10];
        transformsEELV = new RectTransform[10];
        GraphContain = transform.Find("GraphContain").GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        TLCtxt.text = lungGet.TLC.ToString();
        ICtxt.text = lungGet.IC.ToString();
        ERVtxt.text = lungGet.ERV.ToString();
        IRVtxt.text = lungGet.IRV.ToString();
        VTtxt.text = lungGet.VT.ToString();
        DHtxt.text = lungGet.DH.ToString();
        EELVtxt.text = lungGet.EELV.ToString();
        EILVtxt.text = lungGet.EILV.ToString();

        if (timerGet.resetGRAPHLUNG == true)
        {
            timerGet.resetGRAPHLUNG = false;
            GraphMake(lungGet.EELV, 1);
            GraphMake(lungGet.EILV, 0);
            graphcountEELV++;
            graphcountEILV++;
            counter++;
        }

        for (int i = 0; i <= 9; i++)
        {
            circlesEELV[i].transform.Translate((-8 * Time.deltaTime), 0, 0);
            circlesEILV[i].transform.Translate((-8 * Time.deltaTime), 0, 0);
        }
    }

    public void CircleMake(Vector2 Position, int ELV)
    {
        switch (ELV)
        {
            case 1: //EELV 
                if (graphcountEELV == 10)
                {
                    graphcountEELV = 0;
                }
                Destroy(circlesEELV[graphcountEELV]);
                Destroy(transformsEELV[graphcountEELV]);
                circlesEELV[graphcountEELV] = new GameObject("Circle", typeof(Image));
                circlesEELV[graphcountEELV].transform.SetParent(GraphContain, false);
                circlesEELV[graphcountEELV].GetComponent<Image>().sprite = RedCirc;
                transformsEELV[graphcountEELV] = circlesEELV[graphcountEELV].GetComponent<RectTransform>();
                transformsEELV[graphcountEELV].anchoredPosition = Position;
                transformsEELV[graphcountEELV].sizeDelta = new Vector2(11, 11);
                transformsEELV[graphcountEELV].anchorMin = new Vector2(0, 0);
                transformsEELV[graphcountEELV].anchorMax = new Vector2(0, 0);
                break;
            case 0: //EILV    
                if (graphcountEILV == 10)
                {
                    graphcountEILV = 0;
                }
                Destroy(circlesEILV[graphcountEILV]);
                circlesEILV[graphcountEILV] = new GameObject("Circle", typeof(Image));
                circlesEILV[graphcountEELV].transform.SetParent(GraphContain, false);
                circlesEILV[graphcountEILV].GetComponent<Image>().sprite = GreenCirc;
                transformsEILV[graphcountEILV] = circlesEILV[graphcountEILV].GetComponent<RectTransform>();
                transformsEILV[graphcountEILV].anchoredPosition = Position;
                transformsEILV[graphcountEILV].sizeDelta = new Vector2(11, 11);
                transformsEILV[graphcountEILV].anchorMin = new Vector2(0, 0);
                transformsEILV[graphcountEILV].anchorMax = new Vector2(0, 0);
                break;
        }
    }

    public void GraphMake(float input, int ELV)
    {
        float graphHeight = GraphContain.sizeDelta.y;
        float xPosition = 390;
        float yPosition = ((input / lungGet.TLC) * graphHeight);
        switch (ELV)
        {
            case 1: //EELV
                CircleMake(new Vector2(xPosition, yPosition), ELV);
                break;
            case 0: //EILV
                CircleMake(new Vector2(xPosition, yPosition), ELV);
                break;
        }
    }
}
