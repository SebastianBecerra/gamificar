using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerInputText : EsCheckeable {

    [HideInInspector] public InputTextScript[] inputsText;
    [HideInInspector] public GameController controller;
	void Start () {
        inputsText = FindObjectsOfType<InputTextScript>();
        controller = GetComponent<GameController>();
        controller.chequear.Add(this);
    }

    public void chequearEstado() {
        if (EsCorrecto()) {
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
