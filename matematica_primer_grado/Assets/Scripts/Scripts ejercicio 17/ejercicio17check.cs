using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// script para checkear si lo que escribio en el imput text coincide con la respuesta correcta
// se agrega al imput text
public class ejercicio17check : MonoBehaviour {
	public string respuesta;
	public bool gano;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void check()
	{
		
		if (respuesta == gameObject.transform.GetChild (2).GetComponent<Text> ().text) {
			gano = true;
		//	aux.correctos++;
		}


	}
}
