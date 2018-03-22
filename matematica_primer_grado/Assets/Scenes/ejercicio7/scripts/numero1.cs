using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class numero1 : MonoBehaviour
{
    //script con la funcionalidad de identificar si el numero clickeado es el que reprodujo 

    public GameObject btn; //referencia al btn para volverlo a hacer interactuable
    public AudioSource sonido; //referencia al audiosource que contiene el clip a reproducir
    public AudioClip sonidoSiguiente; //referencia al clip que se va a asignar al audiosource
    popUpScript popUp; //referencia a los popUps
    changeSprite spr; //referencia al sciprt changeSprite que proporciona la funcionalidad de cambiar el sprite al momento de darle click
    // Use this for initialization
    void Start()
    {
        //asignacion de las variables
        btn = GameObject.FindGameObjectWithTag("Player");
        sonido = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
        spr = gameObject.GetComponent<changeSprite>();
        popUp = FindObjectOfType<popUpScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    //metodo que se llama al clickear el boton del mouse
    private void OnMouseDown()
    {
        if (btn.GetComponent<Button>().interactable == true) //indica si el boton es interacteable indicando si se proporciono
        {                                                    //el numero en el clip de sonido
            popUp.Mal();//si se puede interactuar significa que no se reprodujo ningun numero, porlotanto no puede seleccionar 
        }               //ninguno, entonces al seleccionar aparece el cartel de intentar denuevo
        else
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//sino es interactuable hace un raycast
            // Casts the ray and get the first game object hit
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            if (hit.transform.name == "numero1" && sonido.clip.name == "voz-uno")//si el rayo golpea a un objeto con el nombre dado
            {                                                                   //y el clip reproducido concuerda
                Debug.Log("numero 1 bien");
                popUp.cartelAcierto(); //desplega el cartel de acierto
                sonido.clip = sonidoSiguiente;//asigna el sonido siguiente a reproducirse
                spr.enabled = false;//desabilita la funcionalidad de cambiar de sprite del numero bien seleccionado

            }
            else
            {
                popUp.Mal();//si falla al seleccionar despues de reproduccir un numero, aparece el cartel de intentar de nuevo
            }
            btn.GetComponent<Button>().interactable = true; //el boton de reproducir vuelve a ser interactuable
        }
    }
}
