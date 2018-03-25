using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class mat1ej5controller : MonoBehaviour {


    public Carta[] cartas; //array que va a contener a todos los objetos Carta
    public bool igualPar1, igualPar2, igualPar3, igualPar4; //banderas en caso de igualdad de pares
    popUpScript popUp; //referencia a los popUps

    public int estado; //variable que lleva la cuenta de cantidad de aciertos
    public bool banderaUltimoPar = false; //cuando estado llega a 3 se activa esta booleana para saber en que momento activar
                                          //el popUp de stage completa

    public GameObject[] btns;

    private void Awake()
    {
        cartas = FindObjectsOfType<Carta>().OrderBy(go => go.name).ToArray(); //asigno los objetos carta al array en orden
        darValores(); //llamada a la funcion que asigna valores aleatorios
        comparacion(); //comparacion de pares
    }

    // Use this for initialization
    void Start() {
        popUp = FindObjectOfType<popUpScript>(); //asignacion del popUp script
        estado = 0; //se empieza en estado 0, sin aciertos
        btns = GameObject.FindGameObjectsWithTag("input2").OrderBy(go => go.name).ToArray();
    }

    // Update is called once per frame
    void Update() {

    }

    void darValores()//por cada objeto carta en el array cartas, le asigna un valor random entre 0 y 9 inclusive a cada variable valor
    {
        foreach (Carta a in cartas)
        {
            a.valor = Random.Range(1, 9);
        }
    }

    void comparacion() //comparo pares(0,1), (2,3), (4,5) y (6,7) en caso de igualdad activo la booleana correspondiente que lo indica
    {
        //par1 (0,1)
        if (cartas[0].valor != cartas[1].valor)//si los valores no son iguales
        {
            if (cartas[0].valor > cartas[1].valor)//compara y asigna el nombre mayor al mas grande
            {                                     //el nomber mayor es la referencia para hacer click bien en caso de que no sean iguales
                cartas[0].transform.name = "mayor";
                cartas[1].transform.name = "menor";
            }
            else
            {
                cartas[1].transform.name = "mayor";
                cartas[0].transform.name = "menor";
            }
        }
        else
        {
            igualPar1 = true;//en caso de igualdad del par se asigna true a la booleana, para despues ser usada en los botones
        }

        //par2 (2,3)
        if (cartas[2].valor != cartas[3].valor)
        {
            if (cartas[2].valor > cartas[3].valor)
            {
                cartas[2].transform.name = "mayor";
                cartas[3].transform.name = "menor";
            }
            else
            {
                cartas[3].transform.name = "mayor";
                cartas[2].transform.name = "menor";
            }
        }
        else
        {
            igualPar2 = true;
        }

        //par3 (4,6)
        if (cartas[4].valor != cartas[5].valor)
        {
            if (cartas[4].valor > cartas[5].valor)
            {
                cartas[4].transform.name = "mayor";
                cartas[5].transform.name = "menor";
            }
            else
            {
                cartas[5].transform.name = "mayor";
                cartas[4].transform.name = "menor";
            }
        }
        else
        {
            igualPar3 = true;
        }

        //par4 (6,7)
        if (cartas[6].valor != cartas[7].valor)
        {
            if (cartas[6].valor > cartas[7].valor)
            {
                cartas[6].transform.name = "mayor";
                cartas[7].transform.name = "menor";
            }
            else
            {
                cartas[7].transform.name = "mayor";
                cartas[6].transform.name = "menor";
            }
        }
        else
        {
            igualPar4 = true;
        }
    }

    public void btnIgualPar1()//metodo para el boton de igualdad en el primer par
    {
        if (igualPar1)//si los valores del primer par son iguales
        {
            if (estado == 3) //me fijo si este es el ultimo par a checkear y si lo es activo popUp.Bien
            {
                popUp.Bien();
                desactivarCartasyBotones();//quito toda interactividad con la escene
            }
            else//sino al acer click 
            {
                popUp.cartelAcierto();// se activa el boton acierto
                estado++;//se le suma uno a estado para dar a saber que se completo un par
                if (estado == 3)//si ya he acertado 3 veces activo la flag que indica que queda solo un acierto para ganar
                {
                    banderaUltimoPar = true;
                }
                cartas[0].GetComponent<Carta>().enabled = false;//se le quita funcionalidad al par
                cartas[1].GetComponent<Carta>().enabled = false;
                cartas[0].GetComponent<InteractuableScale>().enabled = false;
                cartas[1].GetComponent<InteractuableScale>().enabled = false;
                cartas[0].transform.name = "noClick";//cambio nombre al par
                cartas[1].transform.name = "noClick";
                btns[0].GetComponent<Button>().interactable = false;//hago no interactuable al boton
            }
        }
        else
        {
            popUp.Mal();//si los valores no son iguales pierde y sale el cartel de intentar de nuevo
            desactivarCartasyBotones();//quito toda interactividad con la escene
        }
    }

    public void btnIgualPar2()
    {
        if (igualPar2)
        {
            if (estado == 3)
            {
                popUp.Bien();
                desactivarCartasyBotones();
            }
            else
            {
                popUp.cartelAcierto();
                estado++;
                if (estado == 3)
                {
                    banderaUltimoPar = true;
                }
                cartas[2].GetComponent<Carta>().enabled = false;
                cartas[3].GetComponent<Carta>().enabled = false;
                cartas[2].GetComponent<InteractuableScale>().enabled = false;
                cartas[3].GetComponent<InteractuableScale>().enabled = false;
                cartas[2].transform.name = "noClick";
                cartas[3].transform.name = "noClick";
                btns[1].GetComponent<Button>().interactable = false;
            }
        }
        else
        {
            popUp.Mal();
            desactivarCartasyBotones();
        }
    }

    public void btnIgualPar3()
    {
        if (igualPar3)
        {
            if (estado == 3)
            {
                popUp.Bien();
                desactivarCartasyBotones();
            }
            else
            {
                popUp.cartelAcierto();
                estado++;
                if (estado == 3)
                {
                    banderaUltimoPar = true;
                }
                cartas[4].GetComponent<Carta>().enabled = false;
                cartas[5].GetComponent<Carta>().enabled = false;
                cartas[4].GetComponent<InteractuableScale>().enabled = false;
                cartas[5].GetComponent<InteractuableScale>().enabled = false;
                cartas[2].transform.name = "noClick";
                cartas[3].transform.name = "noClick";
                btns[2].GetComponent<Button>().interactable = false;
            }
        }
        else
        {
            popUp.Mal();
            desactivarCartasyBotones();
        }
    }

    public void btnIgualPar4()
    {
        if (igualPar4)
        {
            if (estado == 3)
            {
                popUp.Bien();
                desactivarCartasyBotones();
            }
            else
            {
                popUp.cartelAcierto();
                estado++;
                if (estado == 3)
                {
                    banderaUltimoPar = true;
                }
                cartas[6].GetComponent<Carta>().enabled = false;
                cartas[7].GetComponent<Carta>().enabled = false;
                cartas[6].GetComponent<InteractuableScale>().enabled = false;
                cartas[7].GetComponent<InteractuableScale>().enabled = false;
                cartas[6].transform.name = "noClick";
                cartas[7].transform.name = "noClick";
                btns[3].GetComponent<Button>().interactable = false;
            }
        }
        else
        {
            popUp.Mal();
            desactivarCartasyBotones();
        }
    }

    public void desactivarCartasyBotones()//metodo para que las cartas y los botones dejen de ser clickeables en caso de ganar o perder
    {
        foreach (Carta b in cartas)
        {
            b.transform.name = "noClick";
        }
        foreach (GameObject c in btns)
        {
            c.GetComponent<Button>().interactable = false;
        }
    }
}
