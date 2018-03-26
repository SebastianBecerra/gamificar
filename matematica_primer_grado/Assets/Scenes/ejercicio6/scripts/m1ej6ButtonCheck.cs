using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class m1ej6ButtonCheck : MonoBehaviour {

    ControllerDragAndDrop drag;
    public DropZone campo1;
    public InputField campo2;
    public int total;
    popUpScript popUP;
    public bool sigue;
    public string siguienteEscena;

	// Use this for initialization
	void Start () {
        drag = FindObjectOfType<ControllerDragAndDrop>();
        popUP = FindObjectOfType<popUpScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void checkCantidad()
    {
        if (campo1.gameObject.transform.childCount == total)
        {
            if (sigue == false)
            {
                popUP.Bien();
            }
            else
            {
                popUP.cartelAcierto();
                Invoke("cartelAcierto", 0.4f);
            }
        }
        else
        {
            popUP.Mal();
        }
    }

    public void checkInput()
    {
        if (campo2.text == total.ToString())
        {
            if (sigue == false)
            {
                popUP.Bien();
            }
            else
            {
                popUP.cartelAcierto();
                Invoke("cartelAcierto", 0.4f);
            }
        }
        else
        {
            popUP.Mal();
        }
    }

    void cartelAcierto()
    {
        SceneManager.LoadScene(siguienteEscena);
    }

}
