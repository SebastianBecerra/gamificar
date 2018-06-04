using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionManager : MonoBehaviour {

    [HideInInspector]public popUpScript popUp;
    [HideInInspector]public movCeldas player;
   

	// Use this for initialization
	void Start () {
        popUp = FindObjectOfType<popUpScript>();
        player = FindObjectOfType<movCeldas>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "numBien")
        {
            Destroy(col.gameObject);
        }

        if (col.gameObject.name == "numGanar")
        {
            Destroy(col.gameObject);
            popUp.Bien();
            player.enabled = false;
        }

        if (col.gameObject.name == "numMal")
        {
            Destroy(gameObject);
            popUp.Mal();

        }
    }
}
