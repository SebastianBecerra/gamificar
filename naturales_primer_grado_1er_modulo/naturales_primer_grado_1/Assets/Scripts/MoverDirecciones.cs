using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverDirecciones : MonoBehaviour {
	//scipt para el moviento de un objeto presionando teclas
	//este script debe ir como componente del OBJETO de la escena que queramos mover

	public float vel; // velocidad en la que queremos mover el objeto
	public bool mover8direcciones,mover4direcciones,mover2direccionesx,mover2direccionesy;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// Depende la variable tildada es el tipo de movimiento que va a utilizar
		if(mover8direcciones)
		    movimiento8 ();
		if (mover4direcciones)
			movimiento4 ();
		if (mover2direccionesx)
			movimiento2x ();
		if (mover2direccionesy)
			movimiento2y ();
		
		
	} 
	public void movimiento8 () // Movimiento en 8Direcciones
	{

		if (Input.GetKey (KeyCode.D)) 
		{
			
			this.transform.Translate (Vector2.right *vel * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.A))
		{
			
			this.transform.Translate (Vector2.left *vel * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.S))
		{
			this.transform.Translate (Vector2.down *vel * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.W))
		{
			this.transform.Translate (Vector2.up *vel * Time.deltaTime);
		}
	}
	public void movimiento4 () //Moviemiento en 4 Direcciones
	{
		bool aux = false;
		
		if (Input.GetKey (KeyCode.D) && !aux)
		{
			aux = true;
			this.transform.Translate (Vector2.right *vel * Time.deltaTime);
		}
		if (Input.GetKeyUp (KeyCode.D) && aux)
		{
			aux = false;

		}

		if (Input.GetKey (KeyCode.A) && !aux)
		{
			aux = true;
			this.transform.Translate (Vector2.left *vel * Time.deltaTime);
		}

		if (Input.GetKeyUp (KeyCode.A) && aux)
		{
			aux = false;

		}
		if (Input.GetKey (KeyCode.S) && !aux)
		{
			aux = true;
			this.transform.Translate (Vector2.down *vel * Time.deltaTime);
		}

		if (Input.GetKeyUp (KeyCode.S) && aux)
		{
			aux = false;

		}
		if (Input.GetKey (KeyCode.W) && !aux)
		{
			aux = true;
			this.transform.Translate (Vector2.up *vel * Time.deltaTime);
		}

		if (Input.GetKeyUp (KeyCode.W) && aux)
		{
			aux = false;
	
		}
	}

	public void movimiento2x () //Moviento solo en el eje x
	{
		if (Input.GetKey (KeyCode.D)) 
		{

			this.transform.Translate (Vector2.right *vel * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.A))
		{

			this.transform.Translate (Vector2.left *vel * Time.deltaTime);
		}


	}
	public void movimiento2y ()// Movimiento solo en el eje y
	{

		if (Input.GetKey (KeyCode.S))
		{
			this.transform.Translate (Vector2.down *vel * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.W))
		{
			this.transform.Translate (Vector2.up *vel * Time.deltaTime);
		}
	}
}
