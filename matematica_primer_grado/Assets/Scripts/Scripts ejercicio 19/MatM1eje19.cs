using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatM1eje19 : MonoBehaviour {

    ControllerInputText controller;
    popUpScript popUp;
    public int dificultad;
    public Text numeroPrincipal;
    int numeroEntero;
    public Text cuentaParaAnterior;
    public Text cuentaParaSiguiente;
    public InputTextScript inputAnterior;
    public InputTextScript inputSiguiente;
    public Button botonEstaBien;

    public Image[] imagenesDeFace;
    public Sprite spriteIncorrecto;
    public Sprite spriteCorrecto;
    int face;

	// Use this for initialization
	void Start(){
        controller = FindObjectOfType<ControllerInputText>();
        popUp = FindObjectOfType<popUpScript>();

        face = 0;

        construir();
    }
    public void checkeo() {
        if (controller.EsCorrecto()) {
            if (face == 10){
                popUp.Bien();
            }
            else {
                popUp.cartelAcierto();
                imagenesDeFace[face].sprite = spriteCorrecto;
                face++;
            }
        }
        else {
            popUp.cartelError();
            if (face > 0) {
                face--;
                imagenesDeFace[face].sprite = spriteIncorrecto;
            }
            else {

            }
        }
        construir();
    }

    void construir() {
        inputAnterior.gameObject.GetComponent<InputField>().text = "";
        inputSiguiente.gameObject.GetComponent<InputField>().text = "";

        numeroEntero = Random.Range(2, dificultad);
        numeroPrincipal.text = numeroEntero.ToString();
        cuentaParaAnterior.text = numeroEntero + " - 1 = ";
        cuentaParaSiguiente.text = numeroEntero + " + 1 = ";
        inputAnterior.valoresCorrectos[0] = (numeroEntero - 1).ToString();
        inputSiguiente.valoresCorrectos[0] = (numeroEntero + 1).ToString();
    }

}