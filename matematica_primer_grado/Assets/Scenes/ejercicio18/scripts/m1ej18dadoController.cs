using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class m1ej18dadoController : MonoBehaviour {

    public GameObject[] textosDado1;
    public GameObject[] textosDado2;
    public GameObject[] textos;
    public Button[] botones;
    private int randomInt;
    private int i, j;

	// Use this for initialization
	void Start () {
        textos = GameObject.FindGameObjectsWithTag("input1").OrderBy(go => go.name).ToArray();
        textosDado1 = GameObject.FindGameObjectsWithTag("textoDado1").OrderBy(go => go.name).ToArray();
        textosDado2 = GameObject.FindGameObjectsWithTag("textoDado2").OrderBy(go => go.name).ToArray();
        i = 0;
        j = 0;
        darValores();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void dado1()
    {
        randomInt = Random.Range(1, 6);
        textosDado1[i].GetComponent<Text>().text = randomInt.ToString();
        i++;
        if (i == 4)
        {
            botones[0].interactable = false;
        }
    }

    public void dado2()
    {
        randomInt = Random.Range(1, 6);
        textosDado2[j].GetComponent<Text>().text = randomInt.ToString();
        j++;
        if (j == 4)
        {
            botones[1].interactable = false;
        }
    }

    void darValores()
    {
        foreach(GameObject a in textos)
        {
            a.GetComponent<Text>().text = Random.Range(1, 33).ToString();
        }
    }

}
