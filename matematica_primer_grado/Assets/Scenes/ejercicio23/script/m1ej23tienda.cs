using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class m1ej23tienda : MonoBehaviour {

    private List<Vector3> positions = new List<Vector3>(); //listas que contienen los lugares a moverse en las transisiones
    public List<GameObject> lugares = new List<GameObject>();
    public GameObject objMover;
    private bool regresar;

    // Use this for initialization
    void Start () {
        SavePositions();
        gameObject.GetComponentInChildren<Text>().text = "VER TIENDA";
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void SavePositions()//funcion que guarda las posiciones para las transiciones
    {
        foreach (GameObject g in lugares)
        {
            positions.Add(g.transform.position);
        }
    }

    public void moverObjeto()
    {
        if (regresar)
        {
            ReversePositions();
            objMover.GetComponent<Transform>().DOPath(positions.ToArray(), 0.2f);
            ReversePositions();
            regresar = false;
            gameObject.GetComponentInChildren<Text>().text = "VER TIENDA";
        }
        else
        {
            objMover.GetComponent<Transform>().DOPath(positions.ToArray(), 0.2f);
            regresar = true;
            gameObject.GetComponentInChildren<Text>().text = "OCULTAR TIENDA";
        }
    }

    void ReversePositions()
    {
        positions.Reverse();
    }
}
