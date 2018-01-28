using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPad : MonoBehaviour {
    public Transform[] teleporterPos;
    public GameObject vfxTeleport;
    public GameObject vfxTeleportShockWave;
    public GameObject[] hensenPrefabs; // listed worst to best

    public float teleportDuration;
    public float hensenPause = 1f;

    void Start()
    {
        BadTeleport();
    }


    //public void StartTeleportVFX(int teleporter)
    //{
    //    vfxTeleporters[teleporter].Play();
    //}

    //public void StopTeleportVFX(int teleporter)
    //{
    //    vfxTeleporters[teleporter].Stop();
    //}

    public void Teleport(float value)
    {
        if (value <= 20)
        {
            BadTeleport();
        }
        else if(value <= 40)
        {
            KindaBadTeleport();
        }
        else if (value <= 60)
        {
            DecentTeleport();
        }
        else if (value <= 80)
        {
            OkayTeleport();
        }
        else if (value <= 90)
        {
            GoodTeleport();
        }else
        {
            GreatTeleport();
        }
       
    }

    void BadTeleport()
    {
        //play bad music
        var trans = teleporterPos[Random.Range(0, 3)];
        var partSys = Instantiate(vfxTeleport).GetComponent<ParticleSystem>();
        partSys.transform.position = trans.position;
        var main = partSys.main;

        StartCoroutine(Teleport(partSys, hensenPrefabs[0], teleportDuration, trans));
        partSys.Play();
        
    }

    void KindaBadTeleport()
    {

    }

    void DecentJob()
    {

    }

    void DecentTeleport()
    {

    }

    void OkayTeleport()
    {

    }

    void GoodTeleport()
    {

    }

    void GreatTeleport()
    {

    }

    IEnumerator Teleport(ParticleSystem teleportPartSys, GameObject hensenPrefab, float timeToInvoke, Transform teleporterTrans)
    {
        yield return new WaitForSeconds(timeToInvoke);

        var hensenGO = Instantiate(hensenPrefab);
        hensenGO.transform.position = teleporterTrans.position;
        hensenGO.transform.rotation = teleporterTrans.rotation;

        var teleportShock = Instantiate(vfxTeleportShockWave);
        teleportShock.transform.position = teleportPartSys.transform.position;

        Destroy(teleportShock, teleportShock.GetComponent<ParticleSystem>().main.duration);
        Destroy(teleportPartSys.gameObject);

     
        yield return new WaitForSeconds(hensenPause);
        var hensen = hensenGO.GetComponent<Hensen>();
        hensen.GoToExit();



    }
}
