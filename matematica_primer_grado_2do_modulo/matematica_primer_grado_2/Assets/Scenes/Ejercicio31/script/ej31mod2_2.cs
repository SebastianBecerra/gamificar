using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ej31mod2_2 : MonoBehaviour, IDropHandler {

    public GameObject lugarDrop, huella1, huella2, huella3, cubo, cilindro, piramide;
    private int id, randomSelect, estado;
    popUpScript popUp;
    private bool ultimoObjeto;

	// Use this for initialization
	void Start () {
        popUp = FindObjectOfType<popUpScript>();
        huella1.SetActive(false);
        huella2.SetActive(false);
        huella3.SetActive(false);
        estado = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnDrop(PointerEventData eventData)
    {
        Invoke("getChild", 0.1f);
        Invoke("huella", 0.1f);
    }

    void getChild()
    {
        id = lugarDrop.transform.GetChild(0).GetComponent<Dragable>().idDropZone1;
        switch (id)
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

    void huella()
    {
        if (id == 1)
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

    public void checkHuellaSi()
    {
        switch (id)
        {
            case 1:
                if (!ultimoObjeto)
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
                else
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



    public void checkHuellaNo()
    {
        switch (id)
        {
            case 1:
                if (!ultimoObjeto)
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
                else
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
