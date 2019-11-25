using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PVModulebasic : MonoBehaviour
{
    public GameObject avatarObj;
    public CharacterAvatar avatar;
    public Text rbox1;
    public Text rbox2;
    public Text rbox3;
    public Text rbox4;
    public Text rbox5;
    public Text rbox6;
    //pulmonary basic module

    //equations used
    /*
     FVC
     FEV1
     FEV1/FVC
     PEF
     PIF
     VECap
     */

    //will just place the value from the avatar each update frame as the values should be getting updated somewhere else anyway

    // Start is called before the first frame update
    void Start()
    {
        avatar = avatarObj.GetComponent<CharacterAvatar>();
    }

    // Update is called once per frame
    void Update()
    {
        rbox1.text = avatar.FVC.ToString();
        rbox2.text = avatar.FEV1.ToString();
        rbox3.text = avatar.FEV1FVC.ToString();
        rbox4.text = avatar.PEF.ToString();
        rbox5.text = avatar.PIF.ToString();
        rbox6.text = avatar.Vecap.ToString();
    }
}
