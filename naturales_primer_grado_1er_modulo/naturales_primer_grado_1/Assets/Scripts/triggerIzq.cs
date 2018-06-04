using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerIzq : MonoBehaviour {

    [HideInInspector] public bool hayParedIzq;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "pared")
        {
            hayParedIzq = true;
            Debug.Log(hayParedIzq);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "pared")
        {
            hayParedIzq = false;
            Debug.Log(hayParedIzq);
        }
    }
}
