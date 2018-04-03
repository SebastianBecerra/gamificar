using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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
	/*	else 
		{
			gano = false;
			if (aux.correctos != 0) 
			{
				aux.correctos--;
			}
		}*/

	}
}
