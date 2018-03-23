using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckwinCartasMatematicamodulo1e5 : MonoBehaviour {
	public Ejercicio5MatematicaMod1[] Arraycheck;
	private Ejercicio5MatematicaMod1 aux;
	public int clickeados;
	private popUpScript popup;
	public bool win;
	// Use this for initialization
	void Start () {
		Arraycheck = FindObjectsOfType<Ejercicio5MatematicaMod1> ();
	}
	
	// Update is called once per frame
	void Update () {
		win = checkeo ();
		if (win) {
			popup.Bien ();
		}
		if (!win && clickeados == 4 ) 
		{
			popup.Mal ();
		}
	}
	bool checkeo()
	{
		for (int i = 0; i < Arraycheck.Length; i++){
			aux = Arraycheck [i];
			if (!aux.gano) 
			{
				return false;
			}
		
		}

		return true;

	}
}
