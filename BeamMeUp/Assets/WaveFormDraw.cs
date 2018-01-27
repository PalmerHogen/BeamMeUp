using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveFormDraw : MonoBehaviour {

	float PI = 3.14159265358979323846264338327950f;

	public GameObject draw1, draw2;
	public int numWaves = 10;
	public int buffsize = 512;

	float[] waveBuffer;
	float[] userBuffer;
	int[] userfreqs;
	float[] useramps;

	// Use this for initialization
	void Start () {
		waveBuffer = new float[buffsize];
		userBuffer = new float[buffsize];
		int[] freqs = new int[numWaves];
		float[] amps = new float[numWaves];
		userfreqs = new int[numWaves]; 
		useramps = new float[numWaves];
		int i, j, k;

		for (i = 0; i < numWaves; i++) {
			freqs [i] = Random.Range (0, 100);
			amps[i] = Random.Range(0.0f, 1.0f);
		}

		for (j = 0; j<buffsize; j++){
			for (k = 0; k < numWaves; k++) {
				waveBuffer [j] += Mathf.Sin (((float)j/(float)buffsize)*(2.0f * PI * freqs [k]));
			}
		}

		for (i = 0; i < numWaves; i++) {
			userfreqs [i] = Random.Range (0, 100);
			useramps[i] = Random.Range(0.0f, 1.0f);
		}

		for (j = 0; j<buffsize; j++){
			for (k = 0; k < numWaves; k++) {
				userBuffer [j] += Mathf.Sin (((float)j/(float)buffsize)*(2.0f * PI * freqs [k]));
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void fixedUpdate(){


	}
}
