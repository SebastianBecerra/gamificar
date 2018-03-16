using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class popUpScript : MonoBehaviour {

    public string escenaSiguiente;
    public int nroModulo;
    [HideInInspector] public bool bandera1, bandera2, check;
    [HideInInspector] public GameObject popUp, popUpMal;

	// Use this for initialization
	void Start () {
        bandera1 = true;
        bandera2 = true;
        check = false;
        popUp = GameObject.FindGameObjectWithTag("popUp"); //referencia a los popUps
        popUpMal = GameObject.FindGameObjectWithTag("popUpMal");
        if (popUp != null)//desactiva los popUps al comenzar la escena
        {
            popUp.SetActive(false);
        }
        if (popUpMal != null)
        {
            popUpMal.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void cerrarPopUP()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void siguienteEscena()
    {
        SceneManager.LoadScene(escenaSiguiente);
    }

    public void botonMenu()
    {
        SceneManager.LoadScene("Menu Modulo "+nroModulo);
    }


    public void Bien()
    {
        if (bandera1 && bandera2)
        {
            popUp.SetActive(true);
            if (check == false)
            {
                popUp.GetComponent<Transform>().DOMove(new Vector3(popUp.transform.position.x, popUp.transform.position.y + 0.7f, popUp.transform.position.z), 0.3f);
                check = true;
            }

        }
    }

    public void Mal()
    {
        if (bandera1 && bandera2)
        {
            popUpMal.SetActive(true);
            if (check == false)
            {
                popUpMal.GetComponent<Transform>().DOMove(new Vector3(popUpMal.transform.position.x, popUpMal.transform.position.y + 0.7f, popUpMal.transform.position.z), 0.3f);
                check = true;
            }

        }
    }
}
