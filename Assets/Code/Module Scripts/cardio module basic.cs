using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cardiomodulebasic : MonoBehaviour
{
    public GameObject avatarObj;
    public CharacterAvatar avatar;
    public Text rbox1;
    public Text rbox2;
    public Text rbox3;
    public Text rbox4;
    
    //pulmonary basic module

    //equations used
    /*
    fc
    vo2/fc
    MAP
    fcmax
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
        //rbox1.text = avatar.fc.ToString();
        //rbox2.text = avatar.VO2fc.ToString();
        //rbox3.text = avatar.MAP.ToString();
        //rbox4.text = avatar.FCmax.ToString();
      
    }
    public void ManualUpdate()
    {
        rbox1.text = avatar.fc.ToString();
        rbox2.text = avatar.VO2fc.ToString();
        rbox3.text = avatar.MAP.ToString();
        rbox4.text = avatar.FCmax.ToString();
    }
}
