using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//singleton stagemanager que indica los valores de las stages completadas

public class stageManager : MonoBehaviour
{

    public static stageManager instance { get; private set; }

    [HideInInspector]public int[] value10, value30, value60, value100; //valor para cada dificultad
    [HideInInspector]public bool reinicio; //bandera para reiniciar los sprites
    //public int longitud; //longitud de los array 

    private void Awake()
    {
        if (instance == null) //sino hay un obj stageManager lo creo y si hay lo destruye para que solo se encuentre una instancia en la scene
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        //inicializacion de arrays
        value10 = new int[23];
        value30 = new int[17];
        value60 = new int[16];
        value100 = new int[16];
    }

    
}