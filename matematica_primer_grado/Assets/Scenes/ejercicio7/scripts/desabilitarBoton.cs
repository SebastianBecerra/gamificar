using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class desabilitarBoton : MonoBehaviour
{
    //script con la funcionalidad de los botones de reproducir sonido y identificar si se encuentra o no en el carton

    private Button btn;//referencia al boton reproducir sonido donde se encuentra este script
    private GameObject btn_noEsta,btn2; //referencia al boton que indica que el sonido no esta
    public AudioClip sonidoNoEsta; //referencai al sonido que no se encuentra en la escena
    public AudioClip sonidoSiguiente; //sonido que sigue si se acierta
    private AudioClip sonidoAux; //variable que compara el sonido con el que no se encuentra
    private AudioSource sonido; //referencia al audiosource del boton de reproducir sonido
    popUpScript popUp; //referencia a los popups
    public int aux=0;

    // Use this for initialization
    void Start()
    {
        //asignacion de las variables
        btn = gameObject.GetComponent<Button>();
        btn2 = GameObject.FindGameObjectWithTag("Player");
        btn_noEsta = GameObject.FindGameObjectWithTag("Cuadrado");
        sonido = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
        popUp = FindObjectOfType<popUpScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    //metodo del boton reproducir sonido 
    public void unabled()
    {
        AudioSource audio = GetComponent<AudioSource>();//reproduce el primer audio seteado
        audio.Play();
        sonidoAux = btn.GetComponent<AudioSource>().clip; //lo guarda para comparacion
        btn.interactable = false; //se hace no interactuable hasta que acierte si se encuentra ese numero o no
        btn_noEsta.GetComponent<desabilitarBoton>().sonidoAux = sonidoAux; //le asigna el sonido auxiliar al otro boton para comparar
        aux++;
    }

    //metodo para el boton que identifica si el numero reproducido no se encuentra en el carton
    public void noEsta()
    {
        if (btn_noEsta.GetComponent<desabilitarBoton>().sonidoAux == sonidoNoEsta)//si la comparacion es verdadera significa que
        {                                                                         //el numero reproducido es el que no se encuentra
            popUp.cartelAcierto(); //activa el cartel de acierto
            sonido.clip = sonidoSiguiente; //asigna el sonido siguiente
            //btn.interactable = true;
            btn2.GetComponent<Button>().interactable = true; //el boton vuelve a ser interactuable
        }
        else
        {
            popUp.Mal();//si falla la comparacion, aparece el cartel de intentar denuevo
        }
    }
}
