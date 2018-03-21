using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputTextScript : EsCheckeable {

    InputField inputField;
    ControllerInputText controllerInput;
    public string[] valoresCorrectos;
    public int limiteDeCaracteres = 10;
    public enum Tipo {none, Entero, Decimal, Alfa };
    public Tipo tipoDeInput;

	// Use this for initialization
	void Start () {
        controllerInput = FindObjectOfType<ControllerInputText>();
        inputField = gameObject.GetComponent<InputField>();
        inputField.characterLimit = limiteDeCaracteres;

        inputField.onValueChanged.AddListener(delegate { checkEstadoController(); });

        switch (tipoDeInput) {
            case Tipo.Alfa: inputField.contentType = InputField.ContentType.Alphanumeric; break;
            case Tipo.Decimal: inputField.contentType = InputField.ContentType.DecimalNumber; DesactivarPlaceHolder(); break;
            case Tipo.Entero: inputField.contentType = InputField.ContentType.IntegerNumber; DesactivarPlaceHolder(); break;
			default: inputField.contentType = InputField.ContentType.Standard; break;
        }
    }
    void DesactivarPlaceHolder() {
        Text placehol = inputField.placeholder.GetComponent<Text>();
        placehol.text = null;
    }
    void checkEstadoController() {
        controllerInput.chequearEstado();
    }

    //  Chequea si este input esta correcto.
    public override bool EsCorrecto() {
        if (valoresCorrectos.Length == 0) {
            Debug.LogError("No hay valoresCorrectos asignados para " + gameObject.name);
            return false;
        }
        else {
            bool estado = false;
            for (int i = 0; i < valoresCorrectos.Length; i++) {
                if (inputField.text.ToLower() == valoresCorrectos[i]) {
                    estado = true;
                }
            }
            return estado;
        }
    }

	public bool estaCompleto(){
		return inputField.text != "";
	}
}
