using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ej25mod2Resp : MonoBehaviour {

    public Text respuesta1,respuesta2, respuesta3, respuesta4, respuesta5;
    public bool oso, barco, lampara, baul, lapices, zapatilla;
    public int valorIndRandom;

    //1-oso
    //2-barco
    //3-lampara
    //4-baul
    //5-lapices
    //6-zapatilla


	// Use this for initialization
	void Start () {
        setRespuestasInicio();
        valorIndRandom = Random.Range(1, 7);

        switch (valorIndRandom)
        {
            case 1:
                oso = true;
                break;
            case 2:
                barco = true;
                break;
            case 3:
                lampara = true;
                break;
            case 4:
                baul = true;
                break;
            case 5:
                lapices = true;
                break;
            case 6:
                zapatilla = true;
                break;
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void pregunta1()
    {
        switch (valorIndRandom)
        {
            case 1:
                respuesta1.text = "NO";
                respuesta1.color = new Color32(0xD9, 0x2C, 0x1E,0xFF);//color rojo para no
                break;
            case 2:
                respuesta1.text = "NO";
                respuesta1.color = new Color32(0xD9, 0x2C, 0x1E, 0xFF);//color rojo para no
                break;
            case 3:
                respuesta1.text = "NO";
                respuesta1.color = new Color32(0xD9, 0x2C, 0x1E, 0xFF);//color rojo para no
                break;
            case 4:
                respuesta1.text = "SI";
                respuesta1.color = new Color32(0x94, 0xD0, 0x52, 0xFF);//color verde para si
                break;
            case 5:
                respuesta1.text = "SI";
                respuesta1.color = new Color32(0x94, 0xD0, 0x52, 0xFF);//color verde para si
                break;
            case 6:
                respuesta1.text = "SI";
                respuesta1.color = new Color32(0x94, 0xD0, 0x52, 0xFF);//color verde para si
                break;

        }
    }

    public void pregunta2()
    {
        switch (valorIndRandom)
        {
            case 1:
                respuesta2.text = "SI";
                respuesta2.color = new Color32(0x94, 0xD0, 0x52, 0xFF);//color verde para si
                break;
            case 2:
                respuesta2.text = "SI";
                respuesta2.color = new Color32(0x94, 0xD0, 0x52, 0xFF);//color verde para si
                break;
            case 3:
                respuesta2.text = "NO";
                respuesta2.color = new Color32(0xD9, 0x2C, 0x1E, 0xFF);//color rojo para no
                break;
            case 4:
                respuesta2.text = "NO";
                respuesta2.color = new Color32(0xD9, 0x2C, 0x1E, 0xFF);//color rojo para no
                break;
            case 5:
                respuesta2.text = "NO";
                respuesta2.color = new Color32(0xD9, 0x2C, 0x1E, 0xFF);//color rojo para no
                break;
            case 6:
                respuesta2.text = "NO";
                respuesta2.color = new Color32(0xD9, 0x2C, 0x1E, 0xFF);//color rojo para no
                break;

        }
    }

    public void pregunta3()
    {
        switch (valorIndRandom)
        {
            case 1:
                respuesta3.text = "NO";
                respuesta3.color = new Color32(0xD9, 0x2C, 0x1E, 0xFF);//color rojo para no
                break;
            case 2:
                respuesta3.text = "NO";
                respuesta3.color = new Color32(0xD9, 0x2C, 0x1E, 0xFF);//color rojo para no
                break;
            case 3:
                respuesta3.text = "NO";
                respuesta3.color = new Color32(0xD9, 0x2C, 0x1E, 0xFF);//color rojo para no
                break;
            case 4:
                respuesta3.text = "NO";
                respuesta3.color = new Color32(0xD9, 0x2C, 0x1E, 0xFF);//color rojo para no
                break;
            case 5:
                respuesta3.text = "NO";
                respuesta3.color = new Color32(0xD9, 0x2C, 0x1E, 0xFF);//color rojo para no
                break;
            case 6:
                respuesta3.text = "SI";
                respuesta3.color = new Color32(0x94, 0xD0, 0x52, 0xFF);//color verde para si
                break;

        }
    }

    public void pregunta4()
    {
        switch (valorIndRandom)
        {
            case 1:
                respuesta4.text = "NO";
                respuesta4.color = new Color32(0xD9, 0x2C, 0x1E, 0xFF);//color rojo para no
                break;
            case 2:
                respuesta4.text = "NO";
                respuesta4.color = new Color32(0xD9, 0x2C, 0x1E, 0xFF);//color rojo para no
                break;
            case 3:
                respuesta4.text = "NO";
                respuesta4.color = new Color32(0xD9, 0x2C, 0x1E, 0xFF);//color rojo para no
                break;
            case 4:
                respuesta4.text = "SI";
                respuesta4.color = new Color32(0x94, 0xD0, 0x52, 0xFF);//color verde para si
                break;
            case 5:
                respuesta4.text = "NO";
                respuesta4.color = new Color32(0xD9, 0x2C, 0x1E, 0xFF);//color rojo para no
                break;
            case 6:
                respuesta4.text = "NO";
                respuesta4.color = new Color32(0xD9, 0x2C, 0x1E, 0xFF);//color rojo para no
                break;

        }
    }

    public void pregunta5()
    {
        switch (valorIndRandom)
        {
            case 1:
                respuesta5.text = "NO";
                respuesta5.color = new Color32(0xD9, 0x2C, 0x1E, 0xFF);//color rojo para no
                break;
            case 2:
                respuesta5.text = "SI";
                respuesta5.color = new Color32(0x94, 0xD0, 0x52, 0xFF);//color verde para si
                break;
            case 3:
                respuesta5.text = "NO";
                respuesta5.color = new Color32(0xD9, 0x2C, 0x1E, 0xFF);//color rojo para no
                break;
            case 4:
                respuesta5.text = "NO";
                respuesta5.color = new Color32(0xD9, 0x2C, 0x1E, 0xFF);//color rojo para no
                break;
            case 5:
                respuesta5.text = "NO";
                respuesta5.color = new Color32(0xD9, 0x2C, 0x1E, 0xFF);//color rojo para no
                break;
            case 6:
                respuesta5.text = "NO";
                respuesta5.color = new Color32(0xD9, 0x2C, 0x1E, 0xFF);//color rojo para no
                break;

        }
    }
    

    void setRespuestasInicio()
    {
        respuesta1.text = "";
        respuesta2.text = "";
        respuesta3.text = "";
        respuesta4.text = "";
        respuesta5.text = "";
    }
}
