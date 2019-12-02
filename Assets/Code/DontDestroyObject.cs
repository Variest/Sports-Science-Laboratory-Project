using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyObject : MonoBehaviour
{
    //place this script onto any object that we want to persist between different scenes being loaded.
    //will be placed onto the character avatar holder because we want to keep the variables assigned to it between scenes - they will be reset otherwise and we will lose the gender/age etc
    void Start()
    {
        
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
