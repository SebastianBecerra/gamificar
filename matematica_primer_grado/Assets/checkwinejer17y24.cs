using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkwinejer17y24 : MonoBehaviour {
	public ejercicio17check [] array;
	private ejercicio17check aux;
	private popUpScript popup;
	public bool win;
	// Use this for initialization
	void Start () {
		array = FindObjectsOfType<ejercicio17check> ();
		popup = FindObjectOfType<popUpScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		//win = checkeo ();
	}
	public void checkeo()
	{
		for (int i = 0; i < array.Length; i++){
			aux = array [i];
			if (!aux.gano) 
			{
				popup.Mal ();
			}

		}

		popup.Bien ();

	}
}
