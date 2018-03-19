using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadSceneByButtonText : MonoBehaviour {

    //script con la funcionalidad de abrir la scena con el nombre que posee el boton


    private Button btn;//referencia al boton 
    private Text textbtn;//referencia al texto del boton

	// Use this for initialization
	void Start () {
        btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        textbtn = btn.GetComponentInChildren<Text>();
	}
	
    //abre escena con el nombre del boton
    public void abrirEscena()
    {
        SceneManager.LoadScene(textbtn.text);
    }


	void TaskOnClick()
    {
        abrirEscena();
    }
}
