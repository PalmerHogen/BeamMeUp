using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HensenReallyReallyBad : MonoBehaviour {
    public Material[] shirts = new Material[3];
    // Use this for initialization
    void Start () {
        var body = transform.GetChild(0).transform.Find("Body");
        body.GetComponent<SkinnedMeshRenderer>().material = shirts[Random.Range(0, 2)];
        Destroy(gameObject, 4f);
    }
	
	
}
