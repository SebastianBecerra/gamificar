using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class m1ej18resultController : MonoBehaviour {

    public GameObject[] results;
    m1ej18dadoController num;

	// Use this for initialization
	void Start () {
        results = GameObject.FindGameObjectsWithTag("input2").OrderBy(go => go.name).ToArray();
        num = FindObjectOfType<m1ej18dadoController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void controlarResultados()
    {

    }
}
