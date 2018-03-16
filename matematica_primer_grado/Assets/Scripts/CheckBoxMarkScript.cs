using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBoxMarkScript : MonoBehaviour {

    Animator animator;
    public EsCheckeable[] chekeos;

    void Start(){
        animator = gameObject.GetComponent<Animator>();
    }

	void Update () {
        animator.SetBool("Activo", chequearEstado());
	}

    bool chequearEstado() {
        bool estado = true;
        if (chekeos.Length > 0) {
            for (int i = 0; i < chekeos.Length; i++) {
                estado = estado && chekeos[i].EsCorrecto();
            }
            return estado;
        } else {
            return false;
        }
    }
}
