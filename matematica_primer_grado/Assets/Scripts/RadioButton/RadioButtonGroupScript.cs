using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioButtonGroupScript : EsCheckeable {
	[HideInInspector]public RadioButtonScript []radioButtons;

	void Start () {
		radioButtons = gameObject.GetComponentsInChildren<RadioButtonScript> ();
		ControlDeArmado ();
	}

	public override bool EsCorrecto ()
	{
		bool estado = true;
		foreach (RadioButtonScript rb in radioButtons) {
			estado = (estado && rb.EsCorrecto());
		}
		return estado;
	}
	public void ControlDeArmado(){
		bool estado = false;
		foreach (RadioButtonScript rb in radioButtons) {
			estado = estado || rb.esCorrecto;
		}
		if (!estado) {
			Debug.LogError ("en el grupo de RadioButtons '" + gameObject.name + "' ningun RadioButton es la opcion correcta");
		}
	}
}
