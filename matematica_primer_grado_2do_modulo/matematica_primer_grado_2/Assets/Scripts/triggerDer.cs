using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerDer : MonoBehaviour {

    [HideInInspector] public bool hayParedDer;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "pared")
        {
            hayParedDer = true;
            Debug.Log(hayParedDer);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "pared")
        {
            hayParedDer = false;
            Debug.Log(hayParedDer);
        }
    }
}
