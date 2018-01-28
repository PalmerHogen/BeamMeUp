using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPad : MonoBehaviour {
    public Transform[] teleporterPos;
    public GameObject vfxTeleport;
    public GameObject vfxTeleportShockWave;
    public GameObject[] hensenPrefabs; // listed worst to best
    public AudioSource audio;
 

    public float teleportDuration;
    public float hensenPause = 1f;

    //public void StartTeleportVFX(int teleporter)
    //{
    //    vfxTeleporters[teleporter].Play();
    //}

    //public void StopTeleportVFX(int teleporter)
    //{
    //    vfxTeleporters[teleporter].Stop();
    //}


        void Start()
    {
        //ReallyBad();
        audio.GetComponent<AudioSource>();

    }
    public void Teleport(float value)
    {
        //bad, perfect, really bad, really really bad

        if (value <= 0.008)
        {
            Perfect();
        }
        else if (value <= 0.01)
        {
            Okay();
        }
        else if (value <= 0.05)
        {
            Bad();
        }
        else
        {
            ReallyBad();
        }

      

       
    }

    void Perfect()
    {
        var trans = teleporterPos[Random.Range(0, 3)];
        var partSys = Instantiate(vfxTeleport).GetComponent<ParticleSystem>();
        
        partSys.transform.position = trans.position;
        var main = partSys.main;

        StartCoroutine(TeleportInHensen(partSys, hensenPrefabs[0], teleportDuration, trans));
        partSys.Play();
       
    }

    void Okay()
    {
        //play bad music
        var trans = teleporterPos[Random.Range(0, 3)];
        var partSys = Instantiate(vfxTeleport).GetComponent<ParticleSystem>();
        partSys.transform.position = trans.position;
        var main = partSys.main;

        StartCoroutine(TeleportInHensen(partSys, hensenPrefabs[1], teleportDuration, trans));
        partSys.Play();
        
    }

    void Bad()
    {
        var trans = teleporterPos[Random.Range(0, 3)];
        var partSys = Instantiate(vfxTeleport).GetComponent<ParticleSystem>();
        partSys.transform.position = trans.position;
        var main = partSys.main;

        StartCoroutine(TeleportInHensen(partSys, hensenPrefabs[2], teleportDuration, trans));
        partSys.Play();
    }

   void ReallyBad()
    {
      
        var trans = teleporterPos[Random.Range(0, 3)];
        var partSys = Instantiate(vfxTeleport).GetComponent<ParticleSystem>();
        partSys.transform.position = trans.position;
        var main = partSys.main;

        StartCoroutine(TeleportInReallyBadHensen(partSys, hensenPrefabs[3], teleportDuration, trans));
        partSys.Play();
    }

    IEnumerator TeleportInHensen(ParticleSystem teleportPartSys, GameObject hensenPrefab, float timeToInvoke, Transform teleporterTrans)
    {
        yield return new WaitForSeconds(timeToInvoke);
        audio.Play();
        var hensenGO = Instantiate(hensenPrefab);
        hensenGO.transform.position = teleporterTrans.position;
        hensenGO.transform.rotation = teleporterTrans.rotation;
        Debug.Log(hensenGO);

        var teleportShock = Instantiate(vfxTeleportShockWave);
        teleportShock.transform.position = teleportPartSys.transform.position;

        Destroy(teleportShock, teleportShock.GetComponent<ParticleSystem>().main.duration);
        Destroy(teleportPartSys.gameObject);

     
        yield return new WaitForSeconds(hensenPause);
        var hensen = hensenGO.GetComponent<Hensen>();
        hensen.GoToExit();



    }

    IEnumerator TeleportInReallyBadHensen(ParticleSystem teleportPartSys, GameObject hensenPrefab, float timeToInvoke, Transform teleporterTrans)
    {
        yield return new WaitForSeconds(timeToInvoke);
        audio.Play();
        var hensenGO = Instantiate(hensenPrefab);
        hensenGO.transform.position = teleporterTrans.position;
        hensenGO.transform.rotation = teleporterTrans.rotation;

        var teleportShock = Instantiate(vfxTeleportShockWave);
        teleportShock.transform.position = teleportPartSys.transform.position;

        Destroy(teleportShock, teleportShock.GetComponent<ParticleSystem>().main.duration);
        Destroy(teleportPartSys.gameObject);


       
   


    }
}
