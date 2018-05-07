using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class cartaEjer35 : MonoBehaviour {

    public Image dorso;
    public int id;
    public bool bocaArriba;
    [HideInInspector] public bool bandera;
    [HideInInspector] public bool volteable;
    Transform miTransform;
    ControllerCartaEjer35 controller;
    InteractuableScale CrecimientoConMause;
    // Use this for initialization
    void Start () {
        bandera = true;
        CrecimientoConMause = gameObject.GetComponent<InteractuableScale>();
        miTransform = gameObject.GetComponent<Transform>();
        controller = FindObjectOfType<ControllerCartaEjer35>();
        
    }
    public void darVuelta() {
        StartCoroutine("Voltear");
    }

    void OnMouseDown()
    {
        if (bandera)
        {
            controller.Contralador(this);
            darVuelta();
        }
    }
    // Update is called once per frame
    void Update () {
        bocaArriba = !dorso.enabled;
    }
    IEnumerator Voltear()
    {
        CrecimientoConMause.enabled = false;
        controller.desabilitarBanderas();
        for (int i = 0; i < 10; i++)
        {
            miTransform.localScale -= new Vector3(0.1f, 0, 0);
            yield return new WaitForSeconds(.01f);
        }/*
        while(miTransform.localScale.x > 0)
        {
            miTransform.localScale -= new Vector3(0.1f, 0, 0);
            yield return new WaitForSeconds(.01f);
        }*/
        dorso.enabled = !dorso.enabled;
        for (int i = 0; i < 10; i++)
        {
            miTransform.localScale += new Vector3(0.1f, 0, 0);
            yield return new WaitForSeconds(.01f);
        }/*
        while (miTransform.localScale.x < 1)
        {
            miTransform.localScale += new Vector3(0.1f, 0, 0);
            yield return new WaitForSeconds(.01f);
        }*/
        CrecimientoConMause.enabled = true;

    }
}
