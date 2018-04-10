using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.Linq;

public class popUpScript : MonoBehaviour {

    //script que maneja el comportamiento de los popUps
    //se debe ingresar el texto que indique la escena siguiente
    //las escenas que repiten los ejercicios pero con disintos numeros deben llamarse igual agregando un 30,60 o 100 al final

   
    public string escenaAnterior;//string que debe llenarse para llevar a escena anterior
    public string escenaSiguiente;//string que debe llenarse para llevar a escena siguiente
    public int nroEtapa;//indica el nivel para luego ser usado como indice en el checkeo de stages completos
    public int nroDif;//indica la dificultad-10,30,60 o 100
    [HideInInspector] public bool bandera1, bandera2, check;
    [HideInInspector] public GameObject popUp, popUpMal,acierto,error;
    [HideInInspector]public string activeScene;

    //referencias a los sprites de completar stage
    public GameObject[] stages10, stages30, stages60, stages100;
    [HideInInspector] GameObject[] finder10, finder30, finder60, finder100;
    private Vector3 posIniAcierto,posIniError;//posicion iniciales de los carteles acierto y error
    private Scene scene;//referencia a la primera scene pára reiniciar los vaalores de singleton
    private int indexObj = 0;

    // Use this for initialization
    void Start () {
        finder10 = GameObject.FindGameObjectsWithTag("check 10");
        stages30 = GameObject.FindGameObjectsWithTag("check 30");
        stages60 = GameObject.FindGameObjectsWithTag("check 60");
        stages100 = GameObject.FindGameObjectsWithTag("check 100");

        for (int i = 0; i < finder10.Length; i++)
        {

            for(int j=0; j < finder10.Length; j++)
            {
                if (finder10[j].name == indexObj.ToString())
                {
                    stages10[i] = finder10[j];
                }
            }
            indexObj++;
        }

        

        scene = SceneManager.GetActiveScene();//obtiene el nombre de la escena
        if (scene.name == "primeraEscena")//si es la primera escena resetea el singleton a valor 0 para los arrays de control
        {
            for (int i = 0; i < stageManager.instance.value10.Length; i++)
            {
                stageManager.instance.value10[i] = 0;
            }
            for (int i = 0; i < stageManager.instance.value30.Length; i++)
            {
                stageManager.instance.value30[i] = 0;
            }
            for (int i = 0; i < stageManager.instance.value60.Length; i++)
            {
                stageManager.instance.value60[i] = 0;
            }
            for (int i = 0; i < stageManager.instance.value100.Length; i++)
            {
                stageManager.instance.value100[i] = 0;
            }
        }

        //setea los objetos check en falso
        foreach (GameObject a in stages10)
        {
            a.SetActive(false);
        }
        foreach (GameObject b in stages30)
        {
            b.SetActive(false);
        }
        foreach (GameObject c in stages60)
        {
            c.SetActive(false);
        }
        foreach (GameObject d in stages100)
        {
            d.SetActive(false);
        }

        bandera1 = true;//auxiliares para movimiento de popUp;
        bandera2 = true;
        check = false;
        activeScene = SceneManager.GetActiveScene().name.ToString();//obtengo el nombre de la escena para controlar el nombre
        popUp = GameObject.FindGameObjectWithTag("popUp"); //referencia a los popUps
        popUpMal = GameObject.FindGameObjectWithTag("popUpMal");
        
       
		if (acierto = GameObject.FindGameObjectWithTag("popUpAcierto")) 
		{
			
			posIniAcierto = acierto.transform.position;//asigno las posiciones de acierto y error en sus pos iniciales
		}
		if(error = GameObject.FindGameObjectWithTag("popUpError"))
		{
			
			posIniError = error.transform.position;
		}
        if (popUp != null)//desactiva los popUps al comenzar la escena
        {
            popUp.SetActive(false);
        }
        if (popUpMal != null)
        {
            popUpMal.SetActive(false);
        }
        if (acierto)
        {
            acierto.SetActive(false);
        }
        if (error)
        {
            error.SetActive(false);
        }

        //llena los checks completados
        llenarArray10();
        llenarArray30();
        llenarArray60();
        llenarArray100();


    }

    // Update is called once per frame
    void Update () {
		
	}

    //reinicia la escena
    public void cerrarPopUP()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //lleva a la siguiente escena
    public void siguienteEscena()
    {
        SceneManager.LoadScene(escenaSiguiente);
    }

    //lleva a la escena anterior
    public void anteriorEscena()
    {
        SceneManager.LoadScene(escenaAnterior);
    }

    //lleva a la misma scena con numeros hasta 10
    public void ejercicios10()
    {
        activeScene = Regex.Replace(activeScene, "[^a-zA-Z]", "");
        SceneManager.LoadScene(activeScene + "10");
    }

    //lleva a la misma escena con numeros hasta 30
    public void ejercicios30()
    {
        activeScene = Regex.Replace(activeScene, "[^a-zA-Z]", "");
        SceneManager.LoadScene(activeScene + "30");
    }

    //lleva a la misma escena con numeros hasta 60
    public void ejercicios60()
    {
        activeScene = Regex.Replace(activeScene, "[^a-zA-Z]", "");
        SceneManager.LoadScene(activeScene+ "60");
    }

    //lleva a la misma escena con numeros hasta 100
    public void ejercicios100()
    {
        activeScene = Regex.Replace(activeScene, "[^a-zA-Z]", "");
        SceneManager.LoadScene(activeScene+ "100");
    }

    //lleva al menu principal
    public void cerrarStage()
    {
        SceneManager.LoadScene("Menu");
    }
    
    //metodo que llama al popUp que indica que se ha realizado bien el ejercicio
    public void Bien()
    {

        //diferencia de dificultad para activar los srites de completar etapa
        switch (nroDif)
        {
            case 10:
                stageManager.instance.value10[nroEtapa-1]=1;
                llenarArray10();
                break;
            case 30:
                stageManager.instance.value30[nroEtapa-1] = 1;
                llenarArray30();
                break;
            case 60:
                stageManager.instance.value60[nroEtapa-1] = 1;
                llenarArray60();
                break;
            case 100:
                stageManager.instance.value100[nroEtapa-1] = 1;
                llenarArray100();
                break;
        }

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

    //metodo que llama al popUp que indica que se fallo el ejercicio
    public void Mal()
    {
        switch (nroDif)
        {
            case 10:
                stageManager.instance.value10[nroEtapa-1] = 0;
                llenarArray10();
                break;
            case 30:
                stageManager.instance.value30[nroEtapa-1] = 0;
                llenarArray30();
                break;
            case 60:
                stageManager.instance.value60[nroEtapa-1] = 0;
                llenarArray60();
                break;
            case 100:
                stageManager.instance.value100[nroEtapa-1] = 0;
                llenarArray100();
                break;
        }

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

    //metodo que invoca al cartel acierto
    public void cartelAcierto()
    {
        acierto.SetActive(true);//activa el cartel
        acierto.transform.position = posIniAcierto;//lo lleva a su posicion incial
        acierto.GetComponent<Transform>().DOMove(new Vector3 (acierto.transform.position.x, acierto.transform.position.y + 0.7f, acierto.transform.position.z),0.3f);//realiza movimiento hacia arriba
        Invoke("despawnPopUp",0.5f);//invoca metodo que desactiva el cartel despues del tiempo determinado
    }

    //metodo que invoca al cartel error
    public void cartelError()
    {
        error.SetActive(true);
        error.transform.position = posIniError;//lo vuelve a su posicion inicial
        error.GetComponent<Transform>().DOMove(new Vector3(error.transform.position.x, error.transform.position.y + 0.7f, error.transform.position.z), 0.3f);//realiza movimiento hacia arriba
        Invoke("despawnPopUp", 0.5f);//invoca metodo que desactiva el cartel despues del tiempo determinado
    }

    //desactiva los carteles acierto y error
    void despawnPopUp()
    {
        acierto.SetActive(false);
        error.SetActive(false);
    }

    //metodo que recorre el array value10 y cuando el valor es 1, usa el indice para
    //setear activo el gameObject
    public void llenarArray10()
    {
        for(int i=0; i<stageManager.instance.value10.Length; i++)
        {
            if (stageManager.instance.value10[i]==1)
            {
                stages10[i].SetActive(true);
            }
        }
    }

    //metodo que recorre el array value30 y cuando el valor es 1, usa el indice para
    //setear activo el gameObject
    public void llenarArray30()
    {
        for (int i = 0; i < stageManager.instance.value30.Length; i++)
        {
            if (stageManager.instance.value30[i] == 1)
            {
                stages30[i].SetActive(true);
            }
        }
    }

    //metodo que recorre el array value60 y cuando el valor es 1, usa el indice para
    //setear activo el gameObject
    public void llenarArray60()
    {
        for (int i = 0; i < stageManager.instance.value60.Length; i++)
        {
            if (stageManager.instance.value60[i] == 1)
            {
                stages60[i].SetActive(true);
            }
        }
    }

    //metodo que recorre el array value100 y cuando el valor es 1, usa el indice para
    //setear activo el gameObject
    public void llenarArray100()
    {
        for (int i = 0; i < stageManager.instance.value100.Length; i++)
        {
            if (stageManager.instance.value100[i] == 1)
            {
                stages100[i].SetActive(true);
            }
        }
    }
    
}
