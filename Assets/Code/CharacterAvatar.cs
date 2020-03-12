using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAvatar : MonoBehaviour
{
    
    //stores all the variables for the person: will be the thing that gets updated as the program runs in the end version

    [Header("Base elements")] //basic elements for character creation, will change how the character looks on screen as well as the variables used in some of the equations
    public int gender = 0; // 0 = FEMALE 1 = MALE
    public int race = 0; // 0 = WHITE 1 = BLACK 2 = ASIAN
    public float age = 16; 
    public float height = 0.0f;
    public float weight = 0.0f;



    //[Space(10)]
    [Space(10)]
    [Header("Pulmonary Elements")]
    //values used for inspiration and expiration of air
    public float TI; //inspiratory time
    public float TE; //expiratory time
    public float TITE; //result for TI/TE
    public float breathTime; //total breath time
    //fractional concentration variables
    public float FECO2; //fractional concentration of expired carbon dioxide
    public float FICO2; //fractional concentration of inspired carbon dioxide 
    public float FEO2; //fractional concentration of expired oxygen
    public float FIO2; //fractional concentration of inspired oxygen
    //minute ventillation variables
    public float veATPS; //minute ventilation in an ATPS environment
    public float veSTPD; //minute ventilation in an STPD environment
    public float veBTPS; //minute ventilation in a BTPS environment
    public float VE;

    public float VT; //tidal volume

    public float MET; //metabolic equivalents
    //STPD relates to standard temperature and pressure, dry. (0c, 760 mmHg)
    //BTPS relates to body temperature and pressure, saturated with water vapor
    //ATPS relates to ambient temperature and pressure, saturated with water

    //oxygen consumption variables
    public float VI; //used to calculate some stuff idk
    public float VO2; //value for oxygen consumption
    public float VO2maxAge;
    public float VO2maxHeight;
    public float VO2maxWeight;
    public float VO2fr; //oxygen breath value
    public float VCO2; //carbon dioxide output
    public float EPOC; //excess post-exercise oxygen consumption

    //respiratory variables
    public float fr; //respiratory rate
    public float RER; //respiratory exchange ratio
    public float RQ; //respiratory quotient

    //ventilatory variables
    public float Vecap; //ventilatory capacity
    public float VeVO2; //ventilatory equivalent for oxygen
    public float VeVCO2; //ventilatory equivalent for carbon dioxide
    public float Ttot; //total breath time

    //work rate
    public float W; //work rate

    [Header("Not categorised")]
    public float EE;
    public float FCres;
    public float FCmax;
    public float SpO2;
    public float VO2fc;
    public float petco2;
    public float peto2;
    public float fc;
    public int Dyspnoea;  //rating of breathlessness 
    public float RPE; //rating of perceived exertion - conflicting info as she says it's a scale of 1-10, then that it's a scale of 6-20 calculated by fc*10 ??????????????????????????

    [Space(10)]
    [Header("Cardio stuff")]
    public float Bla; //blood lactate
    public float BPs; //systolic blood pressure 
    public float BlaT; //blood lactate threshold 
    public float SV; //stroke volume
    public float MAP; //mean arterial pressure
    public float BPd; //diastolic blood pressure -		PROBABLY INPUT - this tends not to change too much with exercise
    public float CO; //cardiac output
    [Space(10)]
    [Header("Lung stuff")]
    public float FEV1; //forced expired volume in the first second of exhalation
    public float FVC; //maximum volume expired after exhalation
    public float FEV1FVC; // fev1 / fvc
    public float PImax; //peak inspiratory mouth pressure
    public float PEmax; //peak expiratory mouth pressure
    public float ERV; //expiratory reserve volume
    public float FRC; //functional residual capacity
    public float IC; //inspiratory capacity - maximum volume inspired following tidal expiration
    public float IRV; //inspiratory reserve volume - maximum inspiration at the end of tidal inspiration
    public float PEF; //peak expiratory flow rate - maximum flow available
    public float PIF; //peak inspiratory flow rate - maximum flow available - RARELY MEASURED?
    public float RV; //residual volume - volume in lungs after maximum expiration
    public float TLC; //total lung capacity - volume in lungers after maximum inspiration
    public float VC; //vital capacity - the greatest amount of air that can be expired after a maximal inspiration


    public static CharacterAvatar avatarInstance;
    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (avatarInstance == null)
        {
            avatarInstance = this;
        }
        else
        {
            DestroyObject(gameObject);
            
        }
    }
    void Start()
    {
       // spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
