using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPad : MonoBehaviour {
    public ParticleSystem[] vfxTeleporters;


    public void StartTeleportVFX(int teleporter)
    {
        vfxTeleporters[teleporter].Play();
    }

    public void StopTeleportVFX(int teleporter)
    {
        vfxTeleporters[teleporter].Stop();
    }
}
