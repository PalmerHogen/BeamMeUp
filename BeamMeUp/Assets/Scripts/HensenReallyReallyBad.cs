using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HensenReallyReallyBad : MonoBehaviour{
    public Material[] shirts = new Material[3];
    // Use this for initialization
    void Start () {
        transform.position += new Vector3(0, 1, 0);
        var body = transform.GetChild(0).transform.Find("Body");
        body.GetComponent<MeshRenderer>().material = shirts[Random.Range(0, 2)];
        Destroy(gameObject, 8f);

       


    }
	
	
}
