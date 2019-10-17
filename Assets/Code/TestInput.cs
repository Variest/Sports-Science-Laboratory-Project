using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TestInput : MonoBehaviour {

    pvEquations ventCalc;
    public InputField FEO2box;
    public InputField FECO2box;
    public InputField FIO2box;
    public InputField FICO2box;
    public InputField PBbox;
    public InputField PH2Obox;
    public InputField expTEMPbox;
    public InputField VTbox;
    public InputField TIbox;
    public InputField FRbox;
    public InputField weightTbox;
    public InputField volTbox;
    public InputField timeTbox;
    public InputField durEPOCbox;
    public InputField tbTimeTbox;
    public InputField consEPOCbox;
    public InputField FEV1box;
    public Text resultField;

    public Dropdown tempChoser; // drop down list currently used to experiment with having the program take in different functions

    public GameObject calcScripts;

    public int functionChosen; //int value depending on which function you are trying to find the answer to
    // Use this for initialization
    void Start () {
        resultField = GetComponent<Text>();
        ventCalc = calcScripts.GetComponent<pvEquations>();
	}
	
	// Update is called once per frame
	void Update () {

       
	}
    public void Calculate()
    {
        //float temp1 = float.Parse(box1.text);
        // float temp2 = float.Parse(box2.text);
        //float temp3 = float.Parse(box3.text);
        //float answer = temp1 + temp2 + temp3;
        //resultField.text = answer.ToString();
        /*
        functionChosen = tempChoser.value;
        switch(functionChosen)
        {
            case (0):
                //will be used to handle the expire time function
                ventCalc.breathTime = float.Parse(tbTimeTbox.text);
                ventCalc.TI = float.Parse(TIbox.text);
                float temp = ventCalc.ExpireTime();
                resultField.text = temp.ToString();
                break;
            case (1):
                ventCalc.TI = float.Parse(box1.text);
                ventCalc.TE = float.Parse(box2.text);
                float temp1 = ventCalc.InspireExpireRatio();
                resultField.text = temp1.ToString();
                break;
        }
        */
        ventCalc.breathTime = float.Parse(tbTimeTbox.text);
        ventCalc.TI = float.Parse(TIbox.text);
        ventCalc.VT = float.Parse(VTbox.text);
        ventCalc.FICO2 = float.Parse(FICO2box.text);
        ventCalc.FECO2 = float.Parse(FECO2box.text);
        ventCalc.FEO2 = float.Parse(FEO2box.text);
        ventCalc.FIO2 = float.Parse(FIO2box.text);
        ventCalc.fr = float.Parse(FRbox.text);
        float tempWeight = float.Parse(weightTbox.text);
        float tempFEV = float.Parse(FEV1box.text);
        float tempPb = float.Parse(PBbox.text);
        float tempPH2O = float.Parse(PH2Obox.text);
        float tempExpTemperature = float.Parse(expTEMPbox.text);
        float tempEPOCduration = float.Parse(durEPOCbox.text);
        float tempEPOCconsume = float.Parse(consEPOCbox.text);
        float tempTime = float.Parse(timeTbox.text);
        float tempVolume = float.Parse(volTbox.text);
        //debugging for the actual equations and shit idk
        Debug.Log("expire time = " + ventCalc.ExpireTime());
        Debug.Log("Inpire / expire ratio = " + ventCalc.InspireExpireRatio());
        Debug.Log("VE = " + ventCalc.CalcVE());
        Debug.Log("VE(ATPS) = " + ventCalc.CalcVeATPS(tempVolume, tempTime));
        Debug.Log("VE(STPD) = " + ventCalc.CalcVeSTPD(tempPb, tempPH2O, tempExpTemperature));
        Debug.Log("VE(BTPS) = " + ventCalc.CalcVeBTPS(tempPb, tempPH2O, tempExpTemperature));
        Debug.Log("VI = " + ventCalc.calcVI());
        Debug.Log("VCO2 = " + ventCalc.calcVCO2());
        Debug.Log("VO2 = " + ventCalc.OxygenConsumption());
        Debug.Log("RER = " + ventCalc.respiratoryExRatio());
        Debug.Log("RQ = " + ventCalc.respiratoryQuotient());
        Debug.Log("Vecap = " + ventCalc.VentCapacity(tempFEV));
        Debug.Log("VeVO2 = " + ventCalc.VentEquivOxygen());
        Debug.Log("VeVCO2 = " + ventCalc.VentEquivCO2());
        Debug.Log("EPOC = " + ventCalc.calcEPOC(tempEPOCduration, tempEPOCconsume));
        Debug.Log("MET = " + ventCalc.calcMET(tempWeight));
        Debug.Log("VO2fr = " + ventCalc.OxygenBreath());
    }
}
