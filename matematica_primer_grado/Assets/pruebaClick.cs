using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pruebaClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		if (gameObject.transform.name == "Carta") {
			Debug.Log ("bien");
		
		} else {
			Debug.Log ("mal");
		}
	}

}
