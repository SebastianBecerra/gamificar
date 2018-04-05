using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckwinCartasMatematicamodulo1e5 : MonoBehaviour {

	//	CONTROLADOR CARTAS

	//Script para el checkeo si es correcto el ejercicio
	//Va en el objeto gamemanager
	public Ejercicio5MatematicaMod1[] Arraycheck;
	public int clickeados;
	private popUpScript popup;
	//public bool win;
	// Use this for initialization
	void Awake (){
		Arraycheck = FindObjectsOfType<Ejercicio5MatematicaMod1> ();
		clickeados = 0;
	}
	void Start () {
		
		popup = FindObjectOfType<popUpScript> ();
	}


	public void checkear(){
		Debug.Log ("C");
		if (clickeados == 4) {
			Debug.Log ("c1");
			if (checkeo ()) {
				popup.Bien ();
			} else {
				popup.Mal ();
			}
		}
	}
	bool checkeo()
	{
		for (int i = 0; i < Arraycheck.Length; i++){ // funcion para el boton que checkea
			
			if (!(Arraycheck[i].correcto())) 
			{
				return false;
			}
		
		}
		return true;

	}
}
