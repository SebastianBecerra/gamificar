using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ejercicio5MatematicaMod1 : MonoBehaviour {

	//	PAREJA

	public int valorClickeado;
	public int valorchild1, valorchild2;
	public int valorCorrecto;
	public bool soniguales = false;
	public bool gano;
	public int clickeados;
	private GameObject go1,go2;
	// Use this for initialization
	void Start () {
		go1 = this.transform.GetChild (0).gameObject;
		go2= this.transform.GetChild (1).gameObject;
	
	}
	
	// Update is called once per frame
	void Update () {
		valorchild1 = go1.GetComponent<Carta> ().valor;
		valorchild2 = go2.GetComponent<Carta> ().valor;
		correcto ();
	}
	public bool correcto()
	{
		if (valorchild1 > valorchild2)
		{
			valorCorrecto = valorchild1;

		}  if(valorchild1 < valorchild2)
		{
			valorCorrecto = valorchild2;
		} 
		if (valorchild1 == valorchild2)
		{
			valorCorrecto = 10;

		} 
	
	
		if (valorCorrecto == valorClickeado) {
			return true;
		} else {
			return false;
		}

	}

}
