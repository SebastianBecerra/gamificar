using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadSceneByButton : MonoBehaviour {

    //script con la funcionalidad de abrir la escene que corresponda en el menu
    public string escena;

    private Button btn;//referencia al boton 

	// Use this for initialization
	void Start () {
        btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
	}
	
    //abre escena con el nombre del boton
    public void abrirEscena()
    {
        SceneManager.LoadScene(escena);
    }


	void TaskOnClick()
    {
        abrirEscena();
    }
}
