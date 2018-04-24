using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ej31mod2_2 : MonoBehaviour, IDropHandler {

    public GameObject lugarDrop, huella1, huella2, huella3, cubo, cilindro, piramide; //referencia a los tres objetos y a sus huellas
    private int id, randomSelect, estado; //enteros que indican que figura se dropeo y estado del ejercicio
    popUpScript popUp; //referencia a los popUps
    private bool ultimoObjeto; //bandera que indica que queda un acierto por hacer para terminar el ejercicio

	// Use this for initialization
	void Start () {
        popUp = FindObjectOfType<popUpScript>();//asignacion de los popUps
        huella1.SetActive(false);//seteo las huellas inactivas al comienzo del ejercicio
        huella2.SetActive(false);
        huella3.SetActive(false);
        estado = 0;//seteo el estado 0 al comienzod el ejercicio
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnDrop(PointerEventData eventData)//cuando deja caer uno de los tres objetos en la DropZone
    {
        Invoke("getChild", 0.1f);//llama a la funcion getChild que indica que objeto dropeo
        Invoke("huella", 0.1f);//llama a la funcion huella que genera una huella aleatoria
    }

    void getChild()//funcion que indica que objeto dejo caer
    {
        id = lugarDrop.transform.GetChild(0).GetComponent<Dragable>().idDropZone1;//asigno a id la id del objeto
        switch (id)//controlo que el objeto que dropeo es el correspondiente
        {
            case 1:
                Debug.Log("cilindro");
                break;
            case 2:
                Debug.Log("cubo");
                break;
            case 3:
                Debug.Log("piramide");
                break;
        }
    }

    void huella()//funcion que genera una huella aleatorio para cada objeto dropeado
    {
        if (id == 1)//dependiendo de la id del objeto genera un numero aleatorio y dependiendod el resultado genera una huella
        {
            randomSelect = Random.Range(1, 3);
            switch (randomSelect)
            {
                case 1:
                    huella1.SetActive(true);
                    huella2.SetActive(false);
                    huella3.SetActive(false);
                    break;
                case 2:
                    huella1.SetActive(false);
                    huella2.SetActive(true);
                    huella3.SetActive(false);
                    break;
            }
        }
        if (id == 2)
        {
            randomSelect = Random.Range(1, 3);
            switch (randomSelect)
            {
                case 1:
                    huella1.SetActive(false);
                    huella2.SetActive(false);
                    huella3.SetActive(true);
                    break;
                case 2:
                    huella1.SetActive(false);
                    huella2.SetActive(true);
                    huella3.SetActive(false);
                    break;
            }
        }
        if (id == 3)
        {
            randomSelect = Random.Range(1, 3);
            switch (randomSelect)
            {
                case 1:
                    huella1.SetActive(false);
                    huella2.SetActive(false);
                    huella3.SetActive(true);
                    break;
                case 2:
                    huella1.SetActive(true);
                    huella2.SetActive(false);
                    huella3.SetActive(false);
                    break;
            }
        }
    }

    public void checkHuellaSi()//controla que la huella generada corresponde al objeto dropeado
    {
        switch (id)
        {
            case 1:
                if (!ultimoObjeto)//sino es el ultimo objeto muestra el cartel de acierto
                {
                    if (huella1.activeInHierarchy)
                    {
                        popUp.cartelAcierto();
                        estado++;
                        huella1.SetActive(false);
                        Destroy(cilindro);
                        if (estado == 2)
                        {
                            Invoke("ultimo", 0.2f);
                        }
                    }
                    else
                    {
                        popUp.Mal();
                    }
                }
                else//si es el ultimo objeto muestra el cartel de bien
                {
                    if (huella1.activeInHierarchy)
                    {
                        popUp.Bien();
                    }
                    else
                    {
                        popUp.Mal();
                    }
                }
                break;
            case 2:
                if (!ultimoObjeto)
                {
                    if (huella2.activeInHierarchy)
                    {
                        popUp.cartelAcierto();
                        estado++;
                        huella2.SetActive(false);
                        Destroy(cubo);
                        if (estado == 2)
                        {
                            Invoke("ultimo", 0.2f);
                        }
                    }
                    else
                    {
                        popUp.Mal();
                    }
                }
                else
                {
                    if (huella2.activeInHierarchy)
                    {
                        popUp.Bien();
                    }
                    else
                    {
                        popUp.Mal();
                    }
                }
                break;
            case 3:
                if (!ultimoObjeto)
                {
                    if (huella3.activeInHierarchy)
                    {
                        popUp.cartelAcierto();
                        estado++;
                        huella3.SetActive(false);
                        Destroy(piramide);
                        if (estado == 2)
                        {
                            Invoke("ultimo", 0.2f);
                        }
                    }
                    else
                    {
                        popUp.Mal();
                    }
                }
                else
                {


                    if (huella3.activeInHierarchy)
                    {
                        popUp.Bien();
                    }
                    else
                    {
                        popUp.Mal();
                    }
                }
                break;
        }
    }



    public void checkHuellaNo()//metodo que indica que la huella no corresponde al objeto
    {
        switch (id)
        {
            case 1:
                if (!ultimoObjeto)//sino es el ultimo objeto muestra el cartel de acierto
                {
                    if (!huella1.activeInHierarchy)
                    {
                        popUp.cartelAcierto();
                        estado++;
                        huella2.SetActive(false);
                        huella3.SetActive(false);
                        Destroy(cilindro);
                        if (estado == 2)
                        {
                            Invoke("ultimo", 0.2f);
                        }
                    }
                    else
                    {
                        popUp.Mal();
                    }
                }
                else//sino muestra el cartel de bien
                {
                    if (!huella1.activeInHierarchy)
                    {
                        popUp.Bien();
                    }
                    else
                    {
                        popUp.Mal();
                    }
                }
                break;
            case 2:
                if (!ultimoObjeto)
                {
                    if (!huella2.activeInHierarchy)
                    {
                        popUp.cartelAcierto();
                        estado++;
                        huella1.SetActive(false);
                        huella3.SetActive(false);
                        Destroy(cubo);
                        if (estado == 2)
                        {
                            Invoke("ultimo", 0.2f);
                        }
                    }
                    else
                    {
                        popUp.Mal();
                    }
                }
                else
                {
                    if (!huella2.activeInHierarchy)
                    {
                        popUp.Bien();
                    }
                    else
                    {
                        popUp.Mal();
                    }
                }
                break;
            case 3:
                if (!ultimoObjeto)
                {
                    if (!huella3.activeInHierarchy)
                    {
                        popUp.cartelAcierto();
                        estado++;
                        huella1.SetActive(false);
                        huella2.SetActive(false);
                        Destroy(piramide);
                        if (estado == 2)
                        {
                            Invoke("ultimo", 0.2f);
                        }
                    }
                    else
                    {
                        popUp.Mal();
                    }
                }
                else
                {
                    if (!huella3.activeInHierarchy)
                    {
                        popUp.Bien();
                    }
                    else
                    {
                        popUp.Mal();
                    }
                }
                break;
        }
    }


    void ultimo()
    {
        ultimoObjeto = true;
    }
    
}
