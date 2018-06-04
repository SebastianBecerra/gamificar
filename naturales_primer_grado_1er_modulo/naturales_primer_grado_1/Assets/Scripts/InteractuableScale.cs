using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractuableScale : MonoBehaviour {

	public float cuantoAgrandar =1.3f; //A que escala va a agrandarse con respecto a la escala actual.
	// velocidades en las que cambia la escala.
	public float velocidadAgrandar = 0.1f;
	public float velocidadAchicar = 0.1f;

	Transform miTrasnform;
	Vector2 miEscala= new Vector2 ();			//	escala inicial.
	Vector2 escalaMaximizada = new Vector2 ();	//	escala objetivo.


	void Start () {
		//	inicializacion variables
		miTrasnform = GetComponent<Transform> ();
		miEscala= new Vector3 (miTrasnform.localScale.x, miTrasnform.localScale.y, 1);
		escalaMaximizada = new Vector3 (miTrasnform.localScale.x * cuantoAgrandar, miTrasnform.localScale.y * cuantoAgrandar, 1);
	}


	void OnMouseEnter(){
        if (!enabled) return;
		agrandar ();
	}
	void OnMouseExit(){
        if (!enabled) return;
		achicar ();
	}
	public void agrandar(){
		StartCoroutine ("Agrandar");
	}
	public void achicar (){
		StartCoroutine ("Achicar");
	}
	//	Corrutina que agranda el tamaño del sprite
	IEnumerator Agrandar() {
		Vector3 scaleAux = miEscala;
		while (scaleAux.x < escalaMaximizada.x && scaleAux.y < escalaMaximizada.y){
			scaleAux.x *= (1f+velocidadAgrandar);
			scaleAux.y *= (1f+velocidadAgrandar);
			miTrasnform.localScale = scaleAux;
			yield return null;
		}
	}
	//	Corrutina que achica el tamaño del sprite
	IEnumerator Achicar() {
		Vector3 scaleAux = escalaMaximizada;
		while (scaleAux.x >= miEscala.x && scaleAux.y >= miEscala.y){
			scaleAux.x *= (1f-velocidadAchicar);
			scaleAux.y *= (1f-velocidadAchicar);
			miTrasnform.localScale = scaleAux;
			yield return null;
		}
	}
}
