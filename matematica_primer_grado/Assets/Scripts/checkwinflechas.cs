using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class checkwinflechas : MonoBehaviour {

	public bool win = false;
	private Check asd;
	public Check[] boolArray;
	public popUpScript popup;
	private bool aux;
	private bool aux2;
	private bool flag = false;
	private GameObject aux1;
	// Use this for initialization
	void Start () {
		boolArray = FindObjectsOfType<Check> ();
		popup = FindObjectOfType<popUpScript> ();

	}//
	// Update is called once per frame
	void Update () {

		win = checkeo ();
		if (win) {
			for (int i = 0; i < boolArray.Length; i++) {
				boolArray [i].gameObject.transform.GetChild (0).GetComponent<LineRenderer>().enabled = false;

			}
			popup.Bien ();

		}
		    
		if (!aux && !aux2) {
			
			aux = true;

		}

	}

	bool checkeo()
	{
		for (int i = 0; i < boolArray.Length; i++){
			asd = boolArray [i];
			if (!asd.gano) 
			{
				return false;
			}
		}

		return true;

	}

	public void Salir()
	{

		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		Debug.Log ("GASGA");
	}
	public void Seguir()
	{
		SceneManager.LoadScene ("Libro2");
	}
}
