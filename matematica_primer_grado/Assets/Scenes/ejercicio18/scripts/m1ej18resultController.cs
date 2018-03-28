using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class m1ej18resultController : MonoBehaviour {

    public GameObject[] results;
    m1ej18dadoController num;
    public bool ganar;
    popUpScript popUP;

	// Use this for initialization
	void Start () {
        results = GameObject.FindGameObjectsWithTag("input2").OrderBy(go => go.name).ToArray();
        num = FindObjectOfType<m1ej18dadoController>();
        popUP = FindObjectOfType<popUpScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void controlarResultados()
    {
        if (num.dado1Listo && num.dado2Listo)
        {
            checkfila1();
            checkfila2();
            checkfila3();
            checkfila4();
            if (ganar)
            {
                popUP.Bien();
            }
            else
            {
                popUP.Mal();
            }
        }
        else
        {
            popUP.Mal();
        }
    }

    private void checkfila1()
    {
        InputField a = results[3].GetComponent<InputField>();
        Debug.Log(a.text);
        int b = System.Convert.ToInt32(num.textosDado1[0].GetComponent<Text>().text);
        Debug.Log(b);
        int c = System.Convert.ToInt32(num.textosDado2[0].GetComponent<Text>().text);
        Debug.Log(c);
        int d = System.Convert.ToInt32(num.textos[0].GetComponent<Text>().text);
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
