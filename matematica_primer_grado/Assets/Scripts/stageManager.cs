using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//singleton stagemanager que indica los valores de las stages completadas

public class stageManager : MonoBehaviour
{

    public static stageManager instance { get; private set; }

    [HideInInspector] public int value10, value30, value60, value100; //valor para cada dificultad

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
    }

}