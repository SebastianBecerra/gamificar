using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : EsCheckeable, IDropHandler {

    [Header("DropZone")]
    [Tooltip("Cantidad de Objetos que puede Contener")]
    public int slotDisponibles = 1;
    [Tooltip("ID de este DropZone")]
    public int idDropZone;
    [Tooltip("Este DropZone no cuenta para el checkeo final del juego.")]
    public bool ignorarCheckeo = false;

    ControllerDragAndDrop controllerDaD;

    void Start(){
        controllerDaD = FindObjectOfType<ControllerDragAndDrop>();
    }

        public void OnDrop(PointerEventData evenData) {

        Dragable drag = evenData.pointerDrag.GetComponent<Dragable>();
        if (drag != null ) {
            if (this.transform.childCount < slotDisponibles){
                drag.ObjetoPadreReturn = this.transform;
                
            }
        }
    }
    public void incioCheckeo() {
        controllerDaD.checkearEstado();
    }
    public bool estaIncompleto() {
        return !(this.transform.childCount == slotDisponibles);
    }
    public override bool EsCorrecto() {

        if (!estaIncompleto()){
            bool estado = true;
            foreach (Transform child in this.transform) {
                Dragable d = child.GetComponent<Dragable>();
                if (d.idDropZone1 == idDropZone){
                    estado = estado && true;
                }
                else {
                    estado = estado && false;
                }
            }
            return estado;
        }
        else {
            return false;
        }
    }
	
}
