using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class mat1ej5controller : MonoBehaviour {


    public Carta[] cartas;
    public bool igualPar1, igualPar2, igualPar3, igualPar4;
    popUpScript popUp;

    public int estado;
    public bool banderaUltimoPar = false;

    private void Awake()
    {
        cartas = FindObjectsOfType<Carta>().OrderBy(go => go.name).ToArray();
        darValores();
        comparacion();
    }

    // Use this for initialization
    void Start() {
        //cartas = FindObjectsOfType<Carta>().OrderBy(go => go.name).ToArray();
        popUp= FindObjectOfType<popUpScript>();
        //darValores();
        //comparacion();
        estado = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void darValores()
    {
        foreach (Carta a in cartas)
        {
            a.valor = Random.Range(1, 9);
        }
    }

    void comparacion()
    {
        //par1
        if (cartas[0].valor != cartas[1].valor)
        {
            if (cartas[0].valor > cartas[1].valor)
            {
                cartas[0].transform.name = "mayor";
                cartas[1].transform.name = "menor";
            }
            else
            {
                cartas[1].transform.name = "mayor";
                cartas[0].transform.name = "menor";
            }
        }
        else
        {
            igualPar1 = true;
        }
        //par2
        if (cartas[2].valor != cartas[3].valor)
        {
            if (cartas[2].valor > cartas[3].valor)
            {
                cartas[2].transform.name = "mayor";
                cartas[3].transform.name = "menor";
            }
            else
            {
                cartas[3].transform.name = "mayor";
                cartas[2].transform.name = "menor";
            }
        }
        else
        {
            igualPar2 = true;
        }
        //par3
        if (cartas[4].valor != cartas[5].valor)
        {
            if (cartas[4].valor > cartas[5].valor)
            {
                cartas[4].transform.name = "mayor";
                cartas[5].transform.name = "menor";
            }
            else
            {
                cartas[5].transform.name = "mayor";
                cartas[4].transform.name = "menor";
            }
        }
        else
        {
            igualPar3 = true;
        }
        //par4
        if (cartas[6].valor != cartas[7].valor)
        {
            if (cartas[6].valor > cartas[7].valor)
            {
                cartas[6].transform.name = "mayor";
                cartas[7].transform.name = "menor";
            }
            else
            {
                cartas[7].transform.name = "mayor";
                cartas[6].transform.name = "menor";
            }
        }
        else
        {
            igualPar4 = true;
        }
    }

    public void btnIgualPar1()
    {
        if (igualPar1)
        {
            popUp.cartelAcierto();
            estado++;
            cartas[0].GetComponent<Carta>().enabled = false;
            cartas[1].GetComponent<Carta>().enabled = false;
            cartas[0].GetComponent<InteractuableScale>().enabled = false;
            cartas[1].GetComponent<InteractuableScale>().enabled = false;
            if (estado == 4)
            {
                popUp.Bien();
            }
        }
        else
        {
            popUp.Mal();
        }
    }

    public void btnIgualPar2()
    {
        if (igualPar2)
        {
            popUp.cartelAcierto();
            estado++;
            cartas[2].GetComponent<Carta>().enabled = false;
            cartas[3].GetComponent<Carta>().enabled = false;
            cartas[2].GetComponent<InteractuableScale>().enabled = false;
            cartas[3].GetComponent<InteractuableScale>().enabled = false;
            if (estado == 4)
            {
                popUp.Bien();
            }
        }
        else
        {
            popUp.Mal();
        }
    }

    public void btnIgualPar3()
    {
        if (igualPar3)
        {
            popUp.cartelAcierto();
            estado++;
            cartas[4].GetComponent<Carta>().enabled = false;
            cartas[5].GetComponent<Carta>().enabled = false;
            cartas[4].GetComponent<InteractuableScale>().enabled = false;
            cartas[5].GetComponent<InteractuableScale>().enabled = false;
            if (estado == 4)
            {
                popUp.Bien();
            }
        }
        else
        {
            popUp.Mal();
        }
    }

    public void btnIgualPar4()
    {
        if (igualPar4)
        {
            if (estado == 4)
            {
                popUp.Bien();
            }
            else
            {
                popUp.cartelAcierto();
                estado++;
                cartas[6].GetComponent<Carta>().enabled = false;
                cartas[7].GetComponent<Carta>().enabled = false;
                cartas[6].GetComponent<InteractuableScale>().enabled = false;
                cartas[7].GetComponent<InteractuableScale>().enabled = false;
            }
        }
        else
        {
            popUp.Mal();
        }
    }
}
