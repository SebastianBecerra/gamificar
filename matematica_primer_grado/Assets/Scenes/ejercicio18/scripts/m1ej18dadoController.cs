using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class m1ej18dadoController : MonoBehaviour {

    public GameObject[] textosDado1;//referencia al numero generado por el primer dado
    public GameObject[] textosDado2;//referencia al numero generado por el segundo dado
    public GameObject[] textos; //referencia al numero de la primer columna
    public Button[] botones; //referencia a los botones dados
    private int randomInt; //entero para asignar el valor randomizado
    private int i, j; //indices para las columnas de los dados
    public bool dado1Listo, dado2Listo; //bool que indica que se completo de usar los dados

	// Use this for initialization
	void Start () {
        textos = GameObject.FindGameObjectsWithTag("input1").OrderBy(go => go.name).ToArray();//lleno los array
        textosDado1 = GameObject.FindGameObjectsWithTag("textoDado1").OrderBy(go => go.name).ToArray();
        textosDado2 = GameObject.FindGameObjectsWithTag("textoDado2").OrderBy(go => go.name).ToArray();
        i = 0;//inicializo los indices
        j = 0;
        darValores();//llamo a la funcion dar valores que inicializa los numeros de la primer columna
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void dado1()//metodo para el primer dado
    {
        randomInt = Random.Range(1, 6);//genera un numero aleatorio desde 1 a 6
        textosDado1[i].GetComponent<Text>().text = randomInt.ToString();//asigna el numero a la fila indicada por el indice
        i++;
        if (i == 4)//si completo todas las filas
        {
            botones[0].interactable = false;//el boton del dado se vuelve no interactuable
            dado1Listo = true;//se indica en la bandera  que se completo de utilizar el dado

        }
    }

    public void dado2()//metodo para el segundo dado
    {
        randomInt = Random.Range(1, 6);
        textosDado2[j].GetComponent<Text>().text = randomInt.ToString();
        j++;
        if (j == 4)
        {
            botones[1].interactable = false;
            dado2Listo = true;
        }
    }

    void darValores()//inicializa los valores de la primer columna con un numero desde 1 a 33
    {
        foreach(GameObject a in textos)
        {
            a.GetComponent<Text>().text = Random.Range(1, 33).ToString();
        }
    }

}
