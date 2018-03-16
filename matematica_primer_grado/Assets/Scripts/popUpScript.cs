﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class popUpScript : MonoBehaviour {

    //script que maneja el comportamiento de los popUps
    //se debe ingresar el texto que indique la escena siguiente
    //las escenas que repiten los ejercicios pero con disintos numeros deben llamarse igual agregando un 30,60 o 100 al final

    public string escenaSiguiente;
    [HideInInspector] public bool bandera1, bandera2, check;
    [HideInInspector] public GameObject popUp, popUpMal;
    private Scene activeScene;

	// Use this for initialization
	void Start () {
        bandera1 = true;
        bandera2 = true;
        check = false;
        activeScene = SceneManager.GetActiveScene();
        popUp = GameObject.FindGameObjectWithTag("popUp"); //referencia a los popUps
        popUpMal = GameObject.FindGameObjectWithTag("popUpMal");
        if (popUp != null)//desactiva los popUps al comenzar la escena
        {
            popUp.SetActive(false);
        }
        if (popUpMal != null)
        {
            popUpMal.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //reinicia la escena
    public void cerrarPopUP()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //lleva a la siguiente escena
    public void siguienteEscena()
    {
        SceneManager.LoadScene(escenaSiguiente);
    }

    //lleva a la misma escena con numeros hasta 30
    public void ejercicios30()
    {
        SceneManager.LoadScene(activeScene.name + "30");
    }

    //lleva a la misma escena con numeros hasta 60
    public void ejercicios60()
    {
        SceneManager.LoadScene(activeScene.name + "60");
    }

    //lleva a la misma escena con numeros hasta 100
    public void ejercicios100()
    {
        SceneManager.LoadScene(activeScene.name + "100");
    }

    
    //metodo que llama al popUp que indica que se ha realizado bien el ejercicio
    public void Bien()
    {
        if (bandera1 && bandera2)
        {
            popUp.SetActive(true);
            if (check == false)
            {
                popUp.GetComponent<Transform>().DOMove(new Vector3(popUp.transform.position.x, popUp.transform.position.y + 0.7f, popUp.transform.position.z), 0.3f);
                check = true;
            }

        }
    }

    //metodo que llama al popUp que indica que se fallo el ejercicio
    public void Mal()
    {
        if (bandera1 && bandera2)
        {
            popUpMal.SetActive(true);
            if (check == false)
            {
                popUpMal.GetComponent<Transform>().DOMove(new Vector3(popUpMal.transform.position.x, popUpMal.transform.position.y + 0.7f, popUpMal.transform.position.z), 0.3f);
                check = true;
            }

        }
    }
}
