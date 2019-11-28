using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MetabolicCartModule : MonoBehaviour
{

    //Each module should be separated into two forms, BASIC and ADVANCED
    //BASIC modules will only examine a small number of preselected variables, while ADVANCED modules will be able to look at any user-selected variables as long as they are within the 
    //module's selected parameters. There shall also be an option for a custom module that allows the user to select any value from any module. 

    //BASIC METABOLIC CART MODULE CONTAINS:
    //VE
    //VO2
    //VT
    //VCO2
    //fr
    //MET
    //fc
    //RER
    

    
  
    public GameObject avatarObj;
    public CharacterAvatar avatar;
    public Text rbox1;
    public Text rbox2;
    public Text rbox3;
    public Text rbox4;
    public Text rbox5;
    public Text rbox6;
    public Text rbox7;
    public Text rbox8;
    //matabolic cart basic module

  

    //will just place the value from the avatar each update frame as the values should be getting updated somewhere else anyway

    // Start is called before the first frame update
    void Start()
    {
        avatar = avatarObj.GetComponent<CharacterAvatar>();
    }

    // Update is called once per frame
    void Update()
    {
        rbox1.text = avatar.VE.ToString();
        rbox2.text = avatar.VO2.ToString();
        rbox3.text = avatar.VT.ToString();
        rbox4.text = avatar.VCO2.ToString();
        rbox5.text = avatar.fr.ToString();
        rbox6.text = avatar.MET.ToString();
        rbox7.text = avatar.fc.ToString();
        rbox8.text = avatar.RER.ToString();
    }


}
