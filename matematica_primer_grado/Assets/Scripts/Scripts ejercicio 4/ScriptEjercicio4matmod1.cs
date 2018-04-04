using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptEjercicio4matmod1 : MonoBehaviour {
	// Scrip para confirmar si estaw correcto el ejercicio
	//Contiene la funcion que va a usar el boton de checkeo
	public DropZone[] array;
	public bool gano;
	private popUpScript popup;
	public int cantidad;
	// Use this for initialization
	void Start () {
		popup = FindObjectOfType<popUpScript> ();
		array = FindObjectsOfType<DropZone> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void checkearRepartir() // funcion del bonton
	{
		foreach (DropZone a in array) {  
			if (a.name == "DropZone") {

				if (a.transform.childCount == cantidad) {
					gano = true;
					popup.Bien ();

				} else {
					gano = false;
					popup.Mal ();
				}
			}
		}
	}

}
