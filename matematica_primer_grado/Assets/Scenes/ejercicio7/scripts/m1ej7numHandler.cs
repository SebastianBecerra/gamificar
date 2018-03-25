using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class m1ej7numHandler : MonoBehaviour {

    public GameObject btn; //referencia al btn de reproducir sondo
    public AudioSource sonido; //referencia al audio
    public int cantNumeros; //cantidad de numeros que tiene la plantilla
    popUpScript popUp;//referencia a los popups
    public AudioClip sonidoSiguiente; //siguiente sonido despues de acertar
    changeSprite spr;//referencia para cambiar sprites on click

    // Use this for initialization
    void Start () {
        //asignacion de variables
        btn = GameObject.FindGameObjectWithTag("Player");
        sonido = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
        spr = gameObject.GetComponent<changeSprite>();
        popUp = FindObjectOfType<popUpScript>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnMouseDown()
    {
        if (gameObject.transform.name == "noClick")//si el nombre de el objeto que clickeo es noClick no sucede nada
        {
            return;
        }
        if (btn.GetComponent<Button>().interactable == true) //indica si el boton es interacteable indicando si se proporciono
        {                                                    //el numero en el clip de sonido
            popUp.Mal();//si se puede interactuar significa que no se reprodujo ningun numero, porlotanto no puede seleccionar 
        }
        else
        {
            if (cantNumeros == btn.GetComponent<desabilitarBoton>().aux-1)//si es el ultimo numero a acertar
            {
                if (gameObject.transform.name == sonido.clip.name)//si el nombre del sonido y del objeto concuerdan
                {
                    popUp.Bien();//gano el juego
                    gameObject.transform.name = "noClick";
                }
                else//sino sale el cartel de intentar de nuevo
                {
                    popUp.Mal();
                    gameObject.transform.name = "noClick";
                }
            }
            else//sino es el ultimo numero a acertar
            {
                if (gameObject.transform.name == sonido.clip.name)//si el nombre del sonido y del objeto concuedan
                {
                    popUp.cartelAcierto();//activo el cartel de acierto
                    sonido.clip = sonidoSiguiente;//asigno el siguiente sonido a acertar
                    spr.enabled = false;//desabilito la funcionalidad de cambiar sprite on click
                    gameObject.transform.name = "noClick";//cambio el nombre para que no suceda nada si lo clickeo nuevamente
                }
                else//sino
                {
                    popUp.Mal();//sale el cartel de intentar de nuevo
                    gameObject.transform.name = "noClick";
                }
            }
            btn.GetComponent<Button>().interactable = true;//el boton de reproducir sonido vuelve a ser interactuable para
                                                           //obtener el siguiente sonido a acertar
        }
    }
}
