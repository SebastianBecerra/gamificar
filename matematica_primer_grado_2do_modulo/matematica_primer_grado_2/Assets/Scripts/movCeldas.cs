using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movCeldas : MonoBehaviour {
    
    //script de movimiento en celdas
    //el objeto que tenga como componente a este script debe tener como child object a 4 objetos con box collider trigger
    //y llevar cada uno los scripts triggerDer, izq,arriba,abajo segun corresponda 
    //los objetos que no dejan mover al player deben tener el tag "pared"

    Vector3 pos;
    public float velocidad = 2.0f; //velocidad con la que se mueve en el grid
    public float distancia = 2.0f; //distancia con la que se mueve en el grid
    public bool usarBotones;
    //referencia a los colliders que detectan la colision con las paredes
    triggerDer detDer;  
    triggerIzq detIzq;
    triggerArriba detArriba;
    triggerAbajo detAbajo;

    void Start()
    {
        pos = transform.position; //posicion

        //deteccion de paredes en las cuatro direcciones
        //las paredes deben tener el tag "pared"
        detDer = FindObjectOfType<triggerDer>();
        detIzq = FindObjectOfType<triggerIzq>();
        detArriba = FindObjectOfType<triggerArriba>();
        detAbajo = FindObjectOfType<triggerAbajo>();

    }
    void FixedUpdate()
    {
        

        //Inputs detectan a traves de los coliders si hay un objeto en esa direccion y si no hay deja mover al player
        if (Input.GetKey(KeyCode.A) && transform.position == pos && detIzq.hayParedIzq ==false && !usarBotones)
        {           //(-1,0)
            pos += Vector3.left * distancia;
        }
        if (Input.GetKey(KeyCode.D) && transform.position == pos && detDer.hayParedDer==false && !usarBotones)
        {           //(1,0)
            pos += Vector3.right * distancia;
        }
        if (Input.GetKey(KeyCode.W) && transform.position == pos && detArriba.hayParedArriba==false && !usarBotones)
        {           //(0,1)
            pos += Vector3.up * distancia;
        }
        if (Input.GetKey(KeyCode.S) && transform.position == pos && detAbajo.hayParedAbajo ==false && !usarBotones)
        {           //(0,-1)
            pos += Vector3.down * distancia;
        }
       
        //movimiento
        transform.position = Vector3.MoveTowards(transform.position, pos, velocidad);    
    }
      public void Moverderecha()
    {
        if (usarBotones)
        {
            pos += Vector3.right * distancia;
            transform.position = Vector3.MoveTowards(transform.position, pos, velocidad);
        }
    }
    public void Moverizq()
    {
        if (usarBotones)
        {
            pos += Vector3.left * distancia;
            transform.position = Vector3.MoveTowards(transform.position, pos, velocidad);
        }
    }
    public void Moverarriba()
    {
        if (usarBotones)
        {
            pos += Vector3.up * distancia;
            transform.position = Vector3.MoveTowards(transform.position, pos, velocidad);
        }
    }
    public void Moverabajo()
    {
        if (usarBotones)
        {
            pos += Vector3.down * distancia;
            transform.position = Vector3.MoveTowards(transform.position, pos, velocidad);
        }
    }
}
