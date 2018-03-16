using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerArriba : MonoBehaviour {

    [HideInInspector] public bool hayParedArriba;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "pared")
        {
            hayParedArriba = true;
            Debug.Log(hayParedArriba);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "pared")
        {
            hayParedArriba = false;
            Debug.Log(hayParedArriba);
        }
    }
}
