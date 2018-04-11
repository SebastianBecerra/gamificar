using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptEjercicio4matmod1 : MonoBehaviour {
	// Script para confirmar si estaw correcto el ejercicio
	//Contiene la funcion que va a usar el boton de checkeo
	DropZone[] dropZones;
	private popUpScript popup;
	public int cantidad;
	// Use this for initialization
	void Start () {
		popup = FindObjectOfType<popUpScript> ();
		dropZones = FindObjectsOfType<DropZone> ();
	}

	public void checkearRepartir() // funcion del bonton
	{
        bool estado = true;
		foreach (DropZone dz in dropZones) {
            if (!dz.ignorarCheckeo) {
                estado = estado && (dz.transform.childCount == cantidad);
            }
		}
        if (estado){
            popup.Bien();
        }
        else {
            popup.Mal();
        }
	}

}
