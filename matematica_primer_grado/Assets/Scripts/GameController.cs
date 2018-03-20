using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    [HideInInspector] public List< EsCheckeable> chequear = new List<EsCheckeable>();
    popUpScript popUp;

	[Tooltip("Invoca el popUpCorrecto en lugar del popUpBien y traslada a la siguiente escena")]
	public bool continua;
	[Tooltip("Escena a la cual ir cuando los controles den true")]
	public string siguienteEscena;

	// Use this for initialization
	void Start () {
        popUp = FindObjectOfType<popUpScript>();

		if (continua && siguienteEscena==null) {
			Debug.LogError ("siguiente Escena no esta seteado, desactive la variable 'continua' o complete con la siguiente escena");
		}
	}
    public void checkearEstado() {
        if (chequear.Count != 0) {
            bool estado = true;
            for (int i = 0; i < chequear.Count; i++) {
                estado = estado && chequear[i].EsCorrecto();
            }
            if (estado) {
				if (continua) {
					invocarPopUpCorrecto ();
					SceneManager.LoadScene (siguienteEscena);
				} else {
					invocarPopUp();
				}
            }
        }
        else {
            Debug.LogError("Es imposible chequear el estado del juego porque no se encontro ningun [EsChequeable] en la lista chequear");
        }
    }
    public void invocarPopUp() {
        popUp.Bien();
    }
	public void invocarPopUpMal(){
		popUp.Mal ();
	}
	public void invocarPopUpCorrecto(){
		popUp.cartelAcierto ();
	}
	public void invocarPopUpError(){
		popUp.cartelError ();
	}
}
