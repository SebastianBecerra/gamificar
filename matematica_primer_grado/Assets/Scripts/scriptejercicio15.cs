using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scriptejercicio15 : MonoBehaviour {
	public bool gano = false;
	private checkewinejercicio15 aux;

	// Use this for initialization
	void Start () {
		aux = FindObjectOfType<checkewinejercicio15>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void Desactivar()
	{
		this.transform.parent.transform.GetChild (0).GetComponent<Button> ().interactable = false;
		this.transform.parent.transform.GetChild (1).GetComponent<Button> ().interactable = false;
		this.transform.parent.transform.GetChild (2).GetComponent<Button> ().interactable = false;

	}
	public void Tareaclick()
	{  
		aux.clickeados++;
		if (gano == true)
		{
			aux.correctos++;
		}
		Desactivar ();
		//transform.parent.GetChild (0).GetComponent<Button> ().interactable = false;
		//transform.parent.GetChild (1).GetComponent<Button> ().interactable = false;
		//this.GetComponent<Button>().interactable = false;
		//aux.valorClickeado = 2;

	}
}
