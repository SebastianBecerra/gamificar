using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class numero2 : MonoBehaviour
{

    public GameObject btn;
    public AudioSource sonido;
    public AudioClip sonidoSiguiente;
    popUpScript popUp;
    changeSprite spr;
    public int estado;
    private int i = 0;
    // Use this for initialization
    void Start()
    {
        estado = 0;
        btn = GameObject.FindGameObjectWithTag("Player");
        sonido = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
        spr = gameObject.GetComponent<changeSprite>();
        popUp = FindObjectOfType<popUpScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (btn.GetComponent<Button>().interactable == true)
        {
            popUp.Mal();
        }
        else
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // Casts the ray and get the first game object hit
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            if (hit.transform.name == "numero2" && sonido.clip.name == "voz-tres")
            {
                Debug.Log("numero 2 bien");
                popUp.cartelAcierto();
                sonido.clip = sonidoSiguiente;
                spr.enabled = false;

            }
            else
            {
                Debug.Log("PERDIO JUEGO");
                popUp.Mal();
            }
            btn.GetComponent<Button>().interactable = true;
        }
    }
}