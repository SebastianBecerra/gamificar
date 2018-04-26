using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCartaEjer35 : MonoBehaviour {

    cartaEjer35[] cartas;
    bool esperandoSegunda;
    cartaEjer35 primeraCarta;
    cartaEjer35 segundaCarta;
    popUpScript popUp;
    
    int count;

    // Use this for initialization
    void Start () {
       
        count = 0;
        buscarCartas();
        popUp = FindObjectOfType<popUpScript>();
	}
    void buscarCartas() {
        cartas = FindObjectsOfType<cartaEjer35>();
    }

    public void habilitarBanderas() {
        foreach (cartaEjer35 c in cartas){
            if (c.bocaArriba == false)
            {
                c.bandera = true;
            }
            
        }
    }
    public void desabilitarBanderas()
    {
        foreach (cartaEjer35 c in cartas)
        {
            c.bandera = false;
        }
    }

    public void Contralador(cartaEjer35 carta) {
        

        if (esperandoSegunda)
        {
            segundaCarta = carta;
            desabilitarBanderas();
            if (primeraCarta.id == carta.id)
            {
                buscarCartas();
                if (count == 4)
                {
                    popUp.Bien();
                }
                else
                {
                    popUp.cartelAcierto();
                    Invoke("habilitarBanderas", 0.4f);
                    count++;
                }
            }
            else {
                Invoke("darVueltas", 1.0f);
                Invoke("habilitarBanderas", 1.4f);
                popUp.cartelError();

            }
            //habilitarBanderas();
            esperandoSegunda = false;
        }
        else {
            primeraCarta = carta;
            Invoke("habilitarBanderas", 0.4f);
            //primeraCarta.bandera = false;
            esperandoSegunda = true;
        }
    }
    void darVueltas() {
        primeraCarta.darVuelta();
        primeraCarta.bandera = true;
        segundaCarta.darVuelta();
        segundaCarta.bandera = true;
    }
}
