using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class m1ej7numHandler : MonoBehaviour {

    public GameObject btn;
    public AudioSource sonido;
    public int cantNumeros;
    popUpScript popUp;
    public AudioClip sonidoSiguiente;
    changeSprite spr;

    // Use this for initialization
    void Start () {
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
        if (gameObject.transform.name == "noClick")
        {
            return;
        }
        if (btn.GetComponent<Button>().interactable == true) //indica si el boton es interacteable indicando si se proporciono
        {                                                    //el numero en el clip de sonido
            popUp.Mal();//si se puede interactuar significa que no se reprodujo ningun numero, porlotanto no puede seleccionar 
        }
        else
        {
            if (cantNumeros == btn.GetComponent<desabilitarBoton>().aux-1)
            {
                if (gameObject.transform.name == sonido.clip.name)
                {
                    popUp.Bien();
                    gameObject.transform.name = "noClick";
                }
                else
                {
                    popUp.Mal();
                    gameObject.transform.name = "noClick";
                }
            }
            else
            {
                if (gameObject.transform.name == sonido.clip.name)
                {
                    popUp.cartelAcierto();
                    sonido.clip = sonidoSiguiente;
                    spr.enabled = false;
                    gameObject.transform.name = "noClick";
                }
                else
                {
                    popUp.Mal();
                    gameObject.transform.name = "noClick";
                }
            }
            btn.GetComponent<Button>().interactable = true;
        }
    }
}
