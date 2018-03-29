using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class m1ej13cajaController : MonoBehaviour {

    public DropZone zonaDrop; //referencia a la zona donde se dejan los objetos
    private List<Vector3> positions = new List<Vector3>(); //listas que contienen los lugares a moverse en las transisiones
    public List<GameObject> lugares = new List<GameObject>();
    private int longitudMostrar; //longitud que va a mostrar la caja despues de ingresar los objetos
    private int estado; //indica el estado del juego, 0:inicializacion, ingreso de objetos, 1:resolucion, ingreso de texto 
    private Dragable[] dragChildren; //referencia a los objetos que se draguean en la escena
    private GameObject cartelPregunta; //cartel con la pregunta para ganar el juego
    private InputField inputPlayer; //input para ingresar cantidad
    popUpScript popUP; //refferencia a los popups
    public string siguienteEscena; //escena que se carga luego de completar este juego

    // Use this for initialization
    void Start () {
        SavePositions();//guarda las posiciones para las transiciones
        dragChildren = FindObjectsOfType<Dragable>();//asignacion de variables
        inputPlayer = GameObject.FindGameObjectWithTag("input1").GetComponent<InputField>();
        cartelPregunta = GameObject.FindGameObjectWithTag("input2");
        cartelPregunta.SetActive(false);//se esconde la pregunta para mostrarla una vez que el juego entre e su segundo estado
        longitudMostrar = Random.Range(2, 6); //randomizacion de los objetos que va a mostrar la caja
        popUP = FindObjectOfType<popUpScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()//al hacer click en la caja
    {
        if (zonaDrop.gameObject.transform.childCount >= 10 &&estado==0) //si ya ingreso los 10 objetos y es el primer estado
        {
            estado = 1;//cambio de estado
            foreach(Dragable a in dragChildren)
            {
                a.enabled = false;//desabilito la posibilidad de sacar los objetos de la caja
            }
            //muevo los objetos dentro de la caja
            zonaDrop.GetComponent<Transform>().DOMove(new Vector3(zonaDrop.transform.position.x + 6 , zonaDrop.transform.position.y , zonaDrop.transform.position.z), 0.5f);
            Invoke("shake", 0.8f);//invoco la funcion que mueve la caja hacia los lados
            Invoke("mostrar", 1.5f);//muestro los objetos dependiendo del valor randomizado
        }
        else
        {
            return;//sino ingreso los objetos o el juego esta en su segundo estado no sucede nada 
        }
    }

    void shake()//funcion para mover la caja hacia los lados
    {
        gameObject.GetComponent<Transform>().DOPath(positions.ToArray(), 0.2f);
        gameObject.GetComponent<Transform>().DOPath(positions.ToArray(), 0.2f);
    }

    void mostrar()//funcion que muestra los objetos dependiendo del valor randomizado y muestra el cartel con la pregunta
    {
        zonaDrop.GetComponent<Transform>().DOMove(new Vector3(zonaDrop.transform.position.x - longitudMostrar, zonaDrop.transform.position.y, zonaDrop.transform.position.z), 0.5f);
        cartelPregunta.SetActive(true);
        cartelPregunta.GetComponent<objTransition>().enabled = true;
    }
    
    void SavePositions()//funcion que guarda las posiciones para las transiciones
    {
        foreach (GameObject g in lugares)
        {
            positions.Add(g.transform.position);
        }
    }

    public void botonCantidad()//metodo utilizado en el boton para validar
    {
        switch (longitudMostrar)//dependiendo del valor randomizado se checkea el valor ingresado en el input
        {
            case 2:
                if (inputPlayer.text == (zonaDrop.gameObject.transform.childCount * 0.8).ToString())//si esta bien muestra el cartel de acierto y carga la siguiente escena
                {
                    popUP.cartelAcierto();
                    Invoke("cartelAcierto", 0.4f);
                }
                else
                {
                    popUP.Mal();//sino muestra el cartel de intentar de nuevo
                }
                break;
            case 3:
                if (inputPlayer.text == (zonaDrop.gameObject.transform.childCount * 0.6).ToString())
                {
                    popUP.cartelAcierto();
                    Invoke("cartelAcierto", 0.4f);
                }
                else
                {
                    popUP.Mal();
                }
                break;
            case 4:
                if (inputPlayer.text == (zonaDrop.gameObject.transform.childCount * 0.4).ToString())
                {
                    popUP.cartelAcierto();
                    Invoke("cartelAcierto", 0.4f);
                }
                else
                {
                    popUP.Mal();
                }
                break;
            case 5:
                if (inputPlayer.text == (zonaDrop.gameObject.transform.childCount * 0.2).ToString())
                {
                    popUP.cartelAcierto();
                    Invoke("cartelAcierto", 0.4f);
                }
                else
                {
                    popUP.Mal();
                }
                break;
            case 6:
                if (inputPlayer.text == "0")
                {
                    popUP.cartelAcierto();
                    Invoke("cartelAcierto", 0.4f);
                }
                else
                {
                    popUP.Mal();
                }
                break;
        }
    }

    void cartelAcierto()//funcion para cargar la siguiente escena luego de que el cartel de acierto finalize su transicion
    {
        SceneManager.LoadScene(siguienteEscena);
    }
    
}
