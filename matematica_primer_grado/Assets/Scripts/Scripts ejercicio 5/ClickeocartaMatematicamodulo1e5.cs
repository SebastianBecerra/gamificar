using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickeocartaMatematicamodulo1e5 : MonoBehaviour{
	public Ejercicio5MatematicaMod1 aux;
	private CheckwinCartasMatematicamodulo1e5 aux2;
	public int valorclickeado;
	public bool gano;
	// Use this for initialization
	void Start () {
		aux = this.transform.parent.GetComponent<Ejercicio5MatematicaMod1> ();
		aux2 = FindObjectOfType <CheckwinCartasMatematicamodulo1e5> ();

	}
	
	// Update is called once per frame
	void Update () {


		//Debug.Log ();
		//aux.valorClickeado = this.GetComponent<Carta>().valor;
	}
	 public void Tareaclick()
	{  
		aux2.clickeados++;
		aux.valorClickeado = this.transform.GetComponent<Carta> ().valor;

		Desactivar ();
		//transform.parent.GetChild (0).GetComponent<Button> ().interactable = false;
		//transform.parent.GetChild (1).GetComponent<Button> ().interactable = false;
		//this.GetComponent<Button>().interactable = false;
		//aux.valorClickeado = 2;

	}
	void Desactivar()
	{
		this.transform.parent.transform.GetChild (0).GetComponent<Button> ().interactable = false;
		this.transform.parent.transform.GetChild (1).GetComponent<Button> ().interactable = false;
		this.transform.parent.transform.GetChild (2).GetComponent<Button> ().interactable = false;

	}
	public void SonIguales()
	{   
		aux2.clickeados++;
		aux.soniguales = true;
		Desactivar ();
	}
}
