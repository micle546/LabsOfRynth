using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Interactable
{
    //PlayerUI playerUI;
    public float restoreAmount = 10f;

    public void Start()
    {
        //playerUI = GetComponent
    }


    protected override void Interact()
    {
        PlayerUI.instance.RestoreHealth(restoreAmount);
    }
}
