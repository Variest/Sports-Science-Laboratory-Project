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
    public Text TLC;

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

        //
        //character.gender = 1;
        //character.age = 20;
        //timer.intervals = 10;
        //timer.increase = 10;
        //timer.limit = 100000;
        //exercise.Module = 2;
        //exercise.RPM = 20;
        //exercise.resistance = 5;
        //
    }

    // Update is called once per frame
    void Update()
    {
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

        TLC.text = lungGet.TLC.ToString();
    }

    public void CircleMake(Vector2 Position, int input, int ELV)
    {
        switch (ELV)
        {
            case 1: //EELV 
                if (graphcountEELV == 10)
                {
                    graphcountEELV = 0;
                }
                Destroy(circlesEELV[input]);
                Destroy(transformsEELV[input]);
                circlesEELV[input] = new GameObject("Circle", typeof(Image));
                circlesEELV[input].transform.SetParent(GraphContain, false);
                circlesEELV[input].GetComponent<Image>().sprite = RedCirc;
                transformsEELV[input] = circlesEELV[input].GetComponent<RectTransform>();
                transformsEELV[input].anchoredPosition = Position;
                transformsEELV[input].sizeDelta = new Vector2(11, 11);
                transformsEELV[input].anchorMin = new Vector2(0, 0);
                transformsEELV[input].anchorMax = new Vector2(0, 0);
                break;
            case 0: //EILV    
                if (graphcountEILV == 10)
                {
                    graphcountEILV = 0;
                }
                Destroy(circlesEILV[input]);
                circlesEILV[input] = new GameObject("Circle", typeof(Image));
                circlesEILV[input].transform.SetParent(GraphContain, false);
                circlesEILV[input].GetComponent<Image>().sprite = GreenCirc;
                transformsEILV[input] = circlesEILV[input].GetComponent<RectTransform>();
                transformsEILV[input].anchoredPosition = Position;
                transformsEILV[input].sizeDelta = new Vector2(11, 11);
                transformsEILV[input].anchorMin = new Vector2(0, 0);
                transformsEILV[input].anchorMax = new Vector2(0, 0);
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
                CircleMake(new Vector2(xPosition, yPosition), graphcountEELV, ELV);
                break;
            case 0: //EILV
                CircleMake(new Vector2(xPosition, yPosition), graphcountEILV, ELV);
                break;
        }
    }
}
