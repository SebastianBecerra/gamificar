using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mat1ej5clickManager : MonoBehaviour
{

    mat1ej5controller clicker;
    popUpScript popUP;

    // Use this for initialization
    void Start()
    {
        clicker = FindObjectOfType<mat1ej5controller>();
        popUP = FindObjectOfType<popUpScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown()
    {
        if (clicker.estado < 3)
        {
            if (gameObject.transform.tag == "Player"&&gameObject.GetComponent<Carta>())
            {
                popUP.cartelAcierto();
                clicker.estado++;
                gameObject.GetComponent<Carta>().enabled = false;
                gameObject.GetComponent<InteractuableScale>().enabled = false;
                if (clicker.estado == 3)
                {
                    Invoke("cambiarBandera", 0.5f);
                }
            }

            else
            {
                popUP.Mal();
            }
        }
        if (clicker.banderaUltimoPar)
        {
            if (gameObject.transform.tag == "Player")
            {
                gameObject.GetComponent<Carta>().enabled = false;
                gameObject.GetComponent<InteractuableScale>().enabled = false;
                popUP.Bien();
            }
            else
            {
                popUP.Mal();
            }
        }
    }

    void cambiarBandera()
    {
        clicker.banderaUltimoPar = true;
    }
}

