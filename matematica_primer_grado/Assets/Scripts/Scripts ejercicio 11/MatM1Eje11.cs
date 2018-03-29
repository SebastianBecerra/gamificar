using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatM1Eje11 : MonoBehaviour {

	popUpScript popUp;

	public Text textoProblema;
	public GameObject imagen;
	InputTextScript input;
	InputField inputField;

	//	Array de ScriptableObjects.
	public ProblemaMatematico[] problemas;

	int instanciaActual;

	void Start () {
		popUp = FindObjectOfType<popUpScript> ();
		input = FindObjectOfType<InputTextScript> ();
		inputField = input.gameObject.GetComponent<InputField>();
		instanciaActual = 0;
		ManagerInstancia ();
		inputField.onEndEdit.AddListener(delegate { checkEstadoInput(); });

		Instantiate (imagen);
	}

	void checkEstadoInput(){
		int maxInstancia = problemas.Length-1;

		if (input.EsCorrecto ()) {
			if (instanciaActual == maxInstancia) {
				popUp.Bien ();
			} else {
				popUp.cartelAcierto ();
				instanciaActual++;
				ManagerInstancia();
			}
		} else {
			//if (inputField.text.Length == input.valoresCorrectos[0].Length){
				popUp.cartelError ();
				if (instanciaActual > 0) {
					instanciaActual--;
				}
				ManagerInstancia();
			//}
		}
		inputField.ActivateInputField ();
	}

	void ManagerInstancia(){
		borrarInput ();
		setProblema (instanciaActual);
	}

	void setProblema(int i){
		//	Formar texto del Problema.
		int valor1;
		int valor2;
		if (problemas [i].randoom) {
			valor1 = Random.Range (problemas [i].min1, problemas [i].max1);
		} else {
			valor1 = problemas [i].numero1;
		}
		if (problemas [i].randoom2) {
			valor2 = Random.Range (problemas [i].min2, problemas [i].max2);
		} else {
			valor2 = problemas [i].numero2;
		}
			
		textoProblema.text = problemas [i].inicio + valor1 + problemas [i].problema + valor2 + problemas [i].pregunta;
		//	invoca setSolucion.
		setSolucionEnInput (valor1, valor2, i);
	}

	//	Reinicia el InputText input para que la opcion corrcta pase a ser la solucion del problema.
	void setSolucionEnInput(int valor1, int valor2, int indexProblemas){
		
		borrarInput ();

		//	Obtener numero ENTERO solucion.
		int solucion = 0;

		switch ((int)problemas [indexProblemas].tipo){
		case(0):
			solucion = valor1 + valor2;
			break;
		case (1):
			solucion = valor1 - valor2;
			break;
		case(2):
			solucion = valor1 + valor2;
			break;
		case(3):
			solucion = valor1 / valor2;
			break;
		}
		Debug.Log (solucion);
		input.valoresCorrectos [0] = solucion.ToString();
	}
	void borrarInput(){
		inputField.text = "";
	}
}
