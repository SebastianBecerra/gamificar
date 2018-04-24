using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ejercicio27mover : MonoBehaviour {
    public GameObject cartel;
    private popUpScript popup;
    public bool estado1, estado2, estado3;
	// Use this for initialization
	void Start () {
        estado1 = true;
        estado2 = false;
        estado3 = false;
	}
	
	// Update is called once per frame
	void Update () {
        popup = FindObjectOfType<popUpScript>();
	}
    public void OnTriggerEnter2D(Collider2D other)
    {
        
    
    
       if(other.gameObject.tag == "Respawn" && estado1)
        {
            popup.cartelAcierto();
            estado1 = false;
            estado2 = true;
            cartel.transform.GetChild(0).GetComponent<Text>().enabled = false;
            cartel.transform.GetChild(1).GetComponent<Text>().enabled = true;
            other.GetComponent<BoxCollider2D>().enabled = false;
        }
        if (other.gameObject.tag == "Finish" && estado2)
        {
            popup.cartelAcierto();
            estado2 = false;
            estado3 = true;
            cartel.transform.GetChild(1).GetComponent<Text>().enabled = false;
            cartel.transform.GetChild(2).GetComponent<Text>().enabled = true;
            other.GetComponent<BoxCollider2D>().enabled = false;
        }
        if (other.gameObject.tag == "Player" && estado3)
        {
            popup.Bien();

        }
    }

}
