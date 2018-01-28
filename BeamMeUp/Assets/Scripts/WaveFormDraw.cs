using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveFormDraw : MonoBehaviour {

    float PI = 3.1415926535897932384626433832795f;

    public LineRenderer linedraw;
    public LineRenderer linedraw2;

    public GameObject draw1, draw2;
    public int numWaves = 10;
    public int buffsize = 512;

    public int freqRange = 10;

    public float requiredAccuracy = 0.01f;

    float[] waveBuffer;
    float[] userBuffer;
    int[] userfreqs;
    float[] useramps;
    Vector3 lightOffset;

    int pos1 = 0;
    int pos2 = 0;

    float accum = 0.0f;

    public float yScale, zScale;
    public float xRot, yRot, zRot;

    Transform light1pos, light2pos;

    // Use this for initialization
     void Start() {

        waveBuffer = new float[buffsize];
        userBuffer = new float[buffsize];
        int[] freqs = new int[numWaves];
        float[] amps = new float[numWaves];
        userfreqs = new int[numWaves];
        useramps = new float[numWaves];
        linedraw.positionCount = buffsize;
        linedraw2.positionCount = buffsize;
        lightOffset = draw1.transform.position;
        int i, j, k;

        for (i = 0; i < numWaves; i++) {
            freqs[i] = Random.Range(1, freqRange);
            amps[i] = (float)Random.Range(-4, 4) / 8.0f;
            userfreqs[i] = Random.Range(1, freqRange);
            useramps[i] = (float)Random.Range(-4, 4) / 8.0f;
        }

        linedraw.transform.rotation = Quaternion.Euler(xRot, yRot, zRot);
        linedraw2.transform.rotation = Quaternion.Euler(xRot, yRot, zRot);

        for (j = 0; j < buffsize; j++) {
            for (k = 0; k < numWaves; k++) {
                waveBuffer[j] += amps[k] * Mathf.Sin(((float)j / (float)buffsize) * (2.0f * PI * freqs[k]));
                userBuffer[j] += useramps[k] * Mathf.Sin(((float)j / (float)buffsize) * (2.0f * PI * userfreqs[k]));
            }
            linedraw.SetPosition(j, new Vector3(0.0f, waveBuffer[j] * yScale, (float)j * zScale / 8.0f));
            linedraw2.SetPosition(j, new Vector3(0.0f, userBuffer[j] * yScale, (float)j * zScale / 8.0f));
        }
        light1pos = draw1.transform;
        light2pos = draw2.transform;


    }

    // Update is called once per frame
    void Update() {
        //ReDraw();
    }

    //Call when user changes Values to recalculate!
    void ReDraw() {
        int j, k;
        for (j = 0; j < buffsize; j++) {
            userBuffer[j] = 0;
            for (k = 0; k < numWaves; k++) {
                userBuffer[j] += useramps[k] * Mathf.Sin(((float)j / (float)buffsize) * (2.0f * PI * userfreqs[k]));
            }
            linedraw2.SetPosition(j, new Vector3(0.0f, userBuffer[j] * yScale, (float)j * zScale / 8.0f));
        }
    }

    void FixedUpdate() {
        //light1pos.transform.position = new Vector3 (light1pos.transform.position.x, (float)waveBuffer [pos1]*yScale, (float)pos1*zScale / 8.0f) + lightOffset;
        //light2pos.transform.position = new Vector3 (light2pos.transform.position.x, (float)userBuffer [pos2]*yScale, (float)pos2*zScale/8.0f) + lightOffset;

        //pos1 = (pos1 + 1) % buffsize;
        //pos2 = (pos2 + 1) % buffsize;

    }

    public void changeFreq(int index, int newvalue) {
        userfreqs[index] = newvalue;
        ReDraw();
    }

    public void changeAmp(int index, float newvalue) {
        useramps[index] = newvalue;
        ReDraw();
    }

    public bool checkSuccess() {
        for (int i = 0; i < buffsize; i++) {
            if (Mathf.Abs(waveBuffer[i] - userBuffer[i]) > requiredAccuracy) {
                return false;
            }
        }
        return true;
    }

    public float checkDiff() {
        float total = 0.0f;
        for (int i = 0; i < buffsize; i++)
        {
            total += (Mathf.Abs(waveBuffer[i] - userBuffer[i])) / 10; //10 is arbitrary here
        }
        return total / buffsize;
    }

    public void reset() {
        Start();
        //userfreqs = new int[numWaves];
        //useramps = new float[numWaves];
        //userBuffer = new float[buffsize];
        //waveBuffer = new float[buffsize];

        //int[] freqs = new int[numWaves];
        //float[] amps = new float[numWaves];
        //int i, j, k;
        //for (i = 0; i < numWaves; i++)
        //{
        //    freqs[i] = Random.Range(1, freqRange);
        //    amps[i] = (float)Random.Range(-4, 4) / 8.0f;
          
        //    userfreqs[i] = Random.Range(1, freqRange);
        //    useramps[i] = (float)Random.Range(-4, 4) / 4.0f;
        //}

        //for (j = 0; j < buffsize; j++)
        //{
        //    userBuffer[j] = 0;
        //    waveBuffer[j] = 0;
        //    for (k = 0; k < numWaves; k++)
        //    {
        //        waveBuffer[j] += amps[k] * Mathf.Sin(((float)j / (float)buffsize) * (2.0f * PI * freqs[k]));
        //        userBuffer[j] += useramps[k] * Mathf.Sin(((float)j / (float)buffsize) * (2.0f * PI * userfreqs[k]));
        //    }
        //    linedraw.SetPosition(j, new Vector3(0.0f, waveBuffer[j] * yScale, (float)j * zScale / 8.0f));
        //    linedraw2.SetPosition(j, new Vector3(0.0f, userBuffer[j] * yScale, (float)j * zScale / 8.0f));
        //}

    }


}
