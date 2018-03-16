using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeSprite : MonoBehaviour {


    //scipt con conportamiento para cambibar sprites
    //se debe agregar los dos sprites (azul y color) al objeto
    //el objeto debe tener un box colider
    //cuando se desea que el sprite adecuado sea el de color se debe dejar chequeado la opcion color en el inspector
    //caso contrario se deja sin chequear
    //se debe añadir el script spriteClickManager como componente a un boton en la escena para realizar el chequeo 
    

    public Sprite spriteAzul, spriteColor; //referencia a los sprites(azul y color)
    private SpriteRenderer sr; //componente renderer que indica cual sprite es el sprite corriente

    [HideInInspector]public bool bandera; //variable que indica si es el sprite correcto y accesible desde
                                          //el script spriteClickManager para realizar el chequeo de todos los sprites

    public bool color; //indica en el inspector el tipo de sprite correcto

	
	void Start () {
        sr = gameObject.GetComponent<SpriteRenderer>();
        switch (color) // inicializa las banderas dependiendo que sprite es el adecuado en consecuencia del valor
                       //asignado en el inspector
        {
            case true:
                bandera = false;
                break;
            case false:
                bandera = true;
                break;
        }
    }
	

    private void OnMouseDown()
    {
        if (gameObject.GetComponent<changeSprite>().enabled==true)//despues del chequeo los componentes para cambiar
                                                                  //se desactivan, prohibiendo hacer muchos clicks
                                                                  //y en consecuencia activar muchas veces el popUP
        {
            if (color)
            {
                if (sr.sprite.Equals(spriteAzul))//cambia valor bandera dependiendo el color deseado
                {
                    sr.sprite = spriteColor;
                    bandera = true;
                }
                else
                {
                    sr.sprite = spriteAzul;
                    bandera = false;
                }
            }
            else
            {
                if (sr.sprite.Equals(spriteColor))
                {
                    sr.sprite = spriteAzul;
                    bandera = true;
                }
                else
                {
                    sr.sprite = spriteColor;
                    bandera = false;
                }
            }
        }
        
    }
}
