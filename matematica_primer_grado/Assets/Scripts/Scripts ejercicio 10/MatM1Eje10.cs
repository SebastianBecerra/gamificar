using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatM1Eje10 : MonoBehaviour {
	public Carta cartaRivalDecena;
	public Carta cartaRivalUnidad;

	public DropZone dropZoneDecena;
	public DropZone dropZoneUnida;

	public int veredicto;

	public string siguienteEscena;
	public bool ultima;

	public GameObject botones;
	popUpScript popUp;

	void Start () {
		popUp = FindObjectOfType<popUpScript> ();
	}

	public void InicioCheckeo(){
		if (dropZoneDecena.transform.childCount == 1 && dropZoneUnida.transform.childCount == 1) {
			Carta cartaEnDecena = dropZoneDecena.transform.GetChild (0).GetChild (0).GetComponent<Carta> ();
			Carta cartaEnUnidad = dropZoneUnida.transform.GetChild (0).GetChild (0).GetComponent<Carta> ();
			cartaRivalDecena.darVuelta ();
			cartaRivalUnidad.darVuelta ();
			int valor = cartaEnDecena.getValor() * 10 + cartaEnUnidad.getValor();
			int valorRival = cartaRivalDecena.getValor() * 10 + cartaRivalUnidad.getValor();
			Debug.Log (valor + "   " + valorRival);
			if (valor > valorRival) {
				veredicto = 0;
			} else if (valor == valorRival) {
				veredicto = 1;
			} else {
				veredicto = 2;
			}
			botones.SetActive (true);
		}
		
	}
	public void GanoOPerdio(int boton){
		if (boton == veredicto) {
			
			if (ultima) {
				popUp.Bien ();
			} else {
				popUp.cartelAcierto();
				SceneManager.LoadScene (siguienteEscena);
			}

		} else {
			popUp.Mal ();
		}
	}
}
