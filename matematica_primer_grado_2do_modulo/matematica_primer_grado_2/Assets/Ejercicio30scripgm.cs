using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ejercicio30scripgm : MonoBehaviour {
    private bool pista1 = true;
    public string respuestaCorrecta, respuestaCorrecta2, respuestaCorrecta3;
    public GameObject pista;
    public GameObject iT;
    private popUpScript popUp;
    public string escenaSiguiente;
    public bool continua;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        popUp = FindObjectOfType<popUpScript>();
	}
    public void PistaSiguiente()
    {
        if (pista1)
        {
            pista.transform.GetChild(0).GetComponent<Text>().enabled = false;
            pista.transform.GetChild(1).GetComponent<Text>().enabled = true;
            pista1 = false;


        }

    }
    public void PistaAnterior()
    {
        if (!pista1)
        {
            pista.transform.GetChild(1).GetComponent<Text>().enabled = false;
            pista.transform.GetChild(0).GetComponent<Text>().enabled = true;
            pista1 = true;

        }

    }
    public void Checkeo()
    {

        if (iT.transform.GetChild(2).GetComponent<Text>().text == respuestaCorrecta || iT.transform.GetChild(2).GetComponent<Text>().text == respuestaCorrecta2 || iT.transform.GetChild(2).GetComponent<Text>().text == respuestaCorrecta3)
        {
            if (continua)
            {
                popUp.cartelAcierto();
                Invoke("sigueEscena", 0.5f);
            }
            else
            {
                popUp.Bien();
            }
     
        }
        else
        {
            popUp.Mal();

        }

    }

    void sigueEscena()
    {
        SceneManager.LoadScene(escenaSiguiente);
    }
}
