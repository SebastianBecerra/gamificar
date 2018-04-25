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
	// Use this for initialization
	void Start () {
        bandera = true;
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
        controller.desabilitarBanderas();
        
        while(miTransform.localScale.x > 0)
        {
            miTransform.localScale -= new Vector3(0.1f, 0, 0);
            yield return new WaitForSeconds(.01f);
        }
        dorso.enabled = !dorso.enabled;
       // bocaArriba = !dorso.enabled;
        while (miTransform.localScale.x < 1)
        {
            miTransform.localScale += new Vector3(0.1f, 0, 0);
            yield return new WaitForSeconds(.01f);
        }
        controller.habilitarBanderas();

    }
}
