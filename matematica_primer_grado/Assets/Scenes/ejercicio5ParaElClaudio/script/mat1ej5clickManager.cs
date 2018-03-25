using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mat1ej5clickManager : MonoBehaviour
{

    mat1ej5controller clicker;//referencia al controller que tiene los componentes de carta 
    popUpScript popUP;//referenci al popUp
    GameObject parent;

    // Use this for initialization
    void Start()
    {
        clicker = FindObjectOfType<mat1ej5controller>();//asinacion a las variables
        popUP = FindObjectOfType<popUpScript>();
        parent = gameObject.transform.parent.gameObject;
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
                parent.transform.GetChild(0).transform.name = "noClick";//cambio el nombre del par que corersponde
                parent.transform.GetChild(1).transform.name = "noClick";
                switch (parent.transform.name)//desactivo boton dependiendo el par
                {
                    case "par1":
                        clicker.btns[0].GetComponent<Button>().interactable = false;
                        break;
                    case "par2":
                        clicker.btns[1].GetComponent<Button>().interactable = false;
                        break;
                    case "par3":
                        clicker.btns[2].GetComponent<Button>().interactable = false;
                        break;
                    case "par4":
                        clicker.btns[3].GetComponent<Button>().interactable = false;
                        break;
                }
                if (clicker.estado == 3)//si este es el penultimo par invoco funcion para saber que me queda el ultimo par
                {
                    Invoke("cambiarBandera", 0.5f);
                }
            }
            else//si clickeo mal pierdo y aparece el cartel de intentar de nuevo
            {
                popUP.Mal();
                clicker.desactivarCartasyBotones();//desactivo toda interactividad con la escena
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
                clicker.desactivarCartasyBotones();//desactivo toda interactividad con la escena
            }
        }
    }

    void cambiarBandera()
    {
        clicker.banderaUltimoPar = true;
    }
}

