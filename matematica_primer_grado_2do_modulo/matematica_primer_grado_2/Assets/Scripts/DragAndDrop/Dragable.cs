using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dragable : MonoBehaviour, IBeginDragHandler, IDragHandler , IEndDragHandler {

    [HideInInspector] public Transform ObjetoPadreReturn = null;    //  Determina donde se va a dejar el Drag
    [Header("DropZone")]
    [Tooltip("Determina a que DropZone Tiene que ir.")]
    public int idDropZone1;     //  Determina a que DropZone Tiene que ir.
    
    //  Al Agarrar el Drag
    public void OnBeginDrag(PointerEventData eventData) {
        ObjetoPadreReturn = this.transform.parent;
        this.transform.SetParent(ObjetoPadreReturn.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    //  Mientras se Draguea
    public void OnDrag(PointerEventData eventData)
    {
        // Cambia la posicion del objeto dragueado. 
        Vector3 screenPoint = Input.mousePosition;
        screenPoint.z = 10.0f; 
        transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
    }

    //  Al Soltar el Drag
    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(ObjetoPadreReturn);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        this.transform.parent.GetComponent<DropZone>().incioCheckeo();
    }
}