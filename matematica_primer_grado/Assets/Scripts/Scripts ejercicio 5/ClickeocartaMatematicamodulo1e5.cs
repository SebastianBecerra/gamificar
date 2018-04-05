using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickeocartaMatematicamodulo1e5 : MonoBehaviour{
	//	CARTA

	public Ejercicio5MatematicaMod1 parejaPadre;
	private CheckwinCartasMatematicamodulo1e5 controllerParejas;
	public int valorclickeado;
	public bool gano;
	// Use this for initialization
	void Start () {
		
		parejaPadre = this.transform.parent.GetComponent<Ejercicio5MatematicaMod1> ();
		controllerParejas = FindObjectOfType <CheckwinCartasMatematicamodulo1e5> ();

	}/*
	
	// Update is called once per frame
	void Update () {


		//Debug.Log ();
		//parejaPadre.valorClickeado = this.GetComponent<Carta>().valor;
	}*/
	 public void Tareaclick()
	{  
		controllerParejas.clickeados++;
		parejaPadre.valorClickeado = this.transform.GetComponent<Carta> ().valor;

		Desactivar ();
		//transform.parent.GetChild (0).GetComponent<Button> ().interactable = false;
		//transform.parent.GetChild (1).GetComponent<Button> ().interactable = false;
		//this.GetComponent<Button>().interactable = false;
		//parejaPadre.valorClickeado = 2;

	}
	void Desactivar()
	{
		this.transform.parent.transform.GetChild (0).GetComponent<Button> ().interactable = false;
		this.transform.parent.transform.GetChild (1).GetComponent<Button> ().interactable = false;
		this.transform.parent.transform.GetChild (2).GetComponent<Button> ().interactable = false;

	}

	public void SonIguales()
	{   
		controllerParejas.clickeados++;
		parejaPadre.soniguales = true;
		Desactivar ();
	}
}
