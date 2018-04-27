using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ej31mod2controller : MonoBehaviour {

    public GameObject pos1, pos2, pos3, fig1, fig2, fig3, drop1, drop2, drop3;
    private int randomSelect;
    popUpScript popUp;
    //public string escenaSiguiente;


	// Use this for initialization
	void Start () {
        popUp = FindObjectOfType<popUpScript>();
        randomSelect = Random.Range(1, 4);
        switch (randomSelect)
        {
            case 1:
                fig1.transform.position = pos1.transform.position;
                fig2.transform.position = pos2.transform.position;
                fig3.transform.position = pos3.transform.position;
                drop1.GetComponent<DropZone>().idDropZone = 1;
                drop2.GetComponent<DropZone>().idDropZone = 2;
                drop3.GetComponent<DropZone>().idDropZone = 3;
                break;
            case 2:
                fig1.transform.position = pos3.transform.position;
                fig2.transform.position = pos2.transform.position;
                fig3.transform.position = pos1.transform.position;
                drop1.GetComponent<DropZone>().idDropZone = 3;
                drop2.GetComponent<DropZone>().idDropZone = 2;
                drop3.GetComponent<DropZone>().idDropZone = 1;
                break;
            case 3:
                fig1.transform.position = pos2.transform.position;
                fig2.transform.position = pos3.transform.position;
                fig3.transform.position = pos1.transform.position;
                drop1.GetComponent<DropZone>().idDropZone = 3;
                drop2.GetComponent<DropZone>().idDropZone = 1;
                drop3.GetComponent<DropZone>().idDropZone = 2;
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void checkDrops()
    {
        if (drop1.GetComponent<DropZone>().idDropZone == drop1.GetComponentInChildren<Dragable>().idDropZone1)
        {
            if (drop2.GetComponent<DropZone>().idDropZone == drop2.GetComponentInChildren<Dragable>().idDropZone1)
            {
                if (drop3.GetComponent<DropZone>().idDropZone == drop3.GetComponentInChildren<Dragable>().idDropZone1)
                {
                    popUp.Bien();
                }
                else
                {
                    popUp.Mal();
                }
            }
            else
            {
                popUp.Mal();
            }
        }
        else
        {
            popUp.Mal();
        }
    }

    //void siguienteEscena()
    //{
    //    SceneManager.LoadScene(escenaSiguiente);
    //}
}
