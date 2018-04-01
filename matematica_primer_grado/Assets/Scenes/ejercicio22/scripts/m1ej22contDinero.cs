using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m1ej22contDinero : MonoBehaviour {

    public DropZone drop;//referencia a la zona donde arrastrar los billetes
    private int count;//contador que lleva el resultadod e la suma de los billetes
    public int precio;//precio a alcanzar
    popUpScript popUP;//referencia a los popUPs

	// Use this for initialization
	void Start () {
        popUP = FindObjectOfType<popUpScript>();//asignacion de los popups
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void contarDinero()//metodo utilizado por el boton de validación de la escena
    {
        foreach(Transform child in drop.GetComponent<Transform>())//por cada child en la zonadrop
        {
            switch (child.name)//me fijo en el nombre y dependiendo el nombre es el valor que se le va sumando al contador
            {
                case "2pesos":
                    count = count + 2;
                    break;
                case "5pesos":
                    count = count + 5;
                    break;
                case "10pesos":
                    count = count + 10;
                    break;
                case "20pesos":
                    count = count + 20;
                    break;
                case "50pesos":
                    count = count + 50;
                    break;
            }
        }
        if (count == precio)//si el contador tiene el mismo valor del precio a equiparar
        {
            popUP.Bien();//muestro el popup de etapa completada
        }
        else//sino
        {
            popUP.Mal();//muestro el popup de intentar de nuevo
        }
    }
}
