using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Output : MonoBehaviour
{
    Cardio cardio;
    //HEART RATE(0-1) AND BLOOD LACTATE(0-4)
    //PAINED FACE, AND TIRED LOOKING
    BodyHeat heat;
    //HEAT(0-3) AND WATER CONTENT (0-4)
    //HOT AND SWEATY AND THIRSTY
    Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        cardio = GetComponent<Cardio>();
        heat = GetComponent<BodyHeat>();
        timer = GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
