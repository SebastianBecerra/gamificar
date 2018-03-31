using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ejercicio17checkwin : MonoBehaviour {
	public int opciones;
	public int correctos;
	private popUpScript popup;
	// Use this for initialization
	void Start () {
		popup = FindObjectOfType<popUpScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (opciones == correctos)
		{
			popup.Bien ();
		}

	}
}
