using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportEffect : MonoBehaviour {
    float effectDuration = 5;
    float lerpStart;
    bool isTeleportingIn = false;
    bool isTeleportingOut = false;
    MeshRenderer meshRend;
    Color oldColor;
	// Use this for initialization
	void Start ()
    {
       
        meshRend = GetComponent<MeshRenderer>();
        oldColor = meshRend.material.color;
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.I))
        {
            TeleportIn();
        }

        if (Input.GetKey(KeyCode.O))
        {
            TeleportOut();
       
        }
        if (isTeleportingIn)
        {
            var progress = Time.time - lerpStart;
            meshRend.material.color = new Color(oldColor.r, oldColor.g, oldColor.b, (Mathf.Lerp(0.0f, 1.0f, progress / effectDuration)));
            Debug.Log("IN: "+  meshRend.material.color);
            if (effectDuration < progress)
            {
                isTeleportingIn = false;
            }

        }

        if (isTeleportingOut)
        {
            var progress = Time.time - lerpStart;
            Debug.Log("OUTBefore:" + meshRend.material.color + " " + progress + " " + effectDuration + " " + (Mathf.Lerp(1.0f, 0.0f, progress / effectDuration)));
            meshRend.material.color = new Color(oldColor.r, oldColor.g, oldColor.b, (Mathf.Lerp(1.0f, 0.0f, progress / effectDuration)));
            Debug.Log("OUT:" + meshRend.material.color);
            if (effectDuration < progress)
            {
                isTeleportingIn = false;
            }

        }
    }

    void TeleportIn()
    {
    
        Debug.Log("GO");
        isTeleportingOut = false;
         isTeleportingIn = true;
         lerpStart = Time.time;           
    }

    void TeleportOut()
    {
      
        isTeleportingIn = false;
        isTeleportingOut = true;
       // lerpStart = Time.time;
    }
   
}
