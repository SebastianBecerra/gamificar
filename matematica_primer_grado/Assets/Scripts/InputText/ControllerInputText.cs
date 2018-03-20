using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerInputText : EsCheckeable {

    [HideInInspector] public InputTextScript[] inputsText;
    [HideInInspector] public GameController controller;
	[Tooltip("Deja que el sistema se chequee de forma automatica y termine cuando todos los inputFields estan Correctos")]
	public bool automatico;
	void Start () {
        inputsText = FindObjectsOfType<InputTextScript>();
        controller = GetComponent<GameController>();
        controller.chequear.Add(this);
    }

    public void chequearEstado() {
		if (EsCorrecto() && automatico) {
            controller.checkearEstado();
        }
    }

    //  Chequea si todos los inputs estan correcto.
    public override bool EsCorrecto() {
        if (inputsText.Length > 0)
        {
            bool estado = true;
            for (int i = 0; i < inputsText.Length; i++){
                estado = estado && inputsText[i].EsCorrecto();
            }
            return estado;
        }
        else {
            return false;
        }
    }
}
