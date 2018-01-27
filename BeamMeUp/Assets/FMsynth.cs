using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMsynth : MonoBehaviour {

	float PI = 3.14159265358979323846264338327950f;

	public int modFreq = 500;

	float accum;

	AudioSource sine;

	// Use this for initialization
	void Start () {
		sine = GetComponentInParent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		accum += Time.deltaTime;
		sine.pitch = 1.0f + Mathf.Sin (accum*(2.0f * PI * (float)modFreq));
	}
}
