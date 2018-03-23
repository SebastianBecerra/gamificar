using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creadordecartas : MonoBehaviour {
	public Carta [] arrayCartas;

	// Use this for initialization
	void Start () {
		arrayCartas = FindObjectsOfType <Carta>();
		for (int i = 0; i <= arrayCartas.Length - 1; i++) 
		{
			//arrayCartas [i].valor = Random.Range (1, 9);
			arrayCartas [i].setNumeros(Random.Range(1,9));

		}
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
