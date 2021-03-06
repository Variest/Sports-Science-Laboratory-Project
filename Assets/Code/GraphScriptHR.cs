﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphScriptHR : MonoBehaviour
{
    private RectTransform GraphContainer;
    [SerializeField] private Sprite CircleSprite;
    public GameObject[] circles;
    public RectTransform[] transforms;
    public GameObject[] movement;
    public int graphcounter = 0;
    public int graphcountermovement = 0;
    Cardio cardio;
    BodyHeat heat;
    Timer timer;
    Exercise exercise;
    CharacterAvatar character;
    public float InputMax;
    public string Variable;

    // Start is called before the first frame update
    void Start()
    {
        cardio = GetComponent<Cardio>();
        heat = GetComponent<BodyHeat>();
        timer = GetComponent<Timer>();
        exercise = GetComponent<Exercise>();
        character = GetComponent<CharacterAvatar>();
        circles = new GameObject[10];
        transforms = new RectTransform[10];
        GraphContainer = transform.Find("GraphContainer").GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer.resetGRAPHHR == true)
        {
            timer.resetGRAPHHR = false;
            GraphMaker(cardio.HR, cardio.HRmax, "Heart Rate");
            //GraphMaker(cardio.Bla, 30, "Blood Lactate");
            graphcounter++;
        }

        for(int i = 0; i <= 9; i++)
        {
            circles[i].transform.Translate((-8 * Time.deltaTime), 0, 0);
        }
    }

    public GameObject CircleMaker(Vector2 Position)
    {
        if(graphcounter == 10)
        {
            graphcounter = 0;
        }
        Destroy(circles[graphcounter]);
        circles[graphcounter] = new GameObject("Circle", typeof(Image));
        circles[graphcounter].transform.SetParent(GraphContainer, false);
        circles[graphcounter].GetComponent<Image>().sprite = CircleSprite;
        transforms[graphcounter] = circles[graphcounter].GetComponent<RectTransform>();
        transforms[graphcounter].anchoredPosition = Position;
        transforms[graphcounter].sizeDelta = new Vector2(11, 11);
        transforms[graphcounter].anchorMin = new Vector2(0, 0);
        transforms[graphcounter].anchorMax = new Vector2(0, 0);
        return circles[graphcounter];

    }

    public void GraphMaker(float input, float inputmax, string variable)
    {
        float graphHeight = GraphContainer.sizeDelta.y;
        float xPosition = 390;
        float yPosition = ((input / inputmax) * graphHeight);
        CircleMaker(new Vector2(xPosition, yPosition));
        InputMax = inputmax;
        Variable = variable;
    }

    private void DotConnector(Vector2 dotposA, Vector2 dotposB)
    {
        GameObject gameObject = new GameObject("dotconnect", typeof(Image));
        gameObject.transform.SetParent(GraphContainer, false);
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(100, 3f);
        rectTransform.anchoredPosition = dotposA;
    }
}
