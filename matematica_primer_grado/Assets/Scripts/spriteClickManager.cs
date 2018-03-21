using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class spriteClickManager : MonoBehaviour {

    //scipt con el comportamiento de chequeo de las banderas de los objetos que tengan componente changeSprite
    //este script debe ir como componente del OBJETO BOTON de la escena 

    public changeSprite[] check; //array que va a hacer referencia a todos los objetos que tengan el script changeSprite
    private Button boton;
    private popUpScript popUp;

	// Use this for initialization
	void Start () {
        popUp = FindObjectOfType<popUpScript>();
        check = FindObjectsOfType<changeSprite>().OrderBy(g => g.transform.GetSiblingIndex()).ToArray(); ; //retorna una lista de todos los objetos activos con el script changeSprite
        //referencia al boton de la escena
        boton = gameObject.GetComponent<Button>();
        boton.onClick.AddListener(TaskOnClick);//comportamiento onclick() del boton
    }
	


    public bool checkBools()//metodo que retorna si todas las banderas son verdaderas
    {
        for (int i=0; i<check.Length; i++)
        {
            if (!check[i].bandera)
            {
                return false;
            }          
        }
        return true;
    }

    public void botonColores() //metodo que llama el evento onClick() del boton
    {
        if (checkBools()) //si todas las variables son verdaderas
        {
            //activa el popUp de ejercicio bien completado
            popUp.Bien();
            foreach (changeSprite a in check)
            {
                a.GetComponent<changeSprite>().enabled = false;//desactiva el comportamiento de cambiar sprites de los objetos
            }
            boton.interactable=false;//desactiva la interactivilidad del boton

        }
        else
        {
            //sino activa el popUp de error, desactiva los sprites y el boton
            popUp.Mal();
            foreach(changeSprite a in check)
            {
                a.GetComponent<changeSprite>().enabled = false;
            }
            boton.interactable = false;
        }
    }

    void TaskOnClick()
    {
        botonColores();
    }
}
