using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DobleYMitad : MonoBehaviour {
	public DropZone dropZone;
	popUpScript popUp;
    int cantidadDeHijos;
    string siguienteScene;
    string primerScene;

	// Use this for initialization
	void Start () {
		popUp = FindObjectOfType<popUpScript> ();
        primerScene = "DobleYMitad10";

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
        cantidadDeHijos = 4;
        siguienteScene = "DobleYMitad10_2";

        StartCoroutine("loadScene",1f);

        /*
        if (dropZone.gameObject.transform.childCount == 4) {
			popUp.cartelAcierto();
			SceneManager.LoadScene ("DobleYMitad10_2");
		} else {
			popUp.cartelError();
		}*/
    }
	public void MitadDe6(){
        cantidadDeHijos = 3;
        siguienteScene = "DobleYMitad10_3";

        StartCoroutine("loadScene", 1f);

        /*
        if (dropZone.gameObject.transform.childCount == 3) {
			popUp.cartelAcierto();
			SceneManager.LoadScene ("DobleYMitad10_3");
		} else {
			popUp.cartelError();
			SceneManager.LoadScene ("DobleYMitad10");
		}*/
    }
	public void DobleDe3(){
        cantidadDeHijos = 6;
        siguienteScene = "DobleYMitad10_4";

        StartCoroutine("loadScene",1f);

        /*
        if (dropZone.gameObject.transform.childCount == 6) {
			popUp.cartelAcierto();
			SceneManager.LoadScene ("DobleYMitad10_4");
		} else {
			popUp.cartelError();
			SceneManager.LoadScene ("DobleYMitad10");
		}*/
    }
	public void MitadDe10(){
        cantidadDeHijos = 5;
        siguienteScene = "DobleYMitad10_5";

        StartCoroutine("loadScene",1f);

        /*
        if (dropZone.gameObject.transform.childCount == 5) {
			popUp.cartelAcierto();
			SceneManager.LoadScene ("DobleYMitad10_5");
		} else {
			popUp.cartelError();
			SceneManager.LoadScene ("DobleYMitad10");
		}*/
    }
	public void MitadDe8(){
        cantidadDeHijos = 4;
        siguienteScene = "ultima";

        StartCoroutine("loadScene",1f);

        /*
        if (dropZone.gameObject.transform.childCount == 4) {
			popUp.Bien();
		} else {
			popUp.cartelError();
			SceneManager.LoadScene ("DobleYMitad10");
		}*/
    }
    IEnumerator loadScene(float r) {
        if (dropZone.gameObject.transform.childCount == cantidadDeHijos)
        {
            if (siguienteScene != "ultima")
            {
                popUp.cartelAcierto();
                yield return new WaitForSeconds(.7f);
                SceneManager.LoadScene(siguienteScene);
            }
            else {
                popUp.Bien();
            }
        }
        else {
            popUp.cartelError();
            yield return new WaitForSeconds(.7f);
            SceneManager.LoadScene("DobleYMitad10");
        }
        
    }
}
