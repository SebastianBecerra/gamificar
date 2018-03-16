using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
JERARQUIA DE SCRIPTS

	- GameController
		- ControllerRadioButton
			- RadioButtonGroup
				- RadioButtonScript
				
CICLO DE CHEQUEO.

	1. RadioButtonScript - Listener llama a ControllerRadioButton.ChequearEstado();
	2. ControllerRadioButton.ChequearEstado(); - chequea si cada RadioButtonGroup es correcto ->
	3. RadioButtonGroup.EsCorrecto - Chequea si cada RadioButton del "Group" esta correcto
	4. [Si] ControllerRadioButton.ChequearEstado() Chequeo en true, invoca a GameController.chequearEstado();


*/
public class ControllerRadioButton : EsCheckeable {
	[HideInInspector] public RadioButtonGroupScript[] rBGroup;
	[HideInInspector] public GameController controller;

	void Start () {
		//	Inicializa Variables
		rBGroup = GameObject.FindObjectsOfType<RadioButtonGroupScript> ();
		controller = GetComponent<GameController>();

		//	Se autoañade a la lista para chequear del GameController.
		controller.chequear.Add(this);
	}

	public void chequearEstado() {
		if (EsCorrecto()) {
			controller.checkearEstado();
		}
	}

	public override bool EsCorrecto(){
		bool estado = true;
		foreach (RadioButtonGroupScript group in rBGroup) {
			estado = (estado && group.EsCorrecto ());
		}
		return (estado && rBGroup.Length>0);
	}
}
