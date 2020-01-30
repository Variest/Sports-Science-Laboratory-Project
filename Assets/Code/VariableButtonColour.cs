using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VariableButtonColour : MonoBehaviour
{
    public bool isVariableButton;

    public void ButtonSelected()
    {
        if (isVariableButton)
        {
            if (GetComponent<UnityEngine.UI.Image>().color == Color.white)
            {
                GetComponent<UnityEngine.UI.Image>().color = Color.grey;
            }
            else
                if (GetComponent<UnityEngine.UI.Image>().color == Color.grey)
            {
                GetComponent<UnityEngine.UI.Image>().color = Color.grey;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(GetComponent<UnityEngine.UI.Image>().color);
        if (GetComponent<UnityEngine.UI.Image>().color != Color.white || GetComponent<UnityEngine.UI.Image>().color != Color.grey)
        {
            GetComponent<UnityEngine.UI.Image>().color = Color.white;
            Debug.Log(GetComponent<UnityEngine.UI.Image>().color);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
