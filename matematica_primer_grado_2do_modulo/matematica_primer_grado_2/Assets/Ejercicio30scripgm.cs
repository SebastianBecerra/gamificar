using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ejercicio30scripgm : MonoBehaviour {
    private bool pista1 = true;
    public string respuestaCorrecta, respuestaCorrecta2;
    public GameObject pista;
    public GameObject iT;
    private popUpScript popUp;
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

        if (iT.transform.GetChild(2).GetComponent<Text>().text == respuestaCorrecta || iT.transform.GetChild(2).GetComponent<Text>().text == respuestaCorrecta2)
        {
            popUp.Bien();
     
        }
        else
        {
            popUp.Mal();

        }

    }
}
