using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public float timeForTask = 20;
    public int numOfTeleports = 5;
    public GameObject wave;
    WaveFormDraw waveDraw;
    AudioSource audio;
	// Use this for initialization
	void Start ()
    {
        waveDraw = wave.GetComponent<WaveFormDraw>();
        audio = GetComponent<AudioSource>();
        StartCoroutine(TrasportRequest());
	}
	


    IEnumerator TrasportRequest()
    {
        waveDraw.reset();
        audio.clip = null;//get ready;
        audio.Play();
        yield return new WaitForSeconds(timeForTask);

        yield return new WaitForSeconds(1);

        audio.clip = null;//get ready;
        audio.Play();
        yield return new WaitForSeconds(1);

        audio.clip = null;//get ready;
        audio.Play();
        yield return new WaitForSeconds(1);

        audio.clip = null;//get ready;
        audio.Play();
        yield return new WaitForSeconds(1);

        audio.clip = null;//get ready;
        audio.Play();
        yield return new WaitForSeconds(1);

        audio.clip = null;//get ready;
        audio.Play();
        yield return new WaitForSeconds(1);

        audio.clip = null;//get ready;
        audio.Play();
        yield return new WaitForSeconds(1);

        audio.clip = null;//get ready;
        audio.Play();
        yield return new WaitForSeconds(1);

        audio.clip = null;//get ready;
        audio.Play();
        yield return new WaitForSeconds(1);

        audio.clip = null;//get ready;
        audio.Play();
        yield return new WaitForSeconds(1);

        audio.clip = null;//get ready;
        audio.Play();
        yield return new WaitForSeconds(1);
        audio.clip = null;//get ready;
        audio.Play();

        numOfTeleports--;

        if(numOfTeleports != 0)
        {
            TrasportRequest();
        }else
        {
            GameOver();
        }
        
    }

    void GameOver()
    {

    }
}
