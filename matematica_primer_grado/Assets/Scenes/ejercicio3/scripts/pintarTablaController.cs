using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class pintarTablaController : MonoBehaviour {

    //script con funcionalidad de control para el ejercicio 3 de matematica modulo 1
    //este script genera un numero aleatorio y dependiendo del numero son los botones que hace la validacion para cambiar de color


    spriteClickManager checkClor; //referencia al script spriteClickManager
    [HideInInspector]public GameObject[] sp; //objetos sprite para cambiar de color        
    popUpScript popUP; //referencia a los popus
    private int dado; //numero aleatorio
    private Button btn; //referencia al boton de generar numero
    public Sprite[] coloresSprites; //referencia a los distintos colores que se van a usar en el cambio de color
    private int j; //indice del array de cambio de color
    public int totalSpritesAlternativos; //length del array de colores alternativos
    public Text texoDado; //display del int aleatorio generado

    private GameObject sprDado;
    public Sprite spr1, spr2, spr3, spr4, spr5, spr6;

    void Start (){
        j = 0;
        //asignaciones a las referencias
        checkClor = FindObjectOfType<spriteClickManager>();
        popUP = FindObjectOfType<popUpScript>();
        btn = gameObject.GetComponent<Button>();
        //cuando empieza da la indicacion de tocar el boton de generar numero seteando texto y tamaño de fuente
        texoDado.GetComponent<Text>().fontSize = 30;
        texoDado.GetComponent<Text>().text = "TIRÁ EL DADO ↓";

        sprDado = GameObject.FindGameObjectWithTag("error");
        sprDado.SetActive(false);
    }

    //metodo de generar el numero aleatorio
    public void tirarDado()
    {
        //ordena los objetos a cambiar de color en el orden que aparecen en iherarchy
        sp = GameObject.FindGameObjectsWithTag("color").OrderBy(g => g.transform.GetSiblingIndex()).ToArray();
        for(int i=0; i< sp.Length; i++)//habilitacion de cambio de sprite
        {
            sp[i].GetComponent<changeSprite>().enabled = true;
        }

        //controlo que el rango no sobrepase el limite cuando se esta terminando
        if (sp.Length >= 6)
        {
            dado = Random.Range(1, 7);
        }
        else
        {
            dado = Random.Range(1, sp.Length);
        }
        sprDado.SetActive(true);
        texoDado.GetComponent<Text>().fontSize = 50;//seteo de texto para mostrar el numero
        texoDado.GetComponent<Text>().text = dado.ToString();

        switch (dado)
        {
            case 1:
                sprDado.GetComponent<Image>().sprite = spr1;
                break;
            case 2:
                sprDado.GetComponent<Image>().sprite = spr2;
                break;
            case 3:
                sprDado.GetComponent<Image>().sprite = spr3;
                break;
            case 4:
                sprDado.GetComponent<Image>().sprite = spr4;
                break;
            case 5:
                sprDado.GetComponent<Image>().sprite = spr5;
                break;
            case 6:
                sprDado.GetComponent<Image>().sprite = spr6;
                break;
        }

        btn.interactable = false;//el boton no se podra volver a presionar hasta que no solcione el primer numero aleatorio
        for (int i = 0; i < dado; i++)//seteo de los objetos a cambiar de sprite para que devuelvan el valor booleano correspondiente
        {
            sp[i].GetComponent<changeSprite>().color = true;
            sp[i].GetComponent<changeSprite>().bandera = false;
        }
        for(int i = 0; i < sp.Length; i++)//cambio de sprites de colores que va cambiando
        {
            if (j >= totalSpritesAlternativos)
            {
                j = 0;
            }
            sp[i].GetComponent<changeSprite>().spriteColor = coloresSprites[j];
        }
        j++;
    }


    //metodo que valida si los sprites cambiados concuerdan con el numero generado
    public void validarColor()
    {
        sprDado.SetActive(false);
        texoDado.GetComponent<Text>().fontSize = 30;//una vez presionado el boton cambia el texto para pedir otro roll de numero aleatorio
        texoDado.GetComponent<Text>().text = "TIRÁ EL DADO ↓";
        if (checkClor.checkBools())//llama al metodo checkBools que devuelve si todas las banderas de los objetos da true en su comparacion
        {
            //si  se pintaron los cuadros correctos
            if (dado < sp.Length)//si el numero aleatorio generado es menor a lo que queda por pintar, muestra el cartel de acierdo
            {                   //y desabilita la posibiilidad para volver a cambiarlos de color
                popUP.cartelAcierto();
                for (int i = 0; i < dado; i++)
                {
                    sp[i].GetComponent<changeSprite>().enabled = false;
                    sp[i].transform.tag = "Untagged";
                }
            }
            if (dado == sp.Length)//si el numero aleatorio generado es igual a lo que queda por pintar, quiere decir que termino
            {                       //de pintar la tabla y gana el juego
                popUP.Bien();
            }
        }
        else//si se pintaron la cantidad de cuadros incorrectos, muestra el cartel que intente nuevamente
        {
            popUP.Mal();
        }
        for (int i = dado; i<sp.Length; i++)//no deja tocar mas botones hasta que genere otro numero aleatorio
        {
            sp[i].GetComponent<changeSprite>().enabled = false;
        }
        btn.interactable = true;
    }
}