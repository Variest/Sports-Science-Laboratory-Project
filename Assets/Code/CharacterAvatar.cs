using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAvatar : MonoBehaviour
{
    // Start is called before the first frame update
    //stores all the variables for the person: will be the thing that gets updated as the program runs in the end version

    [Header("Base elements")]
    public bool gender = false; // false = FEMALE true = MALE
    public int race = 0; // 0 = WHITE 1 = BLACK 2 = ASIAN
    public int age = 16; 
    public float height = 0.0f;
    public float weight = 0.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
