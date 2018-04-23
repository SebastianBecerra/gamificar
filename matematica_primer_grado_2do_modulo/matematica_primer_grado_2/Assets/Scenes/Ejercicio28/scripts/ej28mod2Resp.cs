using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ej28mod2Resp : MonoBehaviour {

    public Text respuesta1, respuesta2, respuesta3;//referencia al texto de las respuestas
    private int randomSelect; //selector random
    private bool bandera1, bandera2, bandera3; //bandera que indican que respuesta es la correcta
    public bool continua; //booleana que indica si continua a otra escena
    public string escenaSiguiente, respuestaCorrecta, respuestaIncorrecta1, respuestaIncorrecta2; //si continua indica a que nombre de escena sigue
    popUpScript popUp; //referencia a los popups


    // Use this for initialization
    void Start () {
        popUp = FindObjectOfType<popUpScript>();//asignacion popUps
        randomSelect = Random.Range(1, 4);//numero aleatorio de 1 a 3
        switch (randomSelect)//dependiendo del valor del numero aleatorio cambian el orden de las respuestas
        {
            case 1:
                respuesta1.text = respuestaCorrecta;
                bandera1 = true;
                respuesta2.text = respuestaIncorrecta1;
                bandera2 = false;
                respuesta3.text = respuestaIncorrecta2;
                bandera3 = false;
                break;
            case 2:
                respuesta1.text = respuestaIncorrecta1;
                bandera1 = false;
                respuesta2.text = respuestaIncorrecta2;
                bandera2 = false;
                respuesta3.text = respuestaCorrecta;
                bandera3 = true;
                break;
            case 3:
                respuesta1.text = respuestaIncorrecta1;
                bandera1 = false;
                respuesta2.text = respuestaCorrecta;
                bandera2 = true;
                respuesta3.text = respuestaIncorrecta2;
                bandera3 = false;
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //metodo para cada uno de los botones respuesta

    public void resp1()
    {
        if (bandera1)//si esta es la respuesta correcta
        {
            if (continua)//si continua
            {
                popUp.cartelAcierto();//muestra el cartel de acierto
                Invoke(escenaSiguiente, 0.5f);//y carga la siguiente escena
            }
            else//sino continua termina el popup bien
            {
                popUp.Bien();
            }
        }
        else//sino muestra el popup mal
        {
            popUp.Mal();
        }
    }

    public void resp2()
    {
        if (bandera2)//si esta es la respuesta correcta
        {
            if (continua)//si continua
            {
                popUp.cartelAcierto();//muestra el cartel de acierto
                Invoke(escenaSiguiente, 0.5f);//y carga la siguiente escena
            }
            else//sino continua muestra el popup bien
            {
                popUp.Bien();
            }
        }
        else//sino muestra el popup mal
        {
            popUp.Mal();
        }
    }

    public void resp3()
    {
        if (bandera3)//si esta es la respuesta correcta
        {
            if (continua)//si continua
            {
                popUp.cartelAcierto();//muestra el cartel de acierto
                Invoke(escenaSiguiente, 0.5f);//y carga la siguiente escena
            }
            else//sino continua muestra el popup bien
            {
                popUp.Bien();
            }
        }
        else//sino muestra el popup mal
        {
            popUp.Mal();
        }
    }

    void siguienteEscena()//funcion que carga la escena siguiente
    {
        SceneManager.LoadScene(escenaSiguiente);
    }

}
