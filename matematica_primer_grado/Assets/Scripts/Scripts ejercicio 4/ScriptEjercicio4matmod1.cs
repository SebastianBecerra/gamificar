using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptEjercicio4matmod1 : MonoBehaviour {

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
	public void checkearRepartir()
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
	public void asd()
	{
		Debug.Log ("ASD");
	}
}
