using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class objTransition : MonoBehaviour {

    public int duracion;
    public List<GameObject> lugares = new List<GameObject>();
    private List<Vector3> positions = new List<Vector3>();


    // Use this for initialization
    void Start () {
        SavePositions();
        gameObject.GetComponent<Transform>().DOPath(positions.ToArray(),duracion);
	}
	

    void SavePositions()
    {
        foreach (GameObject g in lugares)
        {
            positions.Add(g.transform.position);
        }
    }
}
