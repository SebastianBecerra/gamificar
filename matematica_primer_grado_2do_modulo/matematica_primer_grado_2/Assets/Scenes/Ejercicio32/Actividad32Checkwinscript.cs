﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Actividad32Checkwinscript : MonoBehaviour {
	public string [] arrayCorrecto;
	public GameObject dropzone;
	private popUpScript popup;
	// Use this for initialization
	void Start () {
		popup = FindObjectOfType<popUpScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void checkeo()
	{
        bool estado = true;
        if (dropzone.transform.childCount == 8) {
            for (int i = 0; i < arrayCorrecto.Length; i++) {
                estado = estado && (arrayCorrecto[i] == dropzone.transform.GetChild(i).name);
			}
            if (estado) {
                popup.Bien();
            }
            else {
                popup.Mal();
            }
        } else
		{
			popup.Mal ();
		}
       

	}

}
