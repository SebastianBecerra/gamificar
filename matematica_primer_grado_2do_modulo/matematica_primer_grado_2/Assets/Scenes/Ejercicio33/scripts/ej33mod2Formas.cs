using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ej33mod2Formas : MonoBehaviour {

    private int contCantidad;//entero que indica la cantidad de pistas seleccionadas
    public Text respuesta1, respuesta2, respuesta3, respuesta4, cantPistas;//referencias a los textos de las preguntas y cantidad de pistas seleccionadas
    public Button btn1, btn2, btn3, btn4;//referencia a los botones de preguntass
    public string txt1, txt2, txt3, txt4, respuestaCorrecta, siguienteEscena; //referencia a las respuesta y string que indica la escena siguiente si el juego continua
    public GameObject input,figura; //referencia al input text y la figura a mostrar
    public bool continua;//booleana que indica si el juego continua o termina en esa escena
    popUpScript popUP;//referencia a los popups

	// Use this for initialization
	void Start () {
        popUP = FindObjectOfType<popUpScript>();//asigno popups
        respuesta1.text = "";//seteo los textos de las respuestas para que no muestren ningun texto
        respuesta2.text = "";
        respuesta3.text = "";
        respuesta4.text = "";
        cantPistas.text = "";//seteo la cantidad de pistas que no muestre ningun numero
        contCantidad = 0;//cantidad de pistas clickeadas es 0 al comenzar
        input = GameObject.FindGameObjectWithTag("Player");//asignacion al input text
        figura.SetActive(false);//desactivo la figura al comenzar el juego
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //COMIENZO DE BOTONES DE PISTAS//

    public void clickPista1()//pista 1
    {
        respuesta1.text = txt1;//le asigno la respuesta
        if (txt1 == "SI")//dependiendo si es SI o NO la respuesta asigno el color al texto
        {
            respuesta1.color = new Color32(0x94,0xD0,0x52,0xFF);//verde para si
        }
        if (txt1 == "NO")
        {
            respuesta1.color = new Color32(0XD9,0X2C,0X1E,0XFF);//rojo para no
        }
        contCantidad++;//aumento la cantidad de pistas clickeadas 
        btn1.interactable = false;//y desactivo la interactibilidad del boton
    }

    public void clickPista2()//pista 2
    {
        respuesta2.text = txt2;
        if (txt2 == "SI")
        {
            respuesta2.color = new Color32(0x94, 0xD0, 0x52, 0xFF);
        }
        if (txt2 == "NO")
        {
            respuesta2.color = new Color32(0XD9, 0X2C, 0X1E, 0XFF);
        }
        contCantidad++;
        btn2.interactable = false;
    }

    public void clickPista3()//pista 3
    {
        respuesta3.text = txt3;
        if (txt3 == "SI")
        {
            respuesta3.color = new Color32(0x94, 0xD0, 0x52, 0xFF);
        }
        if (txt3 == "NO")
        {
            respuesta3.color = new Color32(0XD9, 0X2C, 0X1E, 0XFF);
        }
        contCantidad++;
        btn3.interactable = false;
    }

    public void clickPista4()//pista 4
    {
        respuesta4.text = txt4;
        if (txt4 == "SI")
        {
            respuesta4.color = new Color32(0x94, 0xD0, 0x52, 0xFF);
        }
        if (txt4 == "NO")
        {
            respuesta4.color = new Color32(0XD9, 0X2C, 0X1E, 0XFF);
        }
        contCantidad++;
        btn4.interactable = false;
    }

    //FIN DE BOTONES DE PISTAS//

    public void RespuestaCheck()//metodo que se llama al finalizar del ingreso del input text 
    {
        if (input.transform.GetChild(1).GetComponent<Text>().text.ToUpper() == respuestaCorrecta)//si el texto ingresado essta bien
        {
            figura.SetActive(true);//activa la figura
            cantPistas.text = contCantidad.ToString();//muestra la cantidad de pistas clickeadas
            if (continua)//si el ejercicio continua
            {
                popUP.cartelAcierto();//muestra el cartel de acierto
                Invoke("escenaSiguiente", 0.5f);//invoca la funcion que llama la escena siguiente
            }
            else//sin el ejercicio no continua
            {
                Invoke("mostrarBien", 0.5f);//invoca la funcion que llama al popup bien
            }
        }
        else//si el texto ingresado esta mal
        {
            figura.SetActive(true);//muestra la figura
            cantPistas.text = contCantidad.ToString();//muestra la cantidad de pistas clickeadas
            Invoke("mostrarMal", 0.5f);//inoca la funcion que llama al popup Mal
        }
    }

    //funciones que muestran los popups
    void mostrarBien()
    {
        popUP.Bien();
    }

    void mostrarMal()
    {
        popUP.Mal();
    }

    void escenaSiguiente()//funcion que llama a la escena siguiente
    {
        SceneManager.LoadScene(siguienteEscena);
    }

}
