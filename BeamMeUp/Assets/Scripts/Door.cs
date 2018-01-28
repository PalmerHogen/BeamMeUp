using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(BoxCollider))]
public class Door : MonoBehaviour
{
    Animator anim;
   
    void Start()
    {
        anim = GetComponent<Animator>();
      
    }



     public void OpenDoor()
    {
        anim.SetTrigger("OpenDoor");
    }

    public void CloseDoor()
    {
        anim.SetTrigger("CloseDoor");
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<Hensen>() != null)
        OpenDoor();
    }

    void OnTriggerExit()
    {
        CloseDoor();
    }
   
}
