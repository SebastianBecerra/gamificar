using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DobleYMitad : MonoBehaviour {
	public DropZone dropZone;
	popUpScript popUp;

	// Use this for initialization
	void Start () {
		popUp = FindObjectOfType<popUpScript> ();
	}
	
	public void CantIgualA(int cant){
		int hijos = dropZone.gameObject.transform.childCount;
		if (hijos == cant) {
			popUp.cartelAcierto();

		} else {
			popUp.cartelError();
		}
	}
	public void DobleDe2(){
		if (dropZone.gameObject.transform.childCount == 4) {
			popUp.cartelAcierto();
			SceneManager.LoadScene ("DobleYMitad10_2");
		} else {
			popUp.cartelError();
		}
	}
	public void MitadDe6(){
		if (dropZone.gameObject.transform.childCount == 3) {
			popUp.cartelAcierto();
			SceneManager.LoadScene ("DobleYMitad10_3");
		} else {
			popUp.cartelError();
			SceneManager.LoadScene ("DobleYMitad10");
		}
	}
	public void DobleDe3(){
		if (dropZone.gameObject.transform.childCount == 6) {
			popUp.cartelAcierto();
			SceneManager.LoadScene ("DobleYMitad10_4");
		} else {
			popUp.cartelError();
			SceneManager.LoadScene ("DobleYMitad10");
		}
	}
	public void MitadDe10(){
		if (dropZone.gameObject.transform.childCount == 5) {
			popUp.cartelAcierto();
			SceneManager.LoadScene ("DobleYMitad10_5");
		} else {
			popUp.cartelError();
			SceneManager.LoadScene ("DobleYMitad10");
		}
	}
	public void MitadDe8(){
		if (dropZone.gameObject.transform.childCount == 4) {
			popUp.Bien();
		} else {
			popUp.cartelError();
			SceneManager.LoadScene ("DobleYMitad10");
		}
	}
}
