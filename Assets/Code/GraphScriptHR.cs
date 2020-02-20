using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphScript : MonoBehaviour
{
    private RectTransform GraphContainer;
    [SerializeField] private Sprite CircleSprite;
    public GameObject[] circles;
    public RectTransform[] transforms;
    public int graphcounter = 0;
    public int graphcountermovement = 0;

    Cardio cardio;
    BodyHeat heat;
    Timer timer;
    Module exercise;
    CharacterAvatar character;

    // Start is called before the first frame update
    void Start()
    {
        cardio = GetComponent<Cardio>();
        heat = GetComponent<BodyHeat>();
        timer = GetComponent<Timer>();
        exercise = GetComponent<Module>();
        character = GetComponent<CharacterAvatar>();
        circles = new GameObject[10];
        transforms = new RectTransform[10];
        GraphContainer = transform.Find("GraphContainer").GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer.tensecondGRAPH == true)
        {
            GraphMaker(cardio.HR, cardio.HRmax);
            timer.tensecondGRAPH = false;
        }

        for(int i = 0; i >= 10; i++)
        {
            transforms[i].Translate((-5 * Time.deltaTime), 0, 0);
        }
    }

    private GameObject CircleMaker(Vector2 position)
    {
        GameObject gameObject = new GameObject("Circle", typeof(Image));
        gameObject.transform.SetParent(GraphContainer, false);
        gameObject.GetComponent<Image>().sprite.CircleSprite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = position;
        rectTransform.sizeDelta = new Vector2(11, 11);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        transforms[graphcounter] = rectTransform;
        circles[graphcounter] = gameObject;
        return gameObject;
    }

    private void GraphMaker(float input, float inputmax)
    {
        float graphHeight = GraphContainer.sizeDelta.y;
        if(graphcounter >= 10)
        {
            graphcounter = 0;

        }
        graphcountermovement++;
        if (graphcountermovement >= 10)
        {
            graphcountermovement = 10;
        }
        float xSize = 50f;
        float xPosition = graphcountermovement * xSize;
        float yPosition = (input / inputmax) * graphHeight;
        GameObject circleObject = CircleMaker(new Vector2(xPosition, yPosition));
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
