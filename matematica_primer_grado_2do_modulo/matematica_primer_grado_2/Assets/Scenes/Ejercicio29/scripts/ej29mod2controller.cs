using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ej29mod2controller : MonoBehaviour {

    public GameObject[] Arr;
    private bool banderaDrops;
    popUpScript popUP;

	// Use this for initialization
	void Start () {
        Arr = GameObject.FindGameObjectsWithTag("Player");
        banderaDrops = true;
        popUP = FindObjectOfType<popUpScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void checkDrops()
    {
        for(int i=0; i < Arr.Length; i++)
        {
            if (Arr[i].GetComponent<DropZone>().idDropZone != 0)
            {
                if (Arr[i].transform.childCount > 0)
                {
                    if (Arr[i].GetComponent<DropZone>().idDropZone == Arr[i].transform.GetChild(0).GetComponent<Dragable>().idDropZone1)
                    {
                        banderaDrops = true;
                    }
                    else
                    {
                        banderaDrops = false;
                        i = Arr.Length;
                    }
                }
                else
                {
                    banderaDrops = false;
                    i = Arr.Length;
                }
            }
            else
            {
                if (Arr[i].transform.childCount > 0)
                {
                    banderaDrops = false;
                    i = Arr.Length;
                }
            }
        }

        if (banderaDrops)
        {
            popUP.Bien();
        }
        else
        {
            popUP.Mal();
        }
    }
}
