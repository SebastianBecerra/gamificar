using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class objTransition : MonoBehaviour {

    //script con el comportamiento para realizar movimientos a diferentes puntos de la escena
    //para que este script funcione con botones debe agregarse el boton en el child del objeto que contenga este script
    //para que la funcionalidad de volver con el boton funcione bien, el primer elemento de la lista debe ser la posicion inicial

	public float duracion; //cuanto tarda en realizar la transicion
    public List<GameObject> lugares = new List<GameObject>(); //lista con las posiciones a moverse
    private List<Vector3> positions = new List<Vector3>(); //vector3 que se van a usar en el metodo DoPath
    public bool activarConBoton = false; //indica si el movimiento se realizara despues de dar click a un boton
    private Button btn_transicion; //referencia al boton que inicia la transicion
    private bool regresar = false; //indica si debe invertir el recorrido

    // Use this for initialization
    void Start () {
        SavePositions(); //guarda las posiciones del inspector en la lista para usarlas en el metodo DOPath
        switch (activarConBoton) //indica si el movimiento se activa con boton
        {
            //si el check es falso en el inspector el movimiento se hara al comienzo del juego
            case false: 
                gameObject.GetComponent<Transform>().DOPath(positions.ToArray(), duracion);
                break;
            //si debe activarse por boton, busca el child boton y le añade la funcionalidad
            case true:
                btn_transicion = gameObject.GetComponentInChildren<Button>();
                btn_transicion.onClick.AddListener(TaskOnClick);
                break;
        }
	}
	

    void SavePositions()
    {
        foreach (GameObject g in lugares)
        {
            positions.Add(g.transform.position);
        }
    }

    void ReversePositions()
    {
        positions.Reverse();
    }


    //metodo que realiza el movimiento dependiendo si debe regresar o no
    //en caso que deba regresar se llama a la funcion ReversePositions que invierte el array para que vuelva
    public void moverObjeto()
    {
        if (!regresar)
        {
            gameObject.GetComponent<Transform>().DOPath(positions.ToArray(), duracion);
            regresar = true; //indicacion que la proxima vez que se haga click debe regresar
        }
        else
        {
            ReversePositions(); //se invierte el array para volver a la posicion inicial
            gameObject.GetComponent<Transform>().DOPath(positions.ToArray(), duracion);
            ReversePositions(); //se deja el array como se inicializo para volver a hacer el movimiento al proximo click
            regresar = false;
        }
    }


    //llama al metodo moverObjeto cuando se le hace click al boton child
    void TaskOnClick()
    {
        moverObjeto();
    }
}
