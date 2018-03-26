using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class m1ej6ButtonCheck : MonoBehaviour {

    
    ControllerDragAndDrop drag; //referencia al script controllerDragAndDrop
    public DropZone campo1;    //referencia al campo donde se dejan los objetos
    public InputField campo2;   //referencia al inputfield para las escenas de gradualidad
    public int total;       //total para validar
    popUpScript popUP;  //referencia a los popups
    public bool sigue;  //bool para ver si el ejercicio tiene mas de una escena
    public string siguienteEscena;   //escena siguiente que se carga si el ejercicio sigue

	// Use this for initialization
	void Start () {
        //asignacion
        drag = FindObjectOfType<ControllerDragAndDrop>();
        popUP = FindObjectOfType<popUpScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void checkCantidad()//metodo para el checkeo de cantidad en caso de usar drag and drop
    {
        if (campo1.gameObject.transform.childCount == total) //si el campo donde se dejan los objetos tiene la misma cantidad que total
        {
            if (sigue == false)//si la escena no sigue
            {
                popUP.Bien();//muestra el cartel de gano
            }
            else
            {
                popUP.cartelAcierto();//sino muestra el cartel de acierto
                Invoke("cartelAcierto", 0.4f);//y llama a la funcion para cargar la escena siguiente
            }
        }
        else
        {
            popUP.Mal();//si el campo no tiene la misma cantidad que total muestra el cartel de intentar de nuevo
        }
    }

    public void checkInput()//metodo para el checkeo de cantidad en caso de usar inputField
    {
        if (campo2.text == total.ToString())//si lo que escribe en el input es igual al total
        {
            if (sigue == false)//si la escena sigue
            {
                popUP.Bien();//muestra el cartel de gano
            }
            else
            {
                popUP.cartelAcierto();//sino muestra el cartel de acierto
                Invoke("cartelAcierto", 0.4f);//y llama a la funcion para cargar la siguiente escena
            }
        }
        else
        {
            popUP.Mal();//si lo que introdujo en el inputfield no es igual al total, muestra el cartel de intentar de nuevo
        }
    }

    void cartelAcierto()
    {
        SceneManager.LoadScene(siguienteEscena);
    }

}
