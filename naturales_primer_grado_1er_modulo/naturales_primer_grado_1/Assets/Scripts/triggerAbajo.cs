using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerAbajo : MonoBehaviour {

    [HideInInspector] public bool hayParedAbajo;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "pared")
        {
            hayParedAbajo = true;
            Debug.Log(hayParedAbajo);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "pared")
        {
            hayParedAbajo = false;
            Debug.Log(hayParedAbajo);
        }
    }
}
