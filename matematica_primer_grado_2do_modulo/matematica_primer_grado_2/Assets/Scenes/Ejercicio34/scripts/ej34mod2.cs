using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ej34mod2 : MonoBehaviour {

    spriteClickManager sprControl;//referencia al script que contiene cl control de los sprites
    public bool continuar;//indica si el juego continua
    public string escenaSiguiente;//indica la escena siguiente si el juego continua
    popUpScript popUp;//referencia a los popups

    // Use this for initialization
    void Start()
    {
        sprControl = FindObjectOfType<spriteClickManager>();//asignacion de variables
        popUp = FindObjectOfType<popUpScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void checkearNumeros()//metodo utilizado por el boton de validar
    {
        if (sprControl.checkBools())//llamo al metodo del script que checkea cada bool y retorna si estan bien los sprites
        {
            if (continuar)//si el juego continua y los sprites estan bien
            {
                popUp.cartelAcierto();//muestra el cartel de acierto
                Invoke("siguienteEscena", 0.5f);//y carga la siguiente escena
            }
            else
            {
                popUp.Bien();//si los sprites estan bien y el juego no continua, llamo al scrit de juego completado
            }
        }
        else
        {
            popUp.Mal();//si los sprites estan mal, llamo al script de intentar de nuevo
        }
    }

    void siguienteEscena()//funcion que carga la escena siguiente
    {
        SceneManager.LoadScene(escenaSiguiente);
    }
}

