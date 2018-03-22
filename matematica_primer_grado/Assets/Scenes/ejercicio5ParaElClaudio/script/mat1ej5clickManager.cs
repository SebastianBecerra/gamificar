using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mat1ej5clickManager : MonoBehaviour
{

    mat1ej5controller clicker;//referencia al controller que tiene los componentes de carta 
    popUpScript popUP;//referenci al popUp

    // Use this for initialization
    void Start()
    {
        clicker = FindObjectOfType<mat1ej5controller>();//asinacion a las variables
        popUP = FindObjectOfType<popUpScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown()//al hacer click
    {
        if (gameObject.transform.name == "noClick")//si tiene el nombre noClick no entra
        {
            return;
        }
        if (clicker.estado < 3)//chequeo que no sea el ultimo par
        {
            if (gameObject.transform.name == "mayor"&&gameObject.GetComponent<Carta>())//si lo que clickeo tiene el nombre mayor
            {                                                                          //y tiene el componente carta
                popUP.cartelAcierto();//activo el cartel de acierdo
                clicker.estado++;//accedo al controller y sump estado
                gameObject.GetComponent<Carta>().enabled = false;//quito funcionalidad al objeto clickeado
                gameObject.GetComponent<InteractuableScale>().enabled = false;
                gameObject.transform.name = "check";
                if (clicker.estado == 3)//si este es el penultimo par invoco funcion para saber que me queda el ultimo par
                {
                    Invoke("cambiarBandera", 0.5f);
                }
            }
            else//si clickeo mal pierdo y aparece el cartel de intentar de nuevo
            {
                popUP.Mal();
            }
        }
        if (clicker.banderaUltimoPar)//si queda solo el ultimo par activo el popUp.Bien en vez de acierto para ganar
        {
            if (gameObject.transform.name == "mayor" && gameObject.GetComponent<Carta>())
            {
                gameObject.GetComponent<Carta>().enabled = false;
                gameObject.GetComponent<InteractuableScale>().enabled = false;
                popUP.Bien();
                for (int i = 0; i <= clicker.cartas.Length; i++)
                {
                    clicker.cartas[i].transform.name = "noClick"; //al ganar seteo todo para que no funcione
                }
            }
            else
            {
                popUP.Mal();
            }
        }
    }

    void cambiarBandera()
    {
        clicker.banderaUltimoPar = true;
    }
}

