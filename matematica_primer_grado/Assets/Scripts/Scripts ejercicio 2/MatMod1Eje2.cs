using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatMod1Eje2 : MonoBehaviour {
	popUpScript popUp;
	static int control;
	bool activa;

	void Start () {
		activa = true;
		control = 0;
		popUp = FindObjectOfType<popUpScript> ();
	}

	public void clickeado(){
		if (activa) {
			InteractuableScale interScale = this.gameObject.GetComponent<InteractuableScale> ();
			interScale.agrandar ();
			control++;
			if (control == 5) {
				
				popUp.Bien ();
			} else {
				popUp.cartelAcierto ();	
			}
			activa = false;
		}

	}
}
