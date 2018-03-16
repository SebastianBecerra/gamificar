using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadioButtonScript : EsCheckeable {

	public bool esCorrecto;
	[HideInInspector]public ControllerRadioButton controller;


	Animator miAnimator; //animator del children que maneja la rempresentacion visual
	Toggle miToggle;

	void Start () {
		
		//inicialisacion de variables.
		controller = FindObjectOfType<ControllerRadioButton> ();
		miAnimator = gameObject.GetComponentInChildren<Animator> ();
		miToggle = gameObject.GetComponent<Toggle> ();
		miToggle.isOn = false;
		miToggle.group = gameObject.GetComponentInParent<ToggleGroup> ();

		//	inicia el Listener - llama a control animacion
		miToggle.onValueChanged.AddListener(delegate {ChequearEstado();});
	}

	public void ChequearEstado () {
		//	Control Animacion
		miAnimator.SetBool ("On", miToggle.isOn);

		//	empieza el Ciclo de chequeo.
		controller.chequearEstado ();
	}
	public override bool EsCorrecto(){
		return (miToggle.isOn == esCorrecto);
	}
}
