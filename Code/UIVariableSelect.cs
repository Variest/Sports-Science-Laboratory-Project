using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIVariableSelect : MonoBehaviour
{
    public Button Btn;

    // Start is called before the first frame update
    void Start()
    {
        // Button yourBtn = Btn.GetComponent<Button>();
        Btn = GetComponent<Button>();
        Btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log ("You have clicked the " + Btn.GetComponent<Button>() + "!");

        var colors = GetComponent<Button>().colors;

        if (colors.normalColor == Color.white)
        {
            colors.normalColor = Color.grey;
            GetComponent<Button>().colors = colors;
        }
        else
        {
            colors.normalColor = Color.white;
        }
    }
}
