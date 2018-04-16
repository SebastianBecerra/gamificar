using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatM1Eje11 : MonoBehaviour
{

    popUpScript popUp;

    public Text textoProblema;
    InputTextScript input;
    InputField inputField;

    objTransition[] imagenes;
    //	Array de ScriptableObjects.
    public ProblemaMatematico[] problemas;
    private int solucion;
    int instanciaActual;

    void Start()
    {
        //  Inicializacion variables y colecciones.
        popUp = FindObjectOfType<popUpScript>();
        input = FindObjectOfType<InputTextScript>();
        inputField = input.gameObject.GetComponent<InputField>();
        imagenes = gameObject.GetComponentsInChildren<objTransition>();

        instanciaActual = 0;
        ManagerInstancia();                                                     //  Crea el problema a resolver.
        setSpritesEnImagenes();
        StartCoroutine(MoverImagenes());                                        //  Baja las imagenes a mostrar del primer problema.
        //inputField.onValueChange.AddListener(delegate { checkEstadoInput(); });     //  Inicializa el listener del InputText que se activa al terminar ingreso.
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            checkEstadoInput();
        }
    }


    void ManagerInstancia()
    {
        borrarInput();
        setProblema(instanciaActual);
        

    }

    // Inicializa el problema, lo imprime en pantalla y le envia la solucion del problema al inputText.
    void setProblema(int i)
    {
        //	Formar texto del Problema.
        int valor1;
        int valor2;
        if (problemas[i].randoom) {
            valor1 = Random.Range(problemas[i].min1, problemas[i].max1);
        }
        else {
            valor1 = problemas[i].numero1;
        }
        if (problemas[i].randoom2) {
            valor2 = Random.Range(problemas[i].min2, problemas[i].max2);
        }
        else {
            valor2 = problemas[i].numero2;
        }
        //  imprime.
        textoProblema.text = problemas[i].inicio + valor1 + problemas[i].problema + valor2 + problemas[i].pregunta;
        //	invoca setSolucion.
        if (problemas[i].invertirValores) {
            setSolucionEnInput(valor2, valor1, i);
        }
        else {
            setSolucionEnInput(valor1, valor2, i);
        }
        
    }

    //	Reinicia el InputText "input" le envia la solucion al problema recibido desde "setProblema()".
    void setSolucionEnInput(int valor1, int valor2, int indexProblemas)
    {

        borrarInput();

        //	Obtener numero ENTERO solucion.
        solucion = 0;

        switch ((int)problemas[indexProblemas].tipo)
        {  //  Establece la solucion segun el tipo ded problema.
            case (0):
                solucion = valor1 + valor2;
                break;
            case (1):
                solucion = valor1 - valor2;
                break;
            case (2):
                solucion = valor1 + valor2;
                break;
            case (3):
                solucion = valor1 / valor2;
                break;
        }
        Debug.Log(solucion);
        input.valoresCorrectos[0] = solucion.ToString();    //  Coloca la solucion en el input para que se reconozca automaticamente
    }

    //  Borra el inputText.
    void borrarInput()
    {
        inputField.text = "";
    }

    // Corrutina Que Mueve Las Imagenes
    private IEnumerator MoverImagenes(int cant = 10)
    {
        
        for (int i = 0; i < imagenes.Length && i < cant; i++)
        {
            imagenes[i].moverObjeto();
            yield return new WaitForSeconds(0.1f);
            
        }
        setSpritesEnImagenes();
        yield return new WaitForSeconds(0.9f);
        
    }

    void setSpritesEnImagenes() {
        for (int i = 0; i < imagenes.Length; i++)
        {
            imagenes[i].gameObject.GetComponent<Image>().sprite = problemas[instanciaActual].sprite;
        }
    }

    //  Controla si el texto ingresado en el input es correcto.
    void checkEstadoInput()
    {
        int maxInstancia = problemas.Length - 1;

        if (input.EsCorrecto())                 //  <--Ingreso correcto.
        {
            if (instanciaActual == maxInstancia){       //  <--Fin del Juego.
                popUp.Bien();
            }
            else{
                StartCoroutine(MoverImagenes());
                popUp.cartelAcierto();
                instanciaActual++;
                ManagerInstancia();

                //setSpritesEnImagenes();
                StartCoroutine(MoverImagenes());
            }
        }
        else{                                   //  <--Ingreso Incorrecto.
            StartCoroutine(MoverImagenes());
            popUp.cartelError();
            if (instanciaActual > 0){
                instanciaActual--;
            }
            ManagerInstancia();


            //setSpritesEnImagenes();
            StartCoroutine(MoverImagenes());
        }
        inputField.ActivateInputField();
    }
}
