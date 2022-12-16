using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Interactable
{
    //PlayerUI playerUI;
    public float restoreAmount = 10f;
    public bool isReuseable = false;

    public void Start()
    {
        //playerUI = GetComponent
    }


    protected override void Interact()
    {
        PlayerUI.instance.RestoreHealth(restoreAmount);
        if (!isReuseable)
            this.gameObject.SetActive(false);
    }
}
