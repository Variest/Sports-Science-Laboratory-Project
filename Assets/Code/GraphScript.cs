using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphScript : MonoBehaviour
{
    private RectTransform GraphContainer;
    [SerializeField] private Sprite CircleSprite;

    // Start is called before the first frame update
    void Start()
    {
        GraphContainer = transform.Find("GraphContainer").GetComponent<RectTransform>();
        CircleMaker(new Vector2(200, 200));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CircleMaker(Vector2 position)
    {
        GameObject gameObject = new GameObject("Circle", typeof(Image));
        gameObject.transform.SetParent(GraphContainer, false);
        gameObject.GetComponent<Image>().sprite.CircleSprite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = position;
        rectTransform.sizeDelta = new Vector2(11, 11);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);

    }
}
