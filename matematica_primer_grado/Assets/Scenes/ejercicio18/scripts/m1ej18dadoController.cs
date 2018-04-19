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

    public GameObject[] finderDados, spriteDados, finderDados2, spriteDados2;
    private int indexDados = 0;
    public Sprite spr1, spr2, spr3, spr4, spr5, spr6;

	// Use this for initialization
	void Start () {
        textos = GameObject.FindGameObjectsWithTag("input1").OrderBy(go => go.name).ToArray();//lleno los array
        textosDado1 = GameObject.FindGameObjectsWithTag("textoDado1").OrderBy(go => go.name).ToArray();
        textosDado2 = GameObject.FindGameObjectsWithTag("textoDado2").OrderBy(go => go.name).ToArray();
        i = 0;//inicializo los indices
        j = 0;
        darValores();//llamo a la funcion dar valores que inicializa los numeros de la primer columna

        finderDados = GameObject.FindGameObjectsWithTag("checkColor");
        finderDados2 = GameObject.FindGameObjectsWithTag("color");
        for (int i = 0; i < finderDados.Length; i++)
        {

            for (int j = 0; j < finderDados.Length; j++)
            {
                if (finderDados[j].name == indexDados.ToString())
                {
                    spriteDados[i] = finderDados[j];
                }
            }
            indexDados++;
        }
        indexDados = 0;
        for (int i = 0; i < finderDados2.Length; i++)
        {

            for (int j = 0; j < finderDados2.Length; j++)
            {
                if (finderDados2[j].name == indexDados.ToString())
                {
                    spriteDados2[i] = finderDados2[j];
                }
            }
            indexDados++;
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void dado1()//metodo para el primer dado
    {
        randomInt = Random.Range(1, 7);//genera un numero aleatorio desde 1 a 6
        textosDado1[i].GetComponent<Text>().text = randomInt.ToString();//asigna el numero a la fila indicada por el indice
        i++;
        for(int j=0; j < textosDado1.Length; j++)
        {
            indexDados = j;
            switch (textosDado1[j].GetComponent<Text>().text)//dependiendo del numero generado se asigna el sprite del dado correspondiente
            {
                case "1":
                    spriteDados[indexDados].GetComponent<Image>().sprite = spr1;
                    spriteDados[indexDados].GetComponent<Image>().color = new Color32(0xF4, 0x6A, 0x6A, 0xFF);
                    break;
                case "2":
                    spriteDados[indexDados].GetComponent<Image>().sprite = spr2;
                    spriteDados[indexDados].GetComponent<Image>().color = new Color32(0xF4, 0x6A, 0x6A, 0xFF);
                    break;
                case "3":
                    spriteDados[indexDados].GetComponent<Image>().sprite = spr3;
                    spriteDados[indexDados].GetComponent<Image>().color = new Color32(0xF4, 0x6A, 0x6A, 0xFF);
                    break;
                case "4":
                    spriteDados[indexDados].GetComponent<Image>().sprite = spr4;
                    spriteDados[indexDados].GetComponent<Image>().color = new Color32(0xF4, 0x6A, 0x6A, 0xFF);
                    break;
                case "5":
                    spriteDados[indexDados].GetComponent<Image>().sprite = spr5;
                    spriteDados[indexDados].GetComponent<Image>().color = new Color32(0xF4, 0x6A, 0x6A, 0xFF);
                    break;
                case "6":
                    spriteDados[indexDados].GetComponent<Image>().sprite = spr6;
                    spriteDados[indexDados].GetComponent<Image>().color = new Color32(0xF4, 0x6A, 0x6A, 0xFF);
                    break;
            }
            
        }
        if (i == 4)//si completo todas las filas
        {
            botones[0].interactable = false;//el boton del dado se vuelve no interactuable
            dado1Listo = true;//se indica en la bandera  que se completo de utilizar el dado

        }
    }

    public void dado2()//metodo para el segundo dado
    {
        randomInt = Random.Range(1, 7);
        textosDado2[j].GetComponent<Text>().text = randomInt.ToString();
        j++;
        for (int k = 0; k< textosDado2.Length; k++)
        {
            indexDados = k;
            switch (textosDado2[k].GetComponent<Text>().text)
            {
                case "1":
                    spriteDados2[indexDados].GetComponent<Image>().sprite = spr1;
                    spriteDados2[indexDados].GetComponent<Image>().color = new Color32(0x6A, 0x6B, 0xF4, 0xFF);
                    break;
                case "2":
                    spriteDados2[indexDados].GetComponent<Image>().sprite = spr2;
                    spriteDados2[indexDados].GetComponent<Image>().color = new Color32(0x6A, 0x6B, 0xF4, 0xFF);
                    break;
                case "3":
                    spriteDados2[indexDados].GetComponent<Image>().sprite = spr3;
                    spriteDados2[indexDados].GetComponent<Image>().color = new Color32(0x6A, 0x6B, 0xF4, 0xFF);
                    break;
                case "4":
                    spriteDados2[indexDados].GetComponent<Image>().sprite = spr4;
                    spriteDados2[indexDados].GetComponent<Image>().color = new Color32(0x6A, 0x6B, 0xF4, 0xFF);
                    break;
                case "5":
                    spriteDados2[indexDados].GetComponent<Image>().sprite = spr5;
                    spriteDados2[indexDados].GetComponent<Image>().color = new Color32(0x6A, 0x6B, 0xF4, 0xFF);
                    break;
                case "6":
                    spriteDados2[indexDados].GetComponent<Image>().sprite = spr6;
                    spriteDados2[indexDados].GetComponent<Image>().color = new Color32(0x6A, 0x6B, 0xF4, 0xFF);
                    break;
            }

        }
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
