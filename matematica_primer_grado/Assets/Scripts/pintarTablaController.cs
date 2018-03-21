using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class pintarTablaController : MonoBehaviour {

    spriteClickManager checkClor;
    public GameObject[] sp;
    popUpScript popUP;
    public int dado;
    private Button btn;
    public Sprite[] coloresSprites;
    private int j;
    public int totalSpritesAlternativos;

    public InputField texoDado;

    void Start (){
        j = 0;
        checkClor = FindObjectOfType<spriteClickManager>();
        popUP = FindObjectOfType<popUpScript>();
        texoDado = FindObjectOfType<InputField>();
        btn = gameObject.GetComponent<Button>();
    }

    public void tirarDado()
    {
        sp = GameObject.FindGameObjectsWithTag("color").OrderBy(g => g.transform.GetSiblingIndex()).ToArray();
        if (sp.Length >= 6)
        {
            dado = Random.Range(1, 6);
        }
        else
        {
            dado = Random.Range(1, sp.Length);
        }
        //texoDado.GetComponent<Text>().text = dado.ToString();
        Debug.Log(dado);
        btn.interactable = false;
        for (int i = 0; i < dado; i++)
        {
            sp[i].GetComponent<changeSprite>().color = true;
            sp[i].GetComponent<changeSprite>().spriteColor = coloresSprites[j];
        }
        j++;
        if (j > totalSpritesAlternativos)
        {
            j = 0;
        }
    }

    public void validarColor()
    {
        if (checkClor.checkBools())
        {
            if (dado < sp.Length)
            {
                popUP.cartelAcierto();
                for (int i = 0; i < dado; i++)
                {
                    sp[i].GetComponent<changeSprite>().enabled = false;
                    sp[i].transform.tag = "Untagged";
                }
            }
            if (dado == sp.Length)
            {
                popUP.Bien();
            }
        }
        btn.interactable = true;
    }
}