using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawline : MonoBehaviour {
	//scipt de unir con flechas
	//este script debe ir en cualquier objeto de la escena

	/*el prefab tiene 2 childs el drawline que ahi esta el componente que traza la linea, y el otro child es donde se van
	a unir las lineas
	el script diferencia las columnas usando el layer
	y una vez que una dos las comprueba con el tag*/

	RaycastHit hit;
	private GameObject probando;
	public GameObject go1;
	public GameObject go2;
	private GameObject child;
	private LineRenderer LR;
	public bool equivocado;
	public Material material;
	public Color colorbien; 
	public Color colormal;

	private bool mal;
	public Camera cam;
	private Vector3 posicionMouse;

	// Use this for initialization
	void Start () {
		colorbien= new Color (0,7f,0.9f,0.5f);
		colormal = new Color (5f, 0f, 0f);
		cam = FindObjectOfType<Camera> ();

	}
	
	// Update is called once per frame
	void Update () {
		
		if (go1 != null && go2 == null) 
		{   
			LR.material.color = colorbien;
			Vector3 screenPoint = Input.mousePosition;
			screenPoint.z =  4f; //distance of the plane from the camera
			posicionMouse = Camera.main.ScreenToWorldPoint(screenPoint);
			LR.SetPosition (1, new Vector3 (posicionMouse.x, posicionMouse.y ,posicionMouse.z));
		}
		if (Input.GetMouseButtonDown (0)) {  


			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit))
			 
			{
				probando = hit.collider.gameObject;
				if (go1 == null) {
					if (mal) 
					{
						LR.SetPosition (0, Vector3.zero);
						LR.SetPosition (1, Vector3.zero);

					}
					go1 = hit.collider.gameObject;
					LR = go1.gameObject.transform.GetChild (0).gameObject.GetComponent<LineRenderer>();
					LR.SetPosition (0, new Vector3 (go1.gameObject.transform.GetChild(1).transform.position.x, go1.gameObject.transform.GetChild(1).transform.position.y ,go1.transform.position.z));


				} else if (go2 == null && hit.collider.gameObject.name != go1.name && go1.layer == hit.collider.gameObject.layer) 
				{
					go2 = hit.collider.gameObject;
					LR.SetPosition (0, new Vector3 (go1.gameObject.transform.GetChild(1).transform.position.x, go1.gameObject.transform.GetChild(1).transform.position.y ,go1.transform.position.z));
					LR.SetPosition (1, new Vector3 (go2.gameObject.transform.GetChild(1).transform.position.x, go2.gameObject.transform.GetChild(1).transform.position.y ,go2.transform.position.z));

					if (go1.gameObject.tag == go2.transform.tag) 
					{
						LR.material = new Material (Shader.Find ("Diffuse"));
						LR.material.color = colorbien;
						go1.GetComponent<Check> ().gano = true;  // check es el script que debe en todos los objetos a unir
						go2.GetComponent<Check> ().gano = true;

						go1.layer = 2;
						go2.layer = 2;
						mal = false;
					
					
					}
					else 
					{
						LR.material = material;
						LR.material.color = colormal;
						mal = true;
					
					}
					go1 = null;
					go2 = null;    
				}

			}
		}

	}
}
