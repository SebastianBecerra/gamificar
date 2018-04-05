using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Carta : MonoBehaviour {
	[Header("Variables de instancia")]
	[Tooltip("Valor de la carta. de 1 a 9")]
	public int valor;
	public bool randoom1al9;
	[Tooltip("Sprite para las imagenes de la carta")]
	public Sprite imagenPalo;
	[Tooltip("Como se instancia la carta en la escena al empezar")]
	public bool bocaAbajo;

	Text[] numeros;
	GameObject contenedor;
	GameObject dorso;
	[Header("No Modificar")]
	[Tooltip("[No Modificar] objeto que se repite en la carta")]
	public GameObject objeto;

	void Start () {

		//	Inicializar carta.
		numeros = transform.GetComponentsInChildren<Text> ();
		dorso = gameObject.transform.GetChild (3).gameObject;
		contenedor = gameObject.transform.GetChild (2).gameObject;
		dorso.SetActive (bocaAbajo);
		if (randoom1al9) {
			valor = Random.Range (1, 9);
		}
		setNumeros (valor);
	}

	public int getValor (){
		return valor;
	}
	public void setNumeros(int v){
		valor = v;
		for (int i = 0; i < this.numeros.Length; i++) {
			this.numeros [i].text = valor.ToString ();
		}
		setObjetosEnCarta ();
	}
	void setObjetosEnCarta(){
		foreach (Transform child in contenedor.transform) {
			GameObject.Destroy(child.gameObject);
		}
		for (int i = 0; i < valor; i++) {
			Instantiate(objeto ,contenedor.transform);
		}
		setSpritesEnObjetos ();
	}


	public void setSpritesEnObjetos(){
		for (int i = 0; i < contenedor.transform.childCount; i++) {
			Image imagen = contenedor.transform.GetChild (i).GetComponent<Image>();
			imagen.enabled = true;
			imagen.sprite = imagenPalo;
		}
	}

	//	Da vuelta la carta. activando el UI.Image "Dorso".
	public void darVuelta(){
		dorso.SetActive (!(dorso.activeInHierarchy));
	}
}
