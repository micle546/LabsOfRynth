using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    [SerializeField]
    private GameObject door;
    private bool doorOpen;
    protected override void Interact()
    {
        doorOpen = !doorOpen;
        door.GetComponent<Animator>().SetBool("IsOpen", doorOpen);
    }
}
