using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyObject : MonoBehaviour
{
    //place this script onto any object that we want to persist between different scenes being loaded.
    //will be placed onto the character avatar holder because we want to keep the variables assigned to it between scenes - they will be reset otherwise and we will lose the gender/age etc
    void Start()
    {
        //any scripts that reference the character avatar script will need to find an object in the scene with the tag "Avatar_Holder" and get the component from it, as currently we will
        //not be able to get the value by dragging and dropping as the avatar holder is technically not in any other scene until we are playing the game.
    }
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
