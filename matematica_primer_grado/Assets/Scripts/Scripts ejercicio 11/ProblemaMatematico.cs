using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Matematica/Problema")]
public class ProblemaMatematico : ScriptableObject {

	public enum tipoCuenta {Suma , Resta, Multiplicacion, Division};

	public tipoCuenta tipo;
	public Sprite sprite;
    public bool invertirValores;
	[TextArea]
	public string inicio;
	[Space(10)]
	public bool randoom;
	public int numero1;
	public int max1;
	public int min1;
	[Space(10)]
	[TextArea]
	public string problema;
	[Space(10)]
	public bool randoom2;
	public int numero2;
	public int max2;
	public int min2;
	[Space(10)]
	[TextArea]
	public string pregunta;
}
