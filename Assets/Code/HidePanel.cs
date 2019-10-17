using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HidePanel : MonoBehaviour
{
    public Button hideButton;
    public ClickCalculateButton panel;
    // Start is called before the first frame update
    void Start()
    {
        hideButton.onClick.AddListener(taskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void taskOnClick()
    {
        panel.panel.SetActive(false);
    }
}
