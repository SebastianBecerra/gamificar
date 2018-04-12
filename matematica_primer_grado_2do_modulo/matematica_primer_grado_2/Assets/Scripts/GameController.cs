using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    [HideInInspector] public List< EsCheckeable> chequear = new List<EsCheckeable>();
    [HideInInspector] public popUpScript popUp;

	// Use this for initialization
	void Start () {
        popUp = GameObject.FindObjectOfType<popUpScript>();
	}
    public void checkearEstado() {
        if (chequear.Count != 0) {
            bool estado = true;
            for (int i = 0; i < chequear.Count; i++) {
                estado = estado && chequear[i].EsCorrecto();
            }
            if (estado) {
                invocarPopUp();
            }
        }
        else {
            Debug.LogError("Es imposible chequear el estado del juego porque no se encontro ningun [EsChequeable] en la lista chequear");
        }
    }
    public void invocarPopUp() {
        Debug.Log("win");
        if (popUp != null) {
            popUp.Bien();
        }
    }
}
