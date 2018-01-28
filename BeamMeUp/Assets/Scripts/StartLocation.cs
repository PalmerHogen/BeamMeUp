using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class StartLocation : VRTK_DestinationMarker {

   

    void Start ()
    {
        Invoke("TeleportToStart", 2);
    }

    void TeleportToStart()
    {
        OnDestinationMarkerSet(SetDestinationMarkerEvent
          (0, transform, new RaycastHit(), transform.position, null));
    }
}
