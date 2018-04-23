using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ej25mod2Resp : MonoBehaviour {

    public Text respuesta1,respuesta2, respuesta3, respuesta4, respuesta5; //referencia textos con las respuestas a las preguntas
    public bool oso, barco, lampara, baul, lapices, zapatilla;
    public int valorIndRandom; //valor que randomiza el objeto a encontrar
    public GameObject osoObj, barcoObj, lamparaObj, baulObj, lapicesObj, zapatillaObj; //referencia a los objetos a cambiar de color

    //1-oso
    //2-barco
    //3-lampara
    //4-baul
    //5-lapices
    //6-zapatilla


	// Use this for initialization
	void Start () {
        setRespuestasInicio(); //seteo todas las respuestas a un texto vacio
        valorIndRandom = Random.Range(1, 7); //randomizo un valor de 1 a 6

        switch (valorIndRandom) //dependiendo del valor indico si el objeto debe cambiarse de color para resolver el ejercicio
        {
            case 1:
                oso = true;
                osoObj.GetComponent<changeSprite>().color = true;
                osoObj.GetComponent<changeSprite>().bandera = false;
                break;
            case 2:
                barco = true;
                barcoObj.GetComponent<changeSprite>().color = true;
                barcoObj.GetComponent<changeSprite>().bandera = false;
                break;
            case 3:
                lampara = true;
                lamparaObj.GetComponent<changeSprite>().color = true;
                lamparaObj.GetComponent<changeSprite>().bandera = false;
                break;
            case 4:
                baul = true;
                baulObj.GetComponent<changeSprite>().color = true;
                baulObj.GetComponent<changeSprite>().bandera = false;
                break;
            case 5:
                lapices = true;
                lapicesObj.GetComponent<changeSprite>().color = true;
                lapicesObj.GetComponent<changeSprite>().bandera = false;
                break;
            case 6:
                zapatilla = true;
                zapatillaObj.GetComponent<changeSprite>().color = true;
                zapatillaObj.GetComponent<changeSprite>().bandera = false;
                break;
        }



    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //metodos para los botones con las preguntas

    public void pregunta1()//¿ESTA A LA DERECHA DE LA LAMPARA?
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

    public void pregunta2()//¿ESTA A LA IZQUIERDA DE LA LAMPARA?
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

    public void pregunta3()//¿ESTA ABAJO DE LOS LAPICES?
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

    public void pregunta4()//¿ESTA ARRIBA DE LOS LAPICES?
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

    public void pregunta5()//¿ESTA ABAJO DEL OSO?
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
    

    void setRespuestasInicio()//setea todas las respuestas a un texto vacio al comenzar el ejercicio
    {
        respuesta1.text = "";
        respuesta2.text = "";
        respuesta3.text = "";
        respuesta4.text = "";
        respuesta5.text = "";
    }
}
