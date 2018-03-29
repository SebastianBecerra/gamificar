using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class checkewinejercicio15 : MonoBehaviour {
	public scriptejercicio15 [] array;
	private scriptejercicio15 aux;
	public popUpScript popup;
	private bool win;
	public int clickeados;
	public int correctos;
	public int opciones;
	// Use this for initialization
	void Start () {
		array = FindObjectsOfType<scriptejercicio15> ();
		popup = FindObjectOfType<popUpScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		win = checkeo ();
		if (opciones == correctos) {
			popup.Bien ();
		}
		if (opciones == clickeados && opciones != correctos) 
		{
			popup.Mal ();
		}
		
	}
	bool checkeo()
	{
		for (int i = 0; i < array.Length; i++) {
			aux = array [i];
			if (aux.gano) {
				return false;
			}

		}

		return true;
	}

}
