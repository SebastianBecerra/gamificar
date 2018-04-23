using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ej25mod2Preg : MonoBehaviour
{

    private List<Vector3> positions = new List<Vector3>(); //listas que contienen los lugares a moverse en las transisiones
    public List<GameObject> lugares = new List<GameObject>();
    public GameObject objMover;//referencia al objeto a mover
    private bool regresar;//indica si el objeto hizo su primer recorrido
    public string texto1,texto2;

    // Use this for initialization
    void Start()
    {
        SavePositions();//llamo al metodo que guarda las posiciones asignadas
        gameObject.GetComponentInChildren<Text>().text = texto1;//cambio el texto del boton al comienzo del juego
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SavePositions()//funcion que guarda las posiciones para las transiciones
    {
        foreach (GameObject g in lugares)
        {
            positions.Add(g.transform.position);
        }
    }

    public void moverObjeto()//metodo que itiliza el boton ver/ocultar tienda
    {
        if (regresar)//si el boton hizo su primer movimiento
        {
            ReversePositions();//revierto el orden de las posiciones
            objMover.GetComponent<Transform>().DOPath(positions.ToArray(), 0.8f);//muevo el objeto
            ReversePositions();//vuelvo el orden de las posiciones a su estado original
            regresar = false;//indico que no tiene que volver
            gameObject.GetComponentInChildren<Text>().text = texto1;//cambio el texto del boton
        }
        else//sino
        {
            objMover.GetComponent<Transform>().DOPath(positions.ToArray(), 0.8f);//muevo el objeto
            regresar = true;//indico que tiene que volver
            gameObject.GetComponentInChildren<Text>().text = texto2;//cambio el texto del boton
        }
    }

    void ReversePositions()//metodo que revierte el orden de las posiciones para el movimiento
    {
        positions.Reverse();
    }
}
