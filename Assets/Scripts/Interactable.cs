using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //message shown to the player
    public string promptMesssage;

    //this function will be called from the player
    public void BaseInteract()
    {
        Interact();
    }
    protected virtual void Interact()
    {
        //this is a template function
    }
}
