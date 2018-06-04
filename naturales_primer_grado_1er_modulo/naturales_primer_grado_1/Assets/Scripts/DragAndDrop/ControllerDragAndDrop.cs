using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerDragAndDrop : EsCheckeable {

    List<DropZone> dropZones = new List<DropZone>();
    [HideInInspector] public GameController controller;
    [Tooltip("Deja que el sistema se chequee de forma automatica y termine cuando los Drags esten bien ubicados")]
    public bool automatico;

    void Start () {
        controller = GetComponent<GameController>();
        controller.chequear.Add(this);
        buscarDropZones();
    }
	
    void buscarDropZones()
    {
        DropZone[] dzs = FindObjectsOfType<DropZone>();
        foreach (DropZone item in dzs)
        {
            if (!(item.ignorarCheckeo)) {
                dropZones.Add(item);
            }
        }
        if (dropZones.Count == 0) {
            Debug.LogErrorFormat("No se encontro ningun DropZone con IgnorarCheckeo false");
        }
    }


    public void checkearEstado() {
        if (EsCorrecto() && automatico) {
            controller.checkearEstado();
        }
    }


    public override bool EsCorrecto()
    {
        bool estado = true;
        foreach (DropZone dz in dropZones)
        {
            estado = estado && dz.EsCorrecto();
        }
        return estado;
    }
}
