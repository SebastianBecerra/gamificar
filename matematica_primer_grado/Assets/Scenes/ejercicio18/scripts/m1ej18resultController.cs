using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class m1ej18resultController : MonoBehaviour {

    public GameObject[] results;//referencia a los valores ingrezados en la cuarta columna
    m1ej18dadoController num; //referencia al script que contiene los valores de las otras columnas
    public bool ganar; //indica si estan bien los resultados
    popUpScript popUP;//referencia a los popups

	// Use this for initialization
	void Start () {
        results = GameObject.FindGameObjectsWithTag("input2").OrderBy(go => go.name).ToArray();//lleno el array en orden
        num = FindObjectOfType<m1ej18dadoController>();//asigno variables
        popUP = FindObjectOfType<popUpScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void controlarResultados()//metodo para el boton que valida el ejercicio
    {
        if (num.dado1Listo && num.dado2Listo)//si los dos dados finalizaron de utilizarse
        {
            checkfila1();//llamo  alos metodos de checkear cada fila
            checkfila2();
            checkfila3();
            checkfila4();
            if (ganar)//si estan bien 
            {
                popUP.Bien();//llamo al popup de ganar
            }
            else
            {
                popUP.Mal();//sino llamo al popup de intentar de nuevo
            }
        }
        else
        {
            popUP.Mal();//sino se terminaron de utilizar los dados, se llama al popup de intentar de nuevo
        }
    }

    private void checkfila1()//checkea la primer fila
    {
        InputField a = results[3].GetComponent<InputField>();//asigna el valor ingresado por el usuario
        Debug.Log(a.text);
        int b = System.Convert.ToInt32(num.textosDado1[0].GetComponent<Text>().text);//convierte los valores de las demas columas
        Debug.Log(b);                                                                //de texto a entero
        int c = System.Convert.ToInt32(num.textosDado2[0].GetComponent<Text>().text);
        Debug.Log(c);
        int d = System.Convert.ToInt32(num.textos[0].GetComponent<Text>().text);
        Debug.Log(d);
        int f;
        if (a.text == "")//sino ingreso nada
        {
            f = 0;//se le asigna el valor 0
        }
        else
        {
            f = System.Convert.ToInt32(a.text);
        }
        Debug.Log(f);
        if (f == (b * 10) + c + d)//si la suma es correcta
        {
            ganar = true;//indica que la fila esta bien
        }
        else
        {
            ganar = false;
        }
    }

    private void checkfila2()
    {
        InputField a = results[2].GetComponent<InputField>();
        Debug.Log(a.text);
        int b = System.Convert.ToInt32(num.textosDado1[1].GetComponent<Text>().text);
        Debug.Log(b);
        int c = System.Convert.ToInt32(num.textosDado2[1].GetComponent<Text>().text);
        Debug.Log(c);
        int d = System.Convert.ToInt32(num.textos[1].GetComponent<Text>().text);
        Debug.Log(d);
        int f;
        if (a.text == "")
        {
            f = 0;
        }
        else
        {
            f = System.Convert.ToInt32(a.text);
        }
        Debug.Log(f);
        if (f == (b * 10) + c + d)
        {
            ganar = true;
        }
        else
        {
            ganar = false;
        }
    }

    private void checkfila3()
    {
        InputField a = results[1].GetComponent<InputField>();
        Debug.Log(a.text);
        int b = System.Convert.ToInt32(num.textosDado1[2].GetComponent<Text>().text);
        Debug.Log(b);
        int c = System.Convert.ToInt32(num.textosDado2[2].GetComponent<Text>().text);
        Debug.Log(c);
        int d = System.Convert.ToInt32(num.textos[2].GetComponent<Text>().text);
        Debug.Log(d);
        int f;
        if (a.text == "")
        {
            f = 0;
        }
        else
        {
            f = System.Convert.ToInt32(a.text);
        }
        Debug.Log(f);
        if (f == (b * 10) + c + d)
        {
            ganar = true;
        }
        else
        {
            ganar = false;
        }
    }

    private void checkfila4()
    {
        InputField a = results[0].GetComponent<InputField>();
        Debug.Log(a.text);
        int b = System.Convert.ToInt32(num.textosDado1[3].GetComponent<Text>().text);
        Debug.Log(b);
        int c = System.Convert.ToInt32(num.textosDado2[3].GetComponent<Text>().text);
        Debug.Log(c);
        int d = System.Convert.ToInt32(num.textos[3].GetComponent<Text>().text);
        Debug.Log(d);
        int f;
        if (a.text == "")
        {
            f = 0;
        }
        else
        {
            f = System.Convert.ToInt32(a.text);
        }
        Debug.Log(f);
        if (f == (b * 10) + c + d)
        {
            ganar = true;
        }
        else
        {
            ganar = false;
        }
    }

}
