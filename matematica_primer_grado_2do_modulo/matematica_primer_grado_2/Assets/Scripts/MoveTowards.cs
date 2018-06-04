using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour {
	//scipt para el moviento de un objeto hacia otro clickeado
	//este script debe ir como componente del OBJETO de la escena que queramos mover

	public float vel;    // velocidad en la que queramos mover el objeto
	public Transform pos1;
	private Transform pos2;
	RaycastHit hit;
	public LayerMask LM; // Layer Mask de los objetos que podemos clickear para realizar el movimiento
	public bool moversoloenx; 
	public bool moversoloeny;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//ray cast desde el mouse para clickear el objeto

		if (Input.GetMouseButtonDown (0) ) {  


			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			// cuando clickeamos lanza un raycast desde el mouse para detectar un objecto con la layer mask que establecimos
			if (Physics.Raycast (ray, out hit, LM)) 
			{
				if (pos1 == null) {
					
					pos1 = hit.collider.gameObject.transform;
				} 


			}

		}
		// movimiento
		if (pos1 != null)  
		{
			pos1 = MoverTowards (pos1);
		}
	}
	Transform MoverTowards(Transform posicion)
	{
		//mover hacia el objeto con la X fija
		if (posicion != null && moversoloenx == true)
		{
			this.transform.position = Vector2.MoveTowards (this.gameObject.transform.position, new Vector2(pos1.transform.position.x,this.gameObject.transform.position.y), vel);
		}

		if (this.gameObject.transform.position == new Vector3(pos1.transform.position.x,this.gameObject.transform.position.y,this.transform.position.z) && moversoloenx == true) 
		{
			posicion = null;
		}// hasta aca

		//mover hacia el objeto  con la Y fija
		if (posicion != null && moversoloeny == true)
		{
			this.transform.position = Vector2.MoveTowards (this.gameObject.transform.position, new Vector2(this.transform.position.x,pos1.gameObject.transform.position.y), vel);
		}

		if (this.gameObject.transform.position == new Vector3(this.transform.position.x,pos1.gameObject.transform.position.y,this.transform.position.z) && moversoloeny == true) 
		{
			posicion = null;
		}

		// mover libremente
		if (posicion != null && moversoloenx == false && moversoloeny == false)
		{
			this.transform.position = Vector2.MoveTowards (this.gameObject.transform.position, pos1.transform.position, vel);
		}

		if (this.gameObject.transform.position == pos1.transform.position &&  !moversoloenx  && !moversoloeny) 
		{
			posicion = null;
		}



		return(posicion);

	}
}
