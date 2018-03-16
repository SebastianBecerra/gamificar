using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movCeldas : MonoBehaviour {

    Vector3 pos;
    public float velocidad = 2.0f;
    public float distancia = 2.0f;
    triggerDer detDer;
    triggerIzq detIzq;
    triggerArriba detArriba;
    triggerAbajo detAbajo;

    void Start()
    {
        pos = transform.position;

        //deteccion de paredes en las cuatro direcciones
        //las paredes deben tener el tag "pared"
        detDer = FindObjectOfType<triggerDer>();
        detIzq = FindObjectOfType<triggerIzq>();
        detArriba = FindObjectOfType<triggerArriba>();
        detAbajo = FindObjectOfType<triggerAbajo>();

    }
    void FixedUpdate()
    {
        

        //==Inputs detectan a traves de los coliders si hay un objeto en esa direccion y si no hay deja mover al player
        if (Input.GetKey(KeyCode.A) && transform.position == pos && detIzq.hayParedIzq ==false)
        {           //(-1,0)
            pos += Vector3.left * distancia;
        }
        if (Input.GetKey(KeyCode.D) && transform.position == pos && detDer.hayParedDer==false)
        {           //(1,0)
            pos += Vector3.right * distancia;
        }
        if (Input.GetKey(KeyCode.W) && transform.position == pos && detArriba.hayParedArriba==false)
        {           //(0,1)
            pos += Vector3.up * distancia;
        }
        if (Input.GetKey(KeyCode.S) && transform.position == pos && detAbajo.hayParedAbajo ==false )
        {           //(0,-1)
            pos += Vector3.down * distancia;
        }
       
        //movimiento
        transform.position = Vector3.MoveTowards(transform.position, pos, velocidad);    
    }
}
