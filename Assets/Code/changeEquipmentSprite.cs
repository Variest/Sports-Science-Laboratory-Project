using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeEquipmentSprite : MonoBehaviour
{
    public Image equipmentImage;
    public Sprite[] equipmentPicture = new Sprite[3];
    public Button treadmillButton;
    public Button rowerButton;
    public Button bikeButton;
    // Start is called before the first frame update
    void Start()
    {
        bikeButton.onClick.AddListener(SetBike);
        treadmillButton.onClick.AddListener(SetTreadmill);
        rowerButton.onClick.AddListener(SetRower);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetBike()
    {
        equipmentImage.sprite = equipmentPicture[0];
    }

    void SetRower()
    {
        equipmentImage.sprite = equipmentPicture[1];
    }

    void SetTreadmill()
    {
        equipmentImage.sprite = equipmentPicture[2];
    }
}
